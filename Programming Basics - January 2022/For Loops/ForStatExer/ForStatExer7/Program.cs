using System;

namespace ForStatExer7
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());

            int climbersTotal = 0;
            double climbersMusala = 0;
            double climbersMontBlanc = 0;
            double climbersKilimanjaro = 0;
            double climbersK2 = 0;
            double climbersEverest = 0;


            for (int i = 1; i <= groupsCount; i++)
            {
                int groupSize = int.Parse(Console.ReadLine());
                climbersTotal += groupSize;

                if (groupSize <= 5)
                {
                    climbersMusala += groupSize;
                }
                else if (groupSize > 5 & groupSize <= 12)
                {
                    climbersMontBlanc += groupSize;
                }
                else if (groupSize > 12 & groupSize <= 25)
                {
                    climbersKilimanjaro += groupSize;
                }
                else if (groupSize > 25 & groupSize <= 40)
                {
                    climbersK2 += groupSize;
                }
                else if (groupSize > 40)
                {
                    climbersEverest += groupSize;
                }
            }

            Console.WriteLine($"{((climbersMusala / climbersTotal) * 100):f2}%");
            Console.WriteLine($"{((climbersMontBlanc / climbersTotal) * 100):f2}%");
            Console.WriteLine($"{((climbersKilimanjaro / climbersTotal) * 100):f2}%");
            Console.WriteLine($"{((climbersK2 / climbersTotal) * 100):f2}%");
            Console.WriteLine($"{((climbersEverest / climbersTotal) * 100):f2}%");
        }
    }
}
