using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image4glass
{
    public partial class ZoomImageForm : Form
    {
        private float zoomFactor = 0.2f; // Початковий масштаб
        private const float ZoomIncrement = 0.1f; // Збільшення масштабу при кожній прокрутці
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
                zoomFactor += (zoomFactor < 1.6f) ? ZoomIncrement : 0;
            }
            else
            {
                zoomFactor -= (zoomFactor > 0.2f) ? ZoomIncrement : 0;
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

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox.Left = (int)(this.Width / 2 - e.Location.X);
            pictureBox.Top = (int)(this.Height / 2 - e.Location.Y);
        }

        private void ZoomImageForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ZoomImageForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
            }
        }

        private void ZoomImageForm_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
