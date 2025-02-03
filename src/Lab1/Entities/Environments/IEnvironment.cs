using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public interface IEnvironment
{
    public PassingResult MakeFlight(Spaceship spaceship, double length);
}