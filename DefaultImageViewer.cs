using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class DefaultImageViewer
{
    [DllImport("shell32.dll", SetLastError = true)]
    public static extern uint FindExecutable(string lpFile, string lpDirectory, [Out] char[] lpResult);

    private string imageViewerPath;

    public DefaultImageViewer()
    {
        imageViewerPath = GetDefaultImageViewer();
    }

    public string GetDefaultImageViewer()
    {
        string imagePath = "1.jpg";
        char[] result = new char[1024];
        uint error = FindExecutable(imagePath, String.Empty, result);

        if (error >= 32)
        {
            string executablePath = new string(result).Trim('\0');
            if (!string.IsNullOrEmpty(executablePath))
            {
                return executablePath;
            }
        }

        return String.Empty;
    }

    public void OpenImage(string imagePath)
    {
        try
        {

            //string programPath = @"c:\PortableProgFiles\FSViewer77\FSViewer.exe";
            string parameters;
            
            if(imagePath != null)
                parameters = "\"" + imagePath + "\"";
            else parameters= String.Empty;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = imageViewerPath,
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
}
