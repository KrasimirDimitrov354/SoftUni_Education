using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies.Contracts
{
    public class Gingerbread : Delicacy
    {
        private const double gignerbreadPrice = 4;

        public Gingerbread(string name)
            : base(name, gignerbreadPrice)
        {
        }
    }
}
