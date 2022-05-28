using System;

namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputFirst = int.Parse(Console.ReadLine());
            int inputSecond = int.Parse(Console.ReadLine());
            int inputThird = int.Parse(Console.ReadLine());

            int conditionFirst = inputSecond - 1;
            int conditionSecond = inputThird - 1;
            int conditionThird = (inputThird / 2) - 1;

            char symbolFirst = ' ';
            int symbolSecond = 0;
            int symbolThird = 0;
            int symbolFourth = 0;

            for (int i = inputFirst; i <= conditionFirst; i++)
            {
                symbolFirst = (char)i;
                symbolFourth = i;

                for (int x = 1; x <= conditionSecond; x++)
                {
                    symbolSecond = x;

                    for (int y = 1; y <= conditionThird; y++)
                    {
                        symbolThird = y;

                        bool firstSymbolOdd = (i % 2 != 0);
                        bool sumSymbolsOdd = ((symbolSecond + symbolThird + symbolFourth) % 2 != 0);

                        if (firstSymbolOdd && sumSymbolsOdd)
                        {
                            Console.WriteLine($"{symbolFirst}-{symbolSecond}{symbolThird}{symbolFourth}");
                        }
                    }
                }
            }
        }
    }
}