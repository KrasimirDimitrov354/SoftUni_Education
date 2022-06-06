using System;

namespace ConsoleApp1
{
    class Program
    {
        //Train
        //A train has a n number of wagons. On the next n lines, you will receive the number of people that are going to get on each wagon.
        //Print out the number of passengers in each wagon followed by the total number of passengers on the train.
        //Examples
        //Input     Output
        //3         13 24 8
        //13        45
        //24
        //8
        //Input     Output
        //6         3 52 71 13 65 4
        //3         208
        //52
        //71
        //13
        //65
        //4
        //Input     Output
        //1         100
        //100       100

        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] passengers = new int[wagons];
            int total = 0;

            for (int i = 0; i < passengers.Length; i++)
            {
                int passengersInWagon = int.Parse(Console.ReadLine());
                passengers[i] = passengersInWagon;
                total += passengersInWagon;
            }

            foreach (var wagon in passengers)
            {
                Console.Write($"{wagon} ");
            }
            Console.WriteLine();
            Console.WriteLine(total);
        }
    }
}
