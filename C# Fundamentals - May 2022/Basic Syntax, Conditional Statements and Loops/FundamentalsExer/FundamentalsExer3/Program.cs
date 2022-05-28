using System;

namespace FundamentalsExer3
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double total = 0.0;

            if (groupCount >= 100)
            {
                groupCount -= 10;
            }

            switch (groupType)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            total = groupCount * 8.45;
                            break;
                        case "Saturday":
                            total = groupCount * 9.8;
                            break;
                        case "Sunday":
                            total = groupCount * 10.46;
                            break;
                    }

                    if (groupCount >= 30)
                    {
                        total -= total * 0.15;
                    }
                    break;

                case "Business":
                    if (groupCount >= 100)
                    {
                        groupCount -= 10;
                    }

                    switch (day)
                    {
                        case "Friday":
                            total = groupCount * 10.9;
                            break;
                        case "Saturday":
                            total = groupCount * 15.6;
                            break;
                        case "Sunday":
                            total = groupCount * 16;
                            break;
                    }
                    break;

                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            total = groupCount * 15;
                            break;
                        case "Saturday":
                            total = groupCount * 20;
                            break;
                        case "Sunday":
                            total = groupCount * 22.5;
                            break;
                    }

                    if (groupCount >= 10 && groupCount <= 20)
                    {
                        total -= total * 0.05;
                    }
                    break;
            }

            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}