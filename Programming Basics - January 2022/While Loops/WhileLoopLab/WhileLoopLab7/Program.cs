using System;

namespace WhileLoopLab7
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallestNumber = int.MaxValue;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                int value = int.Parse(input);

                if (value < smallestNumber)
                {
                    smallestNumber = value;
                }
            }

            Console.WriteLine(smallestNumber);
        }
    }
}
