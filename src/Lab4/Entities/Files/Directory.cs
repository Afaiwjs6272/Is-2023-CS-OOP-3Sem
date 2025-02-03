using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;

public class Directory : IFileSystemItem
{
    private readonly List<IFileSystemItem> _items = new();

    public Directory(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemItem> Items => _items;

    public void AddItem(IFileSystemItem item)
    {
        _items.Add(item);
    }
}