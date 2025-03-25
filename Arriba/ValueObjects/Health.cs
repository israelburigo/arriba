using Arriba.Core;
using Arriba.Core.Extensions;
using Arriba.Core.Geometrics;
using Microsoft.Xna.Framework;

namespace Arriba.ValueObjects;

public class Health
{
    public float MaxValue { get; set; }
    public float Value { get; set; }

    public void Draw(GameTime gameTime, Vector2 position)
    {
        Globals.SpriteBatch.DrawRect(new RectangleD
        {
            X = position.X,
            Y = position.Y - 10,
            W = 32,
            H = 4 
        }.ToInt(), 1, Color.Black);
        Globals.SpriteBatch.DrawRect(new RectangleD
        {
            X = position.X + 1,
            Y = position.Y - 9,
            W = 30 * Value/MaxValue,
            H = 2 
        }.ToInt(), 1, Color.Red);
    }
}