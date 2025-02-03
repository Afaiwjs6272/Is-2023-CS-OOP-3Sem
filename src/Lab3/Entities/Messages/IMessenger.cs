using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public interface IMessenger
{
    IReadOnlyCollection<Message> Messages { get; }
    void SendMessage(Message message);
}
