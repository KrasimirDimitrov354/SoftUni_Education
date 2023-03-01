using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Contracts
{
    public class Hibernation : Cocktail
    {
        private const double WINE_PRICE = 10.5;

        public Hibernation(string cocktailName, string size)
            : base(cocktailName, size, WINE_PRICE)
        {
        }
    }
}
