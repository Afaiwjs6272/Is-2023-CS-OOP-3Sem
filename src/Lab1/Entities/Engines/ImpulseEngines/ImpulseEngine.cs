namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public abstract class ImpulseEngine
{
    protected ImpulseEngine(double fuel, double fuelToStart)
    {
        Fuel = fuel - fuelToStart;
        MaxFuel = fuel;
    }

    public double Fuel { get; protected set; }
    public double MaxFuel { get; }

    public abstract void SpendFuel(double distance);
}