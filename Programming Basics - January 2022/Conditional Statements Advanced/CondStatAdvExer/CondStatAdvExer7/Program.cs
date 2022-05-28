using System;

namespace CondStatAdvExer7
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int stay = int.Parse(Console.ReadLine());

            double apartmentRent = 0;
            double studioRent = 0;

            switch (month)
            {
                case "May":
                case "October":
                    apartmentRent = stay * 65;
                    studioRent = stay * 50;

                    if (stay > 7 && stay <= 14)
                    {
                        studioRent = studioRent - (studioRent * 0.05);
                    }
                    else if (stay > 14)
                    {
                        studioRent = studioRent - (studioRent * 0.3);
                    }
                    break;

                case "June":
                case "September":
                    apartmentRent = stay * 68.7;
                    studioRent = stay * 75.2;

                    if (stay > 14)
                    {
                        studioRent = studioRent - (studioRent * 0.2);
                    }
                    break;

                case "July":
                case "August":
                    apartmentRent = stay * 77;
                    studioRent = stay * 76;
                    break;
            }

            if (stay > 14)
            {
                apartmentRent = apartmentRent - (apartmentRent * 0.1);
            }

            Console.WriteLine($"Apartment: {apartmentRent:f2} lv.");
            Console.WriteLine($"Studio: {studioRent:f2} lv.");
        }
    }
}
