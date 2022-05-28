using System;

namespace ForStatExerMore8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int pair1Num1 = 0;
            int pair1Num2 = 0;
            int pair2Num1 = 0;
            int pair2Num2 = 0;
            int pair1Result = 0;
            int pair2Result = 0;

            int counter = 0;
            int currentResult = 0;
            int diffResult = int.MinValue;

            bool hasDifference = false;

            for (int i = 1; i <= n * 2; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                counter++;

                if (counter == 1)
                {
                    pair1Num1 = currentNum;
                }
                else if (counter == 2)
                {
                    pair1Num2 = currentNum;
                    pair1Result = pair1Num1 + pair1Num2;
                }
                else if (counter == 3)
                {
                    pair2Num1 = currentNum;
                }
                else if (counter == 4)
                {
                    pair2Num2 = currentNum;
                    pair2Result = pair2Num1 + pair2Num2;
                    counter = 0;
                }

               if ((i >= 4) & (i % 2 == 0))
                {
                    if (pair1Result != pair2Result)
                    {
                        hasDifference = true;

                        if (pair1Result > pair2Result)
                        {
                            currentResult = pair1Result - pair2Result;
                        }
                        else
                        {
                            currentResult = pair2Result - pair1Result;
                        }
                    }
                    else
                    {
                        currentResult = pair1Result;
                    }

                    if (currentResult > diffResult)
                    {
                        diffResult = currentResult;
                    }
                }
            }

            if (n == 1)
            {
                Console.WriteLine($"Yes, value={pair1Result}");
            }
            else if (hasDifference)
            {
                Console.WriteLine($"No, maxdiff={diffResult}");
            }
            else
            {
                Console.WriteLine($"Yes, value={currentResult}");
            }
        }
    }
}
