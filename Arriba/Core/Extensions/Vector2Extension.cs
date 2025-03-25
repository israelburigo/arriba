using Microsoft.Xna.Framework;

namespace Arriba.Core.Extensions;

public static class Vector2Extension
{
    public static Vector2 Normalized(this Vector2 vector)
    {
        vector.Normalize();
        return vector;
    }
}