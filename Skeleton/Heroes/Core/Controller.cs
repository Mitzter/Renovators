

namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Repositories;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists");
            }

            IHero hero = type switch
            {
                nameof(Knight) => new Knight(name, health,armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException("Invalid hero type.")
            };

            this.heroes.Add(hero);

            var heroAlias = type == nameof(Knight)
                ? $"Sir {hero.Name}"
                : $"{nameof(Barbarian)} {hero.Name}";


            return $"Successfully added {heroAlias} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists");
            }
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            throw new NotImplementedException();
        }

        

        public string HeroReport()
        {
            throw new NotImplementedException();
        }

        public string StartBattle()
        {
            throw new NotImplementedException();
        }
    }
}
