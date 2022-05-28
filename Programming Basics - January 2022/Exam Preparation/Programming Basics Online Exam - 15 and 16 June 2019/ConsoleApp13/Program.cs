using System;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeAvailable = double.Parse(Console.ReadLine());
            int sceneCount = int.Parse(Console.ReadLine());
            int sceneDuration = int.Parse(Console.ReadLine());

            timeAvailable -= timeAvailable * 0.15;

            if (timeAvailable >= (sceneCount * sceneDuration))
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeAvailable - (sceneCount * sceneDuration))} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round((sceneCount * sceneDuration) - timeAvailable)} minutes.");
            }
        }
    }
}
