using System;

namespace NestedLoopExer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            double sumOdd = 0;
            double sumEven = 0;

            for (int i = x; i <= y; i++)
            {
                string currentNum = i.ToString();

                for (int j = 0; j < currentNum.Length; j++)
                {
                    double currentValue = Char.GetNumericValue(currentNum[j]);

                    if (j % 2 != 0)
                    {
                        sumOdd += currentValue;
                    }
                    else
                    {
                        sumEven += currentValue;
                    }
                }

                if (sumOdd == sumEven)
                {
                    Console.Write(currentNum + " ");
                }

                sumOdd = 0;
                sumEven = 0;
            }
        }
    }
}
