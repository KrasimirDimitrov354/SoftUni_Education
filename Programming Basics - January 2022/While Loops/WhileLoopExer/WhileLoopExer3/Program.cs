using System;

namespace WhileLoopExer3
{
    class Program
    {
        static void Main(string[] args)
        {
            double targetMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int daysCounter = 0;
            int spendCounter = 0;

            while (true)
            {
                string action = Console.ReadLine();
                double dailyMoney = double.Parse(Console.ReadLine());

                daysCounter++;

                if (action == "spend")
                {
                    spendCounter++;
                    availableMoney -= dailyMoney;

                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }

                    if (spendCounter == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(daysCounter);
                        break;
                    }
                }
                else
                {
                    spendCounter = 0;
                    availableMoney += dailyMoney;

                    if (availableMoney >= targetMoney)
                    {
                        Console.WriteLine($"You saved the money for {daysCounter} days.");
                        break;
                    }
                }
            }
        }
    }
}
