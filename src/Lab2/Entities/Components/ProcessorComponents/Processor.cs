using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ProcessorComponents;

public class Processor : IComponent, ICloneable<Processor>, IEquatable<Processor>
{
    private readonly List<double> _supportedMemoryFrequencies = new();

    public Processor(
        double coreFrequency,
        Socket socket,
        bool isBuiltInVideoCore,
        double heatDissipation,
        double powerConsumption)
    {
        CoreFrequency = coreFrequency;
        Socket = socket;
        IsBuiltInVideoCore = isBuiltInVideoCore;
        HeatDissipation = heatDissipation;
        PowerConsumption = powerConsumption;
    }

    public IReadOnlyCollection<double> SupportedMemoryFrequencies => _supportedMemoryFrequencies;

    public double CoreFrequency { get; }

    public Socket Socket { get; }

    public bool IsBuiltInVideoCore { get; }

    public double HeatDissipation { get; }

    public double PowerConsumption { get; }

    public Processor Clone()
    {
        return new Processor(
            CoreFrequency,
            Socket.Clone(),
            IsBuiltInVideoCore,
            HeatDissipation,
            PowerConsumption);
    }

    public bool Equals(Processor? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _supportedMemoryFrequencies.Equals(other._supportedMemoryFrequencies) &&
               CoreFrequency.Equals(other.CoreFrequency) && Socket.Equals(other.Socket) &&
               IsBuiltInVideoCore == other.IsBuiltInVideoCore && HeatDissipation.Equals(other.HeatDissipation) &&
               PowerConsumption.Equals(other.PowerConsumption);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Processor)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            _supportedMemoryFrequencies,
            CoreFrequency,
            Socket,
            IsBuiltInVideoCore,
            HeatDissipation,
            PowerConsumption);
    }
}