using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;

public class ComputerValidationErrors
{
    private readonly List<MotherBoardValidationErrors> _motherboardErrors = new();
    private readonly List<ProcessorValidationErrors> _processorErrors = new();
    private readonly List<CoolingSystemValidationErrors> _coolingErrors = new();
    private readonly List<WifiAdapterValidationErrors> _wifiAdapterErrors = new();
    private readonly List<VideocardValidationErrors> _videocardErrors = new();
    private readonly List<PowerModuleValidationErrors> _powerModuleErrors = new();

    public IReadOnlyCollection<MotherBoardValidationErrors> MotherboardErrors => _motherboardErrors;

    public IReadOnlyCollection<ProcessorValidationErrors> ProcessorErrors => _processorErrors;

    public IReadOnlyCollection<CoolingSystemValidationErrors> CoolingErrors => _coolingErrors;

    public IReadOnlyCollection<WifiAdapterValidationErrors> WifiAdapterErrors => _wifiAdapterErrors;

    public IReadOnlyCollection<VideocardValidationErrors> VideocardErrors => _videocardErrors;

    public IReadOnlyCollection<PowerModuleValidationErrors> PowerModuleErrors => _powerModuleErrors;

    public void AddMotherBoardErrors(IEnumerable<MotherBoardValidationErrors> errors)
    {
        _motherboardErrors.AddRange(errors);
    }

    public void AddProcessorErrors(IEnumerable<ProcessorValidationErrors> errors)
    {
        _processorErrors.AddRange(errors);
    }

    public void AddCoolingSystemErrors(IEnumerable<CoolingSystemValidationErrors> errors)
    {
        _coolingErrors.AddRange(errors);
    }

    public void AddWifiAdapterErrors(IEnumerable<WifiAdapterValidationErrors> errors)
    {
        _wifiAdapterErrors.AddRange(errors);
    }

    public void AddVideocardErrors(IEnumerable<VideocardValidationErrors> errors)
    {
        _videocardErrors.AddRange(errors);
    }

    public void AddPowerModuleErrors(IEnumerable<PowerModuleValidationErrors> errors)
    {
        _powerModuleErrors.AddRange(errors);
    }

    public bool IsSuccessBuild()
    {
        return _motherboardErrors.Count == 0
               && _processorErrors.Count == 0
               && _coolingErrors.Count == 0
               && _wifiAdapterErrors.Count == 0
               && _videocardErrors.Count == 0
               && _powerModuleErrors.Count == 0;
    }
}