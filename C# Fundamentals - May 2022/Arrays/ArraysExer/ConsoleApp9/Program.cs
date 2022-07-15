using System;
using System.Linq;

namespace ConsoleApp9
{
    class Program
    {
        //Kamino Factory
        //The clone factory in Kamino got another order to clone troops. But this time you are tasked to find the best DNA sequence to use in the production. 
        //You will receive the DNA length and until you receive the command "Clone them!" you will be receiving a DNA sequence of ones and zeroes, split by "!" (one or several).
        //
        //You should select the sequence with the longest subsequence of ones.
        //If there are several sequences with the same length of the subsequence of ones, print the one with the leftmost starting index.
        //If there are several sequences with the same length and starting index, select the sequence with the greater sum of its elements.
        //
        //After you receive the last command "Clone them!" you should print the collected information in the following format:
        //  "Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
        //  "{DNA sequence, joined by space}"
        //
        //Input/Constraints
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

        static void Main()
        {
            int lengthDNA = int.Parse(Console.ReadLine());
            string[] bestDNA = new string[lengthDNA];

            int counterSamples = 0; //Counter for all DNA samples.
            int bestSample = 0; //Index of the best DNA sample.

            int bestFirstIndex = 0; //First index of 1 in the best DNA sample.
            int bestSampleSum = 0; //Sum of 1s in the best DNA sample.
            int bestSequenceLength = 0; //Longest sequences of 1s in the best DNA sample.

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSampleSum}.");

                    foreach (var element in bestDNA)
                    {
                        Console.Write($"{element} ");
                    }

                    break;
                }
                else
                {
                    string[] currentDNA = input.Split('!');
                    currentDNA = currentDNA.Where(c => !string.IsNullOrEmpty(c)).ToArray();
                    counterSamples++;

                    bool firstIndexNotFound = true;

                    int currentFirstIndex = 0; //First index of 1 in the current DNA sample.
                    int currentSampleSum = 0; //Sum of 1s in the current DNA sample.
                    int currentSequenceLengthMax = 0; //Longest sequence of 1s in the current DNA sample.
                    int currentSequenceLength = 0; //Current sequence of 1s in the current DNA sample. If a 0 appears, sequence is reset.

                    for (int i = 0; i < currentDNA.Length; i++)
                    {
                        int currentElement = int.Parse(currentDNA[i]);

                        if (currentElement == 1)
                        {
                            currentSampleSum++;
                        }

                        if (i + 1 <= currentDNA.Length - 1)
                        {
                            //If next element is not the end of the sample, checks if it is equal to 1.
                            //If yes, increases current sequence length by 1 and takes the current index as the first index of 1.
                            //Else, reset sequence.

                            int nextElement = int.Parse(currentDNA[i + 1]);
                            if (currentElement == 1 && nextElement == 1)
                            {
                                currentSequenceLength++;

                                if (currentSequenceLength > currentSequenceLengthMax)
                                {
                                    currentSequenceLengthMax++;
                                }

                                if (firstIndexNotFound)
                                {
                                    currentFirstIndex = i;
                                    firstIndexNotFound = false;
                                }
                            }
                            else
                            {
                                currentSequenceLength = 0;
                            }
                        }
                        else if (i == currentDNA.Length - 1 && firstIndexNotFound)
                        {
                            //If no sequence of 1s is present, search for the first occurence of 1.

                            for (int j = 0; j < currentDNA.Length; j++)
                            {
                                if (int.Parse(currentDNA[j]) == 1)
                                {
                                    currentFirstIndex = j;
                                    firstIndexNotFound = false;
                                    break;
                                }
                            }
                        }
                    }

                    //First DNA sample is automatically assumed the best.
                    //For every next sample:
                    //  -If current sequence of 1s is longer than that of the previous DNA sample, change bestDNA[] values to currentDNA[] values.
                    //      -Else if sequences are equal, check first index of 1.
                    //          -Else if first indexes are the same, check sum of 1s.

                    if (counterSamples == 1)
                    {
                        bestFirstIndex = currentFirstIndex;
                        bestSequenceLength = currentSequenceLengthMax;
                        bestSample = counterSamples;
                        bestSampleSum = currentSampleSum;
                        Array.Copy(currentDNA, bestDNA, lengthDNA);
                    }
                    else if (currentSequenceLengthMax > bestSequenceLength)
                    {
                        bestSequenceLength = currentSequenceLengthMax;
                        bestSample = counterSamples;
                        bestSampleSum = currentSampleSum;
                        Array.Copy(currentDNA, bestDNA, lengthDNA);
                    }
                    else if (currentSequenceLengthMax == bestSequenceLength)
                    {
                        if (currentFirstIndex < bestFirstIndex)
                        {
                            bestFirstIndex = currentFirstIndex;
                            bestSample = counterSamples;
                            bestSampleSum = currentSampleSum;
                            Array.Copy(currentDNA, bestDNA, lengthDNA);
                        }
                        else if (currentFirstIndex == bestFirstIndex)
                        {
                            if (currentSampleSum > bestSampleSum)
                            {
                                bestSampleSum = currentSampleSum;
                                bestSample = counterSamples;
                                Array.Copy(currentDNA, bestDNA, lengthDNA);
                            }
                        }
                    }
                }
            }           
        }
    }
}
