namespace MyRPGGame.Models
{
    public class Enemy
    {
        public string Name { get; }
        public double BaseDamage { get; }
        public double Health { get; set; }
        public double GoldReward { get; }

        public Enemy(string name, double baseDamage, double health, double goldReward)
        {
            Name = name;
            BaseDamage = baseDamage;
            Health = health;
            GoldReward = goldReward;
        }

        public void TakeDamage(double damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }
    }
}
