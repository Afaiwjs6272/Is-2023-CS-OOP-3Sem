using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector
{
    public PhotonDeflector? PhotonDeflector { get; protected set; }
    public double Armor { get; protected set; }

    public bool IsArmorIntact()
    {
        return Armor > 0;
    }

    public void DoCollision(ISpaceObject spaceObject)
    {
        if (spaceObject == null)
        {
            throw SpaceSimulationException.NullArgumentException("spaceObject");
        }

        Armor -= spaceObject.DamageToDeflector;
    }

    public void DestroyArmor()
    {
        PhotonDeflector?.DestroyArmor();
        Armor = 0;
    }
}