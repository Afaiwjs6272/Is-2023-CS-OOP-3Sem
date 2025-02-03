using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryDrives;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Power;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ProcessorComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Videocards;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerCreationTests
{
    private readonly Motherboard _motherboard;
    private readonly Processor _processor;
    private readonly ProcessorCoolingSystem _coolingSystem;
    private readonly ProcessorCoolingSystem _sillyCoolingSystem;
    private readonly ComputerCase _computerCase;
    private readonly PowerModule _powerModule;
    private readonly PowerModule _sillyPowerModule;
    private readonly Videocard _videocard;
    private readonly RandomAccessMemory _randomAccessMemory;
    private readonly HardDrive _hardDrives;

    public ComputerCreationTests()
    {
        _processor = new Processor(1000, new Socket("socket"), true, 10, 10);

        _motherboard = new MotherboardBuilder()
            .WithBios(new Bios("bios", "1.1", new List<Processor>() { _processor }))
            .WithChipset(new Chipset("chipset"))
            .WithFormfactor(MotherboardFormfactor.Atx)
            .WithSocket(new Socket("socket"))
            .WithOverallSize(new OverallSize(10, 10, 10))
            .WithWifiModuleByDefault(true)
            .WithPciVersion(1)
            .WithPciComponentsCount(10)
            .WithRamComponentsCount(10)
            .WithSataComponentsCount(10)
            .Build();

        _coolingSystem = new ProcessorCoolingSystem(
            1000,
            new OverallSize(10, 10, 10),
            new List<Socket> { new("socket") });

        _sillyCoolingSystem = new ProcessorCoolingSystem(
            1,
            new OverallSize(10, 10, 10),
            new List<Socket> { new("socket") });

        _computerCase = new ComputerCase(
            new List<MotherboardFormfactor>() { MotherboardFormfactor.Atx },
            new OverallSize(100, 100, 100));

        _powerModule = new PowerModule(1000);
        _sillyPowerModule = new PowerModule(1);

        _videocard = new Videocard(new OverallSize(10, 10, 10), 10, 1, 1000, 10);

        _randomAccessMemory = new RandomAccessMemory(
            new List<ExtremeMemoryProfile> { new(1, 1, 1) },
            100,
            new OverallSize(10, 10, 10),
            4,
            1666,
            10);

        _hardDrives = new HardDrive(1000, 1000, 10);
    }

    [Fact]
    public void ValidComputerCreation()
    {
        CreationResult result = new ComputerBuilder()
            .WithComputerCase(_computerCase)
            .WithMotherBoard(_motherboard)
            .WithProcessor(_processor)
            .WithRam(_randomAccessMemory)
            .WithHardDrive(_hardDrives)
            .WithProcessorCoolingSystem(_coolingSystem)
            .WithVideoCard(_videocard)
            .WithPowerModule(_powerModule)
            .Build();

        Assert.True(result.ValidationErrors.IsSuccessBuild());
    }

    [Fact]
    public void InvalidPowerComputerCreation()
    {
        CreationResult result = new ComputerBuilder()
            .WithComputerCase(_computerCase)
            .WithMotherBoard(_motherboard)
            .WithProcessor(_processor)
            .WithRam(_randomAccessMemory)
            .WithHardDrive(_hardDrives)
            .WithProcessorCoolingSystem(_coolingSystem)
            .WithVideoCard(_videocard)
            .WithPowerModule(_sillyPowerModule)
            .Build();

        Assert.Contains(PowerModuleValidationErrors.NotEnoughPowerError, result.ValidationErrors.PowerModuleErrors);
    }

    [Fact]
    public void InvalidTPDComputerCreation()
    {
        CreationResult result = new ComputerBuilder()
            .WithComputerCase(_computerCase)
            .WithMotherBoard(_motherboard)
            .WithProcessor(_processor)
            .WithRam(_randomAccessMemory)
            .WithHardDrive(_hardDrives)
            .WithProcessorCoolingSystem(_sillyCoolingSystem)
            .WithVideoCard(_videocard)
            .WithPowerModule(_powerModule)
            .Build();

        Assert.Contains(CoolingSystemValidationErrors.TdpError, result.ValidationErrors.CoolingErrors);
    }
}