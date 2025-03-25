using System;
using Arriba.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Arriba.Entities.Weapons;

public class Gun : Weapon
{
    public Gun(Game game): base(game)
    {
        MaxCooldown = 1f;
        Damage = 10f;
        MaxAmmo = Ammo = Int32.MaxValue;
        Force = new RangeValue(200);
        //Sound = Game.Content.Load<SoundEffect>("SFX/gun_shot");
    }

    public override void Shoot(Vector2 pos, Vector2 direction, Game game)
    {
        if (!CanShoot)
            return;
        Ammo--;
        CanShoot = false;
        Sound?.Play();
        new Shot(game)
        {
            Position = new Vector2(pos.X, pos.Y),
            Velocity = direction * Force.Random(),
            Damage = Damage,
        };
    }
}