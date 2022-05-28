using System;

namespace CondStatAdvMore1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetMoney = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int groupSize = int.Parse(Console.ReadLine());

            double transportMoney = 0;
            double ticketMoney = 0;

            switch (category)
            {
                case "Normal":
                    ticketMoney = groupSize * 249.99;
                    break;
                case "VIP":
                    ticketMoney = groupSize * 499.99;
                    break;
            }

            if (groupSize <= 4)
            {
                transportMoney = budgetMoney - (budgetMoney * 0.25);
            }
            else if (groupSize > 4 & groupSize <= 9)
            {
                transportMoney = budgetMoney - (budgetMoney * 0.4);
            }
            else if (groupSize > 9 & groupSize <= 24)
            {
                transportMoney = budgetMoney - (budgetMoney * 0.5);
            }
            else if (groupSize > 24 & groupSize <= 49)
            {
                transportMoney = budgetMoney - (budgetMoney * 0.6);
            }
            else
            {
                transportMoney = budgetMoney - (budgetMoney * 0.75);
            }

            if (budgetMoney - transportMoney >= ticketMoney)
            {
                Console.WriteLine($"Yes! You have {((budgetMoney - transportMoney) - ticketMoney):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(ticketMoney - (budgetMoney - transportMoney)):f2} leva.");
            }
        }
    }
}
