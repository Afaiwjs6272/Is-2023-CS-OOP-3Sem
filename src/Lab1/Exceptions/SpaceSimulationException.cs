using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class SpaceSimulationException : Exception
{
    private SpaceSimulationException()
    {
    }

    private SpaceSimulationException(string? message)
        : base(message)
    {
    }

    private SpaceSimulationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static SpaceSimulationException NullArgumentException(string message)
    {
        return new SpaceSimulationException($"{message} object is null");
    }
}