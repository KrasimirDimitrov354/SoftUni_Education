using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9
{
    //Pokemon Don’t Go
    //Ely likes to play Pokemon Go a lot. But Pokemon Go bankrupted so the developers made Pokemon Don’t Go out of depression. And so Ely now plays Pokemon Don’t Go.
    //In Pokemon Don’t Go, when you walk to a certain pokemon, those closest to you naturally get further, and those further from you get closer.
    //
    //You will receive a sequence of integers separated by spaces – the distances to the pokemon. Then you will begin receiving integers, which will correspond to indexes in that sequence.
    //When you receive an index, you must remove the element at that index from the sequence (as if you’ve captured the pokemon).
    //  •	You must increase the value of all elements in the sequence which are less or equal to the removed element, with the value of the removed element.
    //  •	You must decrease the value of all elements in the sequence which are greater than the removed element, with the value of the removed element.
    //
    //If the given index is less than 0, remove the first element of the sequence, and copy the last element to its place.
    //If the given index is greater than the last index of the sequence, remove the last element from the sequence, and copy the first element to its place.
    //The increasing and decreasing of elements should be done in these cases also. The element whose value you should use is the removed element.
    //
    //The program ends when the sequence has no elements (there are no pokemon left for Ely to catch).
    //
    //Input
    //  •	On the first line of input, you will receive a sequence of integers, separated by spaces.
    //  •	On the next several lines you will receive integers – the indexes.
    //Output
    //  •	When the program ends, you must print the summed value of all removed elements.
    //Constrains
    //  •	The input data will consist only of valid integers in the range [-2.147.483.648, 2.147.483.647].
    //Examples
    //Input         Output      Comments
    //4 5 3         14          The array is {4, 5, 3}. The index is 1.
    //1                         We remove 5, and we increase all the lower ones and decrease all the higher ones.
    //1                         In this case, there are no higher than 5.
    //0                         The result is {9, 8}.
    //                          The index is 1. So we remove 8 and decrease all the higher ones.
    //                          The result is {1}. 
    //                          The index is 0. So we remove 1. 
    //                          There are no elements left, so we print the sum of all removed elements - 5 + 8 + 1 = 14.
    //
    //Input         Output      Comments
    //5 10 6 3 5    51          Step 1: {11, 4, 9, 11}
    //2                         Step 2: {22, 15, 20, 22}
    //4                         Step 3: {7, 5, 7}
    //1                         Step 4: {2, 2}
    //1                         Step 5: {4, 4}
    //3                         Step 6: {8}
    //0                         Step 7: {} (empty).
    //0                         Result = 6 + 11 + 15 + 5 + 2 + 4 + 8 = 51.

    class Program
    {
        private static bool IndexOutOfBounds(List<int> list, int index)
        {
            if (index < 0 || index > list.Count - 1)
            {
                return true;
            }

            return false;
        }

        static void Main()
        {
            List<int> pokemons = new List<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(num => int.Parse(num))
                .ToList());

            int caughtPokemonsTotal = 0;

            while (pokemons.Count != 0)
            {
                int caughtPokemonIndex = int.Parse(Console.ReadLine());

                if (IndexOutOfBounds(pokemons, caughtPokemonIndex))
                {
                    if (caughtPokemonIndex < 0)
                    {
                        caughtPokemonIndex = 0;
                    }
                    else if (caughtPokemonIndex > pokemons.Count - 1)
                    {
                        caughtPokemonIndex = pokemons.Count - 1;
                    }                   

                    switch (caughtPokemonIndex)
                    {
                        case 0:
                            pokemons.Insert(0, pokemons[pokemons.Count - 1]);
                            caughtPokemonIndex++;
                            break;
                        default:
                            pokemons.Add(pokemons[0]);
                            break;
                    }
                }                            

                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (i != caughtPokemonIndex)
                    {
                        if (pokemons[i] <= pokemons[caughtPokemonIndex])
                        {
                            pokemons[i] += pokemons[caughtPokemonIndex];
                        }
                        else
                        {
                            pokemons[i] -= pokemons[caughtPokemonIndex];
                        }
                    }                    
                }

                caughtPokemonsTotal += pokemons[caughtPokemonIndex];
                pokemons.RemoveAt(caughtPokemonIndex);
            }

            Console.WriteLine(caughtPokemonsTotal);
        }
    }
}
