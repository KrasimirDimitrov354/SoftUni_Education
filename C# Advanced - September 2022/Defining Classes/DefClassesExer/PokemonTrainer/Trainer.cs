using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get { return name; } set { name = value; } }
        public int Badges { get { return badges; } set { badges = value; } }
        public List<Pokemon> Pokemons { get { return pokemons; } set { pokemons = value; } }

        public bool HasPokemon(string element)
        {
            if (pokemons.Exists(p => p.Element == element))
            {
                return true;
            }

            return false;
        }

        public void Victory()
        {
            Badges++;
        }

        public void Defeat()
        {
            foreach (Pokemon pokemon in pokemons)
            {
                pokemon.LoseHealth();
            }

            pokemons.RemoveAll(p => p.Health <= 0);
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
