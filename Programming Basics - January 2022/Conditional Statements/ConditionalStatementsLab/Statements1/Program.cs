﻿using System;

namespace Statements1
{
    class Program
    {
        static void Main(string[] args)
        {
            double score = double.Parse(Console.ReadLine());

            if (score >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
