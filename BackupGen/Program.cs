using BackupGen.Settings;

namespace BackupGen;

class Program
{
    static void Main(string[] args)
    {
        SetingsFile setingsFile = new SetingsFile("setings.json");
        SetingsOptions setingsOptions = setingsFile.GetOptions();
    }
}