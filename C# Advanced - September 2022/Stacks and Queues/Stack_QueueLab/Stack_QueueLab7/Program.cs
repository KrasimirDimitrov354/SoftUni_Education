using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueLab7
{
    //Hot Potato
    //Hot potato is a game in which children form a circle and start passing a hot potato.
    //The counting starts with the first kid. Every nth toss the child left with the potato leaves the game.
    //When a kid leaves the game, it passes the potato along. This continues until there is only one kid left.
    //
    //Create a program that simulates the game of Hot Potato.
    //Print every kid that is removed from the circle. In the end, print the kid that is left last.
    //
    //Examples
    //Input                             Output
    //Alva James William                Removed James
    //2                                 Removed Alva
    //                                  Last is William
    //Input                             Output
    //Lucas Jacob Noah Logan Ethan      Removed Ethan
    //10                                Removed Jacob
    //                                  Removed Noah
    //                                  Removed Lucas
    //                                  Last is Logan
    //Input                             Output
    //Carter Dylan Jack Luke Gabriel    Removed Carter
    //1                                 Removed Dylan
    //                                  Removed Jack
    //                                  Removed Luke
    //                                  Last is Gabriel

    class Program
    {
        static void Main()
        {
            Queue<string> children = new Queue<string>(Console.ReadLine()
                .Split()
                .ToList());

            int hotToss = int.Parse(Console.ReadLine());
            int currentToss = 0;

            while (children.Count > 1)
            {
                string currentChild = children.Dequeue();
                currentToss++;

                if (currentToss != hotToss)
                {
                    children.Enqueue(currentChild);
                }
                else
                {
                    Console.WriteLine($"Removed {currentChild}");
                    currentToss = 0;
                }
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
