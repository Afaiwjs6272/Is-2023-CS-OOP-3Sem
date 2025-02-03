using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public class PleasureShuttle : Spaceship
{
    private const double PleasureShuttleFuelToStart = 2;
    private const double PleasureShuttleFuel = 100;

    public PleasureShuttle()
        : base(new ImpulseEngineC(PleasureShuttleFuel, PleasureShuttleFuelToStart), new HullClassA())
    {
        AntiNitrineEmitter = false;
        JumpEngine = null;
        Deflector = null;
    }
}