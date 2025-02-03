using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class PathSegment
{
    public PathSegment(IEnvironment environment, double distance)
    {
        Environment = environment;
        Distance = distance;
    }

    public IEnvironment Environment { get; }
    public double Distance { get; }
}