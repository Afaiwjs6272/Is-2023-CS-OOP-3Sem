namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;

public class JumpEngineAlpha : JumpEngine
{
    public JumpEngineAlpha(double fuel)
        : base(fuel)
    {
    }

    public override void SpendFuel(double distance)
    {
        Fuel -= distance * 0.1;
    }
}