using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        //Train
        //On the first line, we will receive a list of wagons(integers).
        //Each integer represents the number of passengers that are currently in each wagon of a passenger train.
        //On the next line you will receive the max capacity of a wagon represented as a single integer.
        //Until you receive the "end" command, you will be receiving two types of input:
        //  •	Add {passengers} – add a wagon to the end of the train with the given number of passengers.
        //  •	{passengers} - find a single wagon to fit all the incoming passengers (starting from the first wagon).
        //
        //In the end, print the final state of the train (all the wagons separated by a space).
        //
        //Example
        //Input                     Output
        //32 54 21 12 4 0 23        72 54 21 12 4 75 23 10 0
        //75
        //Add 10
        //Add 0
        //30
        //10
        //75
        //end
        //Input                     Output
        //0 0 0 10 2 4              10 10 10 10 10 10 10
        //10
        //Add 10
        //10
        //10
        //10
        //8
        //6
        //end

        static void Main()
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                List<string> commands = Console.ReadLine()
                .Split(' ')
                .ToList();

                string command = commands[0];

                if (command == "end")
                {
                    Console.WriteLine(string.Join(' ', wagons));
                    break;
                }
                else
                {
                    switch (command)
                    {
                        case "Add":
                            int wagon = int.Parse(commands[1]);
                            wagons.Add(wagon);
                            break;
                        default:
                            int incomingPassengers = int.Parse(command);

                            for (int i = 0; i < wagons.Count; i++)
                            {
                                int wagonPassengers = wagons[i];

                                if (wagonPassengers + incomingPassengers <= maxCapacity)
                                {
                                    wagons[i] = wagonPassengers + incomingPassengers;
                                    break;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
