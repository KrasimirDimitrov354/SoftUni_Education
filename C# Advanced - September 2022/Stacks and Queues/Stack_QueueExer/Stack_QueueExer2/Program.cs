using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer2
{
    //Basic Queue Operations
    //
    //You will be given:
    //  -   an integer N representing the number of elements to enqueue (add).
    //  -   an integer S representing the number of elements to dequeue (remove) from the queue.
    //  -   an integer X, an element that you should look for in the queue.
    //      If it is present, print true on the console. If it’s not printed the smallest element is currently present in the queue.
    //      If there are no elements in the sequence, print 0 on the console.
    //
    //Examples
    //Input             Output      Comments
    //5 2 32            true        We have to enqueue 5 elements. Then we dequeue 2 of them. Then we have to check whether 32 is present in the queue. Since it is we print true.
    //1 13 45 32 4
    //
    //Input             Output      Input       Output
    //4 1 666           13          3 3 90      0
    //666 69 13 420                 90 0 90

    class Program
    {
        static void Main()
        {
            int[] variables = Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToArray();

            Queue<int> queueOfNums = new Queue<int>(numbers.Skip(0).Take(variables[0]));

            for (int i = 0; i < variables[1]; i++)
            {
                if (queueOfNums.Count > 0)
                {
                    queueOfNums.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queueOfNums.Contains(variables[2]))
            {
                Console.WriteLine("true");
            }
            else if (queueOfNums.Count > 0)
            {
                Console.WriteLine(queueOfNums.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
