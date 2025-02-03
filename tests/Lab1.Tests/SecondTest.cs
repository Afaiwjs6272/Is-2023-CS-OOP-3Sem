using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NebulaIncreasedDensityObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SecondTest
{
    public static IEnumerable<object[]> GetSpaceships
    {
        get
        {
            yield return new object[] { new Vaklas(null) };
            yield return new object[] { new Vaklas(new PhotonDeflector()) };
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
                new(new NebulaIncreasedDensity(new List<AntimatterFlare> { new() }), 10),
            });

        var spaceSimulatorService = new SpaceSimulatorService(new List<Spaceship> { spaceship }, route);
        var simulationResults = spaceSimulatorService.RunSimulation().ToList();

        foreach (SimulationResult simulationResult in simulationResults)
        {
            if (spaceship.Deflector?.PhotonDeflector != null)
            {
                Assert.Equal(PassingResult.Success, simulationResult.PassingResult);
            }
            else
            {
                Assert.NotEqual(PassingResult.Success, simulationResult.PassingResult);
            }
        }
    }
}