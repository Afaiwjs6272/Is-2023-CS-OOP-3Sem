using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Lab4.Console.ConsoleCommands;
using static System.Console;

namespace Lab4.Console;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var fileManager = new FileSystemManager();
        var commandParser = new CommandParser(fileManager);

        // connect C:\Users\10\Desktop\ -m local
        // tree goto C:\Users\10\Desktop\to
        // file move Lab1.pdf C:\Users\10\Desktop\to
        // file copy Lab1.pdf C:\Users\10\Desktop\to
        // file rename Lab1.pdf negr.pdf
        while (true)
        {
            Write(fileManager.FileSystem == null ? "[disconnected] > " : $"({fileManager.FileSystem.CurrentPath})> ");

            string? input = ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            string[] commandArgs = input.Split(' ');

            try
            {
                IConsoleCommand consoleCommand = commandParser.ParseCommand(commandArgs);
                consoleCommand.Execute();
                WriteLine("Command executed successfully.");
            }
            catch (FileSystemException e)
            {
                WriteLine(e);
            }
        }
    }
}