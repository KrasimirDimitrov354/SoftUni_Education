using System;

namespace PizzaCalories
{
    //Pizza Calories
    //You should model a class Pizza, which should have a string Name, a single Dough, and several Toppings as fields.
    //Every type of ingredient is a class with its own properties:
    //  •	Dough
    //      * FlourTypewhite
    //          - White
    //          - Wholegrain
    //      * BakingTechnique
    //          - Crispy
    //          - Chewy
    //          - Homemade
    //  •	Topping
    //      * Type
    //          - Meat
    //          - Veggies
    //          - Cheese
    //          - Sauce
    //
    //Every ingredient should weigh Grams and have a method for calculating its Calories according to its type.
    //Calories per gram are calculated through modifiers. Every ingredient has 2 calories per gram as a base and a modifier that gives the exact calories.
    //For example, a White Dough has a modifier of 1.5, while a Chewy Dough has a modifier of 1.1.
    //This means that a White Chewy Dough weighing 100 grams will have 2 * 100 * 1.5 * 1.1 = 330.00 total calories.
    //
    //Dough modifiers:	
    //  •	White - 1.5;
    //  •	Wholegrain - 1.0;
    //  •	Crispy - 0.9;
    //  •	Chewy - 1.1;
    //  •	Homemade - 1.0;
    //Topping modifiers:
    //  •	Meat - 1.2;
    //  •	Veggies - 0.8;
    //  •	Cheese - 1.1;
    //  •	Sauce - 0.9;
    //
    //The Dough class has the following validation:
    //  •	If an invalid flour type or an invalid baking technique is given, an appropriate Exception is thrown with the message "Invalid type of dough.".
    //  •	The allowed weight of dough is in the range [1..200] grams.
    //      If it's not in this range, throw an appropriate Exception with the message "Dough weight should be in the range [1..200].".
    //Examples:
    //  Dough White Chewy 100 - Valid, no exception thrown.
    //  Dough Tip500 Chewy 100 - Invalid, throw appropriate exception and print "Invalid type of dough."
    //  Dough White Chewy 240 - Invalid, throw appropriate exception and print "Dough weight should be in the range [1..200]."
    //
    //The Topping class has the following validation:
    //  •	If the Type is different from the provided ones, throw an appropriate Exception with the message "Cannot place {name of invalid argument} on top of your pizza.".
    //  •	The allowed weight of a Тopping is in the range [1..50] grams.
    //      If it is outside of this range, throw an appropriate Exception with the message "{Type} weight should be in the range [1..50].".
    //Examples:
    //  Topping meat 30 - Valid, no exception thrown.
    //  Topping Krenvirshi 500 - Invalid, thrown appropriate exception and print "Cannot place Krenvirshi on top of your pizza.".
    //  Topping Meat 500 - Invalid, thrown appropriate exception and print "Meat weight should be in the range [1..50].".
    //
    //NOTE: The classes should only expose a getter for the calories per gram.
    //
    //Now, time to create the Pizza class! A Pizza should have public getters for its name, the number of toppings, and the total calories.
    //The total calories are calculated by summing the calories of all the ingredients a Pizza has.
    //The class should expose a method for adding a topping, a public setter for the dough, and a getter for the total calories.
    //
    //The input for a Pizza consists of several lines. On the first line is the Pizza name. On the second line you will get input for the dough.
    //On the next lines you will receive every topping the Pizza has.
    //
    //The Pizza class has the following validation:
    //  •	The name of the Pizza cannot be an empty string, and it must not be longer than 15 symbols.
    //      If the input does not answer these conditions, throw an appropriate Exception with the message "Pizza name should be between 1 and 15 symbols."
    //  •	The number of toppings should be in the range [0..10].
    //      If it is outside of this range, throw an appropriate Exception with the message "Number of toppings should be in range [0..10].".
    //
    //If the creation of the Pizza is successful, print the name of the Pizza and the total calories it has on a single line.
    //
    //Examples
    //Input
    //  Pizza Meatless
    //  Dough Wholegrain Crispy 100
    //  Topping Veggies 50
    //  Topping Cheese 50
    //  END
    //Output
    //  Meatless - 370.00 Calories.
    //
    //Input
    //  Pizza Burgas
    //  Dough White Homemade 200
    //  Topping Meat 123
    //  END
    //Output
    //  Meat weight should be in the range [1..50].
    //
    //Input
    //  Pizza Bulgarian
    //  Dough White Chewy 100
    //  Topping Sauce 20
    //  Topping Cheese 50
    //  Topping Cheese 40
    //  Topping Meat 10
    //  Topping Sauce 10
    //  Topping Cheese 30
    //  Topping Cheese 40
    //  Topping Meat 20
    //  Topping Sauce 30
    //  Topping Cheese 25
    //  Topping Cheese 40
    //  Topping Meat 40
    //  END
    //Output
    //  Number of toppings should be in range[0..10].
    //
    //Input
    //  Pizza Bulgarian
    //  Dough White Chewy 100
    //  Topping Sirene 50
    //  Topping Cheese 50
    //  Topping Krenvirsh 20
    //  Topping Meat 10
    //  END
    //Output
    //  Cannot place Sirene on top of your pizza.
    //
    //Input
    //  Pizza
    //  Dough White cheWy 200
    //  Topping Meat 50
    //  END
    //Output
    //  Pizza name should be between 1 and 15 symbols.

    public class Program
    {
        static void Main()
        {
            try
            {
                string[] input = Console.ReadLine().Split(' ');

                string pizzaName = null;

                if (input.Length > 1)
                {
                    pizzaName = input[1];
                }

                Pizza pizza = new Pizza(pizzaName);

                while (input[0] != "END")
                {
                    switch (input[0])
                    {
                        case "Dough":
                            pizza.Dough = new Dough(input[1], input[2], double.Parse(input[3]));
                            break;
                        case "Topping":
                            pizza.AddTopping(new Topping(input[1], double.Parse(input[2])));
                            break;
                        default:
                            break;
                    }

                    input = Console.ReadLine().Split(' ');
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
