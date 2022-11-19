using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Hero : BaseHero
    {
        public Hero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} ";
        }

        public int GetPower()
        {
            return Power;
        }
    }
}
