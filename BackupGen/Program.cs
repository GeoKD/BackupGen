using BackupGen.Log;
using BackupGen.Settings;

namespace BackupGen;

class Program
{
    static void Main(string[] args)
    {
        SettingsFile settingsFile = new SettingsFile("settings.json");
        SettingsOptions settingsOptions = settingsFile.GetOptions();
        
        Logger.SetLoggingLevel(settingsOptions.LoggingLevel);
        
        BackupGenerator backupGenerator = new BackupGenerator(settingsOptions);
        backupGenerator.CopyFiles();
        
        Logger.SaveLog();
    }
}