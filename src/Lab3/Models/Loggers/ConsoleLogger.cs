using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[Console Logger] {message}");
    }
}