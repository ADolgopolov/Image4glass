using System.IO;

namespace Image4glass
{
    internal class FilePathBuilder
    {
        private bool isInitializated;
        private string part1;
        private string part2;
        private string part3;
        private string extension;

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
            set { part2 = value.Replace("_", "\\"); }
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
            // За замовчуванням ініціалізуємо поля частинами шляху і розширенням
            part1 = string.Empty;
            part2 = string.Empty;
            part3 = string.Empty;
            extension = ".jpg";
        }

        public void Reset()
        {
            isInitializated = false;
            part1 = string.Empty;
            part2 = string.Empty;
            part3 = string.Empty;
            extension = ".jpg";
        }

    }

}
