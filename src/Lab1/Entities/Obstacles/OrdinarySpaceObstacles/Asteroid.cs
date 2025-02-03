namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.OrdinarySpaceObstacles;

public class Asteroid : IOrdinarySpaceObstacle
{
    public double DamageToHull => 10;
    public double DamageToDeflector => 10;
}