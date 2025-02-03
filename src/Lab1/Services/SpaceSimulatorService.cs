using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class SpaceSimulatorService
{
    private readonly List<Spaceship> _spaceships;

    public SpaceSimulatorService(IEnumerable<Spaceship> spaceships, Route route)
    {
        _spaceships = spaceships.ToList();
        Route = route;
    }

    public IReadOnlyCollection<Spaceship> Spaceships => _spaceships;

    public Route Route { get; }

    public static Spaceship? MostValueSpaceship(IReadOnlyCollection<SimulationResult> results)
    {
        return results
            .Where(x => x.PassingResult == PassingResult.Success)
            .Select(x => x.Spaceship)
            .MinBy(x =>
            {
                if (x.JumpEngine != null)
                {
                    return (x.ImpulseEngine.MaxFuel - x.ImpulseEngine.Fuel) +
                           (x.JumpEngine.MaxFuel - x.JumpEngine.Fuel);
                }

                return x.ImpulseEngine.MaxFuel - x.ImpulseEngine.Fuel;
            });
    }

    public IReadOnlyCollection<SimulationResult> RunSimulation()
    {
        return _spaceships
            .Select(spaceship => Route.MakeFlight(spaceship))
            .ToList();
    }
}