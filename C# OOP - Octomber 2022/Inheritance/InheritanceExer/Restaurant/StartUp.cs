using Restaurant.Beverage;
using Restaurant.Beverage.Hot;
using Restaurant.Food;
using Restaurant.Food.Appetizer;
using Restaurant.Food.Main;
using Restaurant.Food.Sweet;

namespace Restaurant
{
    //Restaurant
    //
    //There are Food and Beverages in the restaurant, and they are all products.
    //
    //The Product class must have a constructor with the following parameters:
    //  o Name – string
    //  o Price – decimal
    //
    //The Beverage class must have a constructor with the following parameters:
    //  •	Name – string
    //  •	Price – decimal
    //  •	Milliliters – double
    //
    //HotBeverage and ColdBeverage are beverages and they reuse the constructor of the inherited class.
    //
    //Coffee and Tea are hot beverages.
    //
    //The Coffee class must accept one more parameter in its constructor - double calories.
    //The Coffee class must have the following constant values:
    //  •	double CoffeeMilliliters = 50
    //  •	decimal CoffeePrice = 3.50
    //
    //The Food class must have a constructor with the following parameters:
    //  o Name – string
    //  o Price – decimal
    //  o Grams – double
    //
    //MainDish, Dessert and Starter are food. They reuse the base class constructor.
    //
    //The Dessert class must accept one more parameter in its constructor - double calories.
    //
    //Create the classes Fish, Soup and Cake, and have them inherit the proper classes.
    //
    //The Cake class must have the following constant values:
    //  •	Grams = 250
    //  •	Calories = 1000
    //  •	CakePrice = 5
    //A Fish must have the following constant values:
    //  •	Grams = 22

    public class StartUp
    {
        public static void Main()
        {

        }
    }
}