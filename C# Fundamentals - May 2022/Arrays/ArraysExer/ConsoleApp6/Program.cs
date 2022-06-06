using System;

namespace ConsoleApp6
{
    class Program
    {
        //Equal Sums
        //Create a program that determines if an element exists in an array for which the sum of all elements to its left is equal to the sum of all elements to its right.
        //If there are no elements to the left or right, their sum is considered to be 0.
        //Print the index of the element that satisfies the condition or "no" if there is no such element.
        //Examples
        //Input     Output      Comments                                    Input     Output        Comments
        //1 2 3 3	2	        At a[2] -> left sum = 3, right sum = 3      1 2	      no            At a[0] -> left sum = 0, right sum = 2
        //                      a[0] + a[1] = a[3]                                                  At a[1] -> left sum = 1, right sum = 0
        //                                                                                          No such index exists                     
        //Input     Output      Comments                                    Input     Output        Comments
        //1	        0	        At a[0] -> left sum = 0, right sum = 0      1 2 3	  no            No such index exists
        //
        //Input                     Output      Comments
        //10 5 5 99 3 4 2 5 1 1 4	3	        At a[3] -> left sum = 20, right sum = 20
        //                                      a[0] + a[1] + a[2] = a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10]

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            bool areEqual = false;
            int indexEqual = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i - 1 < 0)
                    {
                        leftSum += 0;
                    }
                    
                    if (i + 1 > numbers.Length)
                    {
                        rightSum += 0;
                    }

                    if (j > i)
                    {
                        rightSum += numbers[j];
                        
                    }
                    else if (j < i)
                    {
                        leftSum += numbers[j];
                    }
                }

                if (leftSum == rightSum)
                {
                    areEqual = true;
                    indexEqual = i;
                    break;
                }
            }

            if (areEqual)
            {
                Console.WriteLine(indexEqual);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
