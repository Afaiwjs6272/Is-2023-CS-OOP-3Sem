using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class LoggerRecipient : IRecipient
{
    private readonly IRecipient _wrappedRecipient;
    private readonly ILogger _logger;

    public LoggerRecipient(IRecipient wrappedRecipient, ILogger logger)
    {
        _wrappedRecipient = wrappedRecipient ?? throw new ArgumentNullException(nameof(wrappedRecipient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Receive(Message message)
    {
        _wrappedRecipient.Receive(message);
        _logger.Log("Message added to recipient");
    }
}