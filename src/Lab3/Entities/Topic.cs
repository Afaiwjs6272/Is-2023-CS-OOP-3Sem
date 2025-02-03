using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    public Topic(string name, IRecipient recipient)
    {
        Name = name;
        Recipient = recipient;
    }

    public string Name { get; }
    public IRecipient Recipient { get; }

    public void SendMessage(Message message)
    {
        Recipient.Receive(message);
    }
}