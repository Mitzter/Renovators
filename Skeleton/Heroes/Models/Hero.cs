
namespace Heroes.Models
{
    using global::Heroes.Models.Contracts;
    
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        
        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weapon) => this.Weapon = Weapon;


        public void TakeDamage(int points)
        {
            var armourLeft = this.Armour - points;

            if (armourLeft >= 0)
            {
                this.Armour = armourLeft;
            }
            else
            {
                this.Armour = 0;

                var damage = -armourLeft;

                var healthLeft = this.Health - damage;

                if (healthLeft < 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health = healthLeft;
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name}: {this.Name}");
            result.AppendLine($"--Health: {this.Health}");
            result.AppendLine($"--Armour: {this.Armour}");
            result.AppendLine($"--Weapon: {(this.Weapon == null ? "Unarmed" : this.Weapon.Name)}");

            return result.ToString();
        }
    }
}
