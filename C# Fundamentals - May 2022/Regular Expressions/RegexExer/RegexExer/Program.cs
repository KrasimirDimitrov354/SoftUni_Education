using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    //Furniture
    //Create a program to calculate the total cost of different types of furniture.
    //You will be given some lines of input until you receive the line "Purchase". For the line to be valid it should be in the following format:
    //  ">>{furniture name}<<{price}!{quantity}"
    //The price can be a floating-point number or a whole number. Store the names of the furniture and the total price. At the end print each bought furniture on a separate line in the format:
    //  "Bought furniture:
    //  {1st name}
    //  {2nd name}
    //  …"
    //And on the last line print the following: "Total money spend: {spend money}", formatted to the second decimal point.
    //Examples
    //Input                         Comment
    //  >>Sofa<<312.23!3            Only the Sofa and the TV are valid. For each of them we multiply the price by the quantity and print the result.
    //  >>TV<<300!5
    //  >Invalid<<!5
    //  Purchase
    //Output
    //  Bought furniture:
    //  Sofa
    //  TV
    //  Total money spend: 2436.69
    //
    //Input
    //  >>Chair<<412.23!3
    //  >>Sofa<<500!5
    //  >>Recliner<<<<!5
    //  >>Bench<<230!10
    //  >>>>>>Rocking chair<<!5
    //  >>Bed<<700!5
    //  Purchase
    //Output
    //  Bought furniture:
    //  Chair
    //  Sofa
    //  Bench
    //  Bed
    //  Total money spend: 9536.69

    class Furniture
    {
        public Furniture()
        {

        }

        public Furniture(string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static void Main()
        {
            string furniturePattern = @">>(?<furniture>[A-Z][A-Za-z]+)<<(?<price>[0-9]+(?:\.[0-9]+)*)!(?<quantity>[0-9]+)";
            List<Furniture> furnitures = new List<Furniture>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    double total = 0.0;

                    Console.WriteLine("Bought furniture:");

                    foreach (Furniture furniture in furnitures)
                    {
                        Console.WriteLine(furniture.Name);
                        total += furniture.Price * furniture.Quantity;
                    }

                    Console.WriteLine($"Total money spend: {total:f2}");

                    break;
                }
                else
                {
                    Regex regex = new Regex(furniturePattern);

                    if (regex.IsMatch(input))
                    {
                        Match furnitureMatch = regex.Match(input);
                        Furniture furniture = new Furniture(furnitureMatch.Groups["furniture"].Value,
                            double.Parse(furnitureMatch.Groups["price"].Value),
                            int.Parse(furnitureMatch.Groups["quantity"].Value));
                        furnitures.Add(furniture);
                    }
                }
            }
        }
    }
}
