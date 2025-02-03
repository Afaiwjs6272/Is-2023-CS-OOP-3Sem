namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;

public class File : IFileSystemItem
{
    public File(string name)
    {
        Name = name;
    }

    public string Name { get; }
}