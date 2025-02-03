using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Lab4.Console.ConsoleCommands.TreeCommands;

public static class TreeCommandFactory
{
    public static IConsoleCommand ParseTreeGotoCommand(string[] args, FileSystemManager fileSystemManager)
    {
        if (args.Length < 1)
        {
            throw new FileSystemException();
        }

        string path = args[0];

        return new TreeGotoCommand(path, fileSystemManager);
    }

    public static IConsoleCommand ParseTreeListCommand(string[] args, FileSystemManager fileSystemManager)
    {
        return args.Length < 2
            ? new TreeListCommand(fileSystemManager)
            : new TreeListCommand(Convert.ToInt32(args[1], CultureInfo.CurrentCulture), fileSystemManager);
    }
}