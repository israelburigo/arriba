using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arriba.Core.Extensions;

public static class SpriteBatchExtension
{
    private static Texture2D _texture;
    private static Texture2D GetTexture(SpriteBatch spriteBatch)
    {
        if (_texture != null) return _texture;
        _texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
        _texture.SetData(new[] { Color.White });
        return _texture;
    }

    public static void DrawPoint(this SpriteBatch spriteBatch, Vector2 point, float scale, Color color)
    {
        var origin = new Vector2(0.5f, 0.5f);
        spriteBatch.Draw(GetTexture(spriteBatch), point, null, color, 0, origin, scale, SpriteEffects.None, 0);
    }
    
    public static void DrawRect(this SpriteBatch spriteBatch, Rectangle rect, float scale, Color color)
    {
        var origin = new Vector2(0.5f, 0.5f);
        spriteBatch.Draw(GetTexture(spriteBatch), new Vector2(rect.X, rect.Y), rect, color, 0, origin, scale, SpriteEffects.None, 0);
    }
}