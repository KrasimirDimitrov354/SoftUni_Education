using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            SetValidFoods();
        }

        public override void Speak()
        {
            Console.WriteLine("Meow");
        }

        protected override void IncreaseWeight(Food food)
        {
            Weight += 0.3 * food.Quantity;
        }

        protected override void SetValidFoods()
        {
            ValidFoods = new string[] { "Vegetable", "Meat" };
        }
    }
}
