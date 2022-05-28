using System;

namespace ForStatLab7
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());

            int sum = 0;
            int counter = 0;

            if (countNumbers == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (counter < countNumbers)
                {
                    int currentNumber = int.Parse(Console.ReadLine());
                    sum += currentNumber;
                    counter++;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
