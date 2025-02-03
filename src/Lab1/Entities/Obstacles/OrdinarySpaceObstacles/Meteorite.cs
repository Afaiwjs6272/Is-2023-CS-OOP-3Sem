namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.OrdinarySpaceObstacles;

public class Meteorite : IOrdinarySpaceObstacle
{
    public double DamageToHull => 40;
    public double DamageToDeflector => 25;
}