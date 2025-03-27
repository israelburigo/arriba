using System.Globalization;
using Arriba.Core;
using Arriba.Core.Entities;
using Arriba.Core.Extensions;
using Arriba.Entities;
using Arriba.Entities.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arriba;

public class Main : Game
{
    public Main()
    {
        Globals.Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        var xCenter = Globals.Graphics.GraphicsDevice.Viewport.Width / 2;
        var yCenter = Globals.Graphics.GraphicsDevice.Viewport.Height / 2;
        new Character(this)
        {
            Position = new Vector2(xCenter, yCenter),
            Weapon = new ShotGun(this)
        };
    }

    protected override void LoadContent()
    {
        Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        Window.Title = (1 / gameTime.Dt()).ToString(CultureInfo.CurrentCulture);
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Gray);

        Globals.SpriteBatch.Begin();
        base.Draw(gameTime);
        Globals.SpriteBatch.End();
    }
}