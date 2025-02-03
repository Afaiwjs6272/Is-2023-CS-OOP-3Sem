namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public class ImpulseEngineE : ImpulseEngine
{
    public ImpulseEngineE(double fuel, double fuelToStart)
        : base(fuel, fuelToStart)
    {
    }

    public override void SpendFuel(double distance)
    {
        Fuel -= distance * distance * 0.1;
    }
}