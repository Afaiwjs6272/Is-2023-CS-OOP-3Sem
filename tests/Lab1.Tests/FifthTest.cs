using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FifthTest
{
    [Fact]
    public void SpaceshipInNebulaIncreasedDensity()
    {
        var augur = new Augur(null);
        var stella = new Stella(null);

        var route = new Route(
            new List<PathSegment>
            {
                new(new NebulaIncreasedDensity(), 20),
            });

        var spaceSimulatorService = new SpaceSimulatorService(new List<Spaceship> { augur, stella }, route);
        var simulationResults = spaceSimulatorService.RunSimulation().ToList();

        Assert.Equal(SpaceSimulatorService.MostValueSpaceship(simulationResults), stella);
    }
}