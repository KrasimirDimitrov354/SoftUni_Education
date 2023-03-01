using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : Hero
    {
        private const int POWER = 80;

        public Rogue(string name)
            : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {Power} damage";
        }
    }
}
