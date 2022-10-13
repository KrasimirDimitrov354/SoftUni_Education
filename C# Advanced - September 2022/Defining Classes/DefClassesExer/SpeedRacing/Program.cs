using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    //Speed Racing
    //Create a program that keeps track of cars and their fuel, and supports methods for moving the cars.
    //
    //Define a class Car. Each Car has the following properties:
    //  •	string Model
    //  •	double FuelAmount
    //  •	double FuelConsumptionPerKilometer
    //  •	double Travelled distance
    //
    //A car's model is unique - there will never be 2 cars with the same model.
    //
    //On the first line of the input you will receive a number N – the number of cars you need to track.
    //On each of the next N lines, you will receive information about a car in the following format: 
    //  "{model} {fuelAmount} {fuelConsumptionFor1km}"
    //
    //All cars start at 0 kilometers traveled. After the N lines, until the command "End" is received, you will receive commands in the following format: 
    //  "Drive {carModel} {amountOfKm}"
    //Implement a method in the Car class to calculate whether or not a car can move that distance.
    //If it can, the car’s fuel amount should be reduced by the amount of used fuel and its traveled distance should be increased by the number of the traveled kilometers.
    //Otherwise, the car should not move (its fuel amount and the traveled distance should stay the same) and you should print on the console:
    //  "Insufficient fuel for the drive"
    //
    //After the "End" command is received, print each car, its current fuel amount and the traveled distance in the format:
    //  "{model} {fuelAmount} {distanceTraveled}"
    //Print the fuel amount formatted two digits after the decimal separator.
    //
    //Examples
    //Input                         Output
    //2                             AudiA4 17.60 18
    //AudiA4 23 0.3                 BMW-M2 21.48 56
    //BMW-M2 45 0.42
    //Drive BMW-M2 56
    //Drive AudiA4 5
    //Drive AudiA4 13
    //End
    //
    //Input                         Output
    //3                             Insufficient fuel for the drive
    //AudiA4 18 0.34                Insufficient fuel for the drive
    //BMW-M2 33 0.41                AudiA4 1.00 50
    //Ferrari-488Spider 50 0.47     BMW-M2 33.00 0
    //Drive Ferrari-488Spider 97    Ferrari-488Spider 4.41 97
    //Drive Ferrari-488Spider 35
    //Drive AudiA4 85
    //Drive AudiA4 50
    //End

    public class Program
    {
        static void Main()
        {
            List<Car> cars = GetCars();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                string modelToModify = command[1];
                double amountOfKm = double.Parse(command[2]);

                Car carToModify = cars
                    .Where(c => c.Model == modelToModify)
                    .FirstOrDefault();

                carToModify.Drive(amountOfKm);

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (Car car in cars)
            {
                car.Print();
            }
        }

        private static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKm = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);
            }

            return cars;
        }
    }
}
