using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RAM;

public class ExtremeMemoryProfile : ICloneable<ExtremeMemoryProfile>
{
    public ExtremeMemoryProfile(int timings, double voltage, int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public int Timings { get; }
    public double Voltage { get; }
    public int Frequency { get; }

    public ExtremeMemoryProfile Clone()
    {
        return new ExtremeMemoryProfile(Timings, Voltage, Frequency);
    }
}