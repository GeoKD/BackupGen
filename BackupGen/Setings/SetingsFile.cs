namespace BackupGen.Settings;

public class SetingsFile
{
    private SetingsOptions _SetingsOptions;

    public SetingsFile(string filePath)
    {
        
    }

    public SetingsOptions GetOptions()
    {
        return _SetingsOptions;
    }
}