using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : Hero
    {
        private const int POWER = 100;

        public Paladin(string name)
            : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {Power}";
        }
    }
}
