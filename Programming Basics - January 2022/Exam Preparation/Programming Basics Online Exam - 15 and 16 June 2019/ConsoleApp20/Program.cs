using System;

namespace ConsoleApp20
{
    class Program
    {
        static void Main(string[] args)
        {            
            int counter = 0;
            int uppercaseCounter = 0;
            int lowercaseCounter = 0;
            int currentSum = 0;
            int maxSum = 0;
            string bestMovie = "";
            bool limitReached = false;

            while (true)
            {
                if (limitReached)
                {
                    break;
                }

                string input = Console.ReadLine();
                counter++;

                if (input == "STOP")
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        char letter = input[i];
                        bool isUppercase = char.IsUpper(letter);
                        bool isNumber = char.IsNumber(letter);
                        currentSum += (int)letter;

                        if (letter != ' ' && isNumber == false)
                        {
                            if (isUppercase)
                            {
                                uppercaseCounter++;
                            }
                            else
                            {
                                lowercaseCounter++;
                            }
                        }

                        if (i == input.Length - 1)
                        {
                            for (int j = 0; j < uppercaseCounter; j++)
                            {
                                currentSum -= input.Length;
                            }

                            for (int k = 0; k < lowercaseCounter; k++)
                            {
                                currentSum -= input.Length * 2;
                            }

                            if (currentSum > maxSum)
                            {
                                maxSum = currentSum;
                                bestMovie = input;
                            }

                            currentSum = 0;
                            uppercaseCounter = 0;
                            lowercaseCounter = 0;
                        }
                    }

                    if (counter == 7)
                    {
                        Console.WriteLine($"The limit is reached.");
                        limitReached = true;
                        break;
                    }
                }
            }

            Console.WriteLine($"The best movie for you is {bestMovie} with {maxSum} ASCII sum.");
        }
    }
}
