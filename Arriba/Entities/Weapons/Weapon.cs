using System;
using Arriba.Core;
using Arriba.Core.Extensions;
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
    
    public int Ammo
    {
        get => _ammo;
        set
        {
            _ammo = value;
            if (_ammo > MaxAmmo)
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
}