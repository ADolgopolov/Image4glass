using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Image4glass
{
    public partial class Image4lass : Form
    {
        string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string labelForwardImageIndex_Text = "Forward";
        string labelRearImageIndex_Text = "Rear";
        string labelRightImageIndex_Text = "Right";
        string labelLeftImageIndex_Text = "Left";

        ArrayList folderList = new ArrayList();

        DefaultImageViewer viewer = new DefaultImageViewer();

        FilePathBuilder filePathBuilder = new FilePathBuilder();

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
            }
        }


        private string LoadImageOnTab(string tabFolderName, PictureBox pictureBox, decimal FileNameIndex)
        {
            string path = folderName + tabFolderName;
            if (Directory.Exists(path))
            {
                path += @"\" + FileNameIndex + ".jpg";
                if (File.Exists(path))
                {
                    pictureBox.Load(path);
                    return Path.GetFileName(Path.GetDirectoryName(path)) + " " + Path.GetFileNameWithoutExtension(path);
                }
                else
                {
                    pictureBox.Image = null;
                    return path + "; - The file does not exist.";
                }
            }
            else
            {
                pictureBox.Image = null;
                return path + "; - The folder does not exist.";
            }
        }

        private async Task LoadImages(int tabControlSelectedIndex)
        {
            var image = await Task.Run(() =>
            {
                switch (tabControlSelectedIndex)
                {
                    case 0:
                        labelForwardImageIndex_Text = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        labelRearImageIndex_Text = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        labelLeftImageIndex_Text = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        labelRightImageIndex_Text = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        break;
                    case 1:
                        labelRearImageIndex_Text = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        labelForwardImageIndex_Text = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        labelLeftImageIndex_Text = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        labelRightImageIndex_Text = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        break;
                    case 2:
                        labelLeftImageIndex_Text = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        labelRightImageIndex_Text = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        labelRearImageIndex_Text = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        labelForwardImageIndex_Text = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        break;
                    case 3:
                        labelRightImageIndex_Text = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        labelLeftImageIndex_Text = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        labelRearImageIndex_Text = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        labelForwardImageIndex_Text = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
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
            // Upload Picturebox
            pictureBoxForward.Image = null;
            pictureBoxRear.Image = null;
            pictureBoxLeft.Image = null;
            pictureBoxRight.Image = null;
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

            this.labelForwardImageIndex.Text = "Loading...";
            this.labelRearImageIndex.Text = "Loading...";
            this.labelLeftImageIndex.Text = "Loading...";
            this.labelRightImageIndex.Text = "Loading...";
            try
            {
                await this.LoadImages(this.tabControl.SelectedIndex);
            }
            finally
            {
                this.enabledCommandTools(true);
                this.numericUpDownFotoNumber.Focus();
                this.labelForwardImageIndex.Text = this.labelForwardImageIndex_Text;
                this.labelRearImageIndex.Text = this.labelRearImageIndex_Text;
                this.labelLeftImageIndex.Text = this.labelLeftImageIndex_Text;
                this.labelRightImageIndex.Text = this.labelRightImageIndex_Text;
            }
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            /*
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
            */
            string imagePath = ((PictureBox)sender).ImageLocation;

            viewer.OpenImage(imagePath);
        }
        private async void buttonPast_ClickAsync(object sender, EventArgs e)
        {
            //string filePath = builder.FullPath;
            if (Clipboard.ContainsText())
            {
                if (this.filePathBuilder.IsInitializated)
                {
                    string part2 = Clipboard.GetText();
                    filePathBuilder.Part2 = part2.Substring(0, part2.LastIndexOf("_")).Replace("Run ", "Photos\\Run ");
                    int lastSeparatorIndex = part2.LastIndexOf("_") + 1;
                    filePathBuilder.Part3 = part2.Substring(lastSeparatorIndex, part2.Length - lastSeparatorIndex);
                    if (File.Exists(filePathBuilder.FullImageFilePath))
                    {

                        folderNameChange(filePathBuilder.RunFolderFullPath);
                        addNewFolderToList(filePathBuilder.RunFolderFullPath);
                        this.numericUpDownFotoNumber.Value = int.Parse(filePathBuilder.Part3);
                        await this.LoadImages(this.tabControl.SelectedIndex);
                    }
                    else
                    {
                        MessageBox.Show(filePathBuilder.FullImageFilePath + "; - Файл не знайдено. Виберіть теку самостійно.", "Інформація");
                    }
                }
                else
                {
                    int value;
                    string clipboardTextString = Clipboard.GetText();
                    int cutStringToIndex = 0;
                    int digitsAmount = 0;
                    for (int i = clipboardTextString.Length - 1; i >= 0; i--)
                    {
                        if (Char.IsDigit(clipboardTextString[i]))
                        {
                            digitsAmount++;
                        }
                        else
                        {
                            cutStringToIndex = i + 1;
                            break;
                        }
                    }

                    if (digitsAmount == 0)
                    {
                        MessageBox.Show("Буфер обміну не містить рядок з номером.", "Інформація");
                    }
                    else
                    {
                        string subStr = clipboardTextString.Substring(cutStringToIndex);
                        if (Regex.IsMatch(subStr, @"^\d+$"))
                        {
                            value = int.Parse(subStr);
                            this.numericUpDownFotoNumber.Value = value;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Буфер обміну не містить текстовий рядок.", "Інформація");
            }
        }
        private void buttonNumberDown_Click(object sender, EventArgs e)
        {
            if (this.numericUpDownFotoNumber.Value > this.numericUpDownFotoNumber.Minimum)
            {
                this.numericUpDownFotoNumber.Value--;
            }
        }

        private void buttonNumberUp_Click(object sender, EventArgs e)
        {
            this.numericUpDownFotoNumber.Value++;
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

        private void openBasicFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.basicFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.toolStripStatusLabel.Text = this.basicFolderBrowserDialog.SelectedPath;
                filePathBuilder.Part1 = this.basicFolderBrowserDialog.SelectedPath;

            }
        }

        private void resetBasicFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = "Set basic folder to recognize string in clipboard";
            filePathBuilder.Reset();
        }
    }
}