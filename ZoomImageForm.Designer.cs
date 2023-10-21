namespace Image4glass
{
    partial class ZoomImageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel = new Panel();
            pictureBox = new PictureBox();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.AutoSize = true;
            panel.BackColor = SystemColors.ControlDarkDark;
            panel.Controls.Add(pictureBox);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(1008, 985);
            panel.TabIndex = 1;
            panel.Resize += panel_Resize;
            // 
            // pictureBox
            // 
            pictureBox.Cursor = Cursors.SizeAll;
            pictureBox.Location = new Point(256, 256);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(512, 512);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
            // 
            // ZoomImageForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            ClientSize = new Size(1008, 985);
            Controls.Add(panel);
            Name = "ZoomImageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ZoomImageForm";
            panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel;
        private PictureBox pictureBox;
    }
}