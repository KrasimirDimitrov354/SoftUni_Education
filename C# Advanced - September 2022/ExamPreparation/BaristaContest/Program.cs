﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    //Barista Contest
    //Nina is a barista and she just signed up for a barista contest where she has to make as much coffee drinks as possible.
    //She asked you to help her and create a program that will help her count the types of drinks she manages to make.
    //Nina makes the drinks with coffee and milk and each of them come in different quantities.
    //
    //First you will be given a sequence of numbers representing the quantities of the coffee.
    //Afterward you will be given another sequence, this time representing the quantities of the milk.
    //You have to start from the first coffee quantity and compare it to the quantity of the last milk.
    //
    //If the sum of their values is equal to any of the coffee drinks from the table below, it means that Nina is able to make the corresponding drink.
    //In this case, you should remove both quantities from the sequences and continue with the next ones.
    //
    //If their sum is not equal to any of the drinks from the table, remove the current coffee quantity.
    //After that you should take the milk quantity, decrease it by 5 and insert it back to the sequence.
    //
    //Coffee drink  Quantities needed
    //Cortado       50
    //Espresso      75
    //Capuccino     100
    //Americano     150
    //Latte         200
    //
    //Try creating as much drinks as possible while keeping track of the count of different types of coffee beverages that were made.
    //You stop comparing the sum of the coffee and milk in case you are out both of milk and coffee, or in case any one of them is out.
    //
    //Finally, print the different coffee drinks that Nina managed to make, and their count.
    //
    //Input
    //  •	On the first line you will receive the coffee quantities, separated by a comma and a single space (', '). 
    //  •	On the second line you will receive the milk quantities, separated by a comma and a single space(', ').
    //Output
    //  •	On the first line – print whether Nina managed to use all of the coffee and milk:
    //      o If she managed to use all of the coffee and all of the milk: "Nina is going to win! She used all the coffee and milk!"
    //      o If she didn't manage to use all of the coffee and milk: "Nina needs to exercise more! She didn't use all the coffee and milk!"
    //  •	On the second line – print all of the coffee that you have left:
    //      o If there is no coffee left: "Coffee left: none"
    //      o If there is coffee left: "Coffee left: {coffee1}, {coffee2}, {coffee3}, (…)"
    //  •	On the third line – print all of the milk that you have left:
    //      o If there is no milk left: "Milk left: none"
    //      o If is milk left: "Milk left: {milk1}, {milk2}, {milk3}, (…)"
    //  •	Then you need to print the different types of coffee drinks that were made, and their count.
    //      They must be ordered ascending by number and then sorted descending alphabetically.
    //      o   "Latte: {amount}"
    //      o   "Espresso: {amount}"
    //      o   "Cortado: {amount}"
    //      o   "Capuccino: {amount}"
    //      o   "Americano: {amount}"
    //Constraints
    //  •	All of the given numbers will be valid integers in the range [0 … 200].
    //  •	There will be no case where a milk quantity reaches 0.
    //  •	Do not use "\r\n" for a new line.
    //
    //Examples
    //Input                                                         Comment
    //  20, 35, 100, 27, 56, 30, 30                                 We start by taking the first coffee quantity (20) and the last milk quantity (30).
    //  45, 20, 144, 173, 100, 40, 30                               Their sum is 20 + 30 = 50.
    //Output                                                        We check if there is a drink with a quantity of 50. There is such, the Cortado.
    //  Nina is going to win! She used all the coffee and milk!     We add the Cortado to a collection that holds the prepared drinks.
    //  Coffee left: none                                           After that we remove both quantities from the input collections.
    //  Milk left: none                                             Next we have 35 + 40 = 75. The Espresso needs a total quantity of 75.
    //  Espresso: 2                                                 We add it to the collection with drinks and remove both quantities.
    //  Cortado: 2                                                  100 + 100 = 200. We add one Latte. 27 + 173 = 200. We add another Latte.
    //  Latte: 3                                                    56 + 144 = 200. Third Latte. 30 + 20 = 50. Second Cortado. 30 + 45 = 75. Second Espresso.
    //                                                              We have no more coffee and milk quantities, so we print the corresponding messages.
    //
    //Input
    //  20, 1, 10, 16, 1, 5
    //  205, 70, 30
    //Output
    //  Nina is going to win! She used all the coffee and milk!
    //  Coffee left: none
    //  Milk left: none
    //  Latte: 1
    //  Espresso: 1
    //  Cortado: 1
    //
    //Input
    //  25, 50, 30
    //  50, 25
    //Output
    //  Nina needs to exercise more! She didn't use all the coffee and milk!
    //  Coffee left: 30
    //  Milk left: none
    //  Cortado: 1
    //  Capuccino: 1

    class Program
    {
        static void Main()
        {
            Dictionary<string, int> countOfDrinks = new Dictionary<string, int>();
            Queue<int> coffeeQuantities = new Queue<int>(GetQuantities());
            Stack<int> milkQuantities = new Stack<int>(GetQuantities());

            while (coffeeQuantities.Count > 0 && milkQuantities.Count > 0)
            {
                int currentCoffee = coffeeQuantities.Dequeue();
                int currentMilk = milkQuantities.Pop();

                string drink = GetDrink(currentCoffee, currentMilk);

                if (drink == "Invalid drink")
                {
                    milkQuantities.Push(currentMilk - 5);
                }
                else
                {
                    if (!countOfDrinks.ContainsKey(drink))
                    {
                        countOfDrinks.Add(drink, 0);
                    }

                    countOfDrinks[drink]++;
                }
            }

            PrintNinaPerformance(coffeeQuantities, milkQuantities);

            var orderedDrinks = countOfDrinks
                .OrderBy(d => d.Value)
                .ThenByDescending(d => d.Key)
                .ToDictionary(d => d.Key, d => d.Value);

            foreach (var drink in orderedDrinks)
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }

        private static IEnumerable<int> GetQuantities()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(q => int.Parse(q));
        }

        private static string GetDrink(int currentCoffee, int currentMilk)
        {
            switch (currentCoffee + currentMilk)
            {
                case 50:
                    return "Cortado";
                case 75:
                    return "Espresso";
                case 100:
                    return "Capuccino";
                case 150:
                    return "Americano";
                case 200:
                    return "Latte";
                default:
                    return "Invalid drink";
            }
        }

        private static void PrintNinaPerformance(Queue<int> coffeeQuantities, Stack<int> milkQuantities)
        {
            if (coffeeQuantities.Count == 0 && milkQuantities.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            Console.WriteLine($"Coffee left: {QuantityLeft(coffeeQuantities)}");
            Console.WriteLine($"Milk left: {QuantityLeft(milkQuantities)}");
        }

        private static string QuantityLeft<T>(T quantity) where T : IEnumerable<int>
        {
            if (quantity.Count() == 0)
            {
                return "none";
            }
            else
            {
                return String.Join(", ", quantity);
            }
        }
    }
}
