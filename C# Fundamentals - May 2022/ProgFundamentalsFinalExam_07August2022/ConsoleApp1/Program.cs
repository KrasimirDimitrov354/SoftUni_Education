﻿using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = 100f == 100d;
            int value = int.Parse(isTrue);
            Console.WriteLine(value);
        }
    }
}
