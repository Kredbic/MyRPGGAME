using MyRPGGame.Models;
using MyRPGGame.Factories;
using MyRPGGame.Enums;
using System;

namespace MyRPGGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;
            while (restart)

            {
                Player player = new Player();
                player.CurrentWeapon = WeaponFactory.CreateWeapon(WeaponType.Pistol); // Vytvoření počáteční zbraně
                Shop shop = new Shop();
                Random rand = new Random(); // Ujistěte se, že se inicializuje pouze jednou

                Console.WriteLine("Ovládání hry");
                Console.WriteLine("SHOP - Otevře Shop");
                Console.WriteLine("FIGHT - Finální Bossfight");
                Console.WriteLine("1 - Dveře s pokladem nebo nepřítelem (50% šance)");
                Console.WriteLine("2 - Dveře s pokladem nebo nepřítelem (50% šance)");

                while (true)
                {
                    Console.WriteLine($"Aktuální HP: {player.Health}");
                    Console.WriteLine($"Zlato: {player.Gold}");

                    string command = Console.ReadLine();

                    if (command.ToUpper() == "SHOP")
                    {
                        shop.DisplayWeapons();
                        shop.DisplayPotions();
                        Console.WriteLine("Vyber zbraň (1-4) nebo potion (5-7) ke koupi:");
                        int buyChoice = Convert.ToInt32(Console.ReadLine());

                        if (buyChoice >= 1 && buyChoice <= 4)
                        {
                            shop.BuyWeapon(player, buyChoice);
                        }
                        else if (buyChoice >= 5 && buyChoice <= 7)
                        {
                            shop.BuyPotion(player, buyChoice);
                        }
                        else
                        {
                            Console.WriteLine("Neplatná volba. Zkus to znovu.");
                        }
                        continue;
                    }

                    if (command.ToUpper() == "FIGHT")
                    {
                        Console.WriteLine("Připrav se na finální souboj!");
                        Enemy finalBoss = new Enemy("Dragon", 200, 200, 0);

                        if (player.CurrentWeapon == null)
                        {
                            Console.WriteLine("Musíš mít zbraň před bojem!");
                            continue;
                        }

                        // V případě, že hráč má Minigun, vyhraje automaticky
                        if (player.CurrentWeapon.Type == WeaponType.Minigun)
                        {
                            Console.WriteLine("Vyhrál jsi! Gratulujeme!");
                            break;
                        }

                        // Fáze 1 boje
                        while (finalBoss.Health > 0 && player.Health > 0)
                        {
                            finalBoss.TakeDamage(player.CurrentWeapon.Damage);
                            Console.WriteLine($"Způsobil jsi {player.CurrentWeapon.Damage} poškození drakovi.");

                            player.TakeDamage(finalBoss.BaseDamage * 0.5); // Snížení poškození draka v první fázi
                            Console.WriteLine($"Drak ti způsobil {finalBoss.BaseDamage * 0.5} poškození.");

                            if (finalBoss.Health <= 0)
                            {
                                Console.WriteLine("Porazil jsi draka! Vyhrál jsi hru!");
                                break;
                            }

                            if (player.Health <= 0)
                            {
                                Console.WriteLine("Prohrál jsi! Hra končí.");
                                break;
                            }
                        }
                    }

                    // Kontrola, zda je dostupný poklad nebo nepřítel
                    if (command == "1" || command == "2")
                    {
                        int enemyChance = rand.Next(2); // 0 nebo 1 pro 50% šanci na nepřítele nebo poklad
                        Console.WriteLine("Hráč otevřel dveře...");
                        Console.WriteLine($"Šance na nepřítele: {enemyChance}"); // Debug výstup

                        if (enemyChance == 0)
                        {
                            // Vytvoření nepřítele pomocí EnemyFactory
                            Enemy enemy = EnemyFactory.CreateEnemy(); // **ZDŮRAZNI VOLÁNÍ**
                            Console.WriteLine($"Narazil jsi na {enemy.Name}!");

                            // Bitva s nepřítelem
                            while (enemy.Health > 0 && player.Health > 0)
                            {
                                // Hráč útočí
                                enemy.TakeDamage(player.CurrentWeapon.Damage);
                                Console.WriteLine($"Způsobil jsi {player.CurrentWeapon.Damage} poškození {enemy.Name}.");

                                // Nepřítel útočí
                                player.TakeDamage(enemy.BaseDamage);
                                Console.WriteLine($"{enemy.Name} ti způsobil {enemy.BaseDamage} poškození.");

                                // Zkontroluj, zda je nepřítel poražen
                                if (enemy.Health <= 0)
                                {
                                    player.AddGold(enemy.GoldReward);
                                    Console.WriteLine($"Vyhrál jsi! Získal jsi {enemy.GoldReward} zlata.");
                                }

                                // Zkontroluj, zda je hráč poražen
                                if (player.Health <= 0)
                                {
                                    Console.WriteLine("Prohrál jsi! Hra končí.");
                                    break; // Ukonči vnitřní smyčku
                                }
                            }
                        }
                        else
                        {
                            // Nalezení bedny s náhodným množstvím zlata
                            int goldFound = rand.Next(20, 51);
                            Console.WriteLine($"Našel jsi bednu! Získal jsi {goldFound} zlata.");
                            player.AddGold(goldFound); // Přidání zlata hráči
                        }
                    }

                    // Kontrola, zda je hráč poražen
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("Prohrál jsi! Hra končí.");
                        break; // Ukonči hru
                    }
                }

                // Kontrola, zda chce hráč restartovat hru
                Console.WriteLine("Chceš restartovat hru? (Y/N)");
                string restartInput = Console.ReadLine();
                if (restartInput.ToUpper() == "Y")
                {
                    restart = true;
                }
                else
                {
                    restart = false;
                }
            }
        }
    }
}
