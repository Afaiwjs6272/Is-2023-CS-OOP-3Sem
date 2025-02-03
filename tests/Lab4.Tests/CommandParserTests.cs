using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Lab4.Console;
using Lab4.Console.ConsoleCommands;
using Lab4.Console.ConsoleCommands.ConnectionCommands;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandParserTests
{
    [Fact]
    public void ParseCommandThrowsFileSystemExceptionWhenNoArgs()
    {
        // Arrange
        var fileSystemManager = new FileSystemManager();
        var commandParser = new CommandParser(fileSystemManager);

        // Act & Assert
        Assert.Throws<FileSystemException>(() => commandParser.ParseCommand(Array.Empty<string>()));
    }

    [Fact]
    public void ParseConnectCommandReturnsConnectCommandWhenValidArgs()
    {
        // Arrange
        var fileSystemManager = new FileSystemManager();
        var commandParser = new CommandParser(fileSystemManager);
        string[] args = { "connect", "example.com", "some-options", "mode" };

        // Act
        IConsoleCommand result = commandParser.ParseConnectCommand(args);

        // Assert
        Assert.IsType<ConnectCommand>(result);
    }

    [Fact]
    public void ParseConnectCommandThrowsFileSystemExceptionWhenInsufficientArgs()
    {
        // Arrange
        var fileSystemManager = new FileSystemManager();
        var commandParser = new CommandParser(fileSystemManager);
        string[] args = { "connect", "example.com", "some-options" };

        // Act & Assert
        Assert.Throws<FileSystemException>(() => commandParser.ParseConnectCommand(args));
    }
}