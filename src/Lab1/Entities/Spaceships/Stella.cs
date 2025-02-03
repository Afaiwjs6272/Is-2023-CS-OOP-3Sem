using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public class Stella : Spaceship
{
    private const double StellaFuelToStart = 2;
    private const double StellaFuel = 100;
    private const double StellaJumpEngineFuel = 100;
    public Stella(PhotonDeflector? photonDeflector)
        : base(new ImpulseEngineC(StellaFuel, StellaFuelToStart), new HullClassA())
    {
        AntiNitrineEmitter = false;
        JumpEngine = new JumpEngineOmega(StellaJumpEngineFuel);
        Deflector = new DeflectorA(photonDeflector);
    }
}