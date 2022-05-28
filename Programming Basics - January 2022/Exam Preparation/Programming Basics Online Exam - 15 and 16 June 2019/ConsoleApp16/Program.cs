using System;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            int seatsTotal = int.Parse(Console.ReadLine());
            int seatsBeingTaken = 0;
            int seatsTaken = 0;
            double profit = 0;

            while (true)
            { 
                string input = Console.ReadLine();

                if (input == "Movie time!")
                {
                    Console.WriteLine($"There are {seatsTotal - seatsTaken} seats left in the cinema.");
                    break;
                }
                else if (seatsTaken >= seatsTotal)
                {
                    Console.WriteLine("The cinema is full.");
                    break;
                }
                else
                {
                    seatsBeingTaken = int.Parse(input);

                    if (seatsBeingTaken + seatsTaken > seatsTotal)
                    {
                        Console.WriteLine("The cinema is full.");
                        break;
                    }
                    else
                    {
                        seatsTaken += seatsBeingTaken;
                    }

                    if (seatsBeingTaken % 3 == 0)
                    {
                        profit += (seatsBeingTaken * 5) - 5;
                    }
                    else
                    {
                        profit += seatsBeingTaken * 5;
                    }
                }
            }

            Console.WriteLine($"Cinema income - {profit} lv.");
        }
    }
}
