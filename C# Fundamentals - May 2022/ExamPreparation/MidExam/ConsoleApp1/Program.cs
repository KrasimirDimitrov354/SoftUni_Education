using System;

namespace ConsoleApp1
{
    class Program
    {
        //Computer Store
        //Write a program that prints you a receipt for your new computer.
        //You will receive the parts' prices (without tax) until you receive what type of customer this is - special or regular.
        //Once you receive the type of customer you should print the receipt.
        //The taxes are 20% of each part's price you receive.
        //
        //If the customer is special, he has a 10% discount on the total price with taxes.
        //If a given price is not a positive number, you should print "Invalid price!" on the console and continue with the next price.
        //If the total price is equal to zero, you should print "Invalid order!" on the console.
        //
        //Input
        //  •	You will receive numbers representing prices (without tax) until command "special" or "regular":
        //Output
        //  •	The receipt should be in the following format: 
        //      "Congratulations you've just bought a new computer!
        //      Price without taxes: {total price without taxes}$
        //      Taxes: {total amount of taxes}$
        //      -----------
        //      Total price: {total price with taxes}$"
        //
        //Note: All prices should be displayed to the second digit after the decimal point!
        //The discount is applied only on the total price. Discount is only applicable to the final price!
        //
        //Examples:
        //Input         Output                                                      Comment
        //1050          Congratulations you've just bought a new computer!          1050 – valid price, total 1050
        //200           Price without taxes: 1737.36$                               200 – valid price, total 1250
        //450           Taxes: 347.47$                                              …
        //2             -----------                                                 16.86 – valid price, total 1737.36
        //18.50         Total price: 1876.35$                                       We receive special
        //16.86                                                                     Price is positive number, so it is valid order
        //special                                                                   Price without taxes is 1737.36
        //                                                                          Taxes: 20% from 1737.36 = 347.47      
        //                                                                          Final price = 1737.36 + 347.47 = 2084.83
        //                                                                          Additional 10% discount for special customers
        //                                                                          2084.83 – 10% = 1876.35 
        //Input         Output
        //1023          Invalid price!
        //15            Invalid price!
        //-20           Congratulations you've just bought a new computer!
        //-5.50         Price without taxes: 1544.96$
        //450           Taxes: 308.99$
        //20            -----------
        //17.66         Total price: 1853.95$
        //19.30
        //regular
        //
        //Input         Output
        //regular       Invalid order!

        static void Main()
        {
            double total = 0.0;
            double tax = 0.0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "regular" || input == "special")
                {
                    string customer = input;

                    if (total == 0)
                    {
                        Console.WriteLine("Invalid order!");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations you've just bought a new computer!");
                        Console.WriteLine($"Price without taxes: {total:f2}$");
                        Console.WriteLine($"Taxes: {tax:f2}$");
                        Console.WriteLine("-----------");
                        Console.Write("Total price: ");

                        total += tax;

                        if (customer == "special")
                        {
                            Console.WriteLine($"{total - (total * 0.1):f2}$");
                        }
                        else
                        {
                            Console.WriteLine($"{total:f2}$");
                        }
                    }

                    break;
                }
                else
                {
                    double price = double.Parse(input);

                    if (price <= 0)
                    {
                        Console.WriteLine("Invalid price!");
                    }
                    else
                    {
                        total += price;
                        tax += price * 0.2;
                    }
                }
            }
        }
    }
}
