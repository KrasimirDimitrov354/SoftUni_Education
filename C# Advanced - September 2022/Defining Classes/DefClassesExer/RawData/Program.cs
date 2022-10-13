using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    //Raw Data
    //Create a program that tracks cars and their cargo.
    //
    //Start by defining a class Car that holds information about:
    //  •	Model: a string property;
    //  •	Engine: a class with two properties – speed and power;
    //  •	Cargo: a class with two properties – type and weight;
    //  •	Tires: a collection of exactly 4 tires. Each tire should have two properties: age and pressure.
    //
    //Create a constructor that receives all of the information about the Car, then creates and initializes the model and its inner components (engine, cargo, and tires).
    //
    //Input
    //On the first line of input you will receive a number N representing the number of cars you have.
    //
    //On the next N lines you will receive information about each car in the format:
    //  "{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {t3Pressure} {t3Age} {t4Pressure} {t4Age}"
    //  •	The speed, power, weight and tire age inputs are integers.
    //  •	The tire pressure input is a floating point number.
    //Then you will receive a single line with the sought cargo type - either "fragile" or "flammable".
    //
    //Output
    //If the command is:
    //  •	"fragile" - print all cars whose cargo is "fragile" and have a pressure of a single tire < 1.
    //  •	"flammable" - print all cars whose cargo is "flammable" and have engine power > 250.
    //The cars should be printed in order of appearing in the input.
    //
    //Examples
    //Input
    //  2
    //  ChevroletAstro 200 180 1000 fragile 1.3 1 1.5 2 1.4 2 1.7 4
    //  Citroen2CV 190 165 1200 fragile 0.9 3 0.85 2 0.95 2 1.1 1
    //  fragile
    //Output
    //  Citroen2CV
    //Input
    //  4
    //  ChevroletExpress 215 255 1200 flammable 2.5 1 2.4 2 2.7 1 2.8 1
    //  ChevroletAstro 210 230 1000 flammable 2 1 1.9 2 1.7 3 2.1 1
    //  DaciaDokker 230 275 1400 flammable 2.2 1 2.3 1 2.4 1 2 1
    //  Citroen2CV 190 165 1200 fragile 0.8 3 0.85 2 0.7 5 0.95 2
    //  flammable
    //Output
    //  ChevroletExpress
    //  DaciaDokker

    public class Program
    {
        static void Main()
        {
            List<Car> vehicles = GetVehicles();

            string soughtCargoType = Console.ReadLine();
            List<Car> sortedVehicles = FindVehicles(soughtCargoType, vehicles);

            foreach (Car vehicle in sortedVehicles)
            {
                Console.WriteLine(vehicle.Model);
            }
        }

        private static List<Car> FindVehicles(string soughtCargoType, List<Car> vehicles)
        {
            List<Car> sortedVehicles = new List<Car>();

            switch (soughtCargoType)
            {
                case "fragile":
                    sortedVehicles = vehicles
                        .Where(v => v.Cargo.Type == soughtCargoType)
                        .Where(v => v.Tires.Any(t => t.Pressure < 1.0m))
                        .ToList();
                    break;

                case "flammable":
                    sortedVehicles = vehicles
                        .Where(v => v.Cargo.Type == soughtCargoType)
                        .Where(v => v.Engine.Power > 250)
                        .ToList();
                    break;
            }

            return sortedVehicles;
        }

        private static List<Car> GetVehicles()
        {
            List<Car> vehicles = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] rawData = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = GetEngine(int.Parse(rawData[1]), int.Parse(rawData[2]));
                Cargo cargo = GetCargo(int.Parse(rawData[3]), rawData[4]);

                string[] tireData = new string[8];
                Array.Copy(rawData, 5, tireData, 0, 8);
                Tire[] tires = GetTires(tireData);

                Car vehicle = new Car(rawData[0], engine, cargo, tires);
                vehicles.Add(vehicle);
            }

            return vehicles;
        }

        private static Engine GetEngine(int speed, int power)
        {
            return new Engine(speed, power);
        }

        private static Cargo GetCargo(int weight, string type)
        {
            return new Cargo(weight, type);
        }

        private static Tire[] GetTires(string[] tireData)
        {
            Tire[] tires = new Tire[4];

            for (int i = 0; i < tires.Length; i++)
            {
                decimal currentPressure = decimal.Parse(tireData[i + i]);
                int currentAge = int.Parse(tireData[i + i + 1]);

                Tire currentTire = new Tire(currentPressure, currentAge);
                tires[i] = currentTire;
            }

            return tires;
        }
    }
}
