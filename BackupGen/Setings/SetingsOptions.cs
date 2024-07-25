namespace BackupGen.Settings;

public class SetingsOptions
{
    public List<String> sourceFolders { get; set; }
    public String destinationFolder { get; set; }
    public LoggingLevel LoggingLevel { get; set; }
}