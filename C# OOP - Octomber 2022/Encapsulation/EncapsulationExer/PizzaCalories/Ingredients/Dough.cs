using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough : Ingredient
    {
        private string bakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
            : base(flourType, weight)
        {
            BakingTechnique = bakingTechnique;
        }

        protected override string Type 
        { 
            get => base.Type;
            set 
            {
                switch (Convert(value))
                {
                    case "White":
                    case "Wholegrain":
                        base.Type = Convert(value);
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            } 
        }

        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                switch (Convert(value))
                {
                    case "Crispy":
                    case "Chewy":
                    case "Homemade":
                        bakingTechnique = Convert(value);
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        protected override double Weight
        { 
            get => base.Weight;
            set 
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                base.Weight = value; 
            }
        }

        public double TotalCalories { get { return GetTotalCalories(GetModifier(Type), GetModifier(BakingTechnique)); } }

        private double GetModifier(string input)
        {
            switch (input)
            {
                case "White":
                    return 1.5;
                case "Wholegrain":
                case "Homemade":
                    return 1;
                case "Crispy":
                    return 0.9;
                case "Chewy":
                    return 1.1;
                default:
                    return 0;
            }
        }
    }
}
