using System;
using Microsoft.Xna.Framework;

namespace Arriba.Core.Extensions;

public static class Vector2Extension
{
    public static Vector2 Normalized(this Vector2 vector)
    {
        vector.Normalize();
        return vector;
    }

    public static Vector2 Rotate(this Vector2 vector, float radians)
    {
        var x = vector.X * Math.Cos(radians) + vector.Y * Math.Sin(radians);
        var y = -vector.X * Math.Sin(radians) + vector.Y * Math.Cos(radians);
        return new Vector2((float)x, (float)y);
    }
    
    public static Vector2 Rotate(this Vector2 vector, float radians, Vector2 origin)
    {
        return vector;
    }
}