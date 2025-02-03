using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public class Augur : Spaceship
{
    private const double AugurFuelToStart = 2;
    private const double AugurFuel = 100;
    private const double AugurJumpEngineFuel = 1;

    public Augur(PhotonDeflector? photonDeflector)
        : base(new ImpulseEngineE(AugurFuel, AugurFuelToStart), new HullClassB())
    {
        AntiNitrineEmitter = false;
        JumpEngine = new JumpEngineAlpha(AugurJumpEngineFuel);
        Deflector = new DeflectorC(photonDeflector);
    }
}