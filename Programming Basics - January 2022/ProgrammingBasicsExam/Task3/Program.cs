using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double total = 0;

            if (group <= 5)
            {
                switch (season)
                {
                    case "spring":
                        total = group * 50;
                        break;
                    case "summer":
                        total = group * 48.5;
                        break;
                    case "autumn":
                        total = group * 60;
                        break;
                    case "winter":
                        total = group * 86;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (season)
                {
                    case "spring":
                        total = group * 48;
                        break;
                    case "summer":
                        total = group * 45;
                        break;
                    case "autumn":
                        total = group * 49.5;
                        break;
                    case "winter":
                        total = group * 85;
                        break;
                    default:
                        break;
                }
            }

            if (season == "summer")
            {
                total -= total * 0.15;
            }
            else if (season == "winter")
            {
                total += total * 0.08;
            }

            Console.WriteLine($"{total:f2} leva.");
        }
    }
}
