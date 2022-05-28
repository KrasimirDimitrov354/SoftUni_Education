using System;

namespace FundamentalsExer9
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceLightsaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double expenses = 0.0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 6 == 0)
                {
                    expenses += priceLightsaber + priceRobe;
                }
                else
                {
                    expenses += priceLightsaber + priceRobe + priceBelt;
                }
            }

            expenses += priceLightsaber * (Math.Ceiling(students * 0.1));

            if (budget - expenses >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {expenses:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {Math.Abs(expenses - budget):f2}lv more.");
            }
        }
    }
}
