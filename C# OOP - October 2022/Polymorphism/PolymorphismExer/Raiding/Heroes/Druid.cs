using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : Hero
    {
        private const int POWER = 80;

        public Druid(string name)
            : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {Power}";
        }
    }
}
