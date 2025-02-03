using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;

public class Motherboard : IComponent, ICloneable<Motherboard>
{
    public Motherboard(
        Socket socket,
        Chipset chipset,
        int pciComponentsCount,
        int sataComponentsCount,
        int ramComponentsCount,
        OverallSize overallSize,
        Bios bios,
        int pciVersion,
        bool isWifiModuleByDefault,
        MotherboardFormfactor formfactor)
    {
        Socket = socket;
        Chipset = chipset;
        PciComponentsCount = pciComponentsCount;
        SataComponentsCount = sataComponentsCount;
        RamComponentsCount = ramComponentsCount;
        OverallSize = overallSize;
        Bios = bios;
        PciVersion = pciVersion;
        IsWifiModuleByDefault = isWifiModuleByDefault;
        Formfactor = formfactor;
        PowerConsumption = 0;
    }

    public Socket Socket { get; }
    public Chipset Chipset { get; }
    public int PciVersion { get; }
    public int PciComponentsCount { get; }
    public int SataComponentsCount { get; }
    public int RamComponentsCount { get; }
    public OverallSize OverallSize { get; }
    public Bios Bios { get; }
    public bool IsWifiModuleByDefault { get; }
    public MotherboardFormfactor Formfactor { get; }
    public double PowerConsumption { get; }

    public Motherboard Clone()
    {
        return new Motherboard(
            Socket.Clone(),
            Chipset.Clone(),
            PciComponentsCount,
            SataComponentsCount,
            RamComponentsCount,
            OverallSize.Clone(),
            Bios.Clone(),
            PciVersion,
            IsWifiModuleByDefault,
            Formfactor);
    }
}