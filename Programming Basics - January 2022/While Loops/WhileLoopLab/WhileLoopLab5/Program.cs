using System;

namespace WhileLoopLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "default";
            double total = 0;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "NoMoreMoney")
                {
                    break;
                }

                double payment = double.Parse(input);

                if (payment < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {payment:f2}");
                total += payment;
            }

            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
