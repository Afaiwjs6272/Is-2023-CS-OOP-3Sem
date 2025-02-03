using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Lab4.Console.ConsoleCommands;
using Lab4.Console.ConsoleCommands.ConnectionCommands;
using static Lab4.Console.ConsoleCommands.FileCommands.FileCommandFactory;
using static Lab4.Console.ConsoleCommands.TreeCommands.TreeCommandFactory;

namespace Lab4.Console;

public class CommandParser
{
    private readonly Dictionary<string, Func<string[], IConsoleCommand>> _commandFactories;

    public CommandParser(FileSystemManager fileSystemManager)
    {
        FileSystemManager = fileSystemManager;
        _commandFactories = new Dictionary<string, Func<string[], IConsoleCommand>>
        {
            { "connect", ParseConnectCommand },
            { "disconnect", ParseDisconnectCommand },
            { "tree", ParseTreeCommand },
            { "file", ParseFileCommand },
        };
    }

    public FileSystemManager FileSystemManager { get; }

    public IConsoleCommand ParseCommand(string[] commandArgs)
    {
        if (commandArgs.Length == 0)
        {
            throw new FileSystemException();
        }

        if (FileSystemManager.FileSystem == null && commandArgs[0] != "connect")
        {
            throw new FileSystemException();
        }

        string commandName = commandArgs[0].ToLower(System.Globalization.CultureInfo.CurrentCulture);

        return _commandFactories.TryGetValue(commandName, out Func<string[], IConsoleCommand>? commandFactory)
            ? commandFactory.Invoke(commandArgs)
            : throw new FileSystemException();
    }

    public IConsoleCommand ParseConnectCommand(string[] args)
    {
        if (args.Length < 4)
        {
            throw new FileSystemException();
        }

        string address = args[1];
        string mode = args[3];

        return new ConnectCommand(FileSystemManager, address, mode);
    }

    public IConsoleCommand ParseDisconnectCommand(string[] args)
    {
        if (FileSystemManager.FileSystem == null)
        {
            throw new FileSystemException();
        }

        return new DisconnectCommand(FileSystemManager);
    }

    public IConsoleCommand ParseTreeCommand(string[] args)
    {
        if (args.Length < 2)
        {
            throw new FileSystemException();
        }

        string commandName = args[1].ToLower(System.Globalization.CultureInfo.CurrentCulture);
        string[] commandArgs = args.Skip(2).ToArray();

        return commandName switch
        {
            "goto" => ParseTreeGotoCommand(commandArgs, FileSystemManager),
            "list" => ParseTreeListCommand(commandArgs, FileSystemManager),
            _ => throw new FileSystemException(),
        };
    }

    public IConsoleCommand ParseFileCommand(string[] args)
    {
        if (args.Length < 2)
        {
            throw new FileSystemException();
        }

        string[] commandArgs = args.Skip(1).ToArray();
        string commandName = args[1].ToLower(System.Globalization.CultureInfo.CurrentCulture);

        return commandName switch
        {
            "show" => ParseFileShowCommand(commandArgs, FileSystemManager),
            "move" => ParseFileMoveCommand(commandArgs, FileSystemManager),
            "copy" => ParseFileCopyCommand(commandArgs, FileSystemManager),
            "delete" => ParseFileDeleteCommand(commandArgs, FileSystemManager),
            "rename" => ParseFileRenameCommand(commandArgs, FileSystemManager),
            _ => throw new FileSystemException(),
        };
    }
}