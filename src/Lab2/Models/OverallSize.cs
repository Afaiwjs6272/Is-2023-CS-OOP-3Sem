using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class OverallSize : ICloneable<OverallSize>
{
    public OverallSize(int length, int width, int height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public static OverallSize ZeroSize { get; } = new(0, 0, 0);
    public int Length { get; }
    public int Width { get; }
    public int Height { get; }

    public OverallSize Clone()
    {
        return new OverallSize(Length, Width, Height);
    }

    public bool IsBigger(OverallSize overallSize)
    {
        ArgumentNullException.ThrowIfNull(overallSize);
        return Length >= overallSize.Length &&
               Width >= overallSize.Width &&
               Height >= overallSize.Height;
    }
}