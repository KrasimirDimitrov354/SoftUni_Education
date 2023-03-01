using System;
using System.Linq;

namespace PlayCatch
{
    //Play Catch
    //On the first line you will receive an array of integers. Then you will receive commands which manipulate the array:
    //  •	"Replace {index} {element}" – Replace the element at the given index with the given element.
    //  •	"Print {startIndex} {endIndex}" – Print the elements from the start index to the end index, inclusive.
    //  •	"Show {index}" – Print the element at the index.
    //
    //You have the task to rewrite the messages from the exceptions which can be produced from your program:
    //  •	If you receive an index which does not exist in the array print: "The index does not exist!"
    //  •	If you receive a variable which is of invalid type: "The variable is not in the correct format!"
    //
    //When you catch 3 exceptions stop the input and print the elements of the array separated with ", ".
    //
    //Constraints
    //  •	The elements of the array will be in integers in the interval [-2147483648 ... 2147483647].
    //  •	You will always receive a valid string for the first part of the command, but the parameters might be invalid.
    //  •	In the “Print” command startIndex will always be a smaller or equal number to endIndex.
    //  •	You will always receive at least 3 exceptions.
    //
    //Examples
    //Input
    //  1 2 3 4 5
    //  Replace 1 9
    //  Replace 6 3
    //  Show 3
    //  Show peter
    //  Show 6
    //Output
    //  The index does not exist!
    //  4
    //  The variable is not in the correct format!
    //  The index does not exist!
    //  1, 9, 3, 4, 5
    //
    //Input
    //  1 2 3 4 5
    //  Replace 3 9
    //  Print 1 4
    //  Print -3 12
    //  Print 1 5
    //  Show 3
    //  Show 12.3
    //Output
    //  2, 3, 9, 5
    //  The index does not exist!
    //  The index does not exist!
    //  9
    //  The variable is not in the correct format!
    //  1, 2, 3, 9, 5

    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToArray();

            byte exceptionCount = 0;

            while (exceptionCount < 3)
            {
                string[] command = Console.ReadLine().Split();

                try
                {
                    switch (command[0])
                    {
                        case "Replace":
                            ReplaceElement(numbers, command[1], command[2]);
                            break;
                        case "Print":
                            PrintElements(numbers, command[1], command[2]);
                            break;
                        case "Show":
                            ShowIndex(numbers, command[1]);
                            break;
                    }
                }
                catch (IndexOutOfRangeException outOfRange)
                {
                    Console.WriteLine(outOfRange.Message);
                    exceptionCount++;
                }
                catch (ArgumentException invalidArgument)
                {
                    Console.WriteLine(invalidArgument.Message);
                    exceptionCount++;
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        private static int ProcessIndex(int[] array, string index)
        {
            if (int.TryParse(index, out int actualIndex))
            {
                if (actualIndex >= 0 && actualIndex < array.Length)
                {
                    return actualIndex;
                }
                else
                {
                    throw new IndexOutOfRangeException("The index does not exist!");
                }
            }
            else
            {
                throw new ArgumentException("The variable is not in the correct format!");
            }
        }

        private static void ReplaceElement(int[] numbers, string index, string element)
        {
            if (int.TryParse(element, out int result))
            {
                numbers[ProcessIndex(numbers, index)] = result;
            }
            else
            {
                throw new ArgumentException("The variable is not in the correct format!");
            }
        }

        private static void PrintElements(int[] numbers, string startIndex, string endIndex)
        {
            int start = ProcessIndex(numbers, startIndex);
            int end = ProcessIndex(numbers, endIndex);

            int[] final = new int[end - start + 1];
            Array.Copy(numbers, start, final, 0, final.Length);

            Console.WriteLine(String.Join(", ", final));
        }

        private static void ShowIndex(int[] numbers, string index)
        {
            Console.WriteLine(numbers[ProcessIndex(numbers, index)]);
        }
    }
}
