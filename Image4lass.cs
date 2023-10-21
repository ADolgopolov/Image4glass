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
        string folderName;

        ArrayList historyFolderList;

        DefaultImageViewer defaultImageViewer;

        FilePathBuilder filePathBuilder;

        public static class ImageLabelText
        {
            public static string Forward = "Forward";
            public static string Rear = "Rear";
            public static string Right = "Right";
            public static string Left = "Left";
            public static string Loading = "Loading...";
        }

        public Image4lass()
        {
            InitializeComponent();

            this.folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.historyFolderList = new ArrayList();

            this.filePathBuilder = new FilePathBuilder();
            this.toolStripStatusLabel.Text = filePathBuilder.Part1;

            this.defaultImageViewer = new DefaultImageViewer();
        }

        private void addNewFolderToList(string newFolder)
        {
            if (this.historyFolderList.Contains(newFolder))
            {
                this.historyFolderList.RemoveAt(historyFolderList.IndexOf(newFolder));
            }
            this.historyFolderList.Insert(0, newFolder);
            this.comboBoxFoldreName.Items.Clear();
            this.comboBoxFoldreName.Items.AddRange(historyFolderList.ToArray());
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
            
            path += @"\" + FileNameIndex + ".jpg";
            if (File.Exists(path))
            {
                try
                {
                    pictureBox.Load(path);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    pictureBox.Image = null;
                }
                return Path.GetFileName(Path.GetDirectoryName(path)) + " " + Path.GetFileNameWithoutExtension(path);
            }
            else
            {
                pictureBox.Image = null;
                return path + "; - The file does not exist.";
            }
        }

        private async Task LoadImages(int tabControlSelectedIndex)
        {
            var image = await Task.Run(() =>
            {
                switch (tabControlSelectedIndex)
                {
                    case 0:
                        ImageLabelText.Forward = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        break;
                    case 1:
                        ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        ImageLabelText.Forward = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        break;
                    case 2:
                        ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        ImageLabelText.Forward = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        break;
                    case 3:
                        ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        ImageLabelText.Forward = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
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

        /// <summary>
        /// Блокуємо і розблоковуємо елементи керування, що впливають на зміну номера зображення, щоб не спричинити конфлікт з уже запущеним асинхронним методом
        /// завантаження зображень
        /// </summary>
        /// <param name="isEnable"></param>
        private void enabledCommandTools(bool isEnable)
        {
            buttonPast.Enabled = isEnable;
            numericUpDownFotoNumber.Enabled = isEnable;
            buttonNumberDown.Visible = isEnable;
            buttonNumberUp.Visible = isEnable;
            buttonOpenFolder.Enabled = isEnable;
            numericUpDownShiftimageIndex.Enabled = isEnable;
        }
        /// <summary>
        /// Тут відбувається вся магія. Міняється номер, запускається загрузка зображень.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            this.enabledCommandTools(false);

            this.labelForwardImageIndex.Text = ImageLabelText.Loading;
            this.labelRearImageIndex.Text = ImageLabelText.Loading;
            this.labelLeftImageIndex.Text = ImageLabelText.Loading;
            this.labelRightImageIndex.Text = ImageLabelText.Loading;
            try
            {
                await this.LoadImages(this.tabControl.SelectedIndex);
            }
            finally
            {
                this.enabledCommandTools(true);
                this.numericUpDownFotoNumber.Focus();
                this.labelForwardImageIndex.Text = ImageLabelText.Forward;
                this.labelRearImageIndex.Text = ImageLabelText.Rear;
                this.labelLeftImageIndex.Text = ImageLabelText.Left;
                this.labelRightImageIndex.Text = ImageLabelText.Right;
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

            defaultImageViewer.OpenImage(imagePath);
        }
        private void buttonPast_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                if (this.filePathBuilder.IsInitializated)
                {
                    string part2 = Clipboard.GetText();
                    try
                    {
                        part2 = Regex.Replace(part2, @"\p{C}+", ""); // for desktop version 
                        if (part2.Contains("-") && part2.Contains("Run "))
                        {
                            filePathBuilder.Part2 = part2.Substring(0, part2.LastIndexOf("-")).Replace("Run ", "Photos\\Run ");
                        }
                        if (part2.Contains("_") && part2.Contains("Run "))
                        {
                            filePathBuilder.Part2 = part2.Substring(0, part2.LastIndexOf("_")).Replace("Run ", "Photos\\Run ");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка парсування шляху: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    int lastSeparatorIndex = 0;
                    if (part2.Contains("-"))
                    {
                        lastSeparatorIndex = part2.LastIndexOf("-") + 1;
                    }
                    if (part2.Contains("_"))
                    {
                        lastSeparatorIndex = part2.LastIndexOf("_") + 1;
                    }
                    filePathBuilder.Part3 = part2.Substring(lastSeparatorIndex, part2.Length - lastSeparatorIndex);

                    if (int.TryParse(filePathBuilder.Part3, out int fileNumber))
                    {

                        folderNameChange(filePathBuilder.RunFolderFullPath);
                        addNewFolderToList(filePathBuilder.RunFolderFullPath);
                        this.numericUpDownFotoNumber.Value = fileNumber;
                    }
                    else
                    {
                        MessageBox.Show(filePathBuilder.FullImageFilePath + "; - Файл не знайдено. Виберіть теку самостійно.", "Інформація");
                    }
                }
                else
                {
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
                        MessageBox.Show("Буфер обміну не містить рядок з номером.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string subStr = clipboardTextString.Substring(cutStringToIndex);

                        if (int.TryParse(subStr, out int fileNumber))
                        {
                            this.numericUpDownFotoNumber.Value = fileNumber;
                        }
                        else
                        {
                            Console.WriteLine("Рядок не є цілим числом.");
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
            if (this.numericUpDownFotoNumber.Value < this.numericUpDownFotoNumber.Maximum)
            {
                this.numericUpDownFotoNumber.Value++;
            }
        }

        private void SaveFolderListToFile()
        {
            int foldersAmount = Math.Min(10, historyFolderList.Count);
            try
            {
                using (StreamWriter writer = new StreamWriter("folderList.txt"))
                {
                    for (int i = 0; i < foldersAmount; i++)
                    {
                        writer.WriteLine(this.historyFolderList[i]);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Файл з теками, що використовувались не збережено.");
            }
        }

        private void LoadFolderListFromFile()
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
                            historyFolderList.Add(line);
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Файл з теками, не вдалось прочитати.");
                }
            }
        }
        /// <summary>
        /// Закриває форму. Зберігаєм корисні змінні по файлах:
        /// історія робочих директорій;
        /// базова директорія.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image4lass_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveFolderListToFile();
            this.filePathBuilder.SaveData();
        }

        /// <summary>
        /// При загрузці форми 
        /// Зчитуєм файл з набором директорій, що відкривались недавно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image4lass_Load(object sender, EventArgs e)
        {
            this.LoadFolderListFromFile();

            if (this.historyFolderList.Count > 0)
            {
                this.comboBoxFoldreName.Items.Clear();
                this.comboBoxFoldreName.Items.AddRange(historyFolderList.ToArray());
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
            string? str = (string?)this.historyFolderList[0];
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