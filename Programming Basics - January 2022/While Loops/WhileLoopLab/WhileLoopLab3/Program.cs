using System;

namespace WhileLoopLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());

            int sum = 0;

            while (sum < target)
            {
                int input = int.Parse(Console.ReadLine());
                sum += input;
            }

            Console.WriteLine(sum);
        }
    }
}
