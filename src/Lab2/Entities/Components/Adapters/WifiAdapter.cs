using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Adapters;

public class WifiAdapter : IComponent, ICloneable<WifiAdapter>
{
    public WifiAdapter(double wifiVersion, bool bluetoothByDefault, int pciVersion, double powerConsumption)
    {
        WifiVersion = wifiVersion;
        BluetoothByDefault = bluetoothByDefault;
        PciVersion = pciVersion;
        PowerConsumption = powerConsumption;
    }

    public double WifiVersion { get; }
    public bool BluetoothByDefault { get; }
    public int PciVersion { get; }
    public double PowerConsumption { get; }

    public WifiAdapter Clone()
    {
        return new WifiAdapter(WifiVersion, BluetoothByDefault, PciVersion, PowerConsumption);
    }
}