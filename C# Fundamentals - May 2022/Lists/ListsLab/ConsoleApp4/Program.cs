using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        //List of Products
        //Read a number n and n lines of products. Print a numbered list of all the products ordered by name.
        //Examples
        //Input         Output
        //4             1.Apples
        //Potatoes      2.Onions
        //Tomatoes      3.Potatoes
        //Onions        4.Tomatoes
        //Apples	
        //
        //Input         Output
        //5             1.Artichokes
        //Carrots       2.Beans
        //Artichokes    3.Carrots
        //Beans         4.Eggplants
        //Eggplants     5.Peppers
        //Peppers 

        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }

            products.Sort();

            for (int i = 1; i <= products.Count; i++)
            {
                Console.WriteLine($"{i}.{products[i - 1]}");
            }
        }
    }
}
