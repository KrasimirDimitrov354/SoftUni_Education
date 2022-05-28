using System;

namespace CondStatAdvExer9
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysStay = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string score = Console.ReadLine();

            int nightsStay = daysStay - 1;
            double roomPrice = 0; 

            switch (room)
            {
                case "room for one person":
                    roomPrice = nightsStay * 18;
                    break;
                case "apartment":
                    roomPrice = nightsStay * 25;

                    if (nightsStay < 10)
                    {
                        roomPrice = roomPrice - (roomPrice * 0.3);
                    }
                    else if (nightsStay >= 10 && nightsStay <= 15)
                    {
                        roomPrice = roomPrice - (roomPrice * 0.35);
                    }
                    else
                    {
                        roomPrice = roomPrice - (roomPrice * 0.5);
                    }
                    break;
                case "president apartment":
                    roomPrice = nightsStay * 35;

                    if (nightsStay < 10)
                    {
                        roomPrice = roomPrice - (roomPrice * 0.1);
                    }
                    else if (nightsStay >= 10 && nightsStay <= 15)
                    {
                        roomPrice = roomPrice - (roomPrice * 0.15);
                    }
                    else
                    {
                        roomPrice = roomPrice - (roomPrice * 0.2);
                    }
                    break;
            }

            if (score == "positive")
            {
                roomPrice = roomPrice + (roomPrice * 0.25);
            }
            else
            {
                roomPrice = roomPrice - (roomPrice * 0.1);
            }

            Console.WriteLine($"{roomPrice:f2}");
        }
    }
}
