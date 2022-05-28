using System;

namespace ForStatExer5
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabsCount = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int fine = 0;

            for (int i = 1; i <= tabsCount; i++)
            {
                string website = Console.ReadLine();

                switch (website)
                {
                    case "Facebook":
                        fine += 150;
                        break;
                    case "Instagram":
                        fine += 100;
                        break;
                    case "Reddit":
                        fine += 50;
                        break;
                }

                if (salary - fine <= 0)
                {
                    Console.WriteLine($"You have lost your salary.");
                    break;
                }
            }

            if (salary - fine > 0)
            {
                Console.WriteLine(salary - fine);
            }
            
        }
    }
}
