using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Wild_Zoo
{
    class Animal
    {
        public Animal(string name, int neededFood)
        {
            this.Name = name;
            this.NeededFood = neededFood;
        }

        public string Name { get; set; }
        public int NeededFood { get; set; }

        public void Eat(int foodGiven)
        {
            this.NeededFood -= foodGiven;
        }
    }

    class Program
    {
        private static void AddAnimal(Dictionary<string, List<Animal>> areasWithAnimals, string animalInfoRaw)
        {
            string[] animalInfo = animalInfoRaw
                .Split('-', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string animalName = animalInfo[0];
            int animalFood = int.Parse(animalInfo[1]);
            string animalArea = animalInfo[2];

            Animal animal = new Animal(animalName, animalFood);

            if (areasWithAnimals.ContainsKey(animalArea) == false)
            {
                areasWithAnimals.Add(animalArea, new List<Animal>());
                areasWithAnimals[animalArea].Add(animal);
            }
            else
            {
                List<Animal> animalsInArea = areasWithAnimals[animalArea];

                if (animalsInArea.Exists(a => a.Name == animalName))
                {
                    int indexOfAnimal = animalsInArea.FindIndex(a => a.Name == animalName);
                    animalsInArea[indexOfAnimal].NeededFood += animalFood;
                }
                else
                {
                    animalsInArea.Add(animal);
                }
            } 
        }

        private static void FeedAnimal(Dictionary<string, List<Animal>> areasWithAnimals, string animalInfoRaw)
        {
            string[] animalInfo = animalInfoRaw
                .Split('-', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string animalName = animalInfo[0];
            int foodGiven = int.Parse(animalInfo[1]);

            foreach (var area in areasWithAnimals)
            {
                List<Animal> animalsInArea = area.Value;

                if (animalsInArea.Exists(a => a.Name == animalName))
                {
                    int indexOfAnimal = animalsInArea.FindIndex(a => a.Name == animalName);
                    animalsInArea[indexOfAnimal].Eat(foodGiven);

                    if (animalsInArea[indexOfAnimal].NeededFood <= 0)
                    {
                        Console.WriteLine($"{animalName} was successfully fed");
                        animalsInArea.RemoveAt(indexOfAnimal);
                    }

                    break;
                }
            }
        }

        private static void ShowHungryAnimals(Dictionary<string, List<Animal>> areasWithAnimals)
        {
            Dictionary<string, List<Animal>> areasWithHungryAnimals = new Dictionary<string, List<Animal>>(areasWithAnimals
                .Where(area => area.Value.Count != 0));

            Console.WriteLine("Animals:");
            foreach (var area in areasWithHungryAnimals)
            {
                List<Animal> currentArea = area.Value;

                foreach (Animal animal in currentArea)
                {
                    Console.WriteLine($" {animal.Name} -> {animal.NeededFood}g");
                }
            }

            Console.WriteLine($"Areas with hungry animals:");
            foreach (var area in areasWithHungryAnimals)
            {
                Console.WriteLine($" {area.Key}: {area.Value.Count}");
            }
        }

        static void Main()
        {
            Dictionary<string, List<Animal>> areasWithAnimals = new Dictionary<string, List<Animal>>();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "EndDay")
                {
                    ShowHungryAnimals(areasWithAnimals);
                    break;
                }
                else
                {
                    switch (command[0])
                    {
                        case "Add":
                            AddAnimal(areasWithAnimals, command[1]);
                            break;
                        case "Feed":
                            FeedAnimal(areasWithAnimals, command[1]);
                            break;
                    }
                }  
            }
        }
    }
}
