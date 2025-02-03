using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using static System.Console;

namespace Lab4.Console.ConsoleCommands.FileCommands;

public class FileRenameCommand : IConsoleCommand
{
    public FileRenameCommand(string path, string name, FileSystemManager fileSystemManager)
    {
        Path = path;
        FileSystemManager = fileSystemManager;
        Name = name;
    }

    public string Path { get; }
    public string Name { get; }
    public FileSystemManager FileSystemManager { get; }

    public void Execute()
    {
        try
        {
            FileSystemManager.FileSystem?.RenameFile(Path, Name);
            WriteLine($"File '{Path}' renamed to '{Name}'.");
        }
        catch (FileSystemException ex)
        {
            WriteLine($"Error: {ex.Message}");
        }
    }
}