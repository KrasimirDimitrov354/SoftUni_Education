using System;

namespace FundamentalsExer7
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = 0.0;
            double productPrice = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine($"Change: {money:f2}");
                    break;
                }
                else
                {
                    bool isNumber = double.TryParse(input, out double change);

                    if (isNumber)
                    {
                        if (change == 0.1 || change == 0.2 || change == 0.5 || change == 1 || change == 2)
                        {
                            money += change;
                        }
                        else
                        {
                            Console.WriteLine($"Cannot accept {change}");
                        }
                    }
                    else
                    {
                        if (input != "Start")
                        {
                            bool isValid = true;

                            switch (input)
                            {
                                case "Nuts":
                                    productPrice = 2;
                                    break;
                                case "Water":
                                    productPrice = 0.7;
                                    break;
                                case "Crisps":
                                    productPrice = 1.5;
                                    break;
                                case "Soda":
                                    productPrice = 0.8;
                                    break;
                                case "Coke":
                                    productPrice = 1;
                                    break;
                                default:
                                    Console.WriteLine("Invalid product");
                                    isValid = false;
                                    break;
                            }

                            if (isValid)
                            {
                                if (money >= productPrice)
                                {
                                    Console.WriteLine($"Purchased {input.ToLower()}");
                                    money -= productPrice;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                }
                            }
                            
                        }                       
                    }
                }
            }
        }
    }
}
