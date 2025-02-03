using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public class Meredian : Spaceship
{
    private const double MeredianFuelToStart = 2;
    private const double MeredianFuel = 100;
    public Meredian(PhotonDeflector? photonDeflector)
        : base(new ImpulseEngineE(MeredianFuel, MeredianFuelToStart), new HullClassB())
    {
        AntiNitrineEmitter = true;
        JumpEngine = null;
        Deflector = new DeflectorB(photonDeflector);
    }
}