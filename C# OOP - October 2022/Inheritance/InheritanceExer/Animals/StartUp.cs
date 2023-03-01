using System;
using System.Collections.Generic;

namespace Animals
{
    //Animals
    //Create a hierarchy of Animals with the following properties:
    //  •	Name - string
    //  •	Age - integer
    //  •	Gender - string
    //
    //Your program must have three different animals – Dog, Frog, and Cat. Cat must have two additional classes below itself – Kitten and Tomcat.
    //Kittens are always female and Tomcats are always male.
    //
    //All types of animals should be able to produce some kind of sound through the method ProduceSound().
    //
    //You will be given some lines of input. Every two lines will represent an animal.
    //On the first line you will be given the type of animal. On the second line you will be given the name, the age and the gender.
    //When the command "Beast!" is given, print all the animals in the format shown below.
    //
    //Output
    //  •	Print the information for each animal on three lines. On the first line, print: "{AnimalType}"
    //  •	On the second line print: "{Name} {Age} {Gender}"
    //  •	On the third line print the sounds it produces: "{ProduceSound()}"
    //Constraints
    //  •	Each Animal must have a name, an age, and a gender.
    //  •	All input values must not be blank (null or 0).
    //  •	If you receive an input for the gender of a Tomcat or a Kitten, ignore it but create the animal.
    //  •	If the input is invalid for one of the properties, throw an exception with the message: "Invalid input!" and do not print the animal.
    //  •	Each animal must have the functionality to ProduceSound().
    //  •	Here is the type of sound each animal should produce:
    //      o Dog: "Woof!"
    //      o Cat: "Meow meow"
    //      o Frog: "Ribbit"
    //      o Kitten: "Meow"
    //      o Tomcat: "MEOW"
    //
    //Examples
    //Input
    //  Cat
    //  Tom 12 Male
    //  Dog
    //  Buddy 132 Male
    //  Beast!
    //Output
    //  Cat
    //  Tom 12 Male
    //  Meow meow
    //  Dog
    //  Buddy 132 Male
    //  Woof!
    //
    //Input
    //  Frog
    //  Kermit 12 Male
    //  Beast!
    //Output
    //  Frog
    //  Kermit 12 Male
    //  Ribbit
    //
    //Input
    //  Frog
    //  Jelly -2 Male
    //  Frog
    //  Bully 2 Male
    //  Beast!
    //Output
    //  Invalid input!
    //  Frog
    //  Bully 2 Male
    //  Ribbit

    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();

            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] animalData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (input)
                {
                    case "Dog":
                        Dog dog = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);

                        if (dog.IsValid())
                        {
                            animals.Add(dog);
                        }
                        break;
                    case "Cat":
                        Cat cat = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);

                        if (cat.IsValid())
                        {
                            animals.Add(cat);
                        }
                        break;
                    case "Frog":
                        Frog frog = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);

                        if (frog.IsValid())
                        {
                            animals.Add(frog);
                        }
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(animalData[0], int.Parse(animalData[1]));

                        if (kitten.IsValid())
                        {
                            animals.Add(kitten);
                        }
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(animalData[0], int.Parse(animalData[1]));

                        if (tomcat.IsValid())
                        {
                            animals.Add(tomcat);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
