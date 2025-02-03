namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NebulaIncreasedDensityObstacles;

public class AntimatterFlare : INebulaIncreasedDensityObstacle
{
    public double Damage { get; } = 50;
    public double DamageToHull => 0;
    public double DamageToDeflector => 0;
}