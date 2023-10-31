using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image4glass
{
    public partial class ZoomImageForm : Form
    {
        private float zoomFactor = 0.2f; // Початковий масштаб
        private const float ZoomIncrement = 0.2f; // Збільшення масштабу при кожній прокрутці
        public ZoomImageForm(Image img)
        {
            InitializeComponent();
            this.pictureBox.Image = img;
            CenterPictureBox();
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            // Змінюємо масштаб відповідно до кількості клацань колеса мишки
            if (e.Delta > 0)
            {
                zoomFactor += (zoomFactor < 3.0f) ? ZoomIncrement : 0;
            }
            else
            {
                zoomFactor -= (zoomFactor > 0.25f) ? ZoomIncrement : 0;
            }

            // Зберігаємо старі розміри PictureBox
            int previousWidth = pictureBox.Width;
            int previousHeight = pictureBox.Height;

            // Змінюємо розмір зображення
            pictureBox.Width = (int)(pictureBox.Image.Width * zoomFactor);
            pictureBox.Height = (int)(pictureBox.Image.Height * zoomFactor);

            // При зміні масштабу, центруємо PictureBox по курсору
            pictureBox.Left -= (int)((pictureBox.Width - previousWidth) / 2);
            pictureBox.Top -= (int)((pictureBox.Height - previousHeight) / 2);

            if (pictureBox.Size.Height < this.Height)
            {
                CenterPictureBox();
            }
        }

        private void panel_Resize(object sender, EventArgs e)
        {
            // Під час зміни розмірів Panel, центруємо PictureBox
            CenterPictureBox();
        }

        private void CenterPictureBox()
        {
            int x = (int)((panel.Width - pictureBox.Width) / 2);
            int y = (int)((panel.Height - pictureBox.Height) / 2);

            if (x < 0)
            {
                x = 0;
                panel.HorizontalScroll.Value = 0;
            }
            if (y < 0)
            {
                y = 0;
                panel.VerticalScroll.Value = 0;
            }

            pictureBox.Location = new Point(x, y);
        }

        private async void ZoomImageForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
            {
                await LoadImageAsync(1);
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Down)
            {
                await LoadImageAsync(-1);
            }
        }

        private async Task LoadImageAsync(int fileIncrement)
        {
            try
            {
                string newFileImage = this.Text;
                this.Text = "Loading...";
                Image image = await Task.Run(() => LoadImageFromPath(fileIncrement, ref newFileImage));

                // Після завантаження зображення встановлюємо його в PictureBox
                pictureBox.Image = image;
                this.Text = newFileImage;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження зображення: " + ex.Message);
            }
        }
        private Image LoadImageFromPath(int fileNameIncrement, ref string newFullPath)
        {

            string filePath = newFullPath;
            if (int.TryParse(Path.GetFileNameWithoutExtension(filePath), out int fileNameIndex))
            {
                fileNameIndex += fileNameIncrement;
                string? directory = Path.GetDirectoryName(filePath);
                directory ??= string.Empty;
                newFullPath = Path.Combine(directory, fileNameIndex.ToString() + ".jpg");
                if (File.Exists(newFullPath))
                {
                    return Image.FromFile(newFullPath);
                }
            }
            newFullPath = "File request out of name range. Close this window.";
            return new Bitmap(512, 512);
        }

        private Point startPoint;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                Cursor = Cursors.Hand;
            }
            if (e.Button == MouseButtons.Middle)
            {
                pictureBox.Left = (int)(this.Width / 2 - e.Location.X);
                pictureBox.Top = (int)(this.Height / 2 - e.Location.Y);
            }
            if (e.Button == MouseButtons.Right)
            {
                zoomToFit();
            }

        }

        private async void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point newLocation = pictureBox.Location;
                newLocation.X += e.X - startPoint.X;
                newLocation.Y += e.Y - startPoint.Y;

                await Task.Run(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        pictureBox.Location = newLocation;
                    }));
                });
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.Cross;
            }
        }

        private void zoomToFit()
        {
            int desiredSize = this.Height - 42;
            pictureBox.Width = desiredSize;
            pictureBox.Height = desiredSize;
            CenterPictureBox();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            zoomToFit();
        }

        private void buttonFitImage_Click(object sender, EventArgs e)
        {
            zoomToFit();
        }
    }
}
