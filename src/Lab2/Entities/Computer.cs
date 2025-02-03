using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Adapters;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryDrives;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Power;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ProcessorComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Videocards;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
    private readonly List<RandomAccessMemory> _randomAccessMemory;
    private readonly List<HardDrive> _hardDrives;
    private readonly List<SsdDrive> _ssdDrives;

    public Computer(
        Motherboard motherboard,
        Processor processor,
        IEnumerable<RandomAccessMemory> randomAccessMemory,
        ComputerCase computerCase,
        PowerModule powerModule,
        Videocard? videocard,
        WifiAdapter? wifiAdapter,
        ProcessorCoolingSystem? coolingSystem,
        IEnumerable<HardDrive> hardDrives,
        IEnumerable<SsdDrive> ssdDrives)
    {
        Motherboard = motherboard;
        Processor = processor;
        CoolingSystem = coolingSystem;
        _hardDrives = hardDrives.ToList();
        _ssdDrives = ssdDrives.ToList();
        _randomAccessMemory = randomAccessMemory.ToList();
        ComputerCase = computerCase;
        PowerModule = powerModule;
        Videocard = videocard;
        WifiAdapter = wifiAdapter;
    }

    public Motherboard Motherboard { get; }
    public Processor Processor { get; }
    public ProcessorCoolingSystem? CoolingSystem { get; }
    public ComputerCase ComputerCase { get; }
    public PowerModule PowerModule { get; }
    public Videocard? Videocard { get; }
    public WifiAdapter? WifiAdapter { get; }

    public IReadOnlyCollection<HardDrive> HardDrives => _hardDrives;

    public IReadOnlyCollection<SsdDrive> SsdDrives => _ssdDrives;

    public IReadOnlyCollection<RandomAccessMemory> RandomAccessMemory => _randomAccessMemory;
}