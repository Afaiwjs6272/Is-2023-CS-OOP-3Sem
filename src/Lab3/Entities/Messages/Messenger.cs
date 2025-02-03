using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Messenger : IMessenger
{
    private readonly List<Message> _messages = new();

    public IReadOnlyCollection<Message> Messages => _messages;

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messages.Add(message);
    }
}