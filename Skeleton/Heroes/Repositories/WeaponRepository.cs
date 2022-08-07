

namespace Heroes.Repositories
{
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly Dictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }

        
        public IReadOnlyCollection<IWeapon> Models => throw new NotImplementedException();

        public void Add(IWeapon model) => this.weapons.Add(model.Name, model);

        public IWeapon FindByName(string name)
        {
            if (this.weapons.ContainsKey(name))
            {
                return this.weapons[name];
            }
            return null;
        }

        public bool Remove(IWeapon model)
        {
            throw new NotImplementedException();
        }
    }
}
