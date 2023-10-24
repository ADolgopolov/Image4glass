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