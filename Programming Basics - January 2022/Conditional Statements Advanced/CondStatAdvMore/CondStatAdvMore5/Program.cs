using System;

namespace CondStatAdvMore5
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string holidayLocation = "default";
            string holidayEstablishment = "default";
            double holidayPrice = 0;

            if (budget <= 1000)
            {
                holidayEstablishment = "Camp";

                switch (season)
                {
                    case "Summer":
                        holidayLocation = "Alaska";
                        holidayPrice = budget - (budget * 0.35);
                        break;
                    case "Winter":
                        holidayLocation = "Morocco";
                        holidayPrice = budget - (budget * 0.55);
                        break;
                }
            }
            else if (budget > 1000 & budget <= 3000)
            {
                holidayEstablishment = "Hut";

                switch (season)
                {
                    case "Summer":
                        holidayLocation = "Alaska";
                        holidayPrice = budget - (budget * 0.2);
                        break;
                    case "Winter":
                        holidayLocation = "Morocco";
                        holidayPrice = budget - (budget * 0.4);
                        break;
                }
            }
            else
            {
                holidayEstablishment = "Hotel";
                holidayPrice = budget - (budget * 0.1);

                switch (season)
                {
                    case "Summer":
                        holidayLocation = "Alaska";
                        break;
                    case "Winter":
                        holidayLocation = "Morocco";
                        break;
                }
            }

            Console.WriteLine($"{holidayLocation} - {holidayEstablishment} - {holidayPrice:f2}");
        }
    }
}
