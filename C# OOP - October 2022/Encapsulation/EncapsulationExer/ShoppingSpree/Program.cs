using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    //Shopping Spree
    //Create two classes - Person and Product.
    //
    //Each person should have a name, money, and a bag of products. Each product should have a name and a cost.
    //The names cannot be an empty string. Money and cost cannot be a negative number.
    //
    //Each command after the initial declarations corresponds to a person buying a product.
    //If the person can afford a product, add it to his bag. If a person doesn’t have enough money, print the message "{personName} can't afford {productName}".
    //
    //On the first two lines you will be given all people and all products.
    //If no exceptions are thrown and the "END" command is reached, print every person in the order of appearance and all their bought products, also in order of appearance.
    //If nothing was bought, print "{personName} - Nothing bought".
    //
    //Break the program with an appropriate message in case of the following invalid input:
    //  •	negative money; Exception message: "Money cannot be negative".
    //  •	empty name; Exception message: "Name cannot be empty".
    //
    //Examples
    //Input
    //  Peter = 11; George=4
    //  Bread=10;Milk=2;
    //  Peter Bread
    //  George Milk
    //  George Milk
    //  Peter Milk
    //  END
    //Output
    //  Peter bought Bread
    //  George bought Milk
    //  George bought Milk
    //  Peter can't afford Milk
    //  Peter - Bread
    //  George - Milk, Milk
    //
    //Input
    //  Maria = 0
    //  Coffee=2
    //  Maria Coffee
    //  END
    //Output
    //  Maria can't afford Coffee
    //  Maria - Nothing bought
    //
    //Input
    //  John=-3
    //  Peppers=1;Tomatoes=2;Cheese=3
    //  John Peppers
    //  John Tomatoes
    //  John Cheese
    //  END
    //Output
    //  Money cannot be negative

    public class Program
    {
        static void Main()
        {
            string[] peopleRaw = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsRaw = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                List<Person> people = FillPeople(peopleRaw);
                List<Product> products = FillProducts(productsRaw);

                string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                while (command[0] != "END")
                {
                    string personName = command[0];
                    string productName = command[1];

                    if (products.Exists(p => p.Name == productName) &&
                        people.Exists(p => p.Name == personName))
                    {
                        people.Find(p => p.Name == personName)
                            .BuyProduct(products.Find(p => p.Name == productName));
                    }

                    command = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<Person> FillPeople(string[] data)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < data.Length; i++)
            {
                string[] currentPerson = data[i].Split('=');
                Person person = new Person(currentPerson[0], int.Parse(currentPerson[1]));
                people.Add(person);
            }

            return people;
        }

        private static List<Product> FillProducts(string[] data)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < data.Length; i++)
            {
                string[] currentProduct = data[i].Split('=');
                Product product = new Product(currentProduct[0], int.Parse(currentProduct[1]));
                products.Add(product);
            }

            return products;
        }
    }
}
