using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class DisplayRecipient : IRecipient
{
    private readonly Display _display;
    public DisplayRecipient(Display display)
    {
        _display = display;
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _display.SetMessage(message);
    }
}