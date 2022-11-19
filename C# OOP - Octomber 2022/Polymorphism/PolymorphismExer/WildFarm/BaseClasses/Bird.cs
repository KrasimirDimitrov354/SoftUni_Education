using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        protected double WingSize { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Math.Round(Weight, 2)}, {FoodEaten}]";
        }
    }
}
