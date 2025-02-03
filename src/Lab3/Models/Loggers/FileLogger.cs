using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

public class FileLogger : ILogger
{
    private readonly string _logFilePath;

    public FileLogger(string filePath)
    {
        _logFilePath = filePath;
    }

    public void Log(string message)
    {
        File.AppendAllText(_logFilePath, $"[File Logger] {message}\n");
    }
}