namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;

public class JumpEngineGamma : JumpEngine
{
    public JumpEngineGamma(double fuel)
        : base(fuel)
    {
    }

    public override void SpendFuel(double distance)
    {
        Fuel -= distance * distance * 0.1;
    }
}