using System;

namespace ConsoleApp9
{
    class Program
    {
        //Kamino Factory (40/100, to fix)
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
            string[] bestDNA = new string[lengthDNA];

            int counterSamples = 0;
            int bestSample = 0;

            int bestFirstIndex = 0;
            int bestSampleSum = 0;
            int bestSequenceLength = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }
                else
                {
                    string[] currentDNA = input.Split('!');
                    counterSamples++;

                    bool firstIndexNotFound = true;

                    int currentFirstIndex = 0;
                    int currentSampleSum = 0;
                    int currentSequenceLengthMax = 0; //variable keeps the longest sequence of 1s in the currentDNA sequence
                    int currentSequenceLength = 0; //variable keeps the sequence of 1s until a 0 appears

                    for (int i = 0; i < currentDNA.Length; i++)
                    {
                        int currentElement = int.Parse(currentDNA[i]);

                        if (currentElement == 1)
                        {
                            currentSampleSum++;
                        }

                        if (i + 1 < currentDNA.Length)
                        {
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
                            //if no sequence of 1s is present, search for the first occurence of 1
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

                    //saves the value of the first index of 1 within the first currentDNA[] input
                    if (counterSamples == 1)
                    {
                        bestFirstIndex = currentFirstIndex;
                    }

                    //if current sequence of 1s is higher than that of the previous currentDNA[] input, change bestDNA[] values to currentDNA[] values
                    //else if sequences are equal, check first index of 1
                    //else if first indexes are the same, check sum of 1s
                    if (currentSequenceLengthMax > bestSequenceLength)
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

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSampleSum}.");
            foreach (var element in bestDNA)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
