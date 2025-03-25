using Arriba.Core;
using Microsoft.Xna.Framework;

namespace Arriba.Entities.Weapons;

public class MachineGun : Weapon
{
    public MachineGun(Game game): base(game)
    {
        MaxCooldown = 1/10f;
        Damage = 2f;
        Ammo = MaxAmmo = 300;
        Force = new RangeValue(300);
    }

    public override void Shoot(Vector2 pos, Vector2 direction, Game game)
    {
        if (!CanShoot || Depleted)
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