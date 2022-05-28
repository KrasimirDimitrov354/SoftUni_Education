using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameCurrent = "";
            string nameWinner = "";
            int pointsCurrent = 0;
            int pointsWinner = 0;
            int valueCurrent = 0;           
            int valueASCII = 0;           
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }
                else
                {
                    bool isNumber = int.TryParse(input, out valueCurrent);

                    if (!isNumber)
                    {
                        nameCurrent = input;
                    }
                    else
                    {
                        valueASCII = (int)nameCurrent[counter];
                        counter++;

                        if (valueCurrent == valueASCII)
                        {
                            pointsCurrent += 10;
                        }
                        else
                        {
                            pointsCurrent += 2;
                        }

                        if (pointsCurrent >= pointsWinner)
                        {
                            pointsWinner = pointsCurrent;
                            nameWinner = nameCurrent;
                        }
                    }
                    
                    if (counter > nameCurrent.Length - 1)
                    {
                        counter = 0;
                        pointsCurrent = 0;
                    }
                }
            }

            Console.WriteLine($"The winner is {nameWinner} with {pointsWinner} points!");
        }
    }
}
