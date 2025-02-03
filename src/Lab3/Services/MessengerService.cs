using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class MessengerService : IMessengerService
{
    private readonly ILogger? _logger;

    public MessengerService()
    {
    }

    public MessengerService(ILogger logger)
    {
        _logger = logger;
    }

    public Topic CreateTopic(string name, IRecipient recipient)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(recipient);
        return new Topic(name, recipient);
    }

    public Message.MessageBuilder CreateMessageBuilder()
    {
        return new Message.MessageBuilder();
    }

    public User CreateUser(string username, int corporativeCode)
    {
        ArgumentNullException.ThrowIfNull(username);
        return new User(username, corporativeCode);
    }

    public UserRecipient CreateUserRecipient(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        return new UserRecipient(user);
    }

    public GroupRecipient CreateGroupRecipient()
    {
        return new GroupRecipient();
    }

    public DisplayRecipient CreateDisplayRecipient(Display display)
    {
        ArgumentNullException.ThrowIfNull(display);
        return new DisplayRecipient(display);
    }

    public Messenger CreateMessenger()
    {
        return new Messenger();
    }
}