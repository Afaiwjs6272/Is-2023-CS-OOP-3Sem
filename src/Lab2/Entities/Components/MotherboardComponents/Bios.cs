using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ProcessorComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;

public class Bios : ICloneable<Bios>
{
    private readonly List<Processor> _availableProcessors;

    public Bios(string type, string version, IEnumerable<Processor> availableProcessors)
    {
        Type = type;
        Version = version;
        _availableProcessors = availableProcessors.ToList();
    }

    public IReadOnlyCollection<Processor> AvailableProcessors => _availableProcessors;

    public string Type { get; }

    public string Version { get; }

    public Bios Clone()
    {
        var available = _availableProcessors.Select(processor => processor.Clone()).ToList();
        return new Bios(
            Type,
            Version,
            _availableProcessors.Select(processor => processor.Clone()).ToList());
    }
}