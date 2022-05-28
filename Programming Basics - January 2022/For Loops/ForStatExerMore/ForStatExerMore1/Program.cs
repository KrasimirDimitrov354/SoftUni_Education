using System;

namespace ForStatExerMore1
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyInheritance = double.Parse(Console.ReadLine());
            int yearsToReach = int.Parse(Console.ReadLine());

            int yearsOld = 18;
            int moneySpent = 0;

            for (int i = 1800; i <= yearsToReach; i++)
            {
                double yearsCurrent = i;

                if (yearsCurrent % 2 == 0)
                {
                    moneySpent += 12000;
                }
                else
                {
                    moneySpent += 12000 + (50 * yearsOld);
                }

                yearsOld++;
            }

            if (moneyInheritance >= moneySpent)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {(moneyInheritance - moneySpent):f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {(moneySpent - moneyInheritance):f2} dollars to survive.");
            }
        }
    }
}
