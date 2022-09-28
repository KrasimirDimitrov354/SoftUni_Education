using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    //Cities by Continent and Country
    //Create a program that reads continents, countries and their cities, then puts them in a nested dictionary and prints them.
    //
    //Examples
    //Input                     Output
    //9                         Europe:
    //Europe Bulgaria Sofia       Bulgaria -> Sofia, Plovdiv
    //Asia China Beijing          Poland -> Warsaw, Poznan
    //Asia Japan Tokyo            Germany -> Berlin
    //Europe Poland Warsaw      Asia:
    //Europe Germany Berlin       China -> Beijing, Shanghai
    //Europe Poland Poznan        Japan -> Tokyo
    //Europe Bulgaria Plovdiv   Africa:
    //Africa Nigeria Abuja        Nigeria -> Abuja
    //Asia China Shanghai
    //
    //Input                     Output
    //3                         Europe:
    //Europe Germany Berlin       Germany -> Berlin
    //Europe Bulgaria Varna       Bulgaria -> Varna
    //Africa Egypt Cairo        Africa:
    //                            Egypt -> Cairo
    //
    //Input                     Output
    //8                         Africa:
    //Africa Somalia Mogadishu    Somalia -> Mogadishu
    //Asia India Mumbai         Asia:
    //Asia India Delhi            India -> Mumbai, Delhi, Nagpur
    //Europe France Paris       Europe:
    //Asia India Nagpur           France -> Paris
    //Europe Germany Hamburg      Germany -> Hamburg, Danzig
    //Europe Poland Gdansk        Poland -> Gdansk
    //Europe Germany Danzig

    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> countriesInContinents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!countriesInContinents.ContainsKey(continent))
                {
                    countriesInContinents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!countriesInContinents[continent].ContainsKey(country))
                {
                    countriesInContinents[continent].Add(country, new List<string>());
                }

                countriesInContinents[continent][country].Add(city);

            }

            foreach (var continent in countriesInContinents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {String.Join(", ", country.Value)}");
                }
            }
        }
    }
}
