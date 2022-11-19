using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value) ||
                    value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough { get; set; }

        public double TotalCalories
        {
            get
            {
                if (Dough == null)
                {
                    return 0;
                }

                return Dough.TotalCalories + toppings.Sum(t => t.TotalCalories);
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count < 10)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
    }
}
