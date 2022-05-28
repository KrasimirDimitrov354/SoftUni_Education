using System;

namespace ForStatExer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int sum = 0;
            int highestNumber = 0;

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;

                if (number > highestNumber || i == 0)
                {
                    highestNumber = number;
                }
            }

            if (sum - highestNumber == highestNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {highestNumber}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(highestNumber - (sum - highestNumber))}");
            }
        }
    }
}
