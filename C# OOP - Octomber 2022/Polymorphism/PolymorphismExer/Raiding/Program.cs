using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    //Raiding
    //Your task is to create a class hierarchy like the one described below. The BaseHero class should be abstract.
    //  •	BaseHero – string Name, int Power, string CastAbility()
    //      	Druid – power = 80
    //      	Paladin – power = 100
    //      	Rogue – power = 80
    //      	Warrior – power = 100
    //
    //Each hero should override the CastAbility() method:
    //  Druid - "{Type} - {Name} healed for {Power}"
    //  Paladin - "{Type} - {Name} healed for {Power}"
    //  Rogue - "{Type} - {Name} hit for {Power} damage"
    //  Warrior - "{Type} - {Name} hit for {Power} damage"
    //
    //Use the created classes to form a raid group and defeat a boss.
    //You will receive an integer N from the console. On the next lines, you will receive {heroName} and {heroType} until you create N number of heroes.
    //If the hero type is invalid print: "Invalid hero!" and don’t add it to the raid group.
    //
    //After the raid group is formed, you will receive an integer from the console which will be the power of the boss.
    //Each of the heroes in the raid group must cast his ability once, and you must sum the power of all of the heroes.
    //If the total power is greater or equal to the boss’ power, you are victorious and you should print: "Victory!"
    //Else print: "Defeat..."
    //
    //Constraints
    //  You need to create heroes until you have N amount of valid heroes.
    //
    //Example
    //Input
    //  3
    //  Mike
    //  Paladin
    //  Josh
    //  Druid
    //  Scott
    //  Warrior
    //  250
    //Output
    //  Paladin - Mike healed for 100
    //  Druid - Josh healed for 80
    //  Warrior - Scott hit for 100 damage
    //  Victory!
    //
    //Input
    //  2
    //  Mike
    //  Warrior
    //  Tom
    //  Rogue
    //  200
    //Output
    //  Warrior - Mike hit for 100 damage
    //  Rogue - Tom hit for 80 damage
    //  Defeat...

    class Program
    {
        static void Main()
        {
            int heroesCount = int.Parse(Console.ReadLine());
            List<Hero> heroes = GetHeroes(heroesCount);

            int bossHealth = int.Parse(Console.ReadLine());
            StartBattle(heroes, bossHealth);
        }

        private static List<Hero> GetHeroes(int heroesCount)
        {
            List<Hero> heroes = new List<Hero>();
            string[] validHeroes = new string[] { "Druid", "Paladin", "Rogue", "Warrior" };

            while (heroes.Count < heroesCount)
            {
                string heroName = Console.ReadLine();
                string heroClass = Console.ReadLine();

                if (validHeroes.Contains(heroClass))
                {
                    heroes.Add(GetHero(heroName, heroClass));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            return heroes;
        }

        private static Hero GetHero(string heroName, string heroClass)
        {
            switch (heroClass)
            {
                case "Druid":
                    return new Druid(heroName);
                case "Paladin":
                    return new Paladin(heroName);
                case "Rogue":
                    return new Rogue(heroName);
                case "Warrior":
                    return new Warrior(heroName);
                default:
                    return null;
            }
        }

        private static void StartBattle(List<Hero> heroes, int bossHealth)
        {
            int totalPower = 0;

            foreach (var hero in heroes)
            {
                totalPower += hero.GetPower();
                Console.WriteLine(hero.CastAbility());
            }

            if (totalPower >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
