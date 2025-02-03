using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.OrdinarySpaceObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SeventhTest
{
    [Fact]
    public void SpaceshipInNebulaNitrineParticles()
    {
        var pleasureShuttle = new PleasureShuttle();
        var vaklas = new Vaklas(null);
        var meredian = new Meredian(null);

        var route = new Route(
            new List<PathSegment>
            {
                new(new OrdinarySpace(new List<Asteroid> { new(), new() }, new List<Meteorite>()), 2),
                new(new NebulaNitrineParticles(), 2),
            });

        var spaceSimulatorService =
            new SpaceSimulatorService(new List<Spaceship> { pleasureShuttle, vaklas, meredian }, route);
        var simulationResults = spaceSimulatorService.RunSimulation().ToList();

        Assert.Equal(SpaceSimulatorService.MostValueSpaceship(simulationResults), pleasureShuttle);
    }
}