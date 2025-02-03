using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using static System.Console;

namespace Lab4.Console.ConsoleCommands.FileCommands;

public class FileMoveCommand : IConsoleCommand
{
    public FileMoveCommand(string sourcePath, string destPath, FileSystemManager fileSystemManager)
    {
        SourcePath = sourcePath;
        FileSystemManager = fileSystemManager;
        DestPath = destPath;
    }

    public string SourcePath { get; }
    public string DestPath { get; }
    public FileSystemManager FileSystemManager { get; }

    public void Execute()
    {
        try
        {
            string sourceAbsolutePath = FileSystemManager.FileSystem?.GetAbsolutePath(SourcePath) ??
                                        throw new FileSystemException();
            string destAbsolutePath = FileSystemManager.FileSystem.GetAbsolutePath(DestPath);

            if (!FileSystemManager.FileSystem.FileExists(sourceAbsolutePath))
            {
                WriteLine($"Source file '{sourceAbsolutePath}' does not exist.");
                return;
            }

            string destDirectory = FileSystemManager.FileSystem.GetDirectoryName(destAbsolutePath) ??
                                   throw new FileSystemException("destination directory is null");

            if (!FileSystemManager.FileSystem.DirectoryExists(destDirectory))
            {
                WriteLine($"Destination directory '{destDirectory}' does not exist.");
                return;
            }

            FileSystemManager.FileSystem.MoveFile(sourceAbsolutePath, destAbsolutePath);
            WriteLine($"File '{sourceAbsolutePath}' moved to '{destAbsolutePath}'.");
        }
        catch (FileSystemException ex)
        {
            WriteLine($"Error: {ex.Message}");
        }
    }
}