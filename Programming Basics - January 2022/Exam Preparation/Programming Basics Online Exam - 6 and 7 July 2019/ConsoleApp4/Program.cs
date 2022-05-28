using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string package = Console.ReadLine();
            string VIP = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double total = 0;

            bool firstCondition = days > 1;
            bool secondCondition = (city == "Bansko") || (city == "Borovets") || (city == "Varna") || (city == "Burgas");
            bool thirdCondition = (package == "noEquipment") || (package == "withEquipment") || (package == "noBreakfast") || (package == "withBreakfast");

            if (!firstCondition)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else if (!secondCondition || !thirdCondition)
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                if (days > 7)
                {
                    days--;
                }

                switch (city)
                {
                    case "Bansko":
                    case "Borovets":
                        switch (package)
                        {
                            case "withEquipment":
                                total = days * 100;
                                break;
                            case "noEquipment":
                                total = days * 80;
                                break;
                        }
                        break;

                    case "Varna":
                    case "Burgas":
                        switch (package)
                        {
                            case "withBreakfast":
                                total = days * 130;
                                break;
                            case "noBreakfast":
                                total = days * 100;
                                break;
                        }
                        break;
                    default:
                        break;
                }

                if (VIP == "yes")
                {
                    switch (package)
                    {
                        case "withEquipment":
                            total -= total * 0.1;
                            break;
                        case "noEquipment":
                            total -= total * 0.05;
                            break;
                        case "withBreakfast":
                            total -= total * 0.12;
                            break;
                        case "noBreakfast":
                            total -= total * 0.07;
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine($"The price is {total:f2}lv! Have a nice time!");
            }
        }
    }
}
