using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SixthTest
{
    [Fact]
    public void SpaceshipInNebulaNitrineParticles()
    {
        var pleasureShuttle = new PleasureShuttle();
        var vaklas = new Vaklas(null);

        var route = new Route(
            new List<PathSegment>
            {
                new(new NebulaNitrineParticles(), 10),
            });

        var spaceSimulatorService = new SpaceSimulatorService(new List<Spaceship> { pleasureShuttle, vaklas }, route);
        var simulationResults = spaceSimulatorService.RunSimulation().ToList();

        Assert.Equal(SpaceSimulatorService.MostValueSpaceship(simulationResults), pleasureShuttle);
    }
}