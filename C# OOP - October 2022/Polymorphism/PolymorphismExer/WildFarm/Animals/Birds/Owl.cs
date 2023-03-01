using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            SetValidFoods();
        }

        public override void Speak()
        {
            Console.WriteLine("Hoot Hoot");
        }

        protected override void IncreaseWeight(Food food)
        {
            Weight += 0.25 * food.Quantity;
        }

        protected override void SetValidFoods()
        {
            ValidFoods = new string[] { "Meat" };
        }
    }
}
