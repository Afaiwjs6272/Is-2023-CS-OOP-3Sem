using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Adapters;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryDrives;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Power;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ProcessorComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Videocards;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Validation;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

public class ComputerBuilder
{
    private readonly List<RandomAccessMemory> _randomAccessMemory = new();
    private readonly List<HardDrive> _hardDrives = new();
    private readonly List<SsdDrive> _ssdDrives = new();
    private Motherboard? _motherboard;
    private Processor? _processor;
    private ProcessorCoolingSystem? _coolingSystem;
    private ComputerCase? _computerCase;
    private PowerModule? _powerModule;
    private Videocard? _videocard;
    private WifiAdapter? _wifiAdapter;

    public ComputerBuilder()
    {
    }

    public ComputerBuilder(Computer computer)
    {
        if (computer == null)
        {
            throw new ComputerCreationException("computer is null");
        }

        _motherboard = computer.Motherboard.Clone();
        _processor = computer.Processor.Clone();
        _computerCase = computer.ComputerCase.Clone();
        _coolingSystem = computer.CoolingSystem?.Clone();
        _powerModule = computer.PowerModule.Clone();
        _videocard = computer.Videocard?.Clone();
        _wifiAdapter = computer.WifiAdapter?.Clone();
        _randomAccessMemory = computer.RandomAccessMemory.Select(x => x.Clone()).ToList();
        _hardDrives = computer.HardDrives.Select(x => x.Clone()).ToList();
        _ssdDrives = computer.SsdDrives.Select(x => x.Clone()).ToList();
    }

    public ComputerBuilder WithComputerCase(ComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public ComputerBuilder WithPowerModule(PowerModule powerModule)
    {
        if (_computerCase == null)
        {
            throw new ComputerCreationException("no computer case");
        }

        _powerModule = powerModule;
        return this;
    }

    public ComputerBuilder WithMotherBoard(Motherboard motherboard)
    {
        if (_computerCase == null)
        {
            throw new ComputerCreationException("no computer case");
        }

        _motherboard = motherboard;
        return this;
    }

    public ComputerBuilder WithProcessor(Processor processor)
    {
        if (_motherboard == null)
        {
            throw new ComputerCreationException("no motherboard");
        }

        _processor = processor;
        return this;
    }

    public ComputerBuilder WithProcessorCoolingSystem(ProcessorCoolingSystem processorCoolingSystem)
    {
        if (_motherboard == null)
        {
            throw new ComputerCreationException("no motherboard");
        }

        _coolingSystem = processorCoolingSystem;
        return this;
    }

    public ComputerBuilder WithVideoCard(Videocard videocard)
    {
        if (_motherboard == null)
        {
            throw new ComputerCreationException("No motherboard");
        }

        _videocard = videocard;
        return this;
    }

    public ComputerBuilder WithWifiAdapter(WifiAdapter wifiAdapter)
    {
        if (_motherboard == null)
        {
            throw new ComputerCreationException("No motherboard");
        }

        _wifiAdapter = wifiAdapter;
        return this;
    }

    public ComputerBuilder WithRam(RandomAccessMemory randomAccessMemory)
    {
        if (_motherboard == null)
        {
            throw new ComputerCreationException("No motherboard");
        }

        if (!ComputerValidator.IsAvaliableRamPort(_motherboard, _randomAccessMemory))
        {
            throw new ComputerCreationException("No avaliable ram ports");
        }

        _randomAccessMemory.Add(randomAccessMemory);
        return this;
    }

    public ComputerBuilder WithSsdDrive(SsdDrive ssdDrive)
    {
        ArgumentNullException.ThrowIfNull(ssdDrive);
        if (_motherboard == null)
        {
            throw new ComputerCreationException("No motherboard");
        }

        if (ssdDrive.ConnectionType == ConnectionType.Pci)
        {
            if (!ComputerValidator.IsAvaliablePciPort(_motherboard, _videocard, _wifiAdapter, _ssdDrives))
            {
                throw new ComputerCreationException("No avaliable pci ports");
            }
        }
        else
        {
            if (!ComputerValidator.IsAvaliableSataPort(_motherboard, _hardDrives))
            {
                throw new ComputerCreationException("No avaliable sata ports");
            }
        }

        _ssdDrives.Add(ssdDrive);
        return this;
    }

    public ComputerBuilder WithHardDrive(HardDrive hardDrive)
    {
        if (_motherboard == null)
        {
            throw new ComputerCreationException("No motherboard");
        }

        if (!ComputerValidator.IsAvaliableSataPort(_motherboard, _hardDrives))
        {
            throw new ComputerCreationException("No avaliable sata ports");
        }

        _hardDrives.Add(hardDrive);
        return this;
    }

    public CreationResult Build()
    {
        ArgumentNullException.ThrowIfNull(_motherboard);
        ArgumentNullException.ThrowIfNull(_processor);
        ArgumentNullException.ThrowIfNull(_computerCase);
        ArgumentNullException.ThrowIfNull(_powerModule);

        ComputerValidationErrors computerValidationErrors = ComputerValidator.ValidateAllComponents(
            _powerModule,
            _coolingSystem,
            _motherboard,
            _computerCase,
            _processor,
            _videocard,
            _wifiAdapter,
            _ssdDrives,
            _hardDrives);

        var computer = new Computer(
            _motherboard,
            _processor,
            _randomAccessMemory,
            _computerCase,
            _powerModule,
            _videocard,
            _wifiAdapter,
            _coolingSystem,
            _hardDrives,
            _ssdDrives);

        return new CreationResult(computer, computerValidationErrors);
    }
}