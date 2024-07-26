using BackupGen.Settings;

namespace BackupGen;

public class BackupGenerator
{
    private SettingsOptions _settingsOptions;
    private string _backupFolderName;

    public BackupGenerator(SettingsOptions settingsOptions)
    {
        _settingsOptions = settingsOptions;
        _backupFolderName = "backup-" + DateTime.Now.ToString("dd.MM.yyyy Thh.mm.ss");
    }

    public void CopyFiles()
    {
        Directory.CreateDirectory(_settingsOptions.DestinationFolder + @"\" + _backupFolderName);
        foreach (var folder in _settingsOptions.SourceFolders)
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
        File.Copy(filePath, _settingsOptions.DestinationFolder + @"\" + _backupFolderName + @"\" + fileName);
    }
}