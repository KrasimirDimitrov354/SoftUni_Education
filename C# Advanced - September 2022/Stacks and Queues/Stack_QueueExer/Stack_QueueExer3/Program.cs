using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer3
{
    //Maximum and Minimum Element
    //You have an empty sequence and you will be given N queries. Each query is one of these three types:
    //  1 {x} – Push the element x into the stack.
    //  2 – Delete the element present at the top of the stack.
    //  3 – Print the maximum element in the stack.
    //  4 – Print the minimum element in the stack.
    //
    //After you go through all of the queries, print the stack in the following format:
    //  "{n}, {n1}, {n2} …, {nn}"
    //
    //Input
    //  •	The first line of input contains an integer - N.
    //  •	The next N lines each contain an above-mentioned query. It is guaranteed that each query is valid.
    //Output
    //  •	For each type 3 or 4 queries, print the maximum/minimum element in the stack on a new line.
    //
    //Constraints
    //  •	1 ≤ N ≤ 105
    //  •	1 ≤ x ≤ 109
    //  •	1 ≤ type ≤ 4
    //  •	If there are no elements in the stack, don’t print anything on commands 3 and 4.
    //
    //Examples
    //Input     Output          Input       Output
    //9         26              10          32
    //1 97      20              2           66
    //2         91, 20, 26      1 47        8
    //1 20                      1 66        8, 16, 25, 32, 66, 47
    //2                         1 32
    //1 26                      4
    //1 20                      3
    //3                         1 25
    //1 91                      1 16
    //4                         1 8
    //                          4

    class Program
    {
        static void Main()
        {
            int queriesCount = int.Parse(Console.ReadLine());

            Stack<int> stackOfNumbers = new Stack<int>();

            for (int i = 0; i < queriesCount; i++)
            {
                int[] query = Console.ReadLine()
                    .Split()
                    .Select(n => int.Parse(n))
                    .ToArray();

                switch (query[0])
                {
                    case 1:
                        stackOfNumbers.Push(query[1]);
                        break;
                    case 2:
                    case 3:
                    case 4:
                        if (stackOfNumbers.Count != 0)
                        {
                            if (query[0] == 2)
                            {
                                stackOfNumbers.Pop();
                            }
                            else if (query[0] == 3)
                            {
                                Console.WriteLine(stackOfNumbers.Max());
                            }
                            else
                            {
                                Console.WriteLine(stackOfNumbers.Min());
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(String.Join(", ", stackOfNumbers));
        }
    }
}
