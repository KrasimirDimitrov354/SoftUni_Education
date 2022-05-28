using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projectNumber = int.Parse(Console.ReadLine());

            int hoursNeeded = projectNumber * 3;

            Console.WriteLine($"The architect {name} will need {hoursNeeded} " +
                $"hours to complete {projectNumber} project/s.");
        }
    }
}
