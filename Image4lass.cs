using System.IO;

namespace Image4glass
{
    public partial class Image4lass : Form
    {
        string folderName;
        public Image4lass()
        {
            InitializeComponent();
            this.folderBrowserDialog.SelectedPath = @"D:\GDrive\My Drive\Sources\Xplore1\Ayr\Ayr1\Photos\Run 1\";
            this.numericUpDownNumber.Value = 10;
            comboBoxFoldreName.Text = @"D:\GDrive\My Drive\Sources\Xplore1\Ayr\Ayr1\Photos\Run 1";
            folderName = @"D:\GDrive\My Drive\Sources\Xplore1\Ayr\Ayr1\Photos\Run 1";
        }

        private void folderNameChange(string newfolder)
        {
            if (Directory.Exists(newfolder))
            {
                this.folderName = newfolder;
                comboBoxFoldreName.Text = newfolder;
                toolStripStatusLabel.Text = newfolder;
            }
        }
        private bool LoadImages()
        {
            string path;

            path = folderName + @"\Forward";
            if (Directory.Exists(path))
            {
                path += @"\" + this.numericUpDownNumber.Value + ".jpg";
                if (File.Exists(path))
                {
                    this.pictureBoxForward.Load(path);
                }
                else
                {
                    MessageBox.Show("The file does not exist.", path);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("The folder does not exist.", path);
                return false;
            }

            path = folderName + @"\Rear";
            if (Directory.Exists(path))
            {
                path += @"\" + this.numericUpDownNumber.Value + ".jpg";
                if (File.Exists(path))
                {
                    this.pictureBoxRear.Load(path);
                }
                else
                {
                    MessageBox.Show("The file does not exist.", path);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("The folder does not exist.", path);
                return false;
            }

            path = folderName + @"\Left";
            if (Directory.Exists(path))
            {
                path += @"\" + this.numericUpDownNumber.Value + ".jpg";
                if (File.Exists(path))
                {
                    this.pictureBoxLeft.Load(path);
                }
                else
                {
                    MessageBox.Show("The file does not exist.", path);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("The folder does not exist.", path);
                return false;
            }

            path = folderName + @"\Right";
            if (Directory.Exists(path))
            {
                path += @"\" + this.numericUpDownNumber.Value + ".jpg";
                if (File.Exists(path))
                {
                    this.pictureBoxRight.Load(path);
                }
                else
                {
                    MessageBox.Show("The file does not exist.", path);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("The folder does not exist.", path);
                return false;
            }
            return true;
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderNameChange(this.folderBrowserDialog.SelectedPath);
                this.LoadImages();
            }
        }

        private void comboBoxFoldreName_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(comboBoxFoldreName.Text))
            {
                comboBoxFoldreName.BackColor = SystemColors.Window;
                folderNameChange(comboBoxFoldreName.Text);
            }
            else
            {
                comboBoxFoldreName.BackColor = Color.MistyRose;
            }
        }

        private void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            this.LoadImages();
        }
    }
}