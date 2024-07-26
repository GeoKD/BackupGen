using BackupGen.Settings;

namespace BackupGen;

class Program
{
    static void Main(string[] args)
    {
        SettingsFile settingsFile = new SettingsFile("settings.json");
        SettingsOptions settingsOptions = settingsFile.GetOptions();
    }
}