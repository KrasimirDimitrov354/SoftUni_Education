using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public abstract class Ingredient
    {
        public Ingredient(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        protected virtual string Type { get; set; }
        protected virtual double Weight { get; set; }

        protected double GetTotalCalories(params double[] modifiers)
        {
            double total = 2 * Weight;

            foreach (double modifier in modifiers)
            {
                total *= modifier;
            }

            return total;
        }

        protected static string Convert(string value)
        {
            value = value.ToLower();
            char[] arr = value.ToCharArray();
            arr[0] = Char.ToUpper(arr[0]);

            return new String(arr);
        }
    }
}
