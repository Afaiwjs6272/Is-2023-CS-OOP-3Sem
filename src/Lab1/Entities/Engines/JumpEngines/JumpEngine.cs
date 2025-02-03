namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;

public abstract class JumpEngine
{
    protected JumpEngine(double fuel)
    {
        Fuel = fuel;
        MaxFuel = fuel;
    }

    public double Fuel { get; protected set; }
    public double MaxFuel { get; }
    public abstract void SpendFuel(double distance);
}