using System;

namespace ConsoleApp9
{
    class Program
    {
        //Kamino Factory (70/100, to fix)
        //The clone factory in Kamino got another order to clone troops. But this time you are tasked to find the best DNA sequence to use in the production. 
        //You will receive the DNA length and until you receive the command "Clone them!" you will be receiving a DNA sequence of ones and zeroes, split by "!" (one or several).
        //
        //You should select the sequence with the longest subsequence of ones.
        //If there are several sequences with the same length of the subsequence of ones, print the one with the leftmost starting index.
        //If there are several sequences with the same length and starting index, select the sequence with the greater sum of its elements.
        //
        //After you receive the last command "Clone them!" you should print the collected information in the following format:
        //"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
        //"{DNA sequence, joined by space}"
        //
        //Input / Constraints
        //  •	The first line holds the length of the sequences – integer in the range [1…100];
        //  •	On the next lines until you receive "Clone them!" you will be receiving sequences (at least one) of ones and zeroes, split by "!" (one or several).
        //Output
        //  •	The output should be printed on the console and consists of two lines in the following format:
        //      •	"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
        //      •	"{DNA sequence, joined by space}"
        //
        //Examples
        //Input         Output                              Comments
        //5             Best DNA sample 2 with sum: 2.      We receive 2 sequences with the same length of the subsequence of ones.
        //1!0!1!1!0     0 1 1 0 0                           The second is printed because its subsequence starts at index[1].
        //0!1!1!0!0
        //Clone them!
        //	
        //Input         Output                              Comments
        //4             Best DNA sample 1 with sum: 3.      We receive 3 sequences. Both 1 and 3 have the same length of the subsequence of ones -> 2.
        //1!1!0!1       1 1 0 1                             Both start from the index[0], but the first is printed, because its sum is greater.
        //1!0!0!1
        //1!1!0!0
        //Clone them!

        static void Main(string[] args)
        {
            int lengthDNA = int.Parse(Console.ReadLine());
            int currentSample = 0;
            int bestSample = 1;
            int bestSequence = 1;
            int[] bestDNA = new int[lengthDNA];

            int currentFirstIndexOf1 = 0;
            int bestFirstIndexOf1 = 0;
            bool wasNeverSet = true;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }
                else
                {
                    int[] currentDNA = new int[lengthDNA];
                    currentSample++;

                    if (currentSample == 1)
                    {
                        Array.Copy(currentDNA, bestDNA, lengthDNA);
                    }

                    int lastNumberPosition = 0;
                    for (int i = 0; i < currentDNA.Length; i++)
                    {
                        for (int j = 0; j < input.Length; j++)
                        {
                            if (j == 0 && i != 0)
                            {
                                j = lastNumberPosition;
                            }

                            bool isNumber = int.TryParse(input[j].ToString(), out int number);

                            if (isNumber)
                            {
                                currentDNA[i] = number;
                                lastNumberPosition = j + 1;
                                break;
                            }
                        }
                    }

                    int currentSequence = 1;
                    int counterFirstIndexChecking = 0;
                    for (int k = 1; k < currentDNA.Length; k++)
                    {
                        if (currentDNA[k] == 1 && currentDNA[k - 1] == 1)
                        {
                            currentSequence++;
                            counterFirstIndexChecking++;
                            if (counterFirstIndexChecking == 1)
                            {
                                currentFirstIndexOf1 = k - 1;

                                if (wasNeverSet)
                                {
                                    bestFirstIndexOf1 = currentFirstIndexOf1;
                                    wasNeverSet = false;
                                }
                            }

                            if (currentSequence > bestSequence)
                            {
                                bestSequence = currentSequence;
                                bestSample = currentSample;
                                Array.Copy(currentDNA, bestDNA, lengthDNA);
                            }
                            else if (currentSequence == bestSequence)
                            {
                                if (currentFirstIndexOf1 < bestFirstIndexOf1)
                                {
                                    bestSequence = currentSequence;
                                    bestSample = currentSample;
                                    Array.Copy(currentDNA, bestDNA, lengthDNA);
                                }
                            }
                        }
                        else
                        {
                            currentSequence = 1;
                        }
                    }
                }
            }

            int sumOf1s = 0;
            for (int l = 0; l < bestDNA.Length; l++)
            {
                if (bestDNA[l] == 1)
                {
                    sumOf1s++;
                }
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {sumOf1s}.");
            foreach (var element in bestDNA)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
