
namespace Heroes.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mace : Weapon
    {
        private const int Damage = 25;
        public Mace(string name, int durability) : base(name, durability, Damage)
        {

        }
        public override int DoDamage()
        {
            throw new NotImplementedException();
        }
    }
}
