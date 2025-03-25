using Arriba.Core;
using Arriba.Core.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Arriba.Entities;

public class Shot : DrawableGameComponent
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; init; }
    public Texture2D Texture { get; set; }
    public float Damage { get; set; }

    public Shot(Game game) : base(game)
    {
        Texture = game.Content.Load<Texture2D>("Textures/bullet");
        game.Components.Add(this);
    }

    public override void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        Position += Velocity * gameTime.Dt();
        if (Position.X < 0
            || Position.Y < 0
            || Position.X > Game.Window.ClientBounds.Width
            || Position.Y > Game.Window.ClientBounds.Height)
            Game.Components.Remove(this);
    }
}