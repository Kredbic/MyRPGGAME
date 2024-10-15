using System;
using System.Collections.Generic;
using MyRPGGame.Enums;

namespace MyRPGGame.Models
{
    public class Shop
    {
        private Dictionary<WeaponType, Weapon> _weaponsForSale;
        private Dictionary<PotionType, (double HealAmount, double Price)> _potionsForSale;

        public Shop()
        {
            _weaponsForSale = new Dictionary<WeaponType, Weapon>
            {
                { WeaponType.Pistol, new Weapon(WeaponType.Pistol, 12, 0.2, 150) },
                { WeaponType.Shotgun, new Weapon(WeaponType.Shotgun, 50, 0.05, 300) },
                { WeaponType.AK, new Weapon(WeaponType.AK, 120, 0.6, 450) },
                { WeaponType.Minigun, new Weapon(WeaponType.Minigun, 200, 1.0, 600) }
            };

            _potionsForSale = new Dictionary<PotionType, (double HealAmount, double Price)>
            {
                { PotionType.Bandage, (20, 100) },
                { PotionType.Syringe, (50, 200) },
                { PotionType.Medkit, (100, 300) }
            };
        }

        public void DisplayWeapons()
        {
            Console.WriteLine("Zbraně k prodeji:");
            int index = 1;
            foreach (var weapon in _weaponsForSale)
            {
                Console.WriteLine($"{index++}. {weapon.Key} - {weapon.Value.Damage} poškození - {weapon.Value.Price} zlata");
            }
        }

        public void DisplayPotions()
        {
            Console.WriteLine("Potiony k prodeji:");
            int index = 5;
            foreach (var potion in _potionsForSale)
            {
                Console.WriteLine($"{index++}. {potion.Key} - Heal {potion.Value.HealAmount} HP - {potion.Value.Price} zlata");
            }
        }

        public bool BuyWeapon(Player player, int weaponNumber)
        {
            var weapon = (WeaponType)(weaponNumber - 1);

            if (_weaponsForSale.TryGetValue(weapon, out Weapon selectedWeapon))
            {
                if (player.Gold >= selectedWeapon.Price)
                {
                    player.CurrentWeapon = selectedWeapon;
                    player.Gold -= selectedWeapon.Price;
                    Console.WriteLine($"Koupil jsi {selectedWeapon.Type}.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Nemáš dostatek zlata!");
                }
            }
            return false;
        }

        public bool BuyPotion(Player player, int potionNumber)
        {
            var potion = (PotionType)(potionNumber - 5);

            if (_potionsForSale.TryGetValue(potion, out var potionInfo))
            {
                if (player.Gold >= potionInfo.Price)
                {
                    player.Heal(potionInfo.HealAmount);
                    player.Gold -= potionInfo.Price;
                    Console.WriteLine($"Koupil jsi {potion}, který obnovil {potionInfo.HealAmount} HP.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Nemáš dostatek zlata na koupi potiona!");
                }
            }
            return false;
        }
    }
}
