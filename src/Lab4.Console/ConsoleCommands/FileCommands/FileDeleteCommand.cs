using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using static System.Console;

namespace Lab4.Console.ConsoleCommands.FileCommands;

public class FileDeleteCommand : IConsoleCommand
{
    public FileDeleteCommand(string path, FileSystemManager fileSystemManager)
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
            FileSystemManager.FileSystem?.DeleteFile(Path);
            WriteLine($"File '{Path}' deleted successfully.");
        }
        catch (FileSystemException ex)
        {
            WriteLine($"Error: {ex.Message}");
        }
    }
}