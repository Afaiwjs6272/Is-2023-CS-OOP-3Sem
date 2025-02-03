using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User
{
    private readonly Dictionary<Message, MessageStatus> _statusByMessage = new();

    public User(string username, int corporativeCode)
    {
        Username = username;
        CorporativeCode = corporativeCode;
    }

    public string Username { get; }
    public int CorporativeCode { get; }

    public IReadOnlyCollection<Message> Messages => _statusByMessage.Keys;

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _statusByMessage.Add(message, MessageStatus.NotRead);
    }

    public void MarkMessageAsRead(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (!_statusByMessage.TryGetValue(message, out MessageStatus value))
        {
            throw new MessengerException("user message not found");
        }

        if (value == MessageStatus.Read)
        {
            throw new MessengerException("Message already read");
        }

        _statusByMessage[message] = MessageStatus.Read;
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        return _statusByMessage[message];
    }
}