using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayDriver : IDisplayDriver
{
    private ConsoleColor _consoleColor;
    private Message? _message;
    public DisplayDriver()
    {
    }

    public void SetMessage(Message message)
    {
        _message = message;
    }

    public void ShowMessage()
    {
        ArgumentNullException.ThrowIfNull(_message);
        Console.ForegroundColor = _consoleColor;
        string stringMessage = $"Header: {_message.Header} | Body: {_message.Body}";
        Console.WriteLine($"[Display] {stringMessage}");
        Console.ResetColor();
    }

    public void ClearDisplay()
    {
        _message = null;
        Console.Clear();
    }

    public void SetTextColor(ConsoleColor color)
    {
        _consoleColor = color;
    }
}