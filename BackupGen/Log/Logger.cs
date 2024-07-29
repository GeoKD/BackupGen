using BackupGen.Settings;

namespace BackupGen.Log;

public static class Logger
{
    private const LoggingLevel DefaultLoggingLevel = LoggingLevel.Info;
    
    private static StreamWriter _logFile;
    private static LoggingLevel _loggingLevel;

    static Logger()
    {
        Directory.CreateDirectory("logs");
        _logFile = File.CreateText(@"logs\logfile-" + DateTime.Now.ToString("dd.MM.yyyy Thh.mm.ss") + ".txt");
        _logFile.WriteLine("Log file for " + DateTime.Now);

        _loggingLevel = DefaultLoggingLevel;
    }

    public static void SetLoggingLevel(LoggingLevel? loggingLevel)
    {
        if (loggingLevel == null) return;
        _loggingLevel = loggingLevel.Value;
    }
    
    public static void LogError(string message)
    {
        _logFile.WriteLine("ERROR: " + message);
    }

    public static void LogInfo(string message)
    {
        if (_loggingLevel >= LoggingLevel.Info)
        {
            _logFile.WriteLine("INFO: " + message);
        }
    }

    public static void LogDebug(string message)
    {
        if (_loggingLevel >= LoggingLevel.Debug)
        {
            _logFile.WriteLine("DEBUG: " + message);
        }
    }

    public static void SaveLog()
    {
        _logFile.Flush();
    }
}