using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;

public class Chipset : ICloneable<Chipset>
{
    public Chipset(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public Chipset Clone()
    {
        return new Chipset(Name);
    }
}