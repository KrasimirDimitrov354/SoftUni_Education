using System;
using System.Text.RegularExpressions;

namespace _02.Boss_Rush
{
    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            string pattern = @"^\|(?<name>[A-Z]{4,})\|:#(?<title>[a-zA-Z]+ [a-zA-Z]+)#$";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    Match boss = regex.Match(input);
                    string bossName = boss.Groups["name"].Value;
                    string bossTitle = boss.Groups["title"].Value;

                    Console.WriteLine($"{bossName}, The {bossTitle}");
                    Console.WriteLine($">> Strength: {bossName.Length}");
                    Console.WriteLine($">> Armor: {bossTitle.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
