using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursNeeded = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int employees = int.Parse(Console.ReadLine());

            double regularHours = (days - (days * 0.1)) * 8;
            double afterHours = (2 * days) * employees;
            double totalHours = Math.Floor(regularHours + afterHours);

            if (totalHours >= hoursNeeded)
            {
                Console.WriteLine($"Yes!{totalHours - hoursNeeded} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursNeeded - totalHours} hours needed.");
            }
        }
    }
}
