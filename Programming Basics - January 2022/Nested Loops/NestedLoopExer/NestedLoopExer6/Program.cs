using System;

namespace NestedLoopExer6
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentMovie = "";
            double seatsAvailable = 0;
            double seatsOccupied = 0;
            bool seatsLeft = true;

            double ticketsStudent = 0;
            double ticketsStandard = 0;
            double ticketsChildren = 0;
            double ticketsTotal = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Finish")
                {
                    break;
                }
                else
                {
                    if ((input == "student") || (input == "standard") || (input == "kid"))
                    {
                        ticketsTotal++;
                        seatsOccupied++;

                        switch (input)
                        {
                            case "student":
                                ticketsStudent++;
                                break;
                            case "standard":
                                ticketsStandard++;
                                break;
                            case "kid":
                                ticketsChildren++;
                                break;
                            default:
                                break;
                        }

                        if (seatsOccupied == seatsAvailable)
                        {
                            seatsLeft = false;
                        }
                    }
                    else if (input != "End")
                    {
                        bool isNumber = double.TryParse(input, out seatsAvailable);

                        if (!isNumber)
                        {
                            currentMovie = input;
                        }
                    }

                    if ((input == "End") || (!seatsLeft))
                    {
                        Console.WriteLine($"{currentMovie} - {((seatsOccupied / seatsAvailable) * 100):f2}% full.");

                        seatsOccupied = 0;
                        seatsLeft = true;
                    }
                }
            }

            Console.WriteLine($"Total tickets: {ticketsTotal}");
            Console.WriteLine($"{((ticketsStudent / ticketsTotal) * 100):f2}% student tickets.");
            Console.WriteLine($"{((ticketsStandard / ticketsTotal) * 100):f2}% standard tickets.");
            Console.WriteLine($"{((ticketsChildren / ticketsTotal) * 100):f2}% kids tickets.");
        }
    }
}
