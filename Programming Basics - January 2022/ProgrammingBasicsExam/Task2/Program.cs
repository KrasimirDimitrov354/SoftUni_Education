using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double dayMoney = double.Parse(Console.ReadLine());
            double dayProfit = double.Parse(Console.ReadLine());
            double totalExpense = double.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double totalMoney = 0;

            for (int i = 1; i <= 5; i++)
            {
                totalMoney += dayMoney + dayProfit;
            }

            totalMoney -= totalExpense;

            if (totalMoney >= giftPrice)
            {
                Console.WriteLine($"Profit: {totalMoney:f2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {(giftPrice - totalMoney):f2} BGN.");
            }
        }
    }
}
