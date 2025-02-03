using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class ImportanceFilterRecipient : IRecipient
{
    private readonly IRecipient _wrappedRecipient;
    private readonly ImportanceLevel _importanceLevel;

    public ImportanceFilterRecipient(IRecipient wrappedRecipient, ImportanceLevel importanceLevel)
    {
        _wrappedRecipient = wrappedRecipient;
        _importanceLevel = importanceLevel;
    }

    public void Receive(Message message)
    {
        if (message.Importance >= _importanceLevel)
        {
            _wrappedRecipient.Receive(message);
        }
    }
}