using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Route
{
    private readonly List<PathSegment> _pathSegments;

    public Route(IEnumerable<PathSegment> pathSegments)
    {
        _pathSegments = pathSegments.ToList();
    }

    public IReadOnlyCollection<PathSegment> PathSegments => _pathSegments;

    public void AddSegments(IEnumerable<PathSegment> pathSegments)
    {
        _pathSegments.AddRange(pathSegments);
    }

    public SimulationResult MakeFlight(Spaceship spaceship)
    {
        if (spaceship == null)
        {
            throw SpaceSimulationException.NullArgumentException("Spaceship");
        }

        foreach (PathSegment pathSegment in _pathSegments)
        {
            spaceship.MakeFlight(pathSegment);
            PassingResult state = spaceship.CheckSpaceshipState();
            if (state != PassingResult.Success)
            {
                return new SimulationResult(spaceship, state);
            }
        }

        return new SimulationResult(spaceship, PassingResult.Success);
    }
}