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
        private Point lastMousePosition;
        private bool isLeftMouseDown = false;
        public ZoomImageForm(Image img, Size picSize)
        {
            InitializeComponent();
            this.pictureBox.Image = img;
            // Змінюємо розмір зображення на той,що був у головному вікні
            pictureBox.Size = picSize;
            // При зміні масштабу, центруємо PictureBox
            CenterPictureBox();
            //pictureBox.MouseWheel += PictureBox_MouseWheel;
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("ssds");
            // Змінюємо масштаб відповідно до кількості клацань колеса мишки
            if (e.Delta > 0)
            {
                zoomFactor += (zoomFactor < 1.4f) ? ZoomIncrement : 0;
            }
            else
            {
                zoomFactor -= (zoomFactor > 0.2f) ? ZoomIncrement : 0;
            }

            // Змінюємо розмір зображення
            pictureBox.Width = (int)(pictureBox.Image.Width * zoomFactor);
            pictureBox.Height = (int)(pictureBox.Image.Height * zoomFactor);
            // При зміні масштабу, центруємо PictureBox
            CenterPictureBox();
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

        private void pictureBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pictureBox.Location.Y.ToString());
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            lastMousePosition = e.Location;
            isLeftMouseDown = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isLeftMouseDown)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;
                
                if(deltaX < 0)
                {
                    panel.HorizontalScroll.Value = Math.Max(0, panel.HorizontalScroll.Value - Math.Abs(deltaX));
                    //panel.HorizontalScroll.Value = Math.Min(panel.HorizontalScroll.Value - deltaX, panel.HorizontalScroll.Maximum);
                    /*
                    if (deltaY > 0)
                    {
                        panel.VerticalScroll.Value = Math.Min(panel.VerticalScroll.Value + deltaY, panel.VerticalScroll.Maximum);
                        lastMousePosition = e.Location;
                    }
                    else
                    {
                        panel.VerticalScroll.Value = Math.Max(panel.VerticalScroll.Minimum, panel.VerticalScroll.Value + deltaY);
                        lastMousePosition = e.Location;
                    }
                    */
                    lastMousePosition = e.Location;
                }
                else
                {
                    panel.HorizontalScroll.Value = Math.Max(0,  panel.HorizontalScroll.Value + Math.Abs(deltaX));
                    /*
                    if (deltaY > 0)
                    {
                        panel.VerticalScroll.Value = Math.Min(panel.VerticalScroll.Value + deltaY, panel.VerticalScroll.Maximum);
                        lastMousePosition = e.Location;
                    }
                    else
                    {
                        panel.VerticalScroll.Value = Math.Max(panel.VerticalScroll.Minimum, panel.VerticalScroll.Value + deltaY);
                        lastMousePosition = e.Location;
                    }
                    */
                    lastMousePosition = e.Location;
                }
                /*
                if (deltaY > 0)
                {
                    panel.VerticalScroll.Value = Math.Min(panel.VerticalScroll.Value + deltaY, panel.VerticalScroll.Maximum);
                    lastMousePosition = e.Location;
                }
                else
                {
                    panel.VerticalScroll.Value = Math.Max(panel.VerticalScroll.Minimum, panel.VerticalScroll.Value + deltaY);
                    lastMousePosition = e.Location;
                }
                */
                //panel.VerticalScroll.Value = Math.Max(0, panel.VerticalScroll.Value - deltaY);


            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isLeftMouseDown = false;
            //panel.HorizontalScroll.Value = Math.Max(0, panel.HorizontalScroll.Value - e.X + lastMousePosition.X);
            //panel.VerticalScroll.Value = Math.Max(0, panel.VerticalScroll.Value - e.Y + lastMousePosition.Y);
        }
    }
}
