using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    //Wardrobe
    //Create a program that helps you decide what clothes to wear from your wardrobe.
    //
    //You will receive the clothes which are currently in your wardrobe, sorted by their color in the following format:
    //  "{color} -> {item1},{item2},{item3}…"
    //
    //If you receive a certain color which already exists in your wardrobe, just add the clothes to its records.
    //You can also receive repeating items for a certain color and you have to keep their count.
    //
    //Finally, you will receive a color and a piece of clothing for which you must look for in the wardrobe. They will be separated by a space in the following format:
    //  "{color} {clothing}"
    //
    //Your task is to print all the items and their count for each color in the following format: 
    //  "{color} clothes:
    //  * {item1} - {count}
    //  * {item2} - {count}
    //  * {item3} - {count}
    //  …
    //  * {itemN} - {count}"
    //
    //If you find the item you are looking for, you need to print "(found!)" next to it:
    //  "* {itemN} - {count} (found!)"
    //
    //Input
    //  •	On the first line you will receive n - the number of lines of clothes which you will receive.
    //  •	On the next n lines you will receive the clothes in the format described above.
    //Output
    //  •	Print the clothes from your wardrobe in the format described above.
    //
    //Examples
    //Input                             Output
    //4                                 Blue clothes:
    //Blue -> dress,jeans,hat           * dress - 1 (found!)
    //Gold -> dress,t-shirt,boxers      * jeans - 1
    //White -> briefs,tanktop           * hat - 1
    //Blue -> gloves                    * gloves - 1
    //Blue dress                        Gold clothes:
    //                                  * dress - 1
    //                                  * t-shirt - 1
    //                                  * boxers - 1
    //                                  White clothes:
    //                                  * briefs - 1
    //                                  * tanktop - 1
    //
    //Input                             Output
    //4                                 Red clothes:
    //Red -> hat                        * hat - 1
    //Red -> dress,t-shirt,boxers       * dress - 1
    //White -> briefs,tanktop           * t-shirt - 1
    //Blue -> gloves                    * boxers - 1
    //White tanktop                     White clothes:
    //                                  * briefs - 1
    //                                  * tanktop - 1 (found!)
    //                                  Blue clothes:
    //                                  * gloves - 1
    //
    //Input                             Output
    //5                                 Blue clothes:
    //Blue -> shoes                     * shoes - 9
    //Blue -> shoes,shoes,shoes
    //Blue -> shoes,shoes
    //Blue -> shoes
    //Blue -> shoes,shoes
    //Red tanktop

    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                string color = input[0];
                string[] clothes = input[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentClothing = clothes[j];

                    if (!wardrobe[color].ContainsKey(currentClothing))
                    {
                        wardrobe[color].Add(currentClothing, 0);
                    }

                    wardrobe[color][currentClothing]++;
                }
            }

            string[] clothingToFind = Console.ReadLine().Split();

            foreach (var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes:");

                foreach (var clothes in colour.Value)
                {
                    Console.Write($"* {clothes.Key} - {clothes.Value}");

                    if (colour.Key == clothingToFind[0] &&
                        clothes.Key == clothingToFind[1])
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
