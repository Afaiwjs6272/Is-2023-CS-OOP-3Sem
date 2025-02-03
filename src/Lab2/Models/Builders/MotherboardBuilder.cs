using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

public class MotherboardBuilder
{
    private Socket? _socket;
    private Chipset? _chipset;
    private int _pciVersion;
    private int _pciComponentsCount;
    private int _sataComponentsCount;
    private int _ramComponentsCount;
    private OverallSize? _overallSize;
    private Bios? _bios;
    private bool _isWifiModuleByDefault;
    private MotherboardFormfactor _formfactor;

    public MotherboardBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public MotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder WithPciVersion(int pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public MotherboardBuilder WithPciComponentsCount(int pciComponentsCount)
    {
        _pciComponentsCount = pciComponentsCount;
        return this;
    }

    public MotherboardBuilder WithSataComponentsCount(int sataComponentsCount)
    {
        _sataComponentsCount = sataComponentsCount;
        return this;
    }

    public MotherboardBuilder WithWifiModuleByDefault(bool isWifiModuleByDefault)
    {
        _isWifiModuleByDefault = isWifiModuleByDefault;
        return this;
    }

    public MotherboardBuilder WithOverallSize(OverallSize overallSize)
    {
        _overallSize = overallSize;
        return this;
    }

    public MotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public MotherboardBuilder WithRamComponentsCount(int ramComponentsCount)
    {
        _ramComponentsCount = ramComponentsCount;
        return this;
    }

    public MotherboardBuilder WithFormfactor(MotherboardFormfactor formfactor)
    {
        _formfactor = formfactor;
        return this;
    }

    public Motherboard Build()
    {
        if (_socket == null || _chipset == null || _overallSize == null
            || _bios == null)
        {
            throw new ComputerCreationException("Motherboard components is absent");
        }

        return new Motherboard(
            _socket,
            _chipset,
            _pciComponentsCount,
            _sataComponentsCount,
            _ramComponentsCount,
            _overallSize,
            _bios,
            _pciVersion,
            _isWifiModuleByDefault,
            _formfactor);
    }
}