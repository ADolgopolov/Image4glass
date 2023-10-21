using System.IO;
using System.Text.RegularExpressions;

namespace Image4glass
{
    internal class FilePathBuilder
    {
        private bool isInitializated;
        private string part1;
        private string part2;
        private string part3;
        private string extension;
        private const string basicFolderSaveFileName = "basicfolder.txt";

        public bool IsInitializated
        {
            get { return isInitializated; }
        }

        public string Part1
        {
            get { return part1; }
            set { 
                part1 = value; 
                isInitializated = true;
            }
        }

        public string Part2
        {
            get { return part2; }
            set 
            {
                    if (value.Contains("-"))
                    { 
                        part2 = value.Replace("-", "\\"); 
                    }
                    else
                    {
                        part2 = value.Replace("_", "\\");
                    }
            }
        }

        public string Part3
        {
            get { return part3; }
            set { part3 = value; }
        }

        public string FullImageFilePath
        {
            get
            {
                string filePath = Path.Combine(part1, part2, "Right\\" + part3 + extension);
                return filePath;
            }
        }
        
        public string RunFolderFullPath
        {
            get
            {
                string filePath = Path.Combine(part1, part2);
                return filePath;
            }
        }

        public FilePathBuilder()
        {
            isInitializated = false;
            part1 = string.Empty;
            part2 = string.Empty;
            part3 = string.Empty;
            extension = ".jpg";
            this.ReadData();
        }

        public void Reset()
        {
            isInitializated = false;
            part1 = string.Empty;
            part2 = string.Empty;
            part3 = string.Empty;
            extension = ".jpg";
        }
        public void SaveData()
        {
            // Відкриваємо файл для запису
            StreamWriter writer = new StreamWriter(basicFolderSaveFileName, false);

            // Записуємо дані до файлу
            writer.WriteLine(part1);

            // Закриваємо файл
            writer.Close();
        }

        private void ReadData()
        {
            if (File.Exists(basicFolderSaveFileName))
            {
                StreamReader reader = new StreamReader(basicFolderSaveFileName);

                string? data = reader.ReadLine(); reader.Close();

                if (String.IsNullOrEmpty(data)) 
                { 
                    part1 = String.Empty; 
                    isInitializated = false; 
                }
                else
                {
                    part1 = data; 
                    isInitializated = true;
                }
            }
        }
        public bool IsFilePathValid(string path)
        {
            // Регулярний вираз для перевірки шляху до файлу
            //string pattern = @"^(?:[\w]\:|\\)(\\[^\/:*?""><|]*)+\\?$";
              string pattern = @"^(?:[\w]\:|\\)([^\/:*?""><|]*)+\\?$";

            return Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase);
        }
    }

}
