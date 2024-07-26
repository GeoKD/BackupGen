using BackupGen.Settings;

namespace BackupGen;

public class BackupGenerator
{
    private SetingsOptions _settingsOptions;

    public BackupGenerator(SetingsOptions settingsOptions)
    {
        _settingsOptions = settingsOptions;
    }

    public void CopyFiles()
    {
        foreach (var folder in _settingsOptions.sourceFolders)
        {
            if (Directory.Exists(folder))
            {
                CopyFolder(folder);
            }
        }
    }

    private void CopyFolder(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath);
        foreach (var file in files)
        {
            CopyFile(file);
        }
    }

    private void CopyFile(string filePath)
    {
        string fileName = filePath.Split(@"\").Last();
    }

}