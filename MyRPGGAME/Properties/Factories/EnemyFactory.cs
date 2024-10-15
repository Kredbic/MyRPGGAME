using MyRPGGame.Models;
using System;

namespace MyRPGGame.Factories
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy()
        {
            Random rand = new Random();
            int enemyTypeChance = rand.Next(3); // 0, 1 nebo 2 pro 33% šanci na každý typ nepřítele

            if (enemyTypeChance == 0)
            {
                return new Enemy("Goblin", 2.5, 30, rand.Next(20, 51)); // Základní poškození goblina je 5, sníženo o 50%
            }
            else if (enemyTypeChance == 1)
            {
                return new Enemy("Skeleton", 5, 20, rand.Next(20, 51)); // Základní poškození kostlivce je 10, sníženo o 50%
            }
            else
            {
                return new Enemy("Orc", 7.5, 40, rand.Next(20, 51)); // Základní poškození orka je 15, sníženo o 50%
            }
        }
    }
}
