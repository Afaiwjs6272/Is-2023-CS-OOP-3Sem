using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FourthTest
{
    [Fact]
    public void SpaceshipInOrdinarySpace()
    {
        var valkas = new Vaklas(null);
        var pleasureShuttle = new PleasureShuttle();

        var route = new Route(
            new List<PathSegment>
            {
                new(new OrdinarySpace(), 10),
            });

        var spaceSimulatorService = new SpaceSimulatorService(new List<Spaceship> { valkas, pleasureShuttle }, route);
        var simulationResults = spaceSimulatorService.RunSimulation().ToList();

        Assert.Equal(SpaceSimulatorService.MostValueSpaceship(simulationResults), pleasureShuttle);
    }
}