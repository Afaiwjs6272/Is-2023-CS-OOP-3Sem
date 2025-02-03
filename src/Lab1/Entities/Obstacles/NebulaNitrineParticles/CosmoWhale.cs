namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NebulaNitrineParticles;

public class CosmoWhale : INebulaNitrineParticlesObstacle
{
    public double Damage { get; } = double.MaxValue;
    public double DamageToHull => 0;
    public double DamageToDeflector => 0;
}