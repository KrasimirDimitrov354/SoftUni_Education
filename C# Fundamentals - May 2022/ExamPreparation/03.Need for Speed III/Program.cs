using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Need_for_Speed_III
{
    //Need for Speed III
    //Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
    //Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2307#2.
    //
    //You have just bought the latest and greatest computer game – Need for Speed III. Pick your favorite cars and drive them all you want! We know that you can't wait to start playing.
    //
    //On the first line of the standard input you will receive an integer n – the number of cars that you can obtain.
    //On the next n lines you will receive the cars with their mileage and fuel available, separated by "|" in the format:
    //  "{car}|{mileage}|{fuel}"
    //
    //Then, until the "Stop" command is given, you will be receiving the following commands, each on a new line and separated by " : ".
    //  •	"Drive : {car} : {distance} : {fuel}":
    //      o You need to drive the given distance, and you will need the given fuel to do that.
    //      If the car doesn't have enough fuel, print: "Not enough fuel to make that ride".
    //      o If the car has the required fuel available in the tank, increase its mileage with the given distance.
    //      Then, decrease its fuel with the given fuel, and print: "{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.".
    //      o You like driving new cars only, so if a car's mileage reaches 100 000 km, remove it from the collection(s) and print: "Time to sell the {car}!".
    //  •	"Refuel : {car} : {fuel}":
    //      o Refill the tank of your car.
    //      o Each tank can hold a maximum of 75 liters of fuel, so if the given amount of fuel is more than you can fit in the tank, take only what is required to fill it up.
    //      o Print a message in the following format: "{car} refueled with {fuel} liters".
    //  •	"Revert : {car} : {kilometers}":
    //      o Decrease the mileage of the given car with the given kilometers and print the kilometers you have decreased it with in the following format:
    //      "{car} mileage decreased by {amount reverted} kilometers"
    //      o If the mileage becomes less than 10 000 km after it is decreased, just set it to 10 000 km and DO NOT print anything.
    //
    //Upon receiving the "Stop" command, you need to print all cars in your possession in the following format:
    //  "{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt."
    //
    //Input / Constraints
    //  •	The mileage and fuel of the cars will be valid 32-bit integers, and will never be negative.
    //  •	The fuel and distance amounts in the commands will never be negative.
    //  •	The car names in the commands will always be valid cars in your possession.
    //Output
    //  •	All the output messages with the appropriate formats are described in the problem description.
    //Examples
    //Input                                     Output
    //3                                         Audi A6 driven for 543 kilometers. 47 liters of fuel consumed.
    //Audi A6|38000|62                          Mercedes CLS driven for 94 kilometers. 11 liters of fuel consumed.
    //Mercedes CLS|11000|35                     Not enough fuel to make that ride
    //Volkswagen Passat CC|45678|5              Audi A6 refueled with 50 liters
    //Drive : Audi A6 : 543 : 47                Mercedes CLS mileage decreased by 500 kilometers
    //Drive : Mercedes CLS : 94 : 11            Audi A6 -> Mileage: 10000 kms, Fuel in the tank: 65 lt.
    //Drive : Volkswagen Passat CC : 69 : 8     Mercedes CLS -> Mileage: 10594 kms, Fuel in the tank: 24 lt.
    //Refuel : Audi A6 : 50                     Volkswagen Passat CC -> Mileage: 45678 kms, Fuel in the tank: 5 lt.
    //Revert : Mercedes CLS : 500
    //Revert : Audi A6 : 30000
    //Stop
    //
    //Comments
    //"Drive : Volkswagen Passat CC : 69 : 8" - The program calculates that there is not enough fuel. We print the appropriate message.
    //"Revert : Audi A6 : 30000" - we set its mileage to 10000 km since 38543 - 30000 = 8543, which is less than 10000 kms.
    //
    //Input                                     Output
    //4                                         Not enough fuel to make that ride
    //Lamborghini Veneno|11111|74               Aston Martin Valkryie driven for 99 kilometers. 23 liters of fuel consumed.
    //Bugatti Veyron|12345|67                   Aston Martin Valkryie driven for 2 kilometers. 1 liters of fuel consumed.
    //Koenigsegg CCXR|67890|12                  Time to sell the Aston Martin Valkryie!
    //Aston Martin Valkryie|99900|50            Lamborghini Veneno refueled with 1 liters
    //Drive : Koenigsegg CCXR : 382 : 82        Bugatti Veyron mileage decreased by 2000 kilometers
    //Drive : Aston Martin Valkryie : 99 : 23   Lamborghini Veneno -> Mileage: 11111 kms, Fuel in the tank: 75 lt.
    //Drive : Aston Martin Valkryie : 2 : 1     Bugatti Veyron -> Mileage: 10345 kms, Fuel in the tank: 67 lt.
    //Refuel : Lamborghini Veneno : 40          Koenigsegg CCXR -> Mileage: 67890 kms, Fuel in the tank: 12 lt.
    //Revert : Bugatti Veyron : 2000
    //Stop

    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"{this.Name} -> Mileage: {this.Mileage} kms, Fuel in the tank: {this.Fuel} lt.");
        }

        public void Drive(int distance, int fuel)
        {
            if (this.Fuel < fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
            else
            {
                this.Mileage += distance;
                this.Fuel -= fuel;
                Console.WriteLine($"{this.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            }
        }

        public void Refuel(int fuel)
        {
            int initialFuel = this.Fuel;

            if (this.Fuel + fuel > 75)
            {
                this.Fuel = 75;
            }
            else
            {
                this.Fuel += fuel;
            }

            Console.WriteLine($"{this.Name} refueled with {this.Fuel - initialFuel} liters");
        }

        public void Revert(int kilometers)
        {
            if (this.Mileage - kilometers < 10000)
            {
                this.Mileage = 10000;
            }
            else
            {
                this.Mileage -= kilometers;
                Console.WriteLine($"{this.Name} mileage decreased by {kilometers} kilometers");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = new Car(carInfo[0], int.Parse(carInfo[1]), int.Parse(carInfo[2]));
                cars.Add(car);
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Stop")
                {
                    foreach (Car car in cars)
                    {
                        car.PrintInfo();
                    }
                    break;
                }
                else
                {
                    int indexOfCar = cars.FindIndex(c => c.Name == command[1]);

                    switch (command[0])
                    {
                        case "Drive":
                            {
                                int distance = int.Parse(command[2]);
                                int fuel = int.Parse(command[3]);

                                cars[indexOfCar].Drive(distance, fuel);

                                if (cars[indexOfCar].Mileage >= 100000)
                                {
                                    Console.WriteLine($"Time to sell the {cars[indexOfCar].Name}!");
                                    cars.RemoveAt(indexOfCar);
                                }

                                break;
                            }
                        case "Refuel":
                            {
                                int fuel = int.Parse(command[2]);
                                cars[indexOfCar].Refuel(fuel);
                                break;
                            }
                        case "Revert":
                            {
                                int kilometers = int.Parse(command[2]);
                                cars[indexOfCar].Revert(kilometers);
                                break;
                            }
                    }
                }
            }
        }
    }
}
