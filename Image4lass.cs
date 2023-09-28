using System.Diagnostics;
using System.Drawing.Imaging;
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


        private void LoadImageOnTab(string tabFolderName, PictureBox pictureBox, decimal FileNameIndex)
        {
            string path = folderName + tabFolderName;
            if (Directory.Exists(path))
            {
                path += @"\" + FileNameIndex + ".jpg";
                if (File.Exists(path))
                {
                    pictureBox.Load(path);
                }
                else
                {
                    MessageBox.Show(path, "The file does not exist.");
                    //return false;
                }
            }
            else
            {
                MessageBox.Show(path, "The folder does not exist.");
                //return false;
            }
            //return true;
        }

        private async Task LoadImages(int tabControlSelectedIndex)
        {
            var image = await Task.Run(() =>
            {
                switch (tabControlSelectedIndex)
                {
                    case 0:
                        LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownNumber.Value);
                        LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownNumber.Value);
                        break;
                    case 1:
                        LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownNumber.Value);
                        LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownNumber.Value);
                        break;
                    case 2:
                        LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownNumber.Value);
                        LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownNumber.Value);
                        LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        break;
                    case 3:
                        LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownNumber.Value);
                        LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownNumber.Value);
                        LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        break;
                }
                return true;
            });
        }

        private async void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderNameChange(this.folderBrowserDialog.SelectedPath);
                this.numericUpDownNumber.Value = this.numericUpDownShiftimageIndex.Value + 1;
                await this.LoadImages(this.tabControl.SelectedIndex);
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

        private async void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownNumber.Enabled = false;
            buttonNumberDown.Visible = false;
            buttonNumberUp.Visible = false;
            this.labelForwardImageIndex.Text = $"{this.numericUpDownNumber.Value - this.numericUpDownShiftimageIndex.Value}";
            this.labelRearImageIndex.Text = $"{this.numericUpDownNumber.Value + this.numericUpDownShiftimageIndex.Value}";
            try
            {
                await this.LoadImages(this.tabControl.SelectedIndex);
            }
            finally
            {
                numericUpDownNumber.Enabled = true;
                buttonNumberDown.Visible = true;
                buttonNumberUp.Visible = true;
                numericUpDownNumber.Focus();
            }
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                string programPath = @"c:\PortableProgFiles\FSViewer77\FSViewer.exe";
                string parameters = "\"" + ((PictureBox)sender).ImageLocation + "\"";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = programPath,
                    Arguments = parameters,
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting the program: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPast_Click(object sender, EventArgs e)
        {
            // Xplore1_Ayr_Ayr1_Run 43_459
            int value;
            string clipboardText = Clipboard.GetText();
            int endIndex = clipboardText.Length;
            for (int i = clipboardText.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(clipboardText[i]))
                {
                    endIndex = i + 1;
                    break;
                }
            }
            if (endIndex == 0)
            {
                value = int.Parse(clipboardText);
            }

            else
            {
                value = int.Parse(clipboardText.Substring(endIndex));
            }
            this.numericUpDownNumber.Value = value;
        }

        private void buttonNumberDown_Click(object sender, EventArgs e)
        {
            this.numericUpDownNumber.Value--;
        }

        private void buttonNumberUp_Click(object sender, EventArgs e)
        {
            this.numericUpDownNumber.Value++;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageShortName_TAG = String.Empty;
            switch (this.tabControl.SelectedIndex)
            {
                case 0:
                    imageShortName_TAG = "Forward " + $"{this.numericUpDownNumber.Value - this.numericUpDownShiftimageIndex.Value}";

                    break;
                case 1:
                    imageShortName_TAG = "Rear " + $"{this.numericUpDownNumber.Value + this.numericUpDownShiftimageIndex.Value}";
                    break;
                case 2:
                    imageShortName_TAG = "Left " + $"{this.numericUpDownNumber.Value}";
                    break;
                case 3:
                    imageShortName_TAG = "Right " + $"{this.numericUpDownNumber.Value}"; ;
                    break;
            }

            this.toolStripStatusLabelImageTAG.Text = imageShortName_TAG;
            this.toolStripStatusLabelImageTAG.BackColor = SystemColors.Control;
        }

        private void toolStripStatusLabelImageTAG_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.toolStripStatusLabelImageTAG.Text);
            this.toolStripStatusLabelImageTAG.BackColor = SystemColors.ActiveCaption;
        }
    }
}