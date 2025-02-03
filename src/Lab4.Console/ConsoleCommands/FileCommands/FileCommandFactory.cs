using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Lab4.Console.ConsoleCommands.FileCommands;

public static class FileCommandFactory
{
    public static IConsoleCommand ParseFileShowCommand(string[] args, FileSystemManager fileSystemManager)
    {
        if (args.Length < 1)
        {
            throw new FileSystemException();
        }

        string path = args[1];

        return new FileShowCommand(path, fileSystemManager);
    }

    public static IConsoleCommand ParseFileMoveCommand(string[] args, FileSystemManager fileSystemManager)
    {
        if (args.Length < 2)
        {
            throw new FileSystemException();
        }

        string sourcePath = args[1];
        string destinationPath = args[2];

        return new FileMoveCommand(sourcePath, destinationPath, fileSystemManager);
    }

    public static IConsoleCommand ParseFileCopyCommand(string[] args, FileSystemManager fileSystemManager)
    {
        if (args.Length < 2)
        {
            throw new FileSystemException();
        }

        string sourcePath = args[1];
        string destinationPath = args[2];

        return new FileCopyCommand(sourcePath, destinationPath, fileSystemManager);
    }

    public static IConsoleCommand ParseFileDeleteCommand(string[] args, FileSystemManager fileSystemManager)
    {
        if (args.Length < 2)
        {
            throw new FileSystemException();
        }

        string path = args[1];

        return new FileDeleteCommand(path, fileSystemManager);
    }

    public static IConsoleCommand ParseFileRenameCommand(string[] args, FileSystemManager fileSystemManager)
    {
        if (args.Length < 2)
        {
            throw new FileSystemException();
        }

        string sourcePath = args[1];
        string newName = args[2];

        return new FileRenameCommand(sourcePath, newName, fileSystemManager);
    }
}