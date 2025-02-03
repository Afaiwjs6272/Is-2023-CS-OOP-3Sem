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
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Validation;

public static class ComputerValidator
{
    public static IEnumerable<MotherBoardValidationErrors> ValidateMotherboard(
        Motherboard motherboard,
        ComputerCase computerCase)
    {
        var result = new List<MotherBoardValidationErrors>();
        ArgumentNullException.ThrowIfNull(motherboard);
        ArgumentNullException.ThrowIfNull(computerCase);

        if (!computerCase.OverallSize.IsBigger(motherboard.OverallSize))
        {
            result.Add(MotherBoardValidationErrors.MotherBoardSizeError);
        }

        if (!computerCase.AvaliableFormfactors.Contains(motherboard.Formfactor))
        {
            result.Add(MotherBoardValidationErrors.MotherBoardFormFactorError);
        }

        return result;
    }

    public static IEnumerable<ProcessorValidationErrors> ValidateProcessor(
        Processor processor,
        Motherboard motherboard)
    {
        var result = new List<ProcessorValidationErrors>();
        ArgumentNullException.ThrowIfNull(motherboard);
        ArgumentNullException.ThrowIfNull(processor);

        if (!motherboard.Socket.Equals(processor.Socket))
        {
            result.Add(ProcessorValidationErrors.SocketError);
        }

        if (!motherboard.Bios.AvailableProcessors.Contains(processor))
        {
            result.Add(ProcessorValidationErrors.BiosError);
        }

        return result;
    }

    public static IEnumerable<CoolingSystemValidationErrors> ValidateCoolingSystem(
        ProcessorCoolingSystem coolingSystem,
        ComputerCase computerCase,
        Processor processor,
        Motherboard motherboard)
    {
        var result = new List<CoolingSystemValidationErrors>();
        ArgumentNullException.ThrowIfNull(motherboard);
        ArgumentNullException.ThrowIfNull(processor);
        ArgumentNullException.ThrowIfNull(computerCase);
        ArgumentNullException.ThrowIfNull(coolingSystem);
        var overallSize = new OverallSize(
            motherboard.OverallSize.Length + coolingSystem.OverallSize.Length,
            motherboard.OverallSize.Width + coolingSystem.OverallSize.Width,
            motherboard.OverallSize.Height + coolingSystem.OverallSize.Height);

        if (!computerCase.OverallSize.IsBigger(overallSize))
        {
            result.Add(CoolingSystemValidationErrors.SizeError);
        }

        if (!coolingSystem.Sockets.Contains(motherboard.Socket))
        {
            result.Add(CoolingSystemValidationErrors.SocketError);
        }

        if (processor.HeatDissipation > coolingSystem.HeatDissipation)
        {
            result.Add(CoolingSystemValidationErrors.TdpError);
        }

        return result;
    }

    public static IEnumerable<WifiAdapterValidationErrors> ValidateWifiAdapter(
        Motherboard motherboard,
        WifiAdapter? wifiAdapter)
    {
        var result = new List<WifiAdapterValidationErrors>();
        ArgumentNullException.ThrowIfNull(motherboard);

        if (motherboard.IsWifiModuleByDefault && wifiAdapter != null)
        {
            result.Add(WifiAdapterValidationErrors.InBuiltAdapterError);
        }

        return result;
    }

    public static IEnumerable<VideocardValidationErrors> ValidateVideocard(
        Videocard videocard,
        Motherboard motherboard,
        ProcessorCoolingSystem coolingSystem,
        ComputerCase computerCase)
    {
        var result = new List<VideocardValidationErrors>();
        ArgumentNullException.ThrowIfNull(motherboard);
        ArgumentNullException.ThrowIfNull(videocard);
        ArgumentNullException.ThrowIfNull(coolingSystem);
        ArgumentNullException.ThrowIfNull(computerCase);
        var overallSize = new OverallSize(
            motherboard.OverallSize.Length + coolingSystem.OverallSize.Length + videocard.OverallSize.Length,
            motherboard.OverallSize.Width + coolingSystem.OverallSize.Width + videocard.OverallSize.Width,
            motherboard.OverallSize.Height + coolingSystem.OverallSize.Height + videocard.OverallSize.Height);

        if (!computerCase.OverallSize.IsBigger(overallSize))
        {
            result.Add(VideocardValidationErrors.SizeError);
        }

        if (motherboard.PciVersion > videocard.PciVersion)
        {
            result.Add(VideocardValidationErrors.PciVersionError);
        }

        return result;
    }

    public static IEnumerable<PowerModuleValidationErrors> ValidatePowerModule(
        PowerModule powerModule,
        Processor processor,
        Videocard videocard,
        WifiAdapter? wifiAdapter,
        IEnumerable<SsdDrive> ssdDrives,
        IEnumerable<HardDrive> hardDrives)
    {
        var result = new List<PowerModuleValidationErrors>();

        ArgumentNullException.ThrowIfNull(processor);
        ArgumentNullException.ThrowIfNull(videocard);
        ArgumentNullException.ThrowIfNull(powerModule);

        double sumPower = processor.PowerConsumption +
                          videocard.PowerConsumption +
                          ssdDrives.Sum(x => x.PowerConsumption) +
                          hardDrives.Sum(x => x.PowerConsumption)
                          + (wifiAdapter?.PowerConsumption ?? 0);

        if (powerModule.PeakLoad < sumPower)
        {
            result.Add(PowerModuleValidationErrors.NotEnoughPowerError);
        }

        return result;
    }

    public static bool IsAvaliablePciPort(
        Motherboard motherboard,
        Videocard? videocard,
        WifiAdapter? wifiAdapter,
        IEnumerable<SsdDrive> ssdDrives)
    {
        ArgumentNullException.ThrowIfNull(motherboard);

        int sum = 0;
        if (videocard != null)
        {
            sum++;
        }

        if (wifiAdapter != null)
        {
            sum++;
        }

        sum += ssdDrives.Count(x => x.ConnectionType.Equals(ConnectionType.Pci));

        return motherboard.PciComponentsCount > sum;
    }

    public static bool IsAvaliableSataPort(
        Motherboard motherboard,
        IEnumerable<HardDrive> hardDrives)
    {
        ArgumentNullException.ThrowIfNull(motherboard);
        return motherboard.SataComponentsCount > hardDrives.Count();
    }

    public static bool IsAvaliableRamPort(
        Motherboard motherboard,
        IEnumerable<RandomAccessMemory> rams)
    {
        ArgumentNullException.ThrowIfNull(motherboard);
        return motherboard.RamComponentsCount > rams.Count();
    }

    public static ComputerValidationErrors ValidateAllComponents(
        PowerModule? powerModule,
        ProcessorCoolingSystem? coolingSystem,
        Motherboard? motherboard,
        ComputerCase? computerCase,
        Processor? processor,
        Videocard? videocard,
        WifiAdapter? wifiAdapter,
        IEnumerable<SsdDrive> ssdDrives,
        IEnumerable<HardDrive> hardDrives)
    {
        ArgumentNullException.ThrowIfNull(powerModule);
        ArgumentNullException.ThrowIfNull(motherboard);
        ArgumentNullException.ThrowIfNull(computerCase);
        ArgumentNullException.ThrowIfNull(processor);
        ArgumentNullException.ThrowIfNull(coolingSystem);
        ArgumentNullException.ThrowIfNull(videocard);

        var result = new ComputerValidationErrors();
        result.AddMotherBoardErrors(ValidateMotherboard(motherboard, computerCase));
        result.AddProcessorErrors(ValidateProcessor(processor, motherboard));
        result.AddCoolingSystemErrors(ValidateCoolingSystem(coolingSystem, computerCase, processor, motherboard));
        result.AddWifiAdapterErrors(ValidateWifiAdapter(motherboard, wifiAdapter));
        result.AddVideocardErrors(ValidateVideocard(videocard, motherboard, coolingSystem, computerCase));
        result.AddPowerModuleErrors(ValidatePowerModule(powerModule, processor, videocard, wifiAdapter, ssdDrives, hardDrives));

        return result;
    }
}