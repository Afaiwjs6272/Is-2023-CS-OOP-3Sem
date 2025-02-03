using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Lab4.Console.ConsoleCommands.ConnectionCommands;

public class ConnectCommand : IConsoleCommand
{
    public ConnectCommand(FileSystemManager fileSystemManager, string path, string mode)
    {
        FileSystemManager = fileSystemManager;
        Path = path;
        Mode = mode;
    }

    public FileSystemManager FileSystemManager { get; }
    public string Path { get; }
    public string Mode { get; }

    public void Execute()
    {
        if (FileSystemManager.FileSystem != null)
        {
            throw new FileSystemException();
        }

        if (Mode == "local")
        {
            FileSystemManager.Connect(new LocalFileSystem(Path));
        }
    }
}