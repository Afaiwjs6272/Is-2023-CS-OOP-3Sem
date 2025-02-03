using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NebulaIncreasedDensityObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NebulaIncreasedDensity : IEnvironment
{
    private readonly List<INebulaIncreasedDensityObstacle> _antimatterFlares = new();

    public NebulaIncreasedDensity()
    {
    }

    public NebulaIncreasedDensity(IEnumerable<INebulaIncreasedDensityObstacle> antimatterFlares)
    {
        _antimatterFlares = antimatterFlares.ToList();
    }

    public IReadOnlyCollection<INebulaIncreasedDensityObstacle> AntimatterFlares => _antimatterFlares;

    public void AddAntimatterFlares(IEnumerable<INebulaIncreasedDensityObstacle> asteroids)
    {
        _antimatterFlares.AddRange(asteroids);
    }

    public PassingResult MakeFlight(Spaceship spaceship, double length)
    {
        if (spaceship == null)
        {
            throw SpaceSimulationException.NullArgumentException("Spaceship");
        }

        if (spaceship.JumpEngine == null)
        {
            return PassingResult.SpaceshipLost;
        }

        foreach (INebulaIncreasedDensityObstacle antimatterFlare in _antimatterFlares)
        {
            spaceship.DoCollision(antimatterFlare);
        }

        spaceship.JumpEngine.SpendFuel(length);

        return spaceship.CheckSpaceshipState();
    }
}