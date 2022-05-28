using System;

namespace CondStatAdvMore2
{
    class Program
    {
        static void Main(string[] args)
        {
            int countJuniors = int.Parse(Console.ReadLine());
            int countSeniors = int.Parse(Console.ReadLine());
            string track = Console.ReadLine();

            double income = 0;

            switch (track)
            {
                case "trail":
                    income = (countJuniors * 5.5) + (countSeniors * 7);
                    break;
                case "cross-country":
                    income = (countJuniors * 8) + (countSeniors * 9.5);

                    if (countJuniors + countSeniors >= 50)
                    {
                        income = income - (income * 0.25);
                    }
                    break;
                case "downhill":
                    income = (countJuniors * 12.25) + (countSeniors * 13.75);
                    break;
                case "road":
                    income = (countJuniors * 20) + (countSeniors * 21.5);
                    break;
            }

            income = income - (income * 0.05);

            Console.WriteLine($"{income:f2}");
        }
    }
}
