using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Power;

public class PowerModule : IComponent, ICloneable<PowerModule>
{
    public PowerModule(double peakLoad)
    {
        PeakLoad = peakLoad;
        PowerConsumption = 0;
    }

    public double PeakLoad { get; }
    public double PowerConsumption { get; }

    public PowerModule Clone()
    {
        return new PowerModule(PeakLoad);
    }
}