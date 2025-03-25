using System;

namespace Arriba.Core;

public static class RngGenerator
{
    private static readonly Random Random = new();

    public static float Get()
    {
        return (float)Random.NextDouble();
    }
}