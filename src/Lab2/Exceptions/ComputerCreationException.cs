using System;
using System.Runtime.Serialization;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ComputerCreationException : Exception
{
    public ComputerCreationException()
    {
    }

    public ComputerCreationException(string? message)
        : base(message)
    {
    }

    public ComputerCreationException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected ComputerCreationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}