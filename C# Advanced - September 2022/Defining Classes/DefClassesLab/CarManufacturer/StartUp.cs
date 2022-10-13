using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    //Special Cars
    //Until you receive the command "No more tires", you will be given tire info in the format:
    //  {year} {pressure} {year} {pressure} {year} {pressure} {year} {pressure}
    //You have to collect all the sets of tires provided.
    //
    //Next, until you receive the command "Engines done", you will be given engine info in the format:
    //  {horsePower} {cubicCapacity}
    //
    //Until you receive "Show special", you will be given information about cars in the format:
    //  {make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
    //Every time you have to create a new Car with the information provided.
    //The car engine is the provided engineIndex and the tires are tiresIndex.
    //
    //When you receive the command "Show special", drive 20 kilometers with all cars which:
    //  - are manufactured during 2017 or later;
    //  - have horsepower above 330;
    //  - have the sum of their tire pressure between 9 and 10.
    //
    //Print information about each special car in the following format:
    //  "Make: {specialCar.Make}"
    //  "Model: {specialCar.Model}"
    //  "Year: {specialCar.Year}"
    //  "HorsePowers: {specialCar.Engine.HorsePower}"
    //  "FuelQuantity: {specialCar.FuelQuantity}"
    //
    //Input
    //  2 2.6 3 1.6 2 3.6 3 1.6
    //  1 3.3 2 1.6 5 2.4 1 3.2
    //  No more tires
    //  331 2.2
    //  145 2.0
    //  Engines done
    //  Audi A5 2017 200 12 0 0
    //  BMW X5 2007 175 18 1 1
    //  Show special
    //Output
    //  Make: Audi
    //  Model: A5
    //  Year: 2017
    //  HorsePowers: 331
    //  FuelQuantity: 197.6

    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tireSets = GetTires();
            List<Engine> engines = GetEngines();
            List<Car> cars = GetCars(tireSets, engines);

            Func<Tire[], double> getTotalPressure = tires => tires.Sum(tire => tire.Pressure);
            Predicate<double> pressureChecker = x => x >= 9 && x <= 10;

            List<Car> specialCars = cars
                .Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower > 330)
                .Where(c => pressureChecker(getTotalPressure(c.Tires)))
                .ToList();

            foreach (Car car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }

        private static List<Tire[]> GetTires()
        {
            List<Tire[]> totalSets = new List<Tire[]>();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                string[] tireData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Tire[] currentSet = new Tire[tireData.Length / 2];

                for (int i = 0; i < currentSet.Length; i++)
                {
                    int year = int.Parse(tireData[i + i]);
                    double pressure = double.Parse(tireData[i + i + 1]);
                    Tire tire = new Tire(year, pressure);
                    currentSet[i] = tire;
                }

                totalSets.Add(currentSet);
                input = Console.ReadLine();
            }

            return totalSets;
        }

        private static List<Engine> GetEngines()
        {
            List<Engine> engines = new List<Engine>();

            string input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] engineData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                input = Console.ReadLine();
            }

            return engines;
        }

        private static List<Car> GetCars(List<Tire[]> tireSets, List<Engine> engines)
        {
            List<Car> cars = new List<Car>();

            string input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] carData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                Engine engine = engines[int.Parse(carData[5])];
                Tire[] currentSet = tireSets[int.Parse(carData[6])];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, currentSet);
                cars.Add(car);

                input = Console.ReadLine();
            }

            return cars;
        }
    }
}
