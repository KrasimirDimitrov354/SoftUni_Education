﻿using System;

namespace WhileLoopLab
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }
                
                Console.WriteLine(input);
            }
        }
    }
}
