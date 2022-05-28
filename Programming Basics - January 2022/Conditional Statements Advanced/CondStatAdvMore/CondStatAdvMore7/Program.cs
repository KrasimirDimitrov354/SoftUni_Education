using System;

namespace CondStatAdvMore7
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string classComposition = Console.ReadLine();
            int classCount = int.Parse(Console.ReadLine());
            int vacationDays = int.Parse(Console.ReadLine());

            double vacationPrice = 0;
            string vacationSport = "default";

            switch (season)
            {
                case "Winter":
                    switch (classComposition)
                    {
                        case "boys":
                            vacationPrice = classCount * (vacationDays * 9.6);
                            vacationSport = "Judo";
                            break;
                        case "girls":
                            vacationPrice = classCount * (vacationDays * 9.6);
                            vacationSport = "Gymnastics";
                            break;
                        case "mixed":
                            vacationPrice = classCount * (vacationDays * 10);
                            vacationSport = "Ski";
                            break;
                    }
                    break;
                case "Spring":
                    switch (classComposition)
                    {
                        case "boys":
                            vacationPrice = classCount * (vacationDays * 7.2);
                            vacationSport = "Tennis";
                            break;
                        case "girls":
                            vacationPrice = classCount * (vacationDays * 7.2);
                            vacationSport = "Athletics";
                            break;
                        case "mixed":
                            vacationPrice = classCount * (vacationDays * 9.5);
                            vacationSport = "Cycling";
                            break;
                    }
                    break;
                case "Summer":
                    switch (classComposition)
                    {
                        case "boys":
                            vacationPrice = classCount * (vacationDays * 15);
                            vacationSport = "Football";
                            break;
                        case "girls":
                            vacationPrice = classCount * (vacationDays * 15);
                            vacationSport = "Volleyball";
                            break;
                        case "mixed":
                            vacationPrice = classCount * (vacationDays * 20);
                            vacationSport = "Swimming";
                            break;
                    }
                    break;
            }

            if (classCount >= 50)
            {
                vacationPrice = vacationPrice - (vacationPrice * 0.5);
            }
            else if (classCount >= 20 & classCount < 50)
            {
                vacationPrice = vacationPrice - (vacationPrice * 0.15);
            }
            else if (classCount >= 10 & classCount < 20)
            {
                vacationPrice = vacationPrice - (vacationPrice * 0.05);
            }

            Console.WriteLine($"{vacationSport} {vacationPrice:f2} lv.");
        }
    }
}
