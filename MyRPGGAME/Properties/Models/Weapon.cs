using MyRPGGame.Enums;

namespace MyRPGGame.Models
{
    public class Weapon
    {
        public WeaponType Type { get; }
        public double Damage { get; }
        public double AttackSpeed { get; }
        public double Price { get; }

        public Weapon(WeaponType type, double damage, double attackSpeed, double price)
        {
            Type = type;
            Damage = damage;
            AttackSpeed = attackSpeed;
            Price = price;
        }
    }
}
