using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryDrives;

public class SsdDrive : IComponent, ICloneable<SsdDrive>
{
    public SsdDrive(ConnectionType connectionType, double memorySize, double speed, double powerConsumption)
    {
        ConnectionType = connectionType;
        MemorySize = memorySize;
        Speed = speed;
        PowerConsumption = powerConsumption;
    }

    public ConnectionType ConnectionType { get; }
    public double MemorySize { get; }
    public double Speed { get; }
    public double PowerConsumption { get; }

    public SsdDrive Clone()
    {
        return new SsdDrive(ConnectionType, MemorySize, Speed, PowerConsumption);
    }
}