﻿using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            double bonus = 0;

            if (input <= 100)
            {
                bonus = 5;
            }
            else if (input > 100 & input <= 1000)
            {
                bonus = input * 0.2;
            }
            else
            {
                bonus = input * 0.1;
            }
            
            if (input % 2 == 0)
            {
                bonus++;
            }
            else if (input % 10 == 5)
            {
                bonus = bonus + 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(input + bonus);
        }
    }
}
