using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NebulaNitrineParticles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NebulaNitrineParticles : IEnvironment
{
    private readonly List<INebulaNitrineParticlesObstacle> _cosmoWhales = new();

    public NebulaNitrineParticles()
    {
    }

    public NebulaNitrineParticles(IEnumerable<INebulaNitrineParticlesObstacle> cosmoWhales)
    {
        _cosmoWhales = cosmoWhales.ToList();
    }

    public IReadOnlyCollection<INebulaNitrineParticlesObstacle> CosmoWhales => _cosmoWhales;

    public void AddCosmoWhales(IEnumerable<INebulaNitrineParticlesObstacle> cosmoWhales)
    {
        _cosmoWhales.AddRange(cosmoWhales);
    }

    public PassingResult MakeFlight(Spaceship spaceship, double length)
    {
        if (spaceship == null)
        {
            throw SpaceSimulationException.NullArgumentException("Spaceship");
        }

        foreach (INebulaNitrineParticlesObstacle cosmoWhale in _cosmoWhales)
        {
            spaceship.DoCollision(cosmoWhale);
        }

        spaceship.ImpulseEngine.SpendFuel(length);

        return spaceship.CheckSpaceshipState();
    }
}