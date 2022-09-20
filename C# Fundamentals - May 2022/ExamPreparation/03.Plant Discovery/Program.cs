using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Plant_Discovery
{
    //Plant Discovery
    //Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
    //Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2518#2.
    //
    //You have now returned from your world tour. On your way you have discovered some new plants.
    //You want to gather some information about them and create an exhibition to see which plant is highest rated.
    //
    //On the first line you will receive a number n. On the next n lines you will be given information about the plants in the format: "{plant}<->{rarity}".
    //Store that information because you will need it later. If you receive a plant more than once, update its rarity.
    //
    //Until you receive the command "Exhibition", you will be given some of these commands:
    //  •	"Rate: {plant} - {rating}" – add the given rating to the plant (store all ratings).
    //  •	"Update: {plant} - {new_rarity}" – update the rarity of the plant with the new one.
    //  •	"Reset: {plant}" – remove all the ratings of the given plant.
    //
    //Note: If any given plant name is invalid, print "error".
    //
    //After the command "Exhibition", print the information that you have about the plants in the following format:
    //  "Plants for the exhibition:
    //  - {plant_name1}; Rarity: {rarity}; Rating: {average_rating}
    //  - {plant_name2}; Rarity: {rarity}; Rating: {average_rating}
    //  …
    //  - {plant_nameN}; Rarity: {rarity}; Rating: {average_rating}"
    //
    //The average rating should be formatted to the second decimal place.
    //
    //Input / Constraints
    //  •	You will receive the input as described above.
    //  •	JavaScript: you will receive a list of strings.
    //Output
    //  •	Print the information about all plants as described above.
    //Examples
    //Input                     Output
    //3                         Plants for the exhibition:
    //Arnoldii<->4              - Arnoldii; Rarity: 4; Rating: 0.00
    //Woodii<->7                - Woodii; Rarity: 5; Rating: 7.50
    //Welwitschia<->2           - Welwitschia; Rarity: 2; Rating: 7.00
    //Rate: Woodii - 10
    //Rate: Welwitschia - 7
    //Rate: Arnoldii - 3
    //Rate: Woodii - 5
    //Update: Woodii - 5
    //Reset: Arnoldii
    //Exhibition
    //
    //Input                     Output
    //2                         Plants for the exhibition:
    //Candelabra<->10           - Candelabra; Rarity: 10; Rating: 6.00
    //Oahu<->10                 - Oahu; Rarity: 10; Rating: 7.00
    //Rate: Oahu - 7
    //Rate: Candelabra - 6
    //Exhibition

    class PlantInformation
    {
        public PlantInformation(int rarity, double rating, int countOfRatings)
        {
            this.Rarity = rarity;
            this.Rating = rating;
            this.CountOfRatings = countOfRatings;
        }

        public int Rarity { get; set; }
        public double Rating { get; set; }
        public int CountOfRatings { get; set; }

        public void Print(string plantName)
        {
            double averageRating = 0;

            if (this.Rating != 0)
            {
                averageRating = this.Rating / this.CountOfRatings;
            }

            Console.WriteLine($"- {plantName}; Rarity: {this.Rarity}; Rating: {averageRating:f2}");
        }
    }

    class Program
    {
        private static bool PlantExists(Dictionary<string, PlantInformation> ratingsOfPlants, string plantName)
        {
            if (ratingsOfPlants.ContainsKey(plantName) == false)
            {
                Console.WriteLine("error");
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void ModifyPlantInformation(Dictionary<string, PlantInformation> ratingsOfPlants, string command, string plantInfoRaw)
        {
            string[] plantInfo = plantInfoRaw
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string plantName = plantInfo[0];

            switch (command)
            {
                case "Rate":
                    {
                        double plantRating = double.Parse(plantInfo[1]);

                        if (PlantExists(ratingsOfPlants, plantName))
                        {
                            ratingsOfPlants[plantName].Rating += plantRating;
                            ratingsOfPlants[plantName].CountOfRatings++;
                        }

                        break;
                    }
                case "Update":
                    {
                        int plantRating = int.Parse(plantInfo[1]);

                        if (PlantExists(ratingsOfPlants, plantName))
                        {
                            ratingsOfPlants[plantName].Rarity = plantRating;
                        }

                        break;
                    }                    
            }            
        }

        private static void ResetPlantInformation(Dictionary<string, PlantInformation> ratingsOfPlants, string plantName)
        {
            if (PlantExists(ratingsOfPlants, plantName))
            {
                ratingsOfPlants[plantName].Rating = 0;
                ratingsOfPlants[plantName].CountOfRatings = 0;
            }
        }

        static void Main()
        {
            int plantsCount = int.Parse(Console.ReadLine());
            Dictionary<string, PlantInformation> ratingsOfPlants = new Dictionary<string, PlantInformation>();

            for (int i = 0; i < plantsCount; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plantName = plantInfo[0];
                int plantRarity = int.Parse(plantInfo[1]);

                if (ratingsOfPlants.ContainsKey(plantName) == false)
                {
                    ratingsOfPlants.Add(plantName, new PlantInformation(0, 0.0, 0));
                }

                ratingsOfPlants[plantName].Rarity = plantRarity;
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Exhibition")
                {
                    Console.WriteLine("Plants for the exhibition:");

                    foreach (var ratingOfPlant in ratingsOfPlants)
                    {
                        ratingOfPlant.Value.Print(ratingOfPlant.Key);
                    }

                    break;
                }
                else
                {
                    switch (command[0])
                    {
                        case "Rate":
                        case "Update":
                            ModifyPlantInformation(ratingsOfPlants, command[0], command[1]);
                            break;
                        case "Reset":
                            ResetPlantInformation(ratingsOfPlants, command[1]);
                            break;
                    }
                }
            }
        }
    }
}
