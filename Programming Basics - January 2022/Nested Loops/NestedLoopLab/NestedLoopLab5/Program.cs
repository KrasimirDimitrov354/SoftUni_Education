using System;

namespace NestedLoopLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentCountry = "";
            double currentTarget = 0;
            double currentSavings = 0;
            double totalSavings = 0;

            double number = 0;
            bool numIsTarget = true;
            bool noOutput = true;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else
                {
                    bool isNumber = double.TryParse(input, out number);

                    if (isNumber)
                    {                       
                        if (numIsTarget)
                        {
                            currentTarget = number;
                            numIsTarget = false;
                        }
                        else
                        {
                            currentSavings = number;
                            totalSavings += currentSavings;

                            if (totalSavings >= currentTarget)
                            {                              
                                Console.WriteLine($"Going to {currentCountry}!");

                                numIsTarget = true;
                                noOutput = false;
                                totalSavings = 0;                              
                            }
                        }
                    }
                    else
                    {
                        currentCountry = input;
                        numIsTarget = true;
                        totalSavings = 0;
                    }
                }
            }

            if (noOutput)
            {
                Console.WriteLine(" ");
            }
        }
    }
}
