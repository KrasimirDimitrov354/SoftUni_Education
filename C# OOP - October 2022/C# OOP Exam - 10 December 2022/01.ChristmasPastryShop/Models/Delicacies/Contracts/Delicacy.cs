using System;
using System.Collections.Generic;
using System.Text;

using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Delicacies.Contracts
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;

        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
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

        public double Price { get; private set; }

        public override string ToString()
        {
            return $"{Name} - {Math.Round(Price, 2):F2} lv";
        }
    }
}
