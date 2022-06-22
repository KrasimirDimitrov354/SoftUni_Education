using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        //The Lift
        //Write a program that finds a place for the tourist on a lift.
        //Every wagon should have a maximum of 4 people on it.
        //If a wagon is full, you should direct the people to the next one with space available.
        //
        //Input
        //  •	On the first line, you will receive how many people are waiting to get on the lift
        //  •	On the second line, you will receive the current state of the lift separated by a single space: " ".
        //Output
        //When there is no more available space left on the lift, or there are no more people in the queue, you should print on the console the final state of the lift's wagons.
        //It must be separated by " " and one of the following messages:
        //  •	If there are no more people and the lift have empty spots, you should print:
        //      "The lift has empty spots!
        //      {wagons separated by ' '}"
        //  •	If there are still people in the queue and no more available space, you should print:
        //      "There isn't enough space! {people} people in a queue!
        //      {wagons separated by ' '}"
        //  •	If the lift is full and there are no more people in the queue, you should print only the wagons separated by " "
        //
        //Examples
        //Input         Output                      Comment
        //15            The lift has empty spots!   First state - 4 0 0 0 -> 11 people left
        //0 0 0 0       4 4 4 3                     Second state – 4 4 0 0 -> 7 people left
        //                                          Third state – 4 4 4 0 -> 3 people left
        //
        //Input         Output                                              Comment
        //20            There isn't enough space! 10 people in a queue!     First state - 4 2 0  -> 16 people left
        //0 2 0         4 4 4                                               Second state – 4 4 0  -> 14 people left
        //                                                                  Third state – 4 4 4 -> 10 people left, but there're no more wagons.

        static void Main()
        {
            int passengers = int.Parse(Console.ReadLine());
            int[] train = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            bool spotsLeft = true;

            for (int i = 0; i < train.Length; i++)
            {
                while (train[i] < 4)
                {
                    train[i]++;
                    passengers--;

                    if (passengers == 0)
                    {
                        break;
                    }
                }

                if (i == train.Length - 1 && train[i] == 4)
                {
                    spotsLeft = false;
                    break;
                }
                else if (passengers == 0)
                {
                    break;
                }
            }

            if (spotsLeft)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else
            {
                if (passengers != 0)
                {
                    Console.WriteLine($"There isn't enough space! {passengers} people in a queue!");
                }
            }

            foreach (int wagon in train)
            {
                Console.Write($"{wagon} ");
            }
        }
    }
}
