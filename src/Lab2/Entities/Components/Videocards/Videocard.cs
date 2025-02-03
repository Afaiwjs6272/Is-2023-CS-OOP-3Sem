using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Videocards;

public class Videocard : IComponent, ICloneable<Videocard>
{
    public Videocard(
        OverallSize overallSize,
        int memorySize,
        int pciVersion,
        int chipFrequency,
        double powerConsumption)
    {
        OverallSize = overallSize;
        MemorySize = memorySize;
        PciVersion = pciVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public OverallSize OverallSize { get; }
    public int MemorySize { get; }
    public int PciVersion { get; }
    public int ChipFrequency { get; }
    public double PowerConsumption { get; }

    public Videocard Clone()
    {
        return new Videocard(OverallSize.Clone(), MemorySize, PciVersion, ChipFrequency, PowerConsumption);
    }
}