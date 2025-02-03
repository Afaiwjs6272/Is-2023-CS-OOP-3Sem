using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients = new();

    public GroupRecipient()
    {
    }

    public void AddRecipients(IEnumerable<IRecipient> recipients)
    {
        _recipients.AddRange(recipients);
    }

    public void Receive(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.Receive(message);
        }
    }
}