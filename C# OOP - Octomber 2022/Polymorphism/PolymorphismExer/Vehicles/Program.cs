using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    //Vehicles
    //Create a program that models 2 vehicles (a Car and a Truck) and simulates driving and refueling them.
    //
    //Both vehicles have fuel quantity, fuel consumption in liters per km, can be driven a given distance and can be refueled with a given amount of fuel.
    //The vehicles' fuel consumption per km is increased by 0.9 liters for the car and by 1.6 liters for the truck.
    //Also, the truck has a tiny hole in its tank and when it’s refueled it keeps only 95% of the given fuel.
    //
    //If a vehicle cannot travel the given distance, its fuel does not change.
    //
    //Input
    //  •	On the first line – information about the car in the format: "Car {fuel quantity} {liters per km}"
    //  •	On the second line – info about the truck in the format: "Truck {fuel quantity} {liters per km}"
    //  •	On the third line – the number of commands N that will be given on the next N lines
    //  •	On the next N lines – commands in the format:
    //      	"Drive Car {distance}"
    //      	"Drive Truck {distance}"
    //      	"Refuel Car {liters}"
    //      	"Refuel Truck {liters}"
    //Output
    //  •	After each Drive command:
    //      - If there was enough fuel, print "Car/Truck travelled {distance} km"
    //      - If there was not enough fuel, print: "Car/Truck needs refueling"
    //  •	After the End command, print the remaining fuel for both vehicles, rounded to 2 digits after the floating point in the format:
    //      	"Car: {liters}"
    //      	"Truck: {liters}"
    //
    //Examples
    //Input                     Output
    //Car 15 0.3                Car travelled 9 km
    //Truck 100 0.9             Car needs refueling
    //4                         Truck travelled 10 km
    //Drive Car 9               Car: 54.20
    //Drive Car 30              Truck: 75.00
    //Refuel Car 50
    //Drive Truck 10
    //
    //Input                     Output
    //Car 30.4 0.4              Car needs refueling
    //Truck 99.34 0.9           Car travelled 13.5 km
    //5                         Truck needs refueling
    //Drive Car 500             Car: 113.05
    //Drive Car 13.5            Truck: 109.12
    //Refuel Truck 10.300
    //Drive Truck 56.2
    //Refuel Car 100.2
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Vehicles Extension
    //Add a new vehicle – Bus. Add to every vehicle a new property – tank capacity.
    //You can drive the bus with or without people. With people, its fuel consumption must be set to 1.4 liters. With no people on the bus, the fuel consumption is 0.
    //
    //A vehicle cannot start with or refuel above its tank capacity.
    //If there is an attempt to:
    //  •	put more fuel in the tank than the available space, print "Cannot fit {fuel amount} fuel in the tank". Do not add any fuel in the vehicle’s tank.
    //  •	create a vehicle with more fuel than its tank capacity, it must be created with an empty tank.
    //Add validation for the amount of fuel given to the Refuel command – if it is 0 or negative, print "Fuel must be a positive number".
    //
    //Example
    //Input
    //  Car 30 0.04 70
    //  Truck 100 0.5 300
    //  Bus 40 0.3 150
    //  8
    //  Refuel Car -10
    //  Refuel Truck 0
    //  Refuel Car 10
    //  Refuel Car 300
    //  Drive Bus 10
    //  Refuel Bus 1000
    //  DriveEmpty Bus 100
    //  Refuel Truck 1000
    //Output
    //  Fuel must be a positive number
    //  Fuel must be a positive number
    //  Cannot fit 300 fuel in the tank
    //  Bus travelled 10 km
    //  Cannot fit 1000 fuel in the tank
    //  Bus needs refueling
    //  Cannot fit 1000 fuel in the tank
    //  Car: 40.00
    //  Truck: 100.00
    //  Bus: 23.00

    class Program
    {
        static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.Add(GetVehicle());
            vehicles.Add(GetVehicle());
            vehicles.Add(GetVehicle());

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Drive":
                        vehicles
                            .FirstOrDefault(v => v.GetType().Name == command[1])
                            .Drive(double.Parse(command[2]));
                        break;
                    case "DriveEmpty":
                        ((Bus)vehicles
                            .FirstOrDefault(v => v.GetType().Name == command[1]))
                            .DriveEmpty(double.Parse(command[2]));
                        break;
                    case "Refuel":
                        vehicles
                            .FirstOrDefault(v => v.GetType().Name == command[1])
                            .Refuel(double.Parse(command[2]));
                        break;
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        private static Vehicle GetVehicle()
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (input[0])
            {
                case "Car":
                    return new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
                case "Truck":
                    return new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
                case "Bus":
                    return new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
                default:
                    return null;
            }
        }
    }
}
