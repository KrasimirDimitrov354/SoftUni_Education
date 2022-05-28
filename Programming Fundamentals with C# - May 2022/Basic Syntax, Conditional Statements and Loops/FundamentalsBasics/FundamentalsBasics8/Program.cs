using System;

namespace FundamentalsBasics8
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int oddNum = 1;
            int oddSum = 0;

            for (int i = 1; i <= input; i++)
            {
                Console.WriteLine(oddNum);
                oddSum += oddNum;
                oddNum += 2;
            }

            Console.WriteLine($"Sum: {oddSum}");
        }
    }
}
