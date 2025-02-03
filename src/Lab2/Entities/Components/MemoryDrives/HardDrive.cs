using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryDrives;

public class HardDrive : IComponent, ICloneable<HardDrive>
{
    public HardDrive(double memorySize, double speed, double powerConsumption)
    {
        MemorySize = memorySize;
        Speed = speed;
        PowerConsumption = powerConsumption;
    }

    public double MemorySize { get; }
    public double Speed { get; }
    public double PowerConsumption { get; }

    public HardDrive Clone()
    {
        return new HardDrive(MemorySize, Speed, PowerConsumption);
    }
}