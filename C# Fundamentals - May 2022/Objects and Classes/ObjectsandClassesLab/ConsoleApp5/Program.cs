using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        //Store Boxes
        //Define a class Item which contains these properties: Name and Price.
        //Define a class Box which contains these properties: Serial Number, Item, Item Quantity and Price for a Box.
        //
        //Until you receive "end", you will be receiving data in the following format: "{Serial Number} {Item Name} {Item Quantity} {itemPrice}"
        //The Price of one box has to be calculated: itemQuantity * itemPrice.
        //
        //After receiving "end", print all the boxes, ordered descending by price for a box, in the following format: 
        //{boxSerialNumber}
        //-- {boxItemName} – ${boxItemPrice}: {boxItemQuantity}
        //-- ${boxPrice}
        //
        //The price should be formatted to the 2nd digit after the decimal separator.
        //
        //Examples
        //Input
        //  19861519 Dove 15 2.50
        //  86757035 Butter 7 3.20
        //  39393891 Orbit 16 1.60
        //  37741865 Samsung 10 1000
        //  end
        //Output
        //  37741865
        //  -- Samsung - $1000.00: 10
        //  -- $10000.00
        //  19861519
        //  -- Dove - $2.50: 15
        //  -- $37.50
        //  39393891
        //  -- Orbit - $1.60: 16
        //  -- $25.60
        //  86757035
        //  -- Butter - $3.20: 7
        //  -- $22.40
        //
        //Input
        //  48760766 Alcatel 8 100
        //  97617240 Intel 2 500
        //  83840873 Milka 20 2.75
        //  35056501 SneakersXL 15 1.50
        //  end
        //Output
        //  97617240
        //  -- Intel - $500.00: 2
        //  -- $1000.00
        //  48760766
        //  -- Alcatel - $100.00: 8
        //  -- $800.00
        //  83840873
        //  -- Milka - $2.75: 20
        //  -- $55.00
        //  35056501
        //  -- SneakersXL - $1.50: 15
        //  -- $22.50

        private class Package
        {
            public string SerialNumber { get; set; }
            public string ItemName { get; set; }
            public int ItemQuantity { get; set; }
            public double ItemPrice { get; set; }
            public double PackagePrice { get; set; }

            public double CalculatePackagePrice(int quantity, double price)
            {
                return quantity * price;
            }
        }

        private static void PrintPackages(List<Package> packages)
        {
            while (packages.Count > 0)
            {
                Package package = packages[0];
                double maxPackagePrice = 0.0;

                for (int i = 0; i < packages.Count; i++)
                {
                    double currentPackagePrice = packages[i].PackagePrice;

                    if (currentPackagePrice > maxPackagePrice)
                    {
                        maxPackagePrice = currentPackagePrice;
                        package = packages[i];
                    }
                }

                Console.WriteLine(package.SerialNumber);
                Console.WriteLine($"-- {package.ItemName} - ${package.ItemPrice:f2}: {package.ItemQuantity}");
                Console.WriteLine($"-- ${package.PackagePrice:f2}");

                packages.Remove(package);
            }          
        }

        static void Main()
        {
            List<Package> packages = new List<Package>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    PrintPackages(packages);
                    break;
                }
                else
                {
                    List<string> packageInfo = input.Split(' ').ToList();

                    string serialNumber = packageInfo[0];
                    string itemName = packageInfo[1];
                    int itemQuantity = int.Parse(packageInfo[2]);
                    double itemPrice = double.Parse(packageInfo[3]);

                    Package package = new Package();

                    package.SerialNumber = serialNumber;
                    package.ItemName = itemName;
                    package.ItemQuantity = itemQuantity;
                    package.ItemPrice = itemPrice;
                    package.PackagePrice = package.CalculatePackagePrice(itemQuantity, itemPrice);

                    packages.Add(package);
                }
            }
        }
    }
}
