using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordCurrent = "";
            string wordWinner = "";
            double sumCurrent = 0;
            double sumWinner = 0;
            int counter = 0;
            bool startsWithVowel = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End of words")
                {
                    break;
                }
                else
                {
                    wordCurrent = input;
                    counter = 0;

                    while (counter < wordCurrent.Length)
                    {
                        sumCurrent += (int)wordCurrent[counter];

                        if (counter == 0)
                        {
                            bool firstCondition = wordCurrent[counter] == 'a' || wordCurrent[counter] == 'e' || wordCurrent[counter] == 'i'
                                || wordCurrent[counter] == 'o' || wordCurrent[counter] == 'u' || wordCurrent[counter] == 'y';
                            bool secondCondition = wordCurrent[counter] == 'A' || wordCurrent[counter] == 'E' || wordCurrent[counter] == 'I'
                                || wordCurrent[counter] == 'O' || wordCurrent[counter] == 'U' || wordCurrent[counter] == 'Y';

                            if (firstCondition || secondCondition)
                            {
                                startsWithVowel = true;
                            }
                            else
                            {
                                startsWithVowel = false;
                            }
                        }                       

                        if (counter == wordCurrent.Length - 1)
                        {
                            if (startsWithVowel)
                            {
                                sumCurrent *= wordCurrent.Length;
                            }
                            else
                            {
                                sumCurrent = Math.Floor(sumCurrent / wordCurrent.Length);
                            }

                            if (sumCurrent > sumWinner)
                            {
                                sumWinner = sumCurrent;
                                wordWinner = wordCurrent;
                            }

                            sumCurrent = 0;
                        }

                        counter++;
                    }
                }
            }

            Console.WriteLine($"The most powerful word is {wordWinner} - {sumWinner}");
        }
    }
}
