using System;

namespace WhileLoopLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int biggestNumber = int.MinValue;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                int value = int.Parse(input);

                if (value > biggestNumber)
                {
                    biggestNumber = value;
                }
            }

            Console.WriteLine(biggestNumber);
        }
    }
}
