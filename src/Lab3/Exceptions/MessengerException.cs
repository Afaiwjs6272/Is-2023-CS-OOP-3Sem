using System;
using System.Runtime.Serialization;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessengerException : Exception
{
    public MessengerException()
    {
    }

    public MessengerException(string? message)
        : base(message)
    {
    }

    public MessengerException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected MessengerException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}