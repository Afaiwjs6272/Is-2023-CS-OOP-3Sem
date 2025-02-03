namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public class ImpulseEngineC : ImpulseEngine
{
    public ImpulseEngineC(double fuel, double fuelToStart)
        : base(fuel, fuelToStart)
    {
    }

    public override void SpendFuel(double distance)
    {
        Fuel -= distance * 0.1;
    }
}