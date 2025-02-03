using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTest
{
    public static IEnumerable<object[]> GetSpaceships
    {
        get
        {
            yield return new object[] { new PleasureShuttle() };
            yield return new object[] { new Vaklas(null) };
        }
    }

    [Theory]
    [MemberData(nameof(GetSpaceships))]
    public void SpaceshipInNebulaIncreasedDensity(Spaceship spaceship)
    {
        if (spaceship == null)
        {
            throw SpaceSimulationException.NullArgumentException("spaceship");
        }

        var route = new Route(
            new List<PathSegment>
            {
                new(new NebulaIncreasedDensity(), 100),
            });

        var spaceSimulatorService = new SpaceSimulatorService(new List<Spaceship> { spaceship }, route);
        var simulationResults = spaceSimulatorService.RunSimulation().ToList();

        foreach (SimulationResult simulationResult in simulationResults)
        {
            Assert.NotEqual(PassingResult.Success, simulationResult.PassingResult);
        }
    }
}