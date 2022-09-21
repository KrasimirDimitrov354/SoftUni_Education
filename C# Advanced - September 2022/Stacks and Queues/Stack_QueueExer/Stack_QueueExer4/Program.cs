using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer4
{
    //Fast Food
    //Write a program that checks the quantity of orders in a fast food restaurant.
    //You also want to know the client with the biggest order for the day.
    //
    //First, you will be given the quantity of the food that you have for the day (an integer number).
    //Next, you will be given a sequence of integers, each representing the quantity of an order.
    //
    //Keep the orders in a queue. Find the biggest order and print it.
    //
    //You will begin servicing your clients from the first one that came. Before each order, check if you have enough food left to complete it.
    //If you have, remove the order from the queue and reduce the amount of food you have. If you succeeded in servicing all of your clients, print: "Orders complete".
    //If not, print: "Orders left: {order1} {order2} .... {orderN}".
    //
    //Input
    //  •	On the first line you will be given the quantity of your food - an integer in the range [0, 1000].
    //  •	On the second line you will receive a sequence of integers representing each order, separated by a single space.
    //Output
    //  •	Print the quantity of the biggest order.
    //  •	Print "Orders complete" if the orders are complete.
    //  •	If there are orders left, print them in the format given above.
    //Constraints
    //  •	The input will always be valid
    //Examples
    //Input             Output              Input                       Output
    //348               54                  499                         90
    //20 54 30 16 7 9   Orders complete     57 45 62 70 33 90 88 76     Orders left: 76

    class Program
    {
        static void Main()
        {
            int foodAvailable = int.Parse(Console.ReadLine());

            Queue<int> queueOfOrders = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToList());

            Console.WriteLine(queueOfOrders.Max());

            while (foodAvailable > 0 && queueOfOrders.Count > 0)
            {
                int currentOrder = queueOfOrders.Peek();

                if (foodAvailable - currentOrder >= 0)
                {
                    queueOfOrders.Dequeue();
                    foodAvailable -= currentOrder;
                }
                else
                {
                    foodAvailable = 0;
                }
            }

            if (queueOfOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {String.Join(' ', queueOfOrders)}");
            }
        }
    }
}
