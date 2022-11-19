using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping : Ingredient
    {
        public Topping(string type, double weight)
            : base(type, weight)
        {

        }

        protected override string Type
        {
            get => base.Type;
            set
            {
                switch (Convert(value))
                {
                    case "Meat":
                    case "Veggies":
                    case "Cheese":
                    case "Sauce":
                        base.Type = Convert(value);
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {Convert(value)} on top of your pizza.");
                }
            }
        }

        protected override double Weight
        {
            get => base.Weight;
            set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                base.Weight = value;
            }
        }

        public double TotalCalories { get { return GetTotalCalories(GetModifier(Type)); } }

        private double GetModifier(string input)
        {
            switch (input)
            {
                case "Meat":
                    return 1.2;
                case "Veggies":
                    return 0.8;
                case "Cheese":
                    return 1.1;
                case "Sauce":
                    return 0.9;   
                default:
                    return 0;
            }
        }
    }
}
