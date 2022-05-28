using System;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count2 = 0;
            int count3 = 0;
            int count4 = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    count2++;
                }

                if (number % 3 == 0)
                {
                    count3++;
                }

                if (number % 4 == 0)
                {
                    count4++;
                }
            }

            Console.WriteLine($"{(((count2 * 1.0) / n) * 100):f2}%");
            Console.WriteLine($"{(((count3 * 1.0) / n) * 100):f2}%");
            Console.WriteLine($"{(((count4 * 1.0) / n) * 100):f2}%");
        }
    }
}
