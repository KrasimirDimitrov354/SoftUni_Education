using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
    //Input
    //  •	The possible commands are:
    //      o	"vehicle1>>vehicle2>>vehicle3…"
    //      o	"family"
    //      o	"heavyDuty"
    //      o	"sports"
    //Output
    //  •	The possible outputs are:
    //      o	"Invalid car type."
    //      o	"A {car type} car will pay {total tax to pay} euros in taxes."
    //      o	"The National Revenue Agency will collect {total tax collected} euros in taxes."
    //Examples
    //Input                                                         
    //  family 3 7210>>van 4 2345>>heavyDuty 9 31000>>sports 4 7410	
    //Output
    //  A family car will pay 59.00 euros in taxes.
    //  Invalid car type.
    //  A heavyDuty car will pay 50.00 euros in taxes.
    //  A sports car will pay 118.00 euros in taxes.
    //  The National Revenue Agency will collect 227.00 euros in taxes.
    //Comment
    //  We start looping through the array, the first car is a family car, which should pay taxes for 3 years in use and has traveled 7210 km.
    //  The taxes are calculate as follows: 7210 / 3000 * 12 + (50 - 3 * 5) = 59.00 euros
    //  The family car must pay 59.00 euros in taxes.
    //  The next car is a van, which is an invalid car type.
    //  Next, we have heavyDuty car, with 9 years in use, and has traveled 31000 km.The tax which heavyDuty car should pay is 50.00 euros.
    //  On the last iteration, we have a sports car that is 4 years in use and has traveled 7410 km.The tax which the sports car should pay is 118.00 euros.
    //  At the end the National Revenue Agency collected 59.00 + 50.00 + 118.00 = 227.00 euros in taxes.

    //Input
    //  family 5 3210>>pickUp 1 1345>>heavyDuty 7 21000>>sports 5 9410>>family 3 9012	A family car will pay 37.00 euros in taxes.
    //Output
    //  Invalid car type.
    //  A heavyDuty car will pay 52.00 euros in taxes.
    //  A sports car will pay 127.00 euros in taxes.
    //  A family car will pay 71.00 euros in taxes.
    //  The National Revenue Agency will collect 287.00 euros in taxes.

    class Program
    {
        private static bool VehicleIsValid(string vehicleType)
        {
            if (vehicleType == "family" || vehicleType == "heavyDuty" || vehicleType == "sports")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid car type.");
                return false;
            }
        }

        private static decimal SetTypeTax(string vehicleType)
        {
            switch (vehicleType)
            {
                case "family":
                    return 50.0m;
                case "heavyDuty":
                    return 80.0m;
                case "sports":
                    return 100.0m;
            }

            return 0.0m;
        }

        private static decimal SetKilometersTax(string vehicleType, int kilometers)
        {
            bool kilometresLeft = true;
            decimal kilometersTax = 0.0m;

            while (kilometresLeft)
            {
                switch (vehicleType)
                {
                    case "family":
                        {
                            kilometers -= 3000;

                            if (kilometers >= 0)
                            {
                                kilometersTax += 12.0m;
                            }
                            else
                            {
                                kilometresLeft = false;
                            }
                            break;
                        }
                    case "heavyDuty":
                        {
                            kilometers -= 9000;

                            if (kilometers >= 0)
                            {
                                kilometersTax += 14.0m;
                            }
                            else
                            {
                                kilometresLeft = false;
                            }
                            break;
                        }
                    case "sports":
                        {
                            kilometers -= 2000;

                            if (kilometers >= 0)
                            {
                                kilometersTax += 18.0m;
                            }
                            else
                            {
                                kilometresLeft = false;
                            }
                            break;
                        }
                }
            }

            return kilometersTax;
        }

        private static decimal SetYearlyDecline(string vehicleType, int years)
        {
            decimal decline = 0.0m;

            switch (vehicleType)
            {
                case "family":
                    decline = years * 5;
                    break;
                case "heavyDuty":
                    decline = years * 8;
                    break;
                case "sports":
                    decline = years * 9;
                    break;
            }

            return decline;
        }

        static void Main()
        {
            List<string> vehicles = Console.ReadLine()
                .Split(">>")
                .ToList();

            decimal totalTax = 0.0m;

            for (int i = 0; i < vehicles.Count; i++)
            {
                List<string> currentVehicle = new List<string>(vehicles[i].Split(' ').ToList());
                string vehicleType = currentVehicle[0];

                if (VehicleIsValid(vehicleType))
                {
                    int years = int.Parse(currentVehicle[1]);
                    int kilometers = int.Parse(currentVehicle[2]);

                    decimal typeTax = SetTypeTax(vehicleType);
                    decimal kilometersTax = SetKilometersTax(vehicleType, kilometers);
                    decimal yearlyDecline = SetYearlyDecline(vehicleType, years);

                    decimal currentTax = kilometersTax + (typeTax - yearlyDecline);
                    Console.WriteLine($"A {vehicleType} car will pay {currentTax:f2} euros in taxes.");
                    totalTax += currentTax;
                }
            }

            Console.WriteLine($"The National Revenue Agency will collect {totalTax:f2} euros in taxes.");
        }
    }
}
