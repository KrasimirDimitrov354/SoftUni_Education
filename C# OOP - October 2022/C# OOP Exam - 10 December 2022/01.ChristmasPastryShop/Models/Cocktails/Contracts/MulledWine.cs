using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Contracts
{
    public class MulledWine : Cocktail
    {
        private const double WINE_PRICE = 13.5;

        public MulledWine(string cocktailName, string size)
            : base(cocktailName, size, WINE_PRICE)
        {
        }
    }
}
