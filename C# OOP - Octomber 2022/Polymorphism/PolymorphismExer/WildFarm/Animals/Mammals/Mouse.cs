using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            SetValidFoods();
        }

        public override void Speak()
        {
            Console.WriteLine("Squeak");
        }

        protected override void IncreaseWeight(Food food)
        {
            Weight += 0.1 * food.Quantity;
        }

        protected override void SetValidFoods()
        {
            ValidFoods = new string[] { "Vegetable", "Fruit" };
        }
    }
}
