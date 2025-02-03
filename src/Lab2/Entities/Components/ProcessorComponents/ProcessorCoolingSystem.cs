using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ProcessorComponents;

public class ProcessorCoolingSystem : IComponent, ICloneable<ProcessorCoolingSystem>
{
    private readonly List<Socket> _sockets = new();

    public ProcessorCoolingSystem(double heatDissipation, OverallSize overallSize, IEnumerable<Socket> sockets)
    {
        HeatDissipation = heatDissipation;
        OverallSize = overallSize;
        PowerConsumption = 0;
        _sockets = sockets.ToList();
    }

    public IReadOnlyCollection<Socket> Sockets => _sockets;
    public double HeatDissipation { get; }
    public OverallSize OverallSize { get; }
    public double PowerConsumption { get; }

    public ProcessorCoolingSystem Clone()
    {
        return new ProcessorCoolingSystem(HeatDissipation, OverallSize.Clone(), Sockets.Select(x => x.Clone()));
    }
}