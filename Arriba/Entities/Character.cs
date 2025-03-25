using Arriba.Core;
using Arriba.Core.Entities;
using Arriba.Core.Extensions;
using Arriba.Core.Geometrics;
using Arriba.Entities.Weapons;
using Arriba.ValueObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MathF = Arriba.Core.MathF;

namespace Arriba.Entities;

public class Character : DrawableGameComponent, ICharacter
{
    public RectangleD Bounds { get; set; }
    public Weapon Weapon { get; set; }
    public Health Health { get; set; }
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }

    private const int Speed = 100;

    public Character(Game game) : base(game)
    {
        game.Components.Add(this);
        Texture = game.Content.Load<Texture2D>("Textures/mexican");
        Bounds = new RectangleD
        {
            X = Position.X,
            Y = Position.Y,
            W = Texture.Width,
            H = Texture.Height
        };
        Health = new Health
        {
            MaxValue = 100,
            Value = 100,
        };
    }

    public override void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
        Health.Draw(gameTime, Position);

        if (Weapon is not Gun)
            Weapon?.Draw(gameTime, Position);
    }

    public override void Update(GameTime gameTime)
    {
        Weapon?.Update(gameTime);

        var state = Keyboard.GetState();
        var mouse = Mouse.GetState();

        var incY = 0f;
        var incX = 0f;

        if (state.IsKeyDown(Keys.W))
            incY = -Speed;
        else if (state.IsKeyDown(Keys.S))
            incY = Speed;

        if (state.IsKeyDown(Keys.A))
            incX = -Speed;
        else if (state.IsKeyDown(Keys.D))
            incX = Speed;

        if (incX != 0 && incY != 0)
        {
            incX /= MathF.Sqrt2;
            incY /= MathF.Sqrt2;
        }

        var velocity = new Vector2(incX, incY);

        var direction = new Vector2(mouse.X - Bounds.Center.X, mouse.Y - Bounds.Center.Y).Normalized();

        if (mouse.LeftButton == ButtonState.Pressed)
            Weapon?.Shoot(Bounds.Center, direction, Game);
        
        if (Weapon!.Depleted)
            Weapon = new Gun(Game);

        Position += velocity * gameTime.Dt();
        Bounds.TopLeft = Position;
    }
}