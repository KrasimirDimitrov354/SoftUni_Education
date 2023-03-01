using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            SetValidFoods();
        }

        public override void Speak()
        {
            Console.WriteLine("Cluck");
        }

        protected override void IncreaseWeight(Food food)
        {
            Weight += 0.35 * food.Quantity;
        }

        protected override void SetValidFoods()
        {
            ValidFoods = new string[]{ "Vegetable", "Fruit", "Meat", "Seeds" };
        }
    }
}
