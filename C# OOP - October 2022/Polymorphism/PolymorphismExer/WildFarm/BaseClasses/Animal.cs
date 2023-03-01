using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        protected string Name { get; set; }
        protected double Weight { get; set; }
        protected int FoodEaten { get; set; }
        protected string[] ValidFoods { get; set; }

        public void Eat(Food food)
        {
            FoodIsValid(food);
        }

        protected void FoodIsValid(Food food)
        {
            string foodType = food.GetType().Name;

            if (ValidFoods.Contains(foodType))
            {
                IncreaseWeight(food);
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {foodType}!");
            }
        }

        public abstract void Speak();
        protected abstract void IncreaseWeight(Food food);
        protected abstract void SetValidFoods();
    }
}
