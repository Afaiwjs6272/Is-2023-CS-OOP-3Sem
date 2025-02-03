using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : ICloneable<ComputerCase>
{
    private readonly List<MotherboardFormfactor> _avaliableFormfactors;

    public ComputerCase(
        IEnumerable<MotherboardFormfactor> avaliableFormfactors,
        OverallSize overallSize)
    {
        _avaliableFormfactors = avaliableFormfactors.ToList();
        OverallSize = overallSize;
    }

    public IReadOnlyCollection<MotherboardFormfactor> AvaliableFormfactors => _avaliableFormfactors;
    public OverallSize OverallSize { get; }
    public ComputerCase Clone()
    {
        return new ComputerCase(_avaliableFormfactors, OverallSize.Clone());
    }
}