using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public class Vaklas : Spaceship
{
    private const double VaklasFuelToStart = 2;
    private const double VaklasFuel = 100;
    private const double VaklasJumpEngineFuel = 100;

    public Vaklas(PhotonDeflector? photonDeflector)
        : base(new ImpulseEngineE(VaklasFuel, VaklasFuelToStart), new HullClassB())
    {
        AntiNitrineEmitter = false;
        JumpEngine = new JumpEngineGamma(VaklasJumpEngineFuel);
        Deflector = new DeflectorA(photonDeflector);
    }
}