using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.OrdinarySpaceObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class OrdinarySpace : IEnvironment
{
    private readonly List<Asteroid> _asteroids = new();
    private readonly List<Meteorite> _meteorites = new();

    public OrdinarySpace()
    {
    }

    public OrdinarySpace(IEnumerable<Asteroid> asteroids, IEnumerable<Meteorite> meteorites)
    {
        _asteroids = asteroids.ToList();
        _meteorites = meteorites.ToList();
    }

    public IReadOnlyCollection<Asteroid> Asteroids => _asteroids;

    public IReadOnlyCollection<Meteorite> Meteorites => _meteorites;

    public void AddAsteroids(IEnumerable<Asteroid> asteroids)
    {
        _asteroids.AddRange(asteroids);
    }

    public void AddAsteroids(IEnumerable<Meteorite> meteorites)
    {
        _meteorites.AddRange(meteorites);
    }

    public PassingResult MakeFlight(Spaceship spaceship, double length)
    {
        if (spaceship == null)
        {
            throw SpaceSimulationException.NullArgumentException("Spaceship");
        }

        foreach (Asteroid asteroid in _asteroids)
        {
            spaceship.DoCollision(asteroid);
        }

        foreach (Meteorite meteorite in _meteorites)
        {
            spaceship.DoCollision(meteorite);
        }

        if (spaceship.CheckSpaceshipState() == PassingResult.Success)
        {
            spaceship.ImpulseEngine.SpendFuel(length);
        }

        return spaceship.CheckSpaceshipState();
    }
}