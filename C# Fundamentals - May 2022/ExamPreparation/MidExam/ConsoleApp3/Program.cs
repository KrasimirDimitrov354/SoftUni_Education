using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        //Memory game
        //Write a program that recreates the Memory game.
        //On the first line you will receive a sequence of elements. Each element in the sequence will have a twin.
        //Until the player receives "end" from the console, you will receive strings with two integers separated by a space, representing the indexes of elements in the sequence.
        //
        //If the player tries to cheat and enters two equal indexes or indexes which are out of bounds of the sequence,
        //you should add two matching elements at the middle of the sequence in the following format:
        //  "-{number of moves until now}a" 
        //Then print this message on the console:
        //  "Invalid input! Adding additional elements to the board"
        //
        //Input
        //  •	On the first line, you will receive a sequence of elements
        //  •	On the following lines, you will receive integers until the command "end"
        //Output
        //  •	Every time the player hit two matching elements, you should remove them from the sequence and print on the console the following message:
        //      "Congrats! You have found matching elements - ${element}!"
        //  •	If the player hit two different elements, you should print on the console the following message:
        //      "Try again!"
        //  •	If the player hit all matching elements before he receives "end" from the console, you should print on the console the following message: 
        //      "You have won in {number of moves until now} turns!"
        //  •	If the player receives "end" before he hits all matching elements, you should print on the console the following message:
        //      "Sorry you lose :(
        //      {the current sequence's state}"
        //
        //Constraints
        //  •	All elements in the sequence will always have a matching element.
        //
        //Examples
        //Input                 Output                                                      Comment
        //1 1 2 2 3 3 4 4 5 5   Congrats! You have found matching elements -1!              1)
        //1 0                   Invalid input! Adding additional elements to the board      1 0
        //-1 0                  Congrats! You have found matching elements -2!              1 1 2 2 3 3 4 4 5 5 –> 1 = 1, equal elements, so remove them. Moves: 1
        //1 0                   Congrats! You have found matching elements - 3!             2)
        //1 0                   Congrats! You have found matching elements - -2a!           -1 0
        //1 0                   Sorry you lose :(                                           -1 is invalid index so we add additional elements
        //end                   4 4 5 5                                                     2 2 3 3 -2а -2а 4 4 5 5, Moves: 2
        //                                                                                  3)
        //                                                                                  1 0
        //                                                                                  2 2 3 3 -2а -2а 4 4 5 5 -> 2 = 2, equal elements, so remove them. Moves: 3
        //                                                                                  4)
        //                                                                                  1 0
        //                                                                                  3 3 -2а -2а 4 4 5 5 -> 3 = 3, equal elements, so remove them. Moves: 4
        //                                                                                  5)
        //                                                                                  1 0
        //                                                                                  -2а -2а 4 4 5 5 -> -2а = -2а, equal elements, so remove them. Moves: 5
        //                                                                                  6)
        //                                                                                  You receive the end command.
        //                                                                                  There are still elements in the sequence, so the player loses the game.
        //                                                                                  Final state: 4 4 5 5
        //
        //Input             Output                                              Input               Output
        //a 2 4 a 2 4       Congrats!You have found matching elements -a!       a 2 4 a 2 4         Try again!
        //0 3               Congrats! You have found matching elements - 2!     4 0                 Try again!
        //0 2               Congrats! You have found matching elements - 4!     0 2                 Try again!
        //0 1               You have won in 3 turns!                            0 1                 Try again!
        //0 1                                                                   0 1                 Sorry you lose :(
        //end                                                                   end                 a 2 4 a 2 4

        private static bool IndexesAreValid(List<int> indexes, List<string> elements)
        {
            if (indexes[0] == indexes[1])
            {
                return false;
            }
            else
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    int currentIndex = indexes[i];

                    if (currentIndex < 0 || currentIndex > elements.Count - 1)
                    {
                        return false;
                    }
                }
            }            

            return true;
        }

        private static List<string> AddingElements(List<string> elements, byte moves)
        {
            for (int i = 0; i < 2; i++)
            {
                elements.Insert(elements.Count / 2, $"-{moves}a");
            }

            return elements;
        }

        private static bool ElementsMatch(List<int> indexes, List<string> elements)
        {
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            if (elements[firstIndex] == elements[secondIndex])
            {
                return true;
            }

            return false;
        }

        private static List<string> RemovingElements(List<string> elements, List<int> indexes)
        {
            if (indexes[0] < indexes[1])
            {
                indexes.Reverse();
            }

            for (int i = 0; i < indexes.Count; i++)
            {
                int currentIndex = indexes[i];
                elements.RemoveAt(currentIndex);
            }

            return elements;
        }

        static void Main()
        {
            List<string> elements = Console.ReadLine()
                .Split(' ')
                .ToList();

            byte moves = 0;
            byte winningMoves = 0;
            bool hasWon = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    if (hasWon)
                    {
                        Console.WriteLine($"You have won in {winningMoves} turns!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry you lose :(");
                        Console.WriteLine(string.Join(' ', elements));
                    }

                    break;
                }
                else
                {
                    List<int> indexes = input.Split(' ')
                        .Select(int.Parse)
                        .ToList();

                    moves++;

                    if (elements.Count != 0)
                    {
                        if (IndexesAreValid(indexes, elements))
                        {
                            if (ElementsMatch(indexes, elements))
                            {
                                Console.WriteLine($"Congrats! You have found matching elements - {elements[indexes[0]]}!");
                                elements = RemovingElements(elements, indexes);
                            }
                            else
                            {
                                Console.WriteLine("Try again!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Adding additional elements to the board");
                            elements = AddingElements(elements, moves);
                        }

                        if (elements.Count == 0)
                        {
                            hasWon = true;
                            winningMoves = moves;
                        }
                    }
                }
            }
        }
    }
}
