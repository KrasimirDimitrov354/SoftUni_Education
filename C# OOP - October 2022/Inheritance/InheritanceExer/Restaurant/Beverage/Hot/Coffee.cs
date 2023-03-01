using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverage.Hot
{
    public class Coffee : HotBeverage
    {
        private const decimal COFFEE_PRICE = 3.50M;
        private const double COFFEE_MILLIMETERS = 50.0D;

        public Coffee(string name, double caffeine)
            : base(name, COFFEE_PRICE, COFFEE_MILLIMETERS)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
