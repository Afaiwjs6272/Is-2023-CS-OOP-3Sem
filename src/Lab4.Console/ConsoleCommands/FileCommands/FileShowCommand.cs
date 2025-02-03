using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using static System.Console;

namespace Lab4.Console.ConsoleCommands.FileCommands;

public class FileShowCommand : IConsoleCommand
{
    public FileShowCommand(string path, FileSystemManager fileSystemManager)
    {
        Path = path;
        FileSystemManager = fileSystemManager;
    }

    public string Path { get; }
    public FileSystemManager FileSystemManager { get; }

    public void Execute()
    {
        try
        {
            string content = FileSystemManager.FileSystem?.ReadFile(Path) ?? throw new FileSystemException();
            WriteLine($"Contents of file '{Path}':");
            WriteLine(content);
        }
        catch (FileNotFoundException)
        {
            WriteLine($"File '{Path}' not found.");
        }
    }
}