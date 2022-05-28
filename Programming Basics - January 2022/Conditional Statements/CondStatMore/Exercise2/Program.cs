using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int vacationDays = int.Parse(Console.ReadLine());

            int catRest = 30000;
            int playWorkDay = 63;
            int playVacationDay = 127;

            int totalPlayTime = (vacationDays * playVacationDay) + ((365 - vacationDays) * playWorkDay);

            if (catRest >= totalPlayTime)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{(catRest - totalPlayTime) / 60} hours and {(catRest - totalPlayTime) % 60} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{(totalPlayTime - catRest) / 60} hours and {(totalPlayTime - catRest) % 60} minutes more for play");
            }
        }
    }
}
