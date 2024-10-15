namespace MyRPGGame.Models
{
    public class Player
    {
        public double Health { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public double Gold { get; set; }

        public Player()
        {
            Health = 120;
            CurrentWeapon = null;
            Gold = 0;
        }

        public void TakeDamage(double damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void Heal(double amount)
        {
            Health += amount;
            if (Health > 120) Health = 120;
        }

        public void AddGold(double amount)
        {
            Gold += amount;
        }
    }
}
