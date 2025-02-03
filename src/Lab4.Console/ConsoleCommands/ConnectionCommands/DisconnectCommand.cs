using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Lab4.Console.ConsoleCommands.ConnectionCommands;

public class DisconnectCommand : IConsoleCommand
{
    public DisconnectCommand(FileSystemManager fileSystemManager)
    {
        FileSystemManager = fileSystemManager;
    }

    public FileSystemManager FileSystemManager { get; }

    public void Execute()
    {
        FileSystemManager.Disconnect();
    }
}