using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface IMessengerService
{
    Topic CreateTopic(string name, IRecipient recipient);
    Message.MessageBuilder CreateMessageBuilder();
    User CreateUser(string username, int corporativeCode);
    UserRecipient CreateUserRecipient(User user);
    GroupRecipient CreateGroupRecipient();
    DisplayRecipient CreateDisplayRecipient(Display display);

    Messenger CreateMessenger();
}