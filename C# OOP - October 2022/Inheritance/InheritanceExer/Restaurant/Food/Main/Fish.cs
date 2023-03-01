using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Food.Main
{
    public class Fish : MainDish
    {
        private const double GRAMS = 22.0D;

        public Fish(string name, decimal price)
            : base(name, price, GRAMS)
        {

        }
    }
}
