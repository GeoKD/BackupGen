using System.Text.Json.Serialization;

namespace BackupGen.Settings;

public class SettingsOptions(List<String> sourceFolders, String destinationFolder, LoggingLevel loggingLevel)
{
    [JsonPropertyName("sourceFolders")]
    public List<String> SourceFolders { get; set; } = sourceFolders;
    
    [JsonPropertyName("destinationFolder")]
    public String DestinationFolder { get; set; } = destinationFolder;
    
    [JsonPropertyName("loggingLevel")]
    public LoggingLevel LoggingLevel { get; set; } = loggingLevel;
}