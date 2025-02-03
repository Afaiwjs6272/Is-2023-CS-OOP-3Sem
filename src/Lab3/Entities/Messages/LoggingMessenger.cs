using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class LoggingMessenger : IMessenger
{
    private readonly IMessenger _wrappedMessenger;
    private readonly ILogger _logger;

    public LoggingMessenger(IMessenger wrappedMessenger, ILogger logger)
    {
        _wrappedMessenger = wrappedMessenger;
        _logger = logger;
    }

    public IReadOnlyCollection<Message> Messages => _wrappedMessenger.Messages;

    public void SendMessage(Message message)
    {
        _wrappedMessenger.SendMessage(message);
        _logger.Log("Message sent to messenger");
    }
}