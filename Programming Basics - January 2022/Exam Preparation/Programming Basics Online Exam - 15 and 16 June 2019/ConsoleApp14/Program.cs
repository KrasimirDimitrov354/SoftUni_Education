using System;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string package = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            double total = 0.0;

            switch (movie)
            {
                case "John Wick":
                    switch (package)
                    {
                        case "Drink":
                            total = tickets * 12;
                            break;
                        case "Popcorn":
                            total = tickets * 15;
                            break;
                        case "Menu":
                            total = tickets * 19;
                            break;
                    }
                    break;

                case "Star Wars":
                    switch (package)
                    {
                        case "Drink":
                            total = tickets * 18;
                            break;
                        case "Popcorn":
                            total = tickets * 25;
                            break;
                        case "Menu":
                            total = tickets * 30;
                            break;
                    }
                    break;

                case "Jumanji":
                    switch (package)
                    {
                        case "Drink":
                            total = tickets * 9;
                            break;
                        case "Popcorn":
                            total = tickets * 11;
                            break;
                        case "Menu":
                            total = tickets * 14;
                            break;
                    }
                    break;
            }

            if (movie == "Star Wars" && tickets >= 4)
            {
                total -= total * 0.3;
            }

            if (movie == "Jumanji" && tickets == 2)
            {
                total -= total * 0.15;
            }

            Console.WriteLine($"Your bill is {total:f2} leva.");
        }
    }
}
