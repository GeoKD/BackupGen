using System.Globalization;

namespace BackupGen.Loger;

public static class Logger
{
    private static StreamWriter _logFile;

    static Logger()
    {
        Directory.CreateDirectory("logs");
        _logFile = File.CreateText(@"logs\logfile-" + DateTime.Now.ToString("dd.MM.yyyy Thh.mm.ss") + ".txt");
        _logFile.WriteLine("Log file for " + DateTime.Now);
    }
    
    public static void LogError(string message)
    {
        _logFile.WriteLine("ERROR: " + message);
    }

    public static void LogInfo(string message)
    {
        _logFile.WriteLine("INFO: " + message);
    }

    public static void LogDebug(string message)
    {
        _logFile.WriteLine("DEBUG: " + message);
    }

    public static void SaveLog()
    {
        _logFile.Flush();
    }
}