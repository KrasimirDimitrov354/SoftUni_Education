using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        protected string Name { get; set; }
        protected int Power { get; set; }

        public abstract string CastAbility();
    }
}
