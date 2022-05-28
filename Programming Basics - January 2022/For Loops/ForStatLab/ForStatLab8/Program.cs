using System;

namespace ForStatLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int largestNumber = 0;
            int lowestNumber = 0;

            for (int i = 0; i < count; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if ((currentNumber > largestNumber) || (i == 0))
                {
                    largestNumber = currentNumber;
                }

                if ((currentNumber < lowestNumber) || (i == 0))
                {
                    lowestNumber = currentNumber;
                }
            }

            Console.WriteLine($"Max number: {largestNumber}");
            Console.WriteLine($"Min number: {lowestNumber}");
        }
    }
}
