using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    //Orders
    //Create a program that keeps the information about products and their prices.  Each product has a name, a price and a quantity.
    //
    //If the product doesn't exist yet, add it with its starting quantity.
    //If you receive a product which already exists, increase its quantity by the input quantity and if its price is different, replace the price as well.
    //
    //You will receive products' names, prices and quantities on new lines. Until you receive the command "buy", keep adding items.
    //When you do receive the command "buy", print the items with their names and the total price of all the products with that name.
    //
    //Input
    //  •	Until you receive "buy", the products will be coming in the format: "{name} {price} {quantity}".
    //  •	The product data is always delimited by a single space.
    //Output
    //  •	Print information about each product in the following format: 
    //      "{productName} -> {totalPrice}"
    //  •	Format the average grade to the 2nd digit after the decimal separator.
    //Examples
    //Input                 Output              | Input                 Output              | Input                     Output
    //Beer 2.20 100         Beer -> 220.00      | Beer 2.40 350         Beer -> 660.00      | CesarSalad 10.20 25       CesarSalad -> 255.00
    //IceTea 1.50 50        IceTea -> 75.00     | Water 1.25 200        Water -> 250.00     | SuperEnergy 0.80 400      SuperEnergy -> 320.00
    //NukaCola 3.30 80      NukaCola -> 264.00  | IceTea 5.20 100       IceTea -> 110.00    | Beer 1.35 350             Beer -> 472.50
    //Water 1.00 500        Water -> 500.00     | Beer 1.20 200                             | IceCream 1.50 25          IceCream -> 37.50
    //buy                                       | IceTea 0.50 120                           | buy 
    //                                          | buy                                       |

    class Product
    {
        public Product(double price, int quantity)
        {
            this.Price = price;
            this.Quantity = quantity;
        }

        public double Price { get; set; }
        public int Quantity { get; set; }

        public double PrintInfo()
        {
            return this.Price * this.Quantity;
        }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<string, Product> informationForProducts = new Dictionary<string, Product>();

            while (true)
            {
                string[] productValues = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                if (productValues[0] == "buy")
                {
                    foreach (var product in informationForProducts)
                    {
                        Console.WriteLine($"{product.Key} -> {product.Value.PrintInfo():f2}");
                    }

                    break;
                }
                else
                {
                    string currentProduct = productValues[0];
                    Product productInfo = new Product(double.Parse(productValues[1]), int.Parse(productValues[2]));

                    if (informationForProducts.ContainsKey(currentProduct) == false)
                    {
                        informationForProducts.Add(currentProduct, productInfo);
                    }
                    else
                    {
                        informationForProducts[currentProduct].Quantity += productInfo.Quantity;

                        if (informationForProducts[currentProduct].Price != productInfo.Price)
                        {
                            informationForProducts[currentProduct].Price = productInfo.Price;
                        }
                    }
                }
            }
        }
    }
}
