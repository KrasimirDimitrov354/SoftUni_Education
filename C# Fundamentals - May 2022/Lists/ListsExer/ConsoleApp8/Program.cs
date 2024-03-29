﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    //Anonymous Threat (80/100)
    //Anonymous has created a cyberquantum virus which steals data from the CIA.
    //As the lead security developer in the CIA, you have been tasked to analyze the software of the virus and observe its actions on the data.
    //The virus is known for its innovative and unbelievably clever technique of merging and dividing data into partitions.
    //
    //You will receive a single input line containing strings separated by spaces. The strings may contain any ASCII character except whitespace.
    //Then you will begin receiving commands in one of the following formats:
    //  •	merge {startIndex} {endIndex}
    //  •	divide {index} {partitions}
    //
    //Every time you receive the merge command, you must merge all elements from the startIndex to the endIndex (concatenate them).
    //Example:
    //  {abc, def, ghi} -> merge 0 1 -> {abcdef, ghi}
    //If any of the given indexes is out of the array, you must take only the range that is inside the array and merge it.
    //
    //Every time you receive the divide command, you must divide the element at the given index into several small substrings with equal length.
    //The count of the substrings should be equal to the given partitions. 
    //Example:
    //  {abcdef, ghi, jkl} -> divide 0 3 -> {ab, cd, ef, ghi, jkl}
    //If the string cannot be exactly divided into the given partitions, make all partitions except the last with equal lengths, and make the last one the longest. 
    //Example:
    //  {abcd, efgh, ijkl} -> divide 0 3 -> {a, b, cd, efgh, ijkl}
    //
    //The input ends when you receive the command "3:1". At that point, you must print the resulting elements joined by a space.
    //
    //Input
    //  •	The first input line will contain the array of data.
    //  •	On the next several input lines you will receive commands in the format specified above.
    //  •	The input ends when you receive the command "3:1".
    //Output
    //  •	Print a single line containing the elements of the array, joined by a space.
    //Constrains
    //  •	The strings in the array may contain any ASCII character except whitespace.
    //  •	The startIndex and the endIndex will be in the range [-1000, 1000].
    //  •	The endIndex will always be greater than the startIndex.
    //  •	The index in the divide command will always be inside the array.
    //  •	The partitions will be in the range [0, 100].
    //  •	Allowed working time/memory: 100ms / 16MB.
    //Examples
    //Input	                        Output                  Input                               Output
    //Ivo Johny Tony Bony Mony      IvoJohnyTonyBonyMony    abcd efgh ijkl mnop qrst uvwx yz    abcd efgh ijkl mnop qr st uv wx yz
    //merge 0 3                                             merge 4 10
    //merge 3 4                                             divide 4 5
    //merge 0 3                                             3:1
    //3:1

    class Program
    {
        private static bool OneIndexInBounds(List<string> virusTestData, int startIndex, int endIndex)
        {
            if (startIndex < 0 && endIndex < 1)
            {
                return false;
            }
            else if (startIndex > virusTestData.Count - 1)
            {
                return false;
            }

            return true;
        }

        private static void MergeData(List<string> virusTestData, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex >= virusTestData.Count)
            {
                endIndex = virusTestData.Count - 1;
            }

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                virusTestData[startIndex] += virusTestData[i];
                virusTestData.RemoveAt(i);
                endIndex--;
                i--;
            }
        }

        private static List<string> CreatePartitionElements(string element, int partitionsCount)
        {
            List<string> partition = new List<string>();

            double partitionLength = element.Length / (partitionsCount * 1.0);

            if (partitionLength % 1 == 0)
            {
                for (int i = 0; i < partitionsCount; i++)
                {
                    partition.Add(element.Substring(0, (int)partitionLength));
                    element = element.Remove(0, (int)partitionLength);
                }
            }
            else
            {
                for (int i = 1; i <= partitionsCount; i++)
                {
                    if (i == partitionsCount)
                    {
                        partition.Add(element);
                    }
                    else
                    {
                        partition.Add(element.Substring(0, (int)(partitionLength - 1 / 2)));
                        element = element.Remove(0, (int)(partitionLength - 1 / 2));
                    }
                }
            }


            return partition;
        }

        private static void DivideData(List<string> virusTestData, int indexOfDataElement, int partitionsCount)
        {
            if (partitionsCount > 1)
            {
                List<string> partition = CreatePartitionElements(virusTestData[indexOfDataElement], partitionsCount);
                virusTestData.InsertRange(indexOfDataElement, partition);
                virusTestData.RemoveAt(virusTestData.Count - 1);
            }
        }

        static void Main()
        {
            List<string> virusTestData = new List<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    Console.WriteLine(string.Join(' ', virusTestData));
                    break;
                }
                else
                {
                    string[] command = input.Split(' ');

                    if (OneIndexInBounds(virusTestData, int.Parse(command[1]), int.Parse(command[2])))
                    {
                        switch (command[0])
                        {
                            case "merge":
                                MergeData(virusTestData, int.Parse(command[1]), int.Parse(command[2]));
                                break;
                            case "divide":
                                DivideData(virusTestData, int.Parse(command[1]), int.Parse(command[2]));
                                break;
                        }
                    }
                }
            }
        }
    }
}
