using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Lab4.Console.ConsoleCommands.TreeCommands;

public class TreeGotoCommand : IConsoleCommand
{
    private readonly string _path;

    public TreeGotoCommand(string path, FileSystemManager fileSystemManager)
    {
        _path = path;
        FileSystemManager = fileSystemManager;
    }

    public FileSystemManager FileSystemManager { get; }

    public void Execute()
    {
        FileSystemManager.FileSystem?.Move(_path);
    }
}