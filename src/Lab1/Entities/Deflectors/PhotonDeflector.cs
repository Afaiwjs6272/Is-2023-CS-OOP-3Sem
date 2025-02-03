using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NebulaIncreasedDensityObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflector
{
    public double Armor { get; private set; } = 150;

    public void DoCollision(INebulaIncreasedDensityObstacle antimatterFlare)
    {
        if (antimatterFlare == null)
        {
            throw SpaceSimulationException.NullArgumentException("spaceObject");
        }

        Armor -= antimatterFlare.Damage;
    }

    public void DestroyArmor()
    {
        Armor = 0;
    }
}