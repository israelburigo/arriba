using Microsoft.Xna.Framework;

namespace Arriba.Core.Extensions;

public static class GameTimeExtension
{
    public static float Dt(this GameTime gt)
    {
        return (float)gt.ElapsedGameTime.TotalSeconds;
    }
}