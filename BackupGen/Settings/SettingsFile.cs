using System.Text.Json;

namespace BackupGen.Settings;

public class SettingsFile
{
    private SettingsOptions? _settingsOptions;

    public SettingsFile(string filePath)
    {
        try
        {
            TryReadFile(filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void TryReadFile(string filePath)
    {
        using StreamReader streamReader = new StreamReader(filePath);
        string stream = streamReader.ReadToEnd();
        _settingsOptions = JsonSerializer.Deserialize<SettingsOptions>(stream);
    }

    public SettingsOptions GetOptions()
    {
        return _settingsOptions!;
    }
}