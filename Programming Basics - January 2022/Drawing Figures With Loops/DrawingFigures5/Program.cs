using System;

namespace DrawingFigures5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int counterEmpty = 0;
            int counterSymbols = 0;
            int lastEmpty = input - 1;

            for (int i = 1; i <= input; i++)
            {
                if (i == 1 || i == input)
                {
                    Console.Write("+");

                    while (true)
                    {
                        counterSymbols++;

                        if (counterSymbols % 2 == 0)
                        {
                            Console.Write("-");
                        }
                        else
                        {
                            Console.Write(" ");
                            counterEmpty++;
                        }

                        if (counterEmpty == lastEmpty)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("+");
                    counterSymbols = 0;
                    counterEmpty = 0;
                }
                else
                {
                    Console.Write("|");

                    while (true)
                    {
                        counterSymbols++;

                        if (counterSymbols % 2 == 0)
                        {
                            Console.Write("-");
                        }
                        else
                        {
                            Console.Write(" ");
                            counterEmpty++;
                        }

                        if (counterEmpty == lastEmpty)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("|");
                    counterSymbols = 0;
                    counterEmpty = 0;
                }
            }
        }
    }
}
