using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display
{
    private readonly DisplayDriver _displayDriver = new();

    public void SetColor(ConsoleColor color)
    {
        _displayDriver.SetTextColor(color);
    }

    public void SetMessage(Message message)
    {
        _displayDriver.SetMessage(message);
    }

    public void ShowMessage()
    {
        _displayDriver.ShowMessage();
    }
}