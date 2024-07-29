using BackupGen.Log;
using BackupGen.Settings;

namespace BackupGen;

public class BackupGenerator
{
    private List<string> _sourceFolders;
    private string _destinationFolder;
    private string _backupFolderName;
    
    private int _filesAmount;
    private int _copiedFilesAmount;

    public BackupGenerator(SettingsOptions settingsOptions)
    {
        _sourceFolders = settingsOptions.SourceFolders;
        _destinationFolder = settingsOptions.DestinationFolder;
        _backupFolderName = "backup-" + DateTime.Now.ToString("dd.MM.yyyy Thh.mm.ss");
        
        _filesAmount = 0;
        _copiedFilesAmount = 0;
    }

    public void CopyFiles()
    {
        Logger.LogInfo("Starting to generate backups...");
        try
        {
            CopyFilesFromFolders();
            Logger.LogInfo("Backup created\n" +
                           "Files Amount: " + _filesAmount + " files\n" +
                           "Copied files Amount: " + _copiedFilesAmount + " files\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Logger.LogError(e.Message);
        }
    }

    private void CopyFilesFromFolders()
    {
        Directory.CreateDirectory(@$"{_destinationFolder}\{_backupFolderName}");
        foreach (var folder in _sourceFolders)
        {
            if (Directory.Exists(folder))
            {
                CopyFolder(folder);
                Logger.LogInfo(folder + " - Folder copied");
            }
            else
            {
                Logger.LogInfo("Path doesn't exist " + folder);
            }
        }
    }
    
    private void CopyFolder(string folderPath)
    {
        string folderName = folderPath.Split(@"\").Last();
        string destPath = @$"{_destinationFolder}\{_backupFolderName}\{folderName}";
        Directory.CreateDirectory(destPath);
        
        string[] files = Directory.GetFiles(folderPath);
        foreach (var file in files)
        {
            CopyFile(file, destPath);
        }
    }

    private void CopyFile(string filePath, string destPath)
    {
        try
        {
            string fileName = filePath.Split(@"\").Last();
            string destFilePath = $@"{destPath}\{fileName}";
            
            _filesAmount++;
            File.Copy(filePath, destFilePath);
            _copiedFilesAmount++;
            Logger.LogDebug(filePath + " - File copied");
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
            Logger.LogInfo(e.Message);
        }
    }
}