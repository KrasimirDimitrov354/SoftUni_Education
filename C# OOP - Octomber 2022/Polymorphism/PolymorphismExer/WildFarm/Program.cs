using System;
using System.Collections.Generic;

namespace WildFarm
{
    //Wild Farm - 60/100
    //Your task is to create a class hierarchy like the one described below. The Animal, Bird, Mammal, Feline, and Food classes should be abstract. Override the method ToString().
    //  •	Food – int Quantity
    //      •	Vegetable
    //      •	Fruit
    //      •	Meat
    //      •	Seeds
    //  •	Animal – string Name, double Weight, int FoodEaten
    //      •	Bird – double WingSize
    //          •	Owl
    //          •	Hen
    //      •	Mammal – string LivingRegion
    //          •	Mouse
    //          •	Dog
    //          •	Feline – string Breed
    //              •	Cat
    //              •	Tiger
    //
    //All animals should also have the ability to ask for food by producing a sound.
    //  •	Owl – "Hoot Hoot"
    //  •	Hen – "Cluck"
    //  •	Mouse – "Squeak"
    //  •	Dog – "Woof!"
    //  •	Cat – "Meow"
    //  •	Tiger – "ROAR!!!"
    //
    //Use the classes that you have created to instantiate some animals and feed them. Input is read from the console.
    //Every even line (starting from 0) will contain information about an animal in the following format:
    //  •	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}"
    //  •	Birds - "{Type} {Name} {Weight} {WingSize}"
    //  •	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}"
    //
    //On the odd lines you will receive information about a piece of food that you should give to that animal.
    //The line will consist of a FoodType and quantity, separated by whitespace.
    //
    //Animals will only eat a certain type of food:
    //  •	Hens eat everything
    //  •	Mice eat vegetables and fruits
    //  •	Cats eat vegetables and meat
    //  •	Tigers, Dogs, and Owls eat only meat
    //If you try to give an animal a different type of food, it will not eat it and you should print:
    //  •	"{AnimalType} does not eat {FoodType}!"
    //
    //The weight of an animal will increase with every piece of food it eats, as follows:
    //  •	Hen - 0.35
    //  •	Owl - 0.25
    //  •	Mouse - 0.10
    //  •	Cat - 0.30
    //  •	Dog - 0.40
    //  •	Tiger - 1.00
    //
    //Override the ToString() method to print the information about an animal in the formats:
    //  •	Birds - "{AnimalType} [{AnimalName}, {WingSize}, {AnimalWeight}, {FoodEaten}]"
    //  •	Felines - "{AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
    //  •	Mice and Dogs - "{AnimalType} [{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
    //
    //After you have read the information about the animal and the food, the animal must produce a sound. After that, try feeding it.
    //After receiving the "End" command, print information about every animal in order of input.
    //
    //Example
    //Input
    //  Cat Sammy 1.1 Home Persian
    //  Vegetable 4
    //  End
    //Output
    //  Meow
    //  Cat [Sammy, Persian, 2.3, Home, 4]
    //
    //Input
    //  Tiger Rex 167.7 Asia Bengal
    //  Vegetable 1
    //  Dog Tommy 500 Street
    //  Vegetable 150
    //  End
    //Output
    //  ROAR!!!
    //  Tiger does not eat Vegetable!
    //  Woof!
    //  Dog does not eat Vegetable!
    //  Tiger [Rex, Bengal, 167.7, Asia, 0]
    //  Dog [Tommy, 500, Street, 0]
    //
    //Input
    //  Mouse Jerry 0.5 Anywhere
    //  Fruit 1000
    //  Owl Tom 2.5 30
    //  Meat 5
    //  End
    //Output
    //  Squeak
    //  Hoot Hoot
    //  Mouse [Jerry, 100.5, Anywhere, 1000]
    //  Owl [Tom, 30, 3.75, 5]

    class Program
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                animals.Add(GetAnimal(input));

                var currentAnimal = animals[animals.Count - 1];
                currentAnimal.Speak();

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] != "End")
                {
                    currentAnimal.Eat(GetFood(input));

                    input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static Animal GetAnimal(string[] input)
        {
            switch (input[0])
            {
                case "Owl":
                    return new Owl(input[1], double.Parse(input[2]), double.Parse(input[3]));
                case "Hen":
                    return new Hen(input[1], double.Parse(input[2]), double.Parse(input[3]));
                case "Mouse":
                    return new Mouse(input[1], double.Parse(input[2]), input[3]);
                case "Dog":
                    return new Dog(input[1], double.Parse(input[2]), input[3]);
                case "Cat":
                    return new Cat(input[1], double.Parse(input[2]), input[3], input[4]);
                case "Tiger":
                    return new Tiger(input[1], double.Parse(input[2]), input[3], input[4]);
                default:
                    return null;
            }
        }

        private static Food GetFood(string[] input)
        {
            switch (input[0])
            {
                case "Vegetable":
                    return new Vegetable(int.Parse(input[1]));
                case "Fruit":
                    return new Fruit(int.Parse(input[1]));
                case "Meat":
                    return new Meat(int.Parse(input[1]));
                case "Seeds":
                    return new Seeds(int.Parse(input[1]));
                default:
                    return null;
            }
        }
    }
}
