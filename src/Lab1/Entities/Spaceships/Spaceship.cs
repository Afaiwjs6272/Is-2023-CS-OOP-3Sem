using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NebulaIncreasedDensityObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NebulaNitrineParticles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.OrdinarySpaceObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public abstract class Spaceship
{
    private PassingResult _currentState = PassingResult.Success;

    protected Spaceship(ImpulseEngine impulseEngine, Hull hull)
    {
        ImpulseEngine = impulseEngine;
        Hull = hull;
    }

    public ImpulseEngine ImpulseEngine { get; }
    public Hull Hull { get; }
    public bool AntiNitrineEmitter { get; protected set; }
    public JumpEngine? JumpEngine { get; protected set; }
    public Deflector? Deflector { get; protected set; }

    public PassingResult CheckSpaceshipState()
    {
        if (_currentState != PassingResult.Success)
        {
            return _currentState;
        }

        if (ImpulseEngine.Fuel < 0)
        {
            _currentState = PassingResult.FuelRanOut;
        }

        if (JumpEngine is { Fuel: < 0 })
        {
            _currentState = PassingResult.SpaceshipLost;
        }

        if (Hull is { Armor: < 0 })
        {
            _currentState = PassingResult.SpaceshipDestroyed;
        }

        return _currentState;
    }

    public void DoCollision(IOrdinarySpaceObstacle spaceObject)
    {
        if (spaceObject == null)
        {
            throw SpaceSimulationException.NullArgumentException("SpaceObject");
        }

        if (Deflector != null && Deflector.IsArmorIntact())
        {
            Deflector.DoCollision(spaceObject);
        }

        if (Hull.IsArmorIntact())
        {
            Hull.DoCollision(spaceObject);
        }
    }

    public void DoCollision(INebulaNitrineParticlesObstacle cosmoWhale)
    {
        if (cosmoWhale == null)
        {
            throw SpaceSimulationException.NullArgumentException("CosmoWhale");
        }

        if (AntiNitrineEmitter) return;

        if (IsDeflectorDestroyed())
        {
            _currentState = PassingResult.SpaceshipDestroyed;
        }
        else
        {
            Deflector?.DestroyArmor();
        }
    }

    public void DoCollision(INebulaIncreasedDensityObstacle antimatterFlare)
    {
        if (antimatterFlare == null)
        {
            throw SpaceSimulationException.NullArgumentException("AntimatterFlare");
        }

        if (IsPhotonDeflectorDestroyed())
        {
            _currentState = PassingResult.DeathOfTheCrew;
        }
        else
        {
            Deflector?.PhotonDeflector?.DoCollision(antimatterFlare);
        }
    }

    public void MakeFlight(PathSegment pathSegment)
    {
        if (pathSegment == null)
        {
            throw SpaceSimulationException.NullArgumentException("Path segment");
        }

        _currentState = pathSegment.Environment.MakeFlight(this, pathSegment.Distance);
    }

    private bool IsPhotonDeflectorDestroyed()
    {
        return Deflector?.PhotonDeflector == null || Deflector.PhotonDeflector.Armor < 0;
    }

    private bool IsDeflectorDestroyed()
    {
        return Deflector == null || Deflector.Armor < 0;
    }
}