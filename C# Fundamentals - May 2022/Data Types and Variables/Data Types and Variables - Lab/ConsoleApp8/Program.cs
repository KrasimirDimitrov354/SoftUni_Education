﻿using System;

namespace ConsoleApp8
{
    class Program
    {
        //8.	Town Info
        //You will be given 3 lines of input. On the first line you will be given the name of the town, on the second – the population and on the third the area.
        //Use the correct data types and print the result in the following format:
        //"Town {town name} has population of {population} and area {area} square km".
        //Examples
        //Input         Output
        //Sofia
        //1286383
        //492	        Town Sofia has population of 1286383 and area 492 square km.
        //Input         Output
        //Kaliningrad
        //437456
        //223	        Town Kaliningrad has population of 437456 and area 223 square km.

        static void Main()
        {
            string town = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {town} has population of {population} and area {area} square km.");
        }
    }
}
