using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Food.Sweet
{
    public class Cake : Dessert
    {
        private const decimal CAKE_PRICE = 5.0M;
        private const double GRAMS = 250.0D;
        private const double CALORIES = 1000.0D;

        public Cake(string name)
            : base(name, CAKE_PRICE, GRAMS, CALORIES)
        {
            
        }
    }
}
