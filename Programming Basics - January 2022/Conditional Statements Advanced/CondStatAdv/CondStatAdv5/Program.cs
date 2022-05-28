using System;

namespace CondStatAdv5
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double output = 0;

            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        output = quantity * 0.5;
                        break;
                    case "water":
                        output = quantity * 0.8;
                        break;
                    case "beer":
                        output = quantity * 1.2;
                        break;
                    case "sweets":
                        output = quantity * 1.45;
                        break;
                    case "peanuts":
                        output = quantity * 1.6;
                        break;
                }
            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        output = quantity * 0.4;
                        break;
                    case "water":
                        output = quantity * 0.7;
                        break;
                    case "beer":
                        output = quantity * 1.15;
                        break;
                    case "sweets":
                        output = quantity * 1.3;
                        break;
                    case "peanuts":
                        output = quantity * 1.5;
                        break;
                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        output = quantity * 0.45;
                        break;
                    case "water":
                        output = quantity * 0.7;
                        break;
                    case "beer":
                        output = quantity * 1.1;
                        break;
                    case "sweets":
                        output = quantity * 1.35;
                        break;
                    case "peanuts":
                        output = quantity * 1.55;
                        break;
                }
            }

            Console.WriteLine(output);
        }
    }
}
