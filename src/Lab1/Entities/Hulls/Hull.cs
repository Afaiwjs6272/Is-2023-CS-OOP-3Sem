using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

public abstract class Hull
{
    public double Armor { get; protected set; }

    public void DoCollision(ISpaceObject spaceObject)
    {
        if (spaceObject == null)
        {
            throw SpaceSimulationException.NullArgumentException("spaceObject");
        }

        Armor -= spaceObject.DamageToHull;
    }

    public bool IsArmorIntact()
    {
        return Armor > 0;
    }
}