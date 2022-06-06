using System;

namespace ConsoleApp10
{
    class Program
    {
        //Training Hall Equipment
        //You’ll be given a budget and a list of items to buy. Someone else will be tasked with plugging in everything and hopefully not getting anyone electrocuted in the process…
        //Input
        //  •	On the first line, you will receive your budget – a floating-point value in the range [0…1000000]
        //  •	On the second line, you will receive the number of items you need to buy – an integer in the range [0…10]
        //  •	On the next count*3 lines, you will receive the item data as such:
        //      1.	The item name – string
        //      2.	The item price – floating-point value in the range [0.50…1000.00]
        //      3.	The item count – integer in the range [0…1000]
        //Output
        //  Every time an item is added to the cart, print “Adding {count} {item} to cart.” on the console.
        //  Make sure to pluralize item names (if the item count isn’t 1, add an S at the end of the item name).
        //  After all of the items have been added to the cart, you need to calculate the subtotal of the items and check if the budget will be enough.
        //      •	If it’s enough, print “Money left: {moneyLeft}”, formatted to the 2nd decimal point.
        //      •	Otherwise, print “Not enough. We need {moneyNeeded} more.”, formatted to the 2nd decimal point.
        //
        //Examples
        //Input	        Output		                    Input	        Output
        //20000         Adding 2 projectors to cart.    700             Adding 1 projector to cart.
        //4             Adding 1 hdmi cable to cart.    3               Adding 3 hdmi cables to cart.
        //projector     Adding 180 chairs to cart.      projector       Adding 80 chairs to cart.
        //299.99        Adding 60 desks to cart.        399.99          Subtotal: $660.16
        //2             Subtotal: $16202.57             1               Money left: $39.84
        //hdmi cable    Money left: $3797.43            hdmi cable
        //4.99                                          6.99
        //1                                             3
        //chair                                         chair
        //19.99                                         2.99
        //180                                           80
        //desk                                          desk
        //199.99                                        99.99
        //60                                            25
        //Input         Output
        //2000          Adding 1 whiteboard to cart.
        //4             Adding 10 markers to cart.
        //whiteboard    Adding 20 chalks to cart.
        //150           Adding 15 beanbag chairs to cart.
        //1             Subtotal: $2029.75
        //marker        Not enough. We need $29.75 more.
        //6.99
        //10
        //chalk
        //0.50
        //20
        //beanbag chair
        //119.99
        //15

        static void Main()
        {
            int budget = int.Parse(Console.ReadLine());
            int items = int.Parse(Console.ReadLine());
            string[] itemData = new string[3];
            double total = 0.0;
            byte counter = 1;

            for (int i = 1; i <= items * 3; i++)
            {
                string input = Console.ReadLine();

                switch (counter)
                {
                    case 3:
                        {
                            itemData[2] = input;

                            double price = double.Parse(itemData[1]);
                            int count = int.Parse(itemData[2]);

                            if (count > 1)
                            {
                                Console.WriteLine($"Adding {count} {itemData[0]}s to cart.");
                            }
                            else
                            {
                                Console.WriteLine($"Adding {count} {itemData[0]} to cart.");
                            }

                            total += price * count;
                            counter = 1;
                            break;
                        }

                    case 2:
                        itemData[1] = input;
                        counter++;
                        break;
                    default:
                        itemData[0] = input;
                        counter++;
                        break;
                }
            }

            Console.WriteLine($"Subtotal: ${total:f2}");

            if (budget >= total)
            {
                Console.WriteLine($"Money left: ${budget - total:f2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${total - budget:f2} more.");
            }
        }
    }
}
