using System;

namespace NestedLoopExer1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string rowOutput = "";
            int rowNumber = 1;
            int counterNumber = 1;
            bool pyramidEnd = false;

            while (!pyramidEnd)
            {
                for (int i = 1; i <= rowNumber; i++)
                {
                    rowOutput += counterNumber + " ";
                    counterNumber++;

                    if (counterNumber > n)
                    {
                        pyramidEnd = true;
                        break;
                    }
                }

                Console.WriteLine(rowOutput);
                rowOutput = "";
                rowNumber++;
            }
        }
    }
}
