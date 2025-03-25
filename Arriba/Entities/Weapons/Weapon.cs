using System;
using Arriba.Core;
using Arriba.Core.Extensions;
using Arriba.Core.Geometrics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Arriba.Entities.Weapons;

public abstract class Weapon
{
    protected Game Game;
    protected int MaxAmmo { get; set; }
    protected float MaxCooldown { get; init; }
    protected float Damage;
    protected bool CanShoot = true;
    protected RangeValue Force;
    protected SoundEffect Sound;
    private float _cooldown = 0;

    private int _ammo = 0;

    public bool Depleted => Ammo == 0;

    public int Ammo
    {
        get => _ammo;
        set
        {
            _ammo = value;
            if (_ammo > MaxAmmo && MaxAmmo > 0)
                _ammo = MaxAmmo;
        }
    }

    public abstract void Shoot(Vector2 pos, Vector2 direction, Game game);

    protected Weapon(Game game)
    {
        Game = game;
    }

    public void Update(GameTime gameTime)
    {
        if ((_cooldown += gameTime.Dt()) < MaxCooldown) return;
        CanShoot = true;
        _cooldown = 0;
    }

    public void Draw(GameTime gameTime, Vector2 position)
    {
        Globals.SpriteBatch.DrawRect(new RectangleD
        {
            X = position.X + 1,
            Y = position.Y - 4,
            W = 18 * Ammo / MaxAmmo,
            H = 2
        }.ToInt(), 1, Color.Yellow);
    }
}