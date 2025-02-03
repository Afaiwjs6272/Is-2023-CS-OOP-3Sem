using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void UserShouldReceiveUnreadMessage()
    {
        var service = new MessengerService(new ConsoleLogger());

        User user = service.CreateUser("John", 123);
        Message message = service.CreateMessageBuilder()
            .WithHeader("Test")
            .WithBody("Test Body")
            .WithImportance(ImportanceLevel.Low)
            .Build();

        user.SendMessage(message);

        Assert.Equal(MessageStatus.NotRead, user.GetMessageStatus(message));
    }

    [Fact]
    public void UserShouldMarkUnreadMessageAsRead()
    {
        var service = new MessengerService(new ConsoleLogger());

        User user = service.CreateUser("John", 123);
        Message message = service.CreateMessageBuilder()
            .WithHeader("Test")
            .WithBody("Test Body")
            .WithImportance(ImportanceLevel.Low)
            .Build();

        user.SendMessage(message);
        user.MarkMessageAsRead(message);

        Assert.Equal(MessageStatus.Read, user.GetMessageStatus(message));
    }

    [Fact]
    public void UserShouldNotMarkReadMessageAsReadAgain()
    {
        var service = new MessengerService(new ConsoleLogger());

        User user = service.CreateUser("John", 123);
        Message message = service.CreateMessageBuilder()
            .WithHeader("Test")
            .WithBody("Test Body")
            .WithImportance(ImportanceLevel.Low)
            .Build();

        user.SendMessage(message);
        user.MarkMessageAsRead(message);

        Assert.Throws<MessengerException>(() => user.MarkMessageAsRead(message));
    }

    [Fact]
    public void MessageShouldNotReachRecipientWithInappropriateImportanceFilter()
    {
        var service = new MessengerService(new ConsoleLogger());

        User user = service.CreateUser("John", 123);
        UserRecipient userRecipient = service.CreateUserRecipient(user);
        var filterRecipient = new ImportanceFilterRecipient(userRecipient, ImportanceLevel.High);
        Message message = service.CreateMessageBuilder()
            .WithHeader("Test")
            .WithBody("Test Body")
            .WithImportance(ImportanceLevel.Low)
            .Build();

        filterRecipient.Receive(message);

        Assert.Empty(user.Messages);
    }

    [Fact]
    public void LoggerShouldBeCalledOnceForInappropriateImportanceFilter()
    {
        // Создаем заглушку для логгера
        var loggerMock = new Mock<ILogger>();

        var service = new MessengerService(loggerMock.Object);

        User user = service.CreateUser("John", 123);
        UserRecipient userRecipient = service.CreateUserRecipient(user);

        var filterRecipient = new LoggerRecipient(new ImportanceFilterRecipient(userRecipient, ImportanceLevel.High), loggerMock.Object);

        Message message = service.CreateMessageBuilder()
            .WithHeader("Test")
            .WithBody("Test Body")
            .WithImportance(ImportanceLevel.Low)
            .Build();

        filterRecipient.Receive(message);

        loggerMock.Verify(logger => logger.Log(It.IsAny<string>()), Times.Once);
        Assert.Empty(user.Messages);
    }

    [Fact]
    public void MessengerShouldSendExpectedMessage()
    {
        var mockLogger = new Mock<ILogger>();
        var messengerService = new MessengerService(mockLogger.Object);
        Messenger messenger = messengerService.CreateMessenger();

        Message message = messengerService.CreateMessageBuilder()
            .WithHeader("Test")
            .WithBody("Test Body")
            .WithImportance(ImportanceLevel.Low)
            .Build();

        messenger.SendMessage(message);

        mockLogger.Verify(logger => logger.Log("Message sent to messenger"), Times.Never);
    }
}
