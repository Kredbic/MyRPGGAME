using MyRPGGame.Models;
using MyRPGGame.Enums;
using System;

namespace MyRPGGame.Factories
{
    public static class WeaponFactory
    {
        public static Weapon CreateWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Pistol:
                    return new Weapon(WeaponType.Pistol, 12, 0.2, 150);
                case WeaponType.Shotgun:
                    return new Weapon(WeaponType.Shotgun, 50, 0.05, 300);
                case WeaponType.AK:
                    return new Weapon(WeaponType.AK, 120, 0.6, 450);
                case WeaponType.Minigun:
                    return new Weapon(WeaponType.Minigun, 200, 1.0, 600);
                default:
                    throw new ArgumentException("Neplatný typ zbraně.");
            }
        }
    }
}
