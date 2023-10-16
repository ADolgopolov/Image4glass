using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Image4glass
{
    public partial class Image4lass : Form
    {
        string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        ArrayList folderList = new ArrayList();
        public Image4lass()
        {
            InitializeComponent();
        }

        private void addNewFolderToList(string newFolder)
        {
            if (this.folderList.Contains(newFolder))
            {
                this.folderList.RemoveAt(folderList.IndexOf(newFolder));
            }
            this.folderList.Insert(0, newFolder);
            this.comboBoxFoldreName.Items.Clear();
            this.comboBoxFoldreName.Items.AddRange(folderList.ToArray());
            this.comboBoxFoldreName.SelectedIndex = 0;
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
                        LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        break;
                    case 1:
                        LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        break;
                    case 2:
                        LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        break;
                    case 3:
                        LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
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
                addNewFolderToList(this.folderBrowserDialog.SelectedPath);
                this.numericUpDownFotoNumber.Value = this.numericUpDownShiftimageIndex.Value + 1;
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


        private void comboBoxFoldreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownFotoNumber.Focus();
        }

        private void enabledCommandTools(bool isEnable)
        {
            buttonPast.Enabled = isEnable;
            numericUpDownFotoNumber.Enabled = isEnable;
            buttonNumberDown.Visible = isEnable;
            buttonNumberUp.Visible = isEnable;
            buttonOpenFolder.Enabled = isEnable;
            numericUpDownShiftimageIndex.Enabled = isEnable;
        }

        private async void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            this.enabledCommandTools(false);
            this.labelForwardImageIndex.Text = $"{this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value}";
            this.labelRearImageIndex.Text = $"{this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value}";
            try
            {
                await this.LoadImages(this.tabControl.SelectedIndex);
            }
            finally
            {
                this.enabledCommandTools(true);
                numericUpDownFotoNumber.Focus();
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
            if (Clipboard.ContainsText())
            {
                int value;
                string clipboardText = Clipboard.GetText();
                if (IsNumeric(clipboardText))
                {
                    value = int.Parse(clipboardText);
                    this.numericUpDownFotoNumber.Value = value;
                }
                else 
                { 
                    int endIndex = clipboardText.Length;
                    for (int i = clipboardText.Length - 1; i >= 0; i--)
                    {
                        if (!Char.IsDigit(clipboardText[i]))
                        {
                            endIndex = i + 1;
                            break;
                        }
                    }

                    string subStr = clipboardText.Substring(endIndex);
                    if (IsNumeric(subStr))
                    {
                        value = int.Parse(subStr);
                        this.numericUpDownFotoNumber.Value = value;
                    }
                }
            }
            else
            {
                MessageBox.Show("Буфер обміну не містить текстовий рядок.", "Інформація");
            }
        }
        private bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
        private void buttonNumberDown_Click(object sender, EventArgs e)
        {
            this.numericUpDownFotoNumber.Value--;
        }

        private void buttonNumberUp_Click(object sender, EventArgs e)
        {
            this.numericUpDownFotoNumber.Value++;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageShortName_TAG = String.Empty;
            switch (this.tabControl.SelectedIndex)
            {
                case 0:
                    imageShortName_TAG = "Forward " + $"{this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value}";

                    break;
                case 1:
                    imageShortName_TAG = "Rear " + $"{this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value}";
                    break;
                case 2:
                    imageShortName_TAG = "Left " + $"{this.numericUpDownFotoNumber.Value}";
                    break;
                case 3:
                    imageShortName_TAG = "Right " + $"{this.numericUpDownFotoNumber.Value}"; ;
                    break;
            }

            this.toolStripStatusLabelImageTAG.Text = imageShortName_TAG;
            this.toolStripStatusLabelImageTAG.BackColor = SystemColors.Control;
        }

        private void ToolStripStatusLabelImageTAG_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.toolStripStatusLabelImageTAG.Text);
            this.toolStripStatusLabelImageTAG.BackColor = SystemColors.ActiveCaption;
        }

        private void SaveFolderListToFile()
        {
            int foldersAmount = Math.Min(10, folderList.Count);
            try
            {
                using (StreamWriter writer = new StreamWriter("folderList.txt"))
                {
                    for (int i = 0; i < foldersAmount; i++)
                    {
                        writer.WriteLine(this.folderList[i]);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Файл з теками, що використовувались не збережено.");
            }
        }

        public void LoadFolderListFromFile()
        {
            string filePath = "folderList.txt";
            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            folderList.Add(line);
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Файл з теками, не вдалось прочитати.");
                }
            }
        }

        private void Image4lass_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveFolderListToFile();
        }

        private void Image4lass_Load(object sender, EventArgs e)
        {
            this.LoadFolderListFromFile();

            if (this.folderList.Count > 0)
            {
                this.comboBoxFoldreName.Items.Clear();
                this.comboBoxFoldreName.Items.AddRange(folderList.ToArray());
                // Disable edit text in combobox
                comboBoxFoldreName.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBoxFoldreName.SelectedIndex = 0;
                folderName = TakeFirstElementOfArray();
                this.folderBrowserDialog.SelectedPath = TakeFirstElementOfArray();
            } 
            else
            {

                folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                this.folderBrowserDialog.SelectedPath = folderName;
            }
        }

        private string TakeFirstElementOfArray()
        {
            string? str = (string?)this.folderList[0];
            if (str is not null)
                return str.ToString();
            else return "";
        }
    }
}