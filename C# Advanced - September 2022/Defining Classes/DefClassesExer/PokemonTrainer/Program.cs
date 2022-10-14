using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    //Pokemon Trainer
    //Define a class Trainer and a class Pokemon.
    //
    //Trainers have:
    //  •	Name;
    //  •	Number of badges;
    //  •	A collection of pokemon.
    //Pokemon have:
    //  •	Name;
    //  •	Element;
    //  •	Health.
    //All values are mandatory. Every Trainer starts with 0 badges.
    //
    //You will be receiving lines until you receive the command "Tournament". Each line will carry information about a pokemon and the trainer who caught it in the format:
    //  "{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
    //TrainerName is the name of the Trainer who caught the pokemon. Trainers’ names are unique.
    //
    //After receiving the command "Tournament", you will start receiving commands until the "End" command is received.
    //They can contain one of the following:
    //  •	"Fire"
    //  •	"Water"
    //  •	"Electricity"
    //
    //You must check if a trainer has at least one pokemon with the given element. If he does, he receives 1 badge. Otherwise, all of his pokemon lose 10 health.
    //If a pokemon falls to 0 or less health, he is defeated and must be removed from the trainer’s collection.
    //
    //In the end, you must print all of the trainers sorted in descending order by the number of badges they have.
    //If two trainers have the same amount of badges, they should be sorted by their order of appearance in the input.
    //The printing format is "{trainerName} {badges} {numberOfPokemon}".
    //
    //Examples
    //Input                             Output
    //Peter Charizard Fire 100          Peter 2 2
    //George Squirtle Water 38          George 0 1
    //Peter Pikachu Electricity 10
    //Tournament
    //Fire
    //Electricity
    //End
    //
    //Input                             Output
    //Sam Blastoise Water 18            Narry 1 1
    //Narry Pikachu Electricity 22      Sam 0 0
    //John Kadabra Psychic 90           John 0 1
    //Tournament
    //Fire
    //Electricity
    //Fire
    //End

    class Program
    {
        public static void Main()
        {
            List<Trainer> trainers = GottaCatchThemAll();

            string element = Console.ReadLine();

            while (element != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.HasPokemon(element))
                    {
                        trainer.Victory();
                    }
                    else
                    {
                        trainer.Defeat();
                    }
                }

                element = Console.ReadLine();
            }

            var sortedTrainers = trainers
                .OrderByDescending(t => t.Badges)
                .ToList();

            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }

        private static List<Trainer> GottaCatchThemAll()
        {
            List<Trainer> trainers = new List<Trainer>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Tournament")
            {
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                if (!trainers.Exists(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                trainers[trainers.FindIndex(t => t.Name == trainerName)]
                    .Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            return trainers;
        }
    }
}
