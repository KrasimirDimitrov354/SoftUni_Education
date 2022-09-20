using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    //SoftUni Bar Income
    //It is about time for the people behind the bar to go home and you are the person who has to draw the line and calculate the money from the products that were sold throughout the day.
    //Until you receive a line with the text "end of shift" you will be given lines of input. But before processing that line you have to do some validations first.
    //
    //Each valid order should have a customer, product, count, and a price:
    //  •	A valid customer's name should be surrounded by '%' and must start with a capital letter, followed by lower-case letters
    //  •	A valid product contains any word character and must be surrounded by '<' and '>' 
    //  •	A valid count is an integer, surrounded by '|'
    //  •	A valid price is any real number followed by '$'
    //
    //The parts of a valid order should appear in the order given: customer, product, count, and price.
    //Between each part there can be other symbols, except ('|', '$', '%' and '.')
    //For each valid line print on the console: "{customerName}: {product} - {totalPrice}"
    //
    //When you receive "end of shift" print the total amount of money for the day rounded to 2 decimal places in the following format: "Total income: {income}".
    //
    //Input / Constraints
    //  •	Strings that you have to process until you receive text "end of shift".
    //Output
    //  •	Print all of the valid lines in the format "{customerName}: {product} - {totalPrice}"
    //  •	After receiving "end of shift" print the total amount of money for the day rounded to 2 decimal places in the following format: "Total income: {income}"
    //  •	Allowed working time / memory: 100ms / 16MB.
    //Examples
    //Input                                 Comment
    //  %George%<Croissant>|2|10.3$         Each line is valid. We print each order, calculating the total price of the product bought.
    //  %Peter%<Gum>|1|1.3$                 In the end, we print the total income for the day.
    //  %Maria%<Cola>|1|2.4$
    //  end of shift
    //Output
    //  George: Croissant - 20.60
    //  Peter: Gum - 1.30
    //  Maria: Cola - 2.40
    //  Total income: 24.30
    //
    //Input                                 Comment
    //  %InvalidName%<Croissant>|2|10.3$    On the first line the customer name isn`t valid. We skip that line.
    //  %Peter%<Gum>1.3$                    The second line is missing product count.
    //  %Maria%<Cola>|1|2.4                 The third line doesn`t have a valid price.
    //  %Valid%<Valid>valid|10|valid20$     Only the fourth line is valid.
    //  end of shift
    //Output
    //  Valid: Valid - 200.00
    //  Total income: 200.00

    class Order
    {
        public Order(string name, string product, int count, double price)
        {
            this.Name = name;
            this.Product = product;
            this.Count = count;
            this.Price = price;
        }

        public string Name { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double TotalPrice 
        { 
            get { return Count * Price; } 
        }

        public static void PrintAllProfit(List<Order> orders)
        {
            double total = 0.0;

            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.Name}: {order.Product} - {order.TotalPrice:f2}");
                total += order.TotalPrice;
            }

            Console.WriteLine($"Total income: {total:f2}");
        }
    }

    class Program
    {
        static void Main()
        {
            string orderPattern = @"[^%$|.]*%{1}(?<name>[A-Z]{1}[a-z]+)%{1}[^%$|.]*<{1}(?<product>\w+)>{1}[^%$|.]*\|{1}(?<count>[0-9]+)\|{1}[^%$|.0-9]*(?<price>[0-9]+(?:\.[0-9]+)*)\${1}[^%$|.]*$";
            List<Order> orders = new List<Order>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    Order.PrintAllProfit(orders);
                    break;
                }
                else
                {
                    Regex regex = new Regex(orderPattern);

                    if (regex.IsMatch(input))
                    {
                        Match orderMatch = regex.Match(input);
                        Order order = new Order(orderMatch.Groups["name"].Value,
                            orderMatch.Groups["product"].Value,
                            int.Parse(orderMatch.Groups["count"].Value),
                            double.Parse(orderMatch.Groups["price"].Value));
                        orders.Add(order);
                    }
                }
            }
        }
    }
}
