using System;

namespace ConsoleApp5
{
    class Program
    {
        //Top Integers
        //Create a program to find all the top integers in an array.
        //A top integer is an integer that is greater than all the elements to its right.
        //Examples
        //Input                 Output
        //1 4 3 2	            4 3 2
        //Input                 Output
        //14 24 3 19 15 17	    24 19 17
        //Input                 Output
        //27 19 42 2 13 45 48	48

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            for (int j = 0; j < numbers.Length; j++)
            {
                int currentNumber = numbers[j];
                bool isGreater = true;

                for (int k = j; k < numbers.Length; k++)
                {
                    if (currentNumber == numbers[k])
                    {
                        if (k == numbers.Length - 1 && j == numbers.Length - 1)
                        {
                            isGreater = true;
                        }
                        else if (k != numbers.Length - 1)
                        {
                            if (currentNumber > numbers[k + 1])
                            {
                                isGreater = true;
                            }
                        }
                        else
                        {
                            isGreater = false;
                        }
                    }
                    else if (currentNumber < numbers[k])
                    {
                        isGreater = false;
                        break;
                    }
                }

                if (isGreater)
                {
                    Console.Write($"{currentNumber} ");
                }
            }
        }
    }
}
