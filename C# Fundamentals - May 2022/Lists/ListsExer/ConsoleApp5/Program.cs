using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        //Bomb Numbers
        //Create a program that reads a sequence of numbers and a special bomb number that holds a certain power.
        //Your task is to detonate every occurrence of the special bomb number and according to its power the numbers to its left and right.
        //The bomb power refers to how many numbers to the left and right will be removed, no matter their values.
        //Detonations are performed from left to right and all the detonated numbers disappear.
        //Print the sum of the remaining elements in the sequence.
        //Examples
        //Input                     Output  Comments
        //1 2 2 4 2 2 2 9           12      The special number is 4 with power 2.
        //4 2                               After detonation, we are left with the sequence [1, 2, 9] with sum 12.
        //
        //Input                     Output  Comments
        //1 4 4 2 8 9 1             5       The special number is 9 with power 3.
        //9 3                               After detonation, we are left with the sequence [1, 4] with sum 5.
        //                                  Since the 9 has only 1 neighbor from the right we remove just it (one number instead of 3).
        //
        //Input                     Output  Comments
        //1 7 7 1 2 3               6       Detonations are performed from left to right.
        //7 1                               We cannot detonate the second occurrence of 7, because it's already destroyed by the first occurrence.
        //                                  The numbers [1, 2, 3] survive. Their sum is 6.
        //
        //Input                     Output  Comments
        //1 1 2 1 1 1 2 1 1 1       4       The result is the sequence [1, 1, 1, 1]. Sum = 4.
        //2 1             

        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();
            List<int> bomb = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

            int bombNumber = bomb[0];
            int bombPower = bomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber == bombNumber)
                {
                    for (int j = 1; j <= bombPower; j++)
                    {
                        int leftPosition = i - j;

                        if (i - j >= 0)
                        {
                            numbers.RemoveAt(leftPosition);
                        }
                        else
                        {
                            break;
                        }   
                    }

                    int currentIndexOfBomb = numbers.IndexOf(bombNumber);
                    int rightPosition = currentIndexOfBomb + 1;
                    for (int k = 1; k <= bombPower; k++)
                    {
                        if (currentIndexOfBomb + 1 <= numbers.Count - 1)
                        {
                            numbers.RemoveAt(rightPosition);
                        }
                        else
                        {
                            break;
                        }
                    }

                    i = currentIndexOfBomb - 1;
                    numbers.Remove(bombNumber);
                }   
            }

            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
