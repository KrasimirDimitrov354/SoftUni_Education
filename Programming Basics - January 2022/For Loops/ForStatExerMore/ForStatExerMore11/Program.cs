using System;

namespace ForStatExerMore11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddMin = 0;
            double oddMax = 0;
            double oddSum = 0;
            double evenMin = 0;
            double evenMax = 0;
            double evenSum = 0;

            int counter = 0;

            for (int i = 1; i <= n; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());
                counter++;

                switch (counter)
                {
                    case 1:
                        oddSum += currentNum;

                        if (i == 1)
                        {
                            oddMin = currentNum;
                            oddMax = currentNum;
                        }
                        else
                        {
                            if (currentNum > oddMax)
                            {
                                oddMax = currentNum;
                            }
                            else if (currentNum < oddMin)
                            {
                                oddMin = currentNum;
                            }
                        }
                        break;
                    case 2:
                        evenSum += currentNum;
                        counter = 0;

                        if (i == 2)
                        {
                            evenMin = currentNum;
                            evenMax = currentNum;
                        }
                        else
                        {
                            if (currentNum > evenMax)
                            {
                                evenMax = currentNum;
                            }
                            else if (currentNum < evenMin)
                            {
                                evenMin = currentNum;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");

            if (n == 0)
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");

            }

            Console.WriteLine($"EvenSum={evenSum:f2},");

            if (n == 0 || n == 1)
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
