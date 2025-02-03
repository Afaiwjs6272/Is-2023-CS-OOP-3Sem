using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class SimulationResult
{
    public SimulationResult(Spaceship spaceship, PassingResult passingResult)
    {
        Spaceship = spaceship;
        PassingResult = passingResult;
    }

    public Spaceship Spaceship { get; }
    public PassingResult PassingResult { get; }
}