using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    //Product Shop
    //Create a program that prints information about food shops and the products they store.
    //
    //Until the "Revision" command is received, you will be receiving input in the format: "{shop}, {product}, {price}".
    //Keep in mind that if you receive a shop you already have received, you must collect its product information.
    //
    //Your output must be ordered by shop name and must be in the format:
    //  "{shop}->
    //  Product: { product}, Price: {price}"
    //
    //Note: The price should not be rounded or formatted.
    //
    //Examples
    //Input                         Output
    //lidl, juice, 2.30             fantastico->
    //fantastico, apple, 1.20       Product: apple, Price: 1.2
    //kaufland, banana, 1.10        Product: grape, Price: 2.2
    //fantastico, grape, 2.20       kaufland->
    //Revision                      Product: banana, Price: 1.1
    //                              lidl->
    //                              Product: juice, Price: 2.3
    //
    //Input                         Output
    //tmarket, peanuts, 2.20        GoGrill->
    //GoGrill, meatballs, 3.30      Product: meatballs, Price: 3.3
    //GoGrill, HotDog, 1.40         Product: HotDog, Price: 1.4
    //tmarket, sweets, 2.20         tmarket->
    //Revision                      Product: peanuts, Price: 2.2
    //                              Product: sweets, Price: 2.2

    class Product
    {
        public Product(string productName, decimal productPrice)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }

        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }

    class Program
    {
        static void Main()
        {
            SortedDictionary<string, List<Product>> productsInShops = new SortedDictionary<string, List<Product>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Revision")
                {
                    foreach (var shop in productsInShops)
                    {
                        Console.WriteLine($"{shop.Key}->");

                        for (int i = 0; i < shop.Value.Count; i++)
                        {
                            Console.WriteLine($"Product: {shop.Value[i].ProductName}, Price: {shop.Value[i].ProductPrice.ToString("G29")}");
                        }
                    }

                    break;
                }
                else
                {
                    string shop = input[0];
                    string productName = input[1];
                    decimal productPrice = decimal.Parse(input[2]);
                    Product product = new Product(productName, productPrice);

                    if (productsInShops.ContainsKey(shop) == false)
                    {
                        productsInShops.Add(shop, new List<Product>());
                    }

                    bool productDoesNotExist = true;

                    foreach (Product prod in productsInShops[shop])
                    {
                        if (prod.ProductName == product.ProductName)
                        {
                            prod.ProductPrice += product.ProductPrice;
                            productDoesNotExist = false;
                            break;
                        }
                    }

                    if (productDoesNotExist)
                    {
                        productsInShops[shop].Add(product);
                    }

                }
            }
        }
    }
}
