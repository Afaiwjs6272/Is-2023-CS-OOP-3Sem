using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RAM;

public class RandomAccessMemory : IComponent, ICloneable<RandomAccessMemory>
{
    private readonly List<ExtremeMemoryProfile> _extremeMemoryProfiles;

    public RandomAccessMemory(
        IEnumerable<ExtremeMemoryProfile> extremeMemoryProfiles,
        int memorySize,
        OverallSize overallSize,
        int ddrStandart,
        int frequency,
        double powerConsumption)
    {
        _extremeMemoryProfiles = extremeMemoryProfiles.ToList();
        MemorySize = memorySize;
        OverallSize = overallSize;
        DdrStandart = ddrStandart;
        Frequency = frequency;
        PowerConsumption = powerConsumption;
    }

    public IReadOnlyCollection<ExtremeMemoryProfile> ExtremeMemoryProfiles => _extremeMemoryProfiles;
    public int MemorySize { get; }
    public OverallSize OverallSize { get; }
    public int DdrStandart { get; }
    public int Frequency { get; }
    public double PowerConsumption { get; }

    public RandomAccessMemory Clone()
    {
        return new RandomAccessMemory(
            ExtremeMemoryProfiles.Select(x => x.Clone()),
            MemorySize,
            OverallSize.Clone(),
            DdrStandart,
            Frequency,
            PowerConsumption);
    }
}