using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponents;

public class Socket : ICloneable<Socket>, IEquatable<Socket>
{
    public Socket(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public Socket Clone()
    {
        return new Socket(Name);
    }

    public bool Equals(Socket? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Socket)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }
}