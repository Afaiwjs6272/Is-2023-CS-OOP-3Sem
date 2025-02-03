using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;

public class JumpEngineOmega : JumpEngine
{
    public JumpEngineOmega(double fuel)
        : base(fuel)
    {
    }

    public override void SpendFuel(double distance)
    {
        Fuel -= distance * 0.1 * Math.Log2(distance);
    }
}