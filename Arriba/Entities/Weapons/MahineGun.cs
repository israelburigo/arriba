using Arriba.Core;
using Microsoft.Xna.Framework;

namespace Arriba.Entities.Weapons;

public class MachineGun : Weapon
{
    public MachineGun(Game game): base(game)
    {
        MaxCooldown = 1/5f;
        Damage = 5f;
        MaxAmmo = Ammo = 500;
        Force = new RangeValue(200);
    }

    public override void Shoot(Vector2 pos, Vector2 direction, Game game)
    {
        if (!CanShoot)
            return;
        Ammo--;
        CanShoot = false;

        new Shot(game)
        {
            Position = new Vector2(pos.X, pos.Y),
            Velocity = direction * Force.Random(),
            Damage = Damage,
        };
    }
}