using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class FileSystemManager
{
    public IFileSystem? FileSystem { get; private set; }

    public void Connect(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void Disconnect()
    {
        FileSystem = null;
    }
}