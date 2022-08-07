
namespace Heroes.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Claymore : Weapon
    {
        private const int Damage = 20;
        public Claymore(string name, int durability) : base(name, durability, Damage)
        {

        }
        public override int DoDamage()
        {
            throw new NotImplementedException();
        }
    }
}
