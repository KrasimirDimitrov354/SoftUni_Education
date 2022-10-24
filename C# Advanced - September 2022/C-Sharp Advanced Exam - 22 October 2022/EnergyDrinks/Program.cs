using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    //Energy Drinks
    //Your friend Stamat is working on a new AI program. Like every irresponsible teenager, he programs all night and, of course, drinks a lot of energy drinks.
    //Stamat's friends are concerned about him and want you to create a program that tells him when to stop the energy drinks and start drinking water.
    //
    //On the first line you will receive a sequence of numbers representing milligrams of caffeinе.
    //On the second line you will receive another sequence of numbers representing energy drinks.
    //
    //It is important to know that the maximum caffeine Stamat can have for the night is 300 milligrams, and his initial is always 0.
    //
    //To calculate the caffeine in the drink, take the last milligrams of caffeinе and the first energy drink, then multiply them.
    //
    //Compare the result with the caffeine Stamat drank.
    //  •	If the sum of the drink doesn't exceed 300 milligrams, remove both the milligrams of caffeinе and the energy drink from their sequences.
    //      Add the sum of the drink to Stamat's total caffeine.
    //  •	If Stamat is about to exceed his maximum caffeine per night, do not add the caffeine to Stamat’s total caffeine.
    //      Remove the milligrams of caffeinе and move the drink to the end of the sequence.
    //      Reduce the current caffeine that Stamat has taken by 30. Stamat's caffeine cannot go below 0.
    //
    //Stop calculating when you are out of drinks or milligrams of caffeine.
    //
    //Input
    //  •	On the first line you will be given a sequence of the milligrams of caffeinе - integers separated by comma and space ", " in the range [1, 50].
    //  •	On the second line you will be given a sequence of energy drinks - integers separated by comma and space ", " in the range [1, 300].
    //Output
    //  •	On the first line:
    //      o   If Stamat hasn't drank all the energy drinks, print the remaining ones separated by a comma and a space ", ": 
    //          	"Drinks left: {remaining drinks separated by ", " }"
    //      o   If Stamat has drunk all the energy drinks, print:
    //          	"At least Stamat wasn't exceeding the maximum caffeine."
    //  •	On the next line, print:
    //      o   "Stamat is going to sleep with { current caffeine } mg caffeine."
    //Constraints
    //  •	You will always have at least one element in each sequence at the beginning.
    //
    //Examples
    //Input                         Output
    //34, 2, 3                      Drinks left: 100, 250
    //40, 100, 250                  Stamat is going to sleep with 60 mg caffeine.
    //
    //Comment
    //1) We take the last milligrams of caffeine (3) and multiply them by the first energy drink (40).
    //   The result (120) doesn’t exceed the caffeine limit per day (300), so we can add it to Stamat's caffeine.
    //   We remove both items from their sequences. Stamat can accept 180 miligrams of caffeine more.
    //
    //2) We take the next mg of caffeine (2) and multiply them by the next energy drink (100).
    //   The result is 200 and if Stamat takes the drink, he will exceed the caffeine limit per day.
    //   We remove the mg of caffeine (2) and place the drink (100) at the end of the sequence ("250, 100").
    //   Then we decrease Stamat's caffeine by 30 (Stamat's caffeine becomes 90).
    //   Stamat can accept 210 miligrams of caffeine more.
    //
    //3) We take the next mg of caffeine (34) and multiply them by the next energy drink (250).
    //   The result (8500) is above 210, so we remove the mg of caffeine (34) and place the drink (250) at the end of the sequence ("100, 250").
    //   Then we decrease Stamat's caffeine by 30 (Stamat's caffeine becomes 60).
    //
    //4) Stamat goes to sleep with 60 mg of caffeine.
    //
    //Input                         Output
    //1, 16, 8, 14, 5               At least Stamat wasn't exceeding the maximum caffeine.
    //27, 23                        Stamat is going to sleep with 289 mg caffeine.
    //
    //Input                         Output
    //1, 23, 2, 1, 42, 22, 7, 14    At least Stamat wasn't exceeding the maximum caffeine.
    //51, 100, 3, 7                 Stamat is going to sleep with 264 mg caffeine.

    class Program
    {
        static void Main()
        {
            Stack<int> caffeinе = new Stack<int>(GetDosages());
            Queue<int> energyDrinks = new Queue<int>(GetDosages());

            int total = 0;

            while (caffeinе.Count > 0 && energyDrinks.Count > 0)
            {
                int currentCaffeine = caffeinе.Pop();
                int currentEnergyDrink = energyDrinks.Dequeue();

                if (total + (currentCaffeine * currentEnergyDrink) > 300)
                {
                    total -= 30;

                    if (total < 0)
                    {
                        total = 0;
                    }

                    energyDrinks.Enqueue(currentEnergyDrink);
                }
                else
                {
                    total += (currentCaffeine * currentEnergyDrink);
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {String.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {total} mg caffeine.");
        }

        private static IEnumerable<int> GetDosages()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n));
        }
    }
}
