using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            SetValidFoods();
        }

        public override void Speak()
        {
            Console.WriteLine("ROAR!!!");
        }

        protected override void IncreaseWeight(Food food)
        {
            Weight += 1 * food.Quantity;
        }

        protected override void SetValidFoods()
        {
            ValidFoods = new string[] { "Meat" };
        }
    }
}
