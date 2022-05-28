using System;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractDuration = Console.ReadLine();
            string contractType = Console.ReadLine();
            string mobileData = Console.ReadLine();
            int paymentsCount = int.Parse(Console.ReadLine());

            double total = 0;

            switch (contractDuration)
            {
                case "one":
                    switch (contractType)
                    {
                        case "Small":
                            total = paymentsCount * 9.98;
                            break;
                        case "Middle":
                            total = paymentsCount * 18.99;
                            break;
                        case "Large":
                            total = paymentsCount * 25.98;
                            break;
                        case "ExtraLarge":
                            total = paymentsCount * 35.99;
                            break;
                    }
                    break;

                case "two":
                    switch (contractType)
                    {
                        case "Small":
                            total = paymentsCount * 8.58;
                            break;
                        case "Middle":
                            total = paymentsCount * 17.09;
                            break;
                        case "Large":
                            total = paymentsCount * 23.59;
                            break;
                        case "ExtraLarge":
                            total = paymentsCount * 31.79;
                            break;
                    }
                    break;
            }

            if (mobileData == "yes")
            {
                if (contractType == "Small")
                {
                    total += paymentsCount * 5.5;
                }
                else if (contractType == "Middle" || contractType == "Large")
                {
                    total += paymentsCount * 4.35;
                }
                else if (contractType == "ExtraLarge")
                {
                    total += paymentsCount * 3.85;
                }
            }

            if (contractDuration == "two")
            {
                total -= total * 0.0375;
            }

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}