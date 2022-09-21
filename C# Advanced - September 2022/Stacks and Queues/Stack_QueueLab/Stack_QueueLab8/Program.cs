using System;
using System.Collections.Generic;

namespace Stack_QueueLab8
{
    //Traffic Jam
    //Create a program that simulates the queue that forms during a traffic jam.
    //
    //When the light goes green N number of cars pass the crossroads and a message "{car} passed!" is displayed for each.
    //The program reads the vehicles that arrive after that and adds them to the queue until the next "green" command is given.
    //
    //When the "end" command is given, terminate the program and display a message with the total number of cars that passed the crossroads.
    //
    //Input
    //  •	On the first line you will receive N – the number of cars that can pass during a green light.
    //  •	Until the "end" command is given, on the next lines you will receive commands – a single string, either a car or "green".
    //Output
    //  •	Every time the "green" command is given, print out a message for every car that passes the crossroads in the format "{car} passed!".
    //  •	When the "end" command is given, print out a message in the format "{number of cars} cars passed the crossroads.".
    //
    //Examples
    //Input         Output                              Input           Output
    //4             Hummer H2 passed!                   3               Enzo's car passed!
    //Hummer H2     Audi passed!                        Enzo's car      Jade's car passed!
    //Audi          Lada passed!                        Jade's car      Mercedes CLS passed!
    //Lada          Tesla passed!                       Mercedes CLS    Audi passed!
    //Tesla         Renault passed!                     Audi            BMW X5 passed!
    //Renault       Trabant passed!                     green           5 cars passed the crossroads.
    //Trabant       Mercedes passed!                    BMW X5
    //Mercedes      MAN Truck passed!                   green
    //MAN Truck     8 cars passed the crossroads.       end
    //green
    //green
    //Tesla
    //Renault
    //Trabant
    //end

    class Program
    {
        static void Main()
        {
            int carsThatPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine($"{carsPassed} cars passed the crossroads.");
                    break;
                }
                else if (input == "green")
                {
                    for (int i = 0; i < carsThatPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            carsPassed++;
                        }
                        else
                        {
                            break;
                        }                       
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
        }
    }
}
