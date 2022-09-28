using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer12
{
    //Cups and Bottles
    //You will be given a sequence of integers, each indicating a cup's capacity. After that you will be given another sequence of integers – a bottle with water in it.
    //Your job is to try to fill up all of the cups.
    //
    //The filling is done by picking exactly one bottle at a time. You must start picking from the last received bottle and start filling from the first entered cup.
    //If the current bottle has N water, you give the first entered cup N water and reduce its integer value by N.
    //
    //The current cup's value may be greater than the current bottle's value. In that case you pick bottles until you reduce the cup's integer value to 0 or less.
    //When a cup's integer value reaches 0 or less, it gets removed.
    //
    //If a bottle's value is greater or equal to the cup's current value, you fill up the cup and the remaining water becomes wasted.
    //You should keep track of the wasted litres of water and print them at the end of the program.
    //
    //If you have managed to fill up all of the cups, print the remaining water bottles from the last entered to the first.
    //Otherwise you must print the remaining cups by order of entrance – from the first entered to the last.
    //
    //Input
    //  •	On the first line of input you will receive the integers representing the cups' capacity separated by a single space. 
    //  •	On the second line of input you will receive the integers representing the filled bottles separated by a single space.
    //Output
    //  •	On the first line of output you must print the remaining bottles or the remaining cups, depending on the case you are in.
    //      Keep the orders of printing exactly as specified.
    //      o   "Bottles: {remainingBottles}"
    //      o   "Cups: {remainingCups}"
    //  •	On the second line print the wasted litres of water in the following format: "Wasted litters of water: {wastedLitresOfWater}".
    //Constraints
    //  •	All of the given numbers will be valid integers in the range [1, 500].
    //  •	There will be no case in which the water is exactly as much as the cups' values so that at the end there are no cups and no water in the bottles.
    //  •	Allowed time/memory: 100ms/16MB.
    //
    //Examples
    //Input             Output                          Comment
    //4 2 10 5          Bottles: 3                      We take the first entered cup and the last entered bottle.
    //3 15 15 11 6      Wasted litters of water: 26     6 – 4 = 2. We have 2 as a remainder so the wasted water becomes 2.
    //                                                  11 – 2 = 9. Wasted water becomes 11.
    //                                                  15 – 10 = 5. Wasted water = 16.
    //                                                  15 – 5 = 10. Wasted water = 26.
    //                                                  We have filled all of the cups.
    //                                                  We print the remaining bottles and the total amount of wasted water.
    //
    //Input             Output                          Input               Output
    //1 5 28 1 4        Cups: 4                         10 20 30 40 50      Cups: 30 40 50
    //3 18 1 9 30 4 5   Wasted litters of water: 35     20 11               Wasted litters of water: 1

    class Program
    {
        static void Main()
        {
            Queue<int> queueOfCups = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(c => int.Parse(c))
                .ToList());

            Stack<int> stackOfBottles = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(c => int.Parse(c))
                .ToList());

            int wastedWater = 0;

            while (true)
            {
                if (queueOfCups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {String.Join(' ', stackOfBottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    break;
                }
                else if (stackOfBottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {String.Join(' ', queueOfCups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    break;
                }
                else
                {
                    int currentBottle = stackOfBottles.Pop();
                    int currentCup = queueOfCups.Peek();

                    while (currentCup > 0)
                    {
                        currentCup -= currentBottle;

                        if (currentCup > 0)
                        {
                            currentBottle = stackOfBottles.Pop();
                        }
                        else
                        {
                            queueOfCups.Dequeue();
                            wastedWater += Math.Abs(currentCup);
                        }
                    }
                }
            }
        }
    }
}
