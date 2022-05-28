using System;

namespace CondStatAdv11
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double output = 0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch (fruit)
                    {
                        case "banana":
                            output = quantity * 2.5;
                            break;
                        case "apple":
                            output = quantity * 1.2;
                            break;
                        case "orange":
                            output = quantity * 0.85;
                            break;
                        case "grapefruit":
                            output = quantity * 1.45;
                            break;
                        case "kiwi":
                            output = quantity * 2.7;
                            break;
                        case "pineapple":
                            output = quantity * 5.5;
                            break;
                        case "grapes":
                            output = quantity * 3.85;
                            break;

                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;

                case "Saturday":
                case "Sunday":
                    switch (fruit)
                    {
                        case "banana":
                            output = quantity * 2.7;
                            break;
                        case "apple":
                            output = quantity * 1.25;
                            break;
                        case "orange":
                            output = quantity * 0.9;
                            break;
                        case "grapefruit":
                            output = quantity * 1.6;
                            break;
                        case "kiwi":
                            output = quantity * 3;
                            break;
                        case "pineapple":
                            output = quantity * 5.6;
                            break;
                        case "grapes":
                            output = quantity * 4.2;
                            break;

                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }

            if (output > 0)
            {
                Console.WriteLine($"{output:f2}");
            }          
        }
    }
}
