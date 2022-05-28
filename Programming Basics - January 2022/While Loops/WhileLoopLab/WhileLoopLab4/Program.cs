using System;

namespace WhileLoopLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int k = 1;

            while (k <= input)
            {
                Console.WriteLine(k);
                k = k * 2 + 1;
            }
        }
    }
}
