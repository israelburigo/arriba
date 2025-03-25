using System;
using Arriba.Core;
using Arriba.Core.Extensions;
using Microsoft.Xna.Framework;
using MathF = Arriba.Core.MathF;

namespace Arriba.Entities.Weapons;

public class ShotGun : Weapon
{
    public ShotGun(Game game) : base(game)
    {
        MaxCooldown = 1 / 2f;
        Damage = 5f;
        Ammo = MaxAmmo = 50;
        Force = new RangeValue(300);
    }

    public override void Shoot(Vector2 pos, Vector2 direction, Game game)
    {
        if (!CanShoot || Depleted)
            return;
        CanShoot = false;
        
        Ammo--;
        var range = new RangeValue(4, 7);
        var angle = new RangeValue(-MathF.PI/20, MathF.PI/20);

        for (var i = 0; i < range.RandomInt(); i++)
            new Shot(game)
            {
                Position = new Vector2(pos.X, pos.Y),
                Velocity = direction.Rotate(angle.Random()) * Force.Random(),
                Damage = Damage,
            };
    }
}