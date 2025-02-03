using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new FileSystemException($"The directory '{path}' does not exist.");
        }

        CurrentPath = path;
    }

    public string CurrentPath { get; private set; }

    public static string NormalizePath(string path)
    {
        return Path.GetFullPath(new Uri(path).LocalPath)
            .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
    }

    public void Move(string path)
    {
        string newPath;

        switch (path)
        {
            case ".":
                newPath = CurrentPath;
                break;
            case "..":
            {
                string? parentDirectory = Path.GetDirectoryName(CurrentPath);
                newPath = parentDirectory ?? CurrentPath;
                break;
            }

            default:
                newPath = NormalizePath(Path.Combine(CurrentPath, path));
                break;
        }

        if (!Directory.Exists(newPath))
        {
            throw new FileSystemException($"The directory '{newPath}' does not exist.");
        }

        CurrentPath = newPath;
    }

    public void CreateDirectory(string path)
    {
        string absolutePath = GetAbsolutePath(path);

        if (!Directory.Exists(absolutePath))
        {
            Directory.CreateDirectory(absolutePath);
        }
        else
        {
            throw new FileSystemException($"The directory '{absolutePath}' already exists.");
        }
    }

    public void CreateFile(string path)
    {
        string absolutePath = GetAbsolutePath(path);

        if (!File.Exists(absolutePath))
        {
            File.Create(absolutePath).Close();
        }
        else
        {
            throw new FileSystemException($"The file '{absolutePath}' already exists.");
        }
    }

    public IEnumerable<string> GetDirectoryContents(string path)
    {
        string absolutePath = GetAbsolutePath(path);

        if (Directory.Exists(absolutePath))
        {
            return Directory.EnumerateFileSystemEntries(absolutePath);
        }
        else
        {
            throw new FileSystemException($"The directory '{absolutePath}' does not exist.");
        }
    }

    public string ReadFile(string path)
    {
        string absolutePath = GetAbsolutePath(path);

        if (File.Exists(absolutePath))
        {
            return File.ReadAllText(absolutePath);
        }

        throw new FileSystemException($"The file '{absolutePath}' does not exist.");
    }

    public void WriteFile(string path, string content)
    {
        string absolutePath = GetAbsolutePath(path);

        File.WriteAllText(absolutePath, content);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        string sourceAbsolutePath = GetAbsolutePath(sourcePath);
        string destAbsolutePath = GetAbsolutePath(destinationPath);

        if (!File.Exists(sourceAbsolutePath))
        {
            throw new FileSystemException($"Source file '{sourceAbsolutePath}' does not exist.");
        }

        string? destDirectory = GetDirectoryName(destAbsolutePath);
        if (destDirectory is not null)
        {
            if (!Directory.Exists(destDirectory))
            {
                throw new FileSystemException($"Destination directory '{destDirectory}' does not exist.");
            }

            string destFilePath = Path.Combine(destAbsolutePath, Path.GetFileName(sourceAbsolutePath));
            File.Move(sourceAbsolutePath, destFilePath);
        }
        else
        {
            throw new FileSystemException($"Invalid destination path '{destinationPath}'.");
        }
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        string sourceAbsolutePath = GetAbsolutePath(sourcePath);
        string destAbsolutePath = GetAbsolutePath(destinationPath);

        if (!File.Exists(sourceAbsolutePath))
        {
            throw new FileSystemException($"Source file '{sourceAbsolutePath}' does not exist.");
        }

        string? destDirectory = GetDirectoryName(destAbsolutePath);
        if (destDirectory is not null)
        {
            if (!Directory.Exists(destDirectory))
            {
                throw new FileSystemException($"Destination directory '{destDirectory}' does not exist.");
            }

            string destFilePath = Path.Combine(destAbsolutePath, Path.GetFileName(sourceAbsolutePath));
            File.Copy(sourceAbsolutePath, destFilePath);
        }
        else
        {
            throw new FileSystemException($"Invalid destination path '{destinationPath}'.");
        }
    }

    public void DeleteFile(string path)
    {
        string absolutePath = GetAbsolutePath(path);

        if (!File.Exists(absolutePath))
        {
            throw new FileSystemException($"File '{absolutePath}' does not exist.");
        }

        File.Delete(absolutePath);
    }

    public void RenameFile(string path, string newName)
    {
        string sourceAbsolutePath = GetAbsolutePath(path);
        string destAbsolutePath = GetAbsolutePath(
            Path.Combine(GetDirectoryName(sourceAbsolutePath) ?? throw new FileSystemException(), newName));

        if (!File.Exists(sourceAbsolutePath))
        {
            throw new FileSystemException($"Source file '{sourceAbsolutePath}' does not exist.");
        }

        File.Move(sourceAbsolutePath, destAbsolutePath);
    }

    public bool FileExists(string path)
    {
        string absolutePath = GetAbsolutePath(path);
        return File.Exists(absolutePath);
    }

    public bool DirectoryExists(string path)
    {
        string absolutePath = GetAbsolutePath(path);
        return Directory.Exists(absolutePath);
    }

    public string? GetDirectoryName(string path)
    {
        string absolutePath = GetAbsolutePath(path);
        return Path.GetDirectoryName(absolutePath);
    }

    public string GetAbsolutePath(string path)
    {
        return Path.IsPathRooted(path) ? path : Path.Combine(CurrentPath, path);
    }
}