using MyRPGGame.Models;
using MyRPGGame.Enums;
using System;

namespace MyRPGGame.Factories
{
    public static class PotionFactory
    {
        public static (double HealAmount, double Price) CreatePotion(PotionType type)
        {
            switch (type)
            {
                case PotionType.Bandage:
                    return (20, 100);
                case PotionType.Syringe:
                    return (50, 200);
                case PotionType.Medkit:
                    return (100, 300);
                default:
                    throw new ArgumentException("Neplatný typ potionu.");
            }
        }
    }
}
