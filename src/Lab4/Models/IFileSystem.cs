using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public interface IFileSystem
{
    string CurrentPath { get; }
    void Move(string path);
    void CreateDirectory(string path);
    void CreateFile(string path);
    IEnumerable<string> GetDirectoryContents(string path);
    string ReadFile(string path);
    void WriteFile(string path, string content);
    void MoveFile(string sourcePath, string destinationPath);
    void CopyFile(string sourcePath, string destinationPath);
    void DeleteFile(string path);
    void RenameFile(string path, string newName);
    bool FileExists(string path);
    bool DirectoryExists(string path);
    string GetAbsolutePath(string path);
    string? GetDirectoryName(string path);
}