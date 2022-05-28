using System;

namespace FundamentalsExer4
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = start; i <= finish; i++)
            {
                sum += i;

                if (i != finish)
                {
                    Console.Write($"{i} ");
                }
                else
                {
                    Console.WriteLine(i);
                    Console.WriteLine($"Sum: {sum}");
                }                
            }
        }
    }
}