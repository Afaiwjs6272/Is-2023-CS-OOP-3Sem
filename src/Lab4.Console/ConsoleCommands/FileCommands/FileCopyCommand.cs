using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using static System.Console;

namespace Lab4.Console.ConsoleCommands.FileCommands;

public class FileCopyCommand : IConsoleCommand
{
    public FileCopyCommand(string sourcePath, string destPath, FileSystemManager fileSystemManager)
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
            FileSystemManager.FileSystem?.CopyFile(SourcePath, DestPath);
            WriteLine($"File '{SourcePath}' copied to '{DestPath}'.");
        }
        catch (FileSystemException ex)
        {
            WriteLine($"Error: {ex.Message}");
        }
    }
}