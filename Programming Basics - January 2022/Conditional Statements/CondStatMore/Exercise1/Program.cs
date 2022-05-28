using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            double V = double.Parse(Console.ReadLine());
            double P1 = double.Parse(Console.ReadLine());
            double P2 = double.Parse(Console.ReadLine());
            double H = double.Parse(Console.ReadLine());

            double totalP1 = P1 * H;
            double totalP2 = P2 * H;
            double totalP = totalP1 + totalP2;

            if (totalP <= V)
            {
                Console.WriteLine($"The pool is {(totalP / V) * 100}% full. Pipe 1: {(totalP1 / totalP) * 100}%. Pipe 2: {(totalP2 / totalP) * 100}%.");
            }
            else
            {
                Console.WriteLine($"For {H} hours the pool overflows with {totalP - V} liters.");
            }

        }
    }
}
