using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            SetValidFoods();
        }

        public override void Speak()
        {
            Console.WriteLine("Woof!");
        }

        protected override void IncreaseWeight(Food food)
        {
            Weight += 0.4 * food.Quantity;
        }

        protected override void SetValidFoods()
        {
            ValidFoods = new string[] { "Meat" };
        }
    }
}
