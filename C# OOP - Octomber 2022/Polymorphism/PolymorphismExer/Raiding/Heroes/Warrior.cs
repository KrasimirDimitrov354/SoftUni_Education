using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : Hero
    {
        private const int POWER = 100;

        public Warrior(string name)
            : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {Power} damage";
        }
    }
}
