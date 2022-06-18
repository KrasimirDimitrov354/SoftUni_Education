using System;
using System.Linq;

namespace ConsoleApp11
{
    class Program
    {
        //Array Manipulator - TODO
        //The array may be manipulated by one of the following commands
        //  •	exchange {index}
        //      - splits the array after the given index and exchanges the places of the two resulting sub-arrays.
        //      E.g. [1, 2, 3, 4, 5] -> exchange 2 -> result: [4, 5, 1, 2, 3]
        //          o If the index is outside the boundaries of the array, print "Invalid index"
        //  •	max even/odd
        //      - returns the INDEX of the max even/odd element -> [1, 4, 8, 2, 3] -> max odd -> print 4
        //  •	min even/odd
        //      - returns the INDEX of the min even/odd element -> [1, 4, 8, 2, 3] -> min even > print 3
        //          o If there are two or more equal min/max elements, return the index of the rightmost one
        //          o If a min/max even/odd element cannot be found, print "No matches"
        //  •	first {count} even/odd
        //      – returns the first {count} elements -> [1, 8, 2, 3] -> first 2 even -> print [8, 2]
        //  •	last {count} even/odd
        //      – returns the last {count} elements-> [1, 8, 2, 3] -> last 2 odd -> print [1, 3]
        //          o If the count is greater than the array length, print "Invalid count"
        //          o If there are not enough elements to satisfy the count, print as many as you can. If there are zero even/odd elements, print an empty array “[]”
        //  •	end
        //      – stop taking input and print the final state of the array
        //Input
        //  •	The input data should be read from the console.
        //  •	On the first line, the initial array is received as a line of integers, separated by a single space
        //  •	On the next lines, until the command "end" is received, you will receive the array manipulation commands
        //  •	The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //  •	The output should be printed on the console.
        //  •	On a separate line, print the output of the corresponding command
        //  •	On the last line, print the final array in square brackets with its elements separated by a comma and a space 
        //  •	See the examples below to get a better understanding of your task
        //Constraints
        //  •	The number of input lines will be in the range [2 … 50].
        //  •	The array elements will be integers in the range [0 … 1000].
        //  •	The number of elements will be in the range [1 .. 50]
        //  •	The split index will be an integer in the range [-231 … 231 – 1]
        //  •	The first/last count will be an integer in the range [1 … 231 – 1]
        //  •	There will not be redundant whitespace anywhere in the input
        //  •	Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	        Output              Input	        Output
        //1 3 5 7 9     2                   1 10 100 1000   3
        //exchange 1    No matches          max even        Invalid count
        //max odd       [5, 7]              first 5 even    Invalid index
        //min even      []                  exchange 10     0
        //first 2 odd   [3, 5, 7, 9, 1]     min odd         2
        //last 2 even                       exchange 0      0
        //exchange 3                        max even        [10, 100, 1000, 1]
        //end                               min even
        //                                  end
        //Input             Output
        //1 10 100 1000     [1]
        //exchange 3        [1]
        //first 2 odd       [1, 10, 100, 1000]
        //last 4 odd
        //end	

        private static void PrintArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                {
                    Console.Write($"{array[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{array[i]}]");
                }
            }
        }

        private static int[] ExchangeArray(int[] array, int index)
        {
            int[] exchangedArray = new int[array.Length];
            int[] firstArray = new int[index + 1];
            int[] secondArray = new int[array.Length - (index + 1)];

            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];

                if (i <= index)
                {
                    firstArray[i] = currentNum;
                }
                else
                {
                    secondArray[i - (index + 1)] = currentNum;
                }
            }

            byte counterSecondArray = 0;
            for (int i = 0; i < exchangedArray.Length; i++)
            {
                if (i <= secondArray.Length - 1)
                {
                    exchangedArray[i] = secondArray[i];
                }
                else
                {
                    exchangedArray[i] = firstArray[counterSecondArray];
                    counterSecondArray++;
                }
            }

            return exchangedArray;
        }

        private static void FindMax(int[] array, string type)
        {
            int maxIndex = 0;
            bool neverFound = true;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];

                switch (type)
                {
                    case "even":
                        if (currentNum % 2 == 0)
                        {
                            if (neverFound)
                            {
                                maxIndex = i;
                                neverFound = false;
                            }
                            else
                            {
                                if (currentNum >= array[maxIndex])
                                {
                                    maxIndex = i;
                                }
                            }
                        }
                        break;
                    case "odd":
                        if (currentNum % 2 != 0)
                        {
                            if (neverFound)
                            {
                                maxIndex = i;
                                neverFound = false;
                            }
                            else
                            {
                                if (currentNum >= array[maxIndex])
                                {
                                    maxIndex = i;
                                }
                            }
                        }
                        break;
                }

            }

            if (neverFound)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxIndex);
            }
        }

        private static void FindMin(int[] array, string type)
        {
            int minIndex = 0;
            bool neverFound = true;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];

                switch (type)
                {
                    case "even":
                        if (currentNum % 2 == 0)
                        {
                            if (neverFound)
                            {
                                minIndex = i;
                                neverFound = false;
                            }
                            else
                            {
                                if (currentNum <= array[minIndex])
                                {
                                    minIndex = i;
                                }
                            }
                        }
                        break;
                    case "odd":
                        if (currentNum % 2 != 0)
                        {
                            if (neverFound)
                            {
                                minIndex = i;
                                neverFound = false;
                            }
                            else
                            {
                                if (currentNum <= array[minIndex])
                                {
                                    minIndex = i;
                                }
                            }
                        }
                        break;
                }

            }

            if (neverFound)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minIndex);
            }
        }

        private static void PrintFirst(int[] array, int elementsNum, string elementsType)
        {
            int[] result = new int[elementsNum];
            bool arrayFilled = false;
            bool noElementsEntered = true;
            byte counterResultElements = 0;
            byte counterEmptyPositions = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];

                if (arrayFilled)
                {
                    break;
                }
                else
                {
                    switch (elementsType)
                    {
                        case "even":
                            if (currentNum % 2 == 0)
                            {
                                result[counterResultElements] = currentNum;
                                counterResultElements++;

                                noElementsEntered = false;
                                counterEmptyPositions++;

                                if (counterResultElements == result.Length)
                                {
                                    arrayFilled = true;
                                }
                            }
                            break;
                        case "odd":
                            if (currentNum % 2 != 0)
                            {
                                result[counterResultElements] = currentNum;
                                counterResultElements++;

                                noElementsEntered = false;
                                counterEmptyPositions++;

                                if (counterResultElements == result.Length)
                                {
                                    arrayFilled = true;
                                }
                            }
                            break;
                    }
                }
            }

            if (noElementsEntered)
            {
                Console.WriteLine("[]");
            }
            else
            {
                if (counterEmptyPositions < result.Length)
                {
                    Array.Resize<int>(ref result, counterEmptyPositions);
                }

                PrintArray(result);
            }
        }

        private static void PrintLast(int[] array, int elementsNum, string elementsType)
        {
            int[] result = new int[elementsNum];
            bool arrayFilled = false;
            bool noElementsEntered = true;
            byte counterResultElements = 0;
            byte counterEmptyPositions = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int currentNum = array[i];

                if (arrayFilled)
                {
                    break;
                }
                else
                {
                    switch (elementsType)
                    {
                        case "even":
                            if (currentNum % 2 == 0)
                            {
                                result[counterResultElements] = currentNum;
                                counterResultElements++;

                                noElementsEntered = false;
                                counterEmptyPositions++;

                                if (counterResultElements == result.Length)
                                {
                                    arrayFilled = true;
                                }
                            }
                            break;
                        case "odd":
                            if (currentNum % 2 != 0)
                            {
                                result[counterResultElements] = currentNum;
                                counterResultElements++;

                                noElementsEntered = false;
                                counterEmptyPositions++;

                                if (counterResultElements == result.Length)
                                {
                                    arrayFilled = true;
                                }
                            }
                            break;
                    }
                }
            }

            if (noElementsEntered)
            {
                Console.WriteLine("[]");
            }
            else
            {
                if (counterEmptyPositions < result.Length)
                {
                    Array.Resize<int>(ref result, counterEmptyPositions);
                }

                Array.Reverse(result);
                PrintArray(result);
            }
        }

        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    PrintArray(numbers);
                    break;
                }
                else
                {
                    string[] commandElements = command.Split(' ');
                    string methodCommand = commandElements[0];

                    switch (methodCommand)
                    {
                        case "exchange":
                            int breakingIndex = int.Parse(commandElements[1].ToString());

                            if (breakingIndex < 0 || breakingIndex > numbers.Length - 1)
                            {
                                Console.WriteLine("Invalid index");
                            }
                            else
                            {
                                numbers = ExchangeArray(numbers, breakingIndex);
                            }
                            break;
                        case "max":
                        case "min":
                            string elementType = commandElements[1];

                            if (methodCommand == "max")
                            {
                                FindMax(numbers, elementType);
                            }
                            else
                            {
                                FindMin(numbers, elementType);
                            }
                            break;
                        case "first":
                        case "last":
                            int elementsCount = int.Parse(commandElements[1].ToString());
                            string elementsType = commandElements[2];

                            if (elementsCount > numbers.Length)
                            {
                                Console.WriteLine("Invalid count");
                            }
                            else
                            {
                                if (methodCommand == "first")
                                {
                                    PrintFirst(numbers, elementsCount, elementsType);
                                }
                                else
                                {
                                    PrintLast(numbers, elementsCount, elementsType);
                                }
                            }
                            break;

                    }
                }
            }
        }
    }
}
