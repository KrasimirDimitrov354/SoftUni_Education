using System;

namespace ForStatLab9
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstSum += number;
            }

            for (int y = 0; y < count; y++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSum += number;
            }

            if (firstSum == secondSum)
            {
                Console.WriteLine($"Yes, sum = {firstSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(firstSum - secondSum)}");
            }
        }
    }
}
