using System.Text.Json;
using BackupGen.Log;

namespace BackupGen.Settings;

public class SettingsFile
{
    private SettingsOptions? _settingsOptions;

    public SettingsFile(string filePath)
    {

        string settingsFile = ReadFile(filePath);
        _settingsOptions = DeserializeFile(settingsFile);
    }

    private string ReadFile(string filePath)
    {
        using StreamReader streamReader = new StreamReader(filePath);
        return streamReader.ReadToEnd();
    }

    private SettingsOptions DeserializeFile(string file)
    {
        SettingsOptions? settingsOptions = JsonSerializer.Deserialize<SettingsOptions>(file);

        CheckSettingsOptions(settingsOptions);

        return settingsOptions;
    }

    private void CheckSettingsOptions(SettingsOptions? settingsOptions)
    {
        if (settingsOptions == null)
        {
            throw new Exception("Deserialization result is null");
        }
        
        if (settingsOptions.SourceFolders == null)
        {
            throw new ArgumentException("Can't find source folders");
        }
        
        if (settingsOptions.DestinationFolder == null)
        {
            throw new ArgumentException("Can't find destination folder");
        }
    }

    public SettingsOptions GetOptions()
    {
        return _settingsOptions!;
    }
}