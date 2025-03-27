using System;
using Arriba.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Arriba.Entities.Weapons;

public class Gun : Weapon
{
    public Gun(Game game): base(game)
    {
        MaxCooldown = 1/3f;
        Damage = 10f;
        Ammo = MaxAmmo = Int32.MaxValue;
        Force = new RangeValue(300);
        //Sound = Game.Content.Load<SoundEffect>("SFX/gun_shot");
    }

    protected override void DoShoot(Vector2 pos, Vector2 direction, Game game)
    {
        if (!CanShoot)
            return;
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