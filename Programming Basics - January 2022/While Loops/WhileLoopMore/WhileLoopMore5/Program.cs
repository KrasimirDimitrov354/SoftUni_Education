using System;

namespace WhileLoopMore5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine($"{(sum / input):f2}");
        }
    }
}
