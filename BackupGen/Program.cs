using BackupGen.Log;
using BackupGen.Settings;

namespace BackupGen;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SettingsFile settingsFile = new SettingsFile("settings.json");
            SettingsOptions settingsOptions = settingsFile.GetOptions();
            
            Logger.SetLoggingLevel(settingsOptions.LoggingLevel);
            
            BackupGenerator backupGenerator = new BackupGenerator(settingsOptions);
            backupGenerator.CopyFiles();
            
            Console.WriteLine("Backups created!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Logger.LogError(e.Message);
        }
        
        Logger.SaveLog();
    }
}