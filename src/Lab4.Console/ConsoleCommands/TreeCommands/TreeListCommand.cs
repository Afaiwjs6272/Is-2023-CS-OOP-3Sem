using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using static System.Console;

namespace Lab4.Console.ConsoleCommands.TreeCommands;

public class TreeListCommand : IConsoleCommand
{
    private readonly int _depth = 1;

    public TreeListCommand(FileSystemManager fileSystemManager)
    {
        FileSystemManager = fileSystemManager;
    }

    public TreeListCommand(int depth, FileSystemManager fileSystemManager)
    {
        _depth = depth;
        FileSystemManager = fileSystemManager;
    }

    public FileSystemManager FileSystemManager { get; }

    public void Execute()
    {
        if (FileSystemManager.FileSystem is null)
        {
            throw new FileSystemException();
        }

        WriteLine($"System tree (Depth: {_depth})");
        PrintDirectory(FileSystemManager.FileSystem.CurrentPath, 0);
    }

    private void PrintDirectory(string path, int currentDepth)
    {
        if (currentDepth > _depth)
        {
            return;
        }

        if (FileSystemManager.FileSystem is null)
        {
            throw new FileSystemException();
        }

        var directoryContents = FileSystemManager.FileSystem.GetDirectoryContents(path).ToList();

        for (int i = 0; i < directoryContents.Count; i++)
        {
            string itemName = Path.GetFileName(directoryContents.ElementAt(i));
            string branch = i == directoryContents.Count - 1 ? "└──" : "├──";
            string indentation = new(' ', currentDepth * 4);

            WriteLine($"{indentation}{branch} {itemName}");

            if (Directory.Exists(directoryContents.ElementAt(i)))
            {
                PrintDirectory(directoryContents.ElementAt(i), currentDepth + 1);
            }
        }
    }
}