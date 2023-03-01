using System;
using System.Collections.Generic;
using System.Text;

using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails.Contracts
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }

        public string Size { get; private set; }

        public double Price
        {
            get { return price; }
            set
            {
                switch (Size)
                {
                    case "Large":
                        price = value;
                        break;
                    case "Middle":
                        price = (value / 3) * 2;
                        break;
                    case "Small":
                        price = value / 3;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Math.Round(price, 2):F2} lv";
        }
    }
}
