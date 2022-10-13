using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    //Car Salesman
    //Define two classes Car and Engine.
    //
    //Start by defining a class Car that holds information about:
    //  •	Model: a string property.
    //  •	Engine: a property holding the engine object.
    //  •	Weight: an int property, optional.
    //  •	Color: a string property, optional.
    //Next, the Engine class has the following properties:
    //  •	Model: a string property.
    //  •	Power: an int property.
    //  •	Displacement: an int property optional.
    //  •	Efficiency: a string property, optional.
    //
    //Input
    //On the first line you will read a number N, which will specify how many lines of engines you will receive.
    //  •	On each of the next N lines you will receive information about an Engine in the following format: "{model} {power} {displacement} {efficiency}".
    //  •	Keep in mind that "displacement" and "efficiency" are optional - they could be missing from the command.
    //
    //Next, you will receive a number M, which will specify how many lines of car you will receive.
    //  •	On each of the next M lines you will receive information about a Car in the following format: "{model} {engine} {weight} {color}".
    //  •	Keep in mind that "weight" and "color" are optional - they could be missing from the command.
    //  •	The "engine" will always be the model of an existing Engine.
    //  •	When creating the object for a Car, you must keep a reference to the real engine in it, not just the engine’s model. 
    //
    //Output
    //Your task is to print all the cars in the order they were received and their information in the format defined below.
    //Override the classes' "ToString()" methods in order to have a reusable way of displaying the objects.
    //If any of the optional fields are missing, print "n/a" in its place.
    //  "{CarModel}:
    //      {EngineModel}:
    //          Power: {EnginePower}
    //          Displacement: {EngineDisplacement}
    //          Efficiency: {EngineEfficiency}
    //      Weight: {CarWeight}
    //      Color: {CarColor}"
    //
    //Examples
    //Input
    //  2
    //  V8-101 220 50
    //  V4-33 140 28 B
    //  3
    //  FordFocus V4-33 1300 Silver
    //  FordMustang V8-101
    //  VolkswagenGolf V4-33 Orange
    //Output
    //  FordFocus:
    //    V4 - 33:
    //      Power: 140
    //      Displacement: 28
    //      Efficiency: B
    //    Weight: 1300
    //    Color: Silver
    //  FordMustang:
    //    V8 - 101:
    //      Power: 220
    //      Displacement: 50
    //      Efficiency: n/a
    //    Weight: n/a
    //    Color: n/a
    //  VolkswagenGolf:
    //  V4 - 33:
    //      Power: 140
    //      Displacement: 28
    //      Efficiency: B
    //    Weight: n/a
    //    Color: Orange
    //
    //Input
    //  4
    //  DSL - 10 280 B
    //  V7-55 200 35
    //  DSL-13 305 55 A+
    //  V7-54 190 30 D
    //  4
    //  FordMondeo DSL-13 Purple
    //  VolkswagenPolo V7-54 1200 Yellow
    //  VolkswagenPassat DSL-10 1375 Blue
    //  FordFusion DSL-13
    //Output
    //  FordMondeo:
    //    DSL - 13:
    //      Power: 305
    //      Displacement: 55
    //      Efficiency: A+
    //    Weight: n/a
    //    Color: Purple
    //  VolkswagenPolo:
    //    V7 - 54:
    //      Power: 190
    //      Displacement: 30
    //      Efficiency: D
    //    Weight: 1200
    //    Color: Yellow
    //  VolkswagenPassat:
    //    DSL - 10:
    //      Power: 280
    //      Displacement: n/a
    //      Efficiency: B
    //    Weight: 1375
    //    Color: Blue
    //  FordFusion:
    //    DSL - 13:
    //      Power: 305
    //      Displacement: 55
    //      Efficiency: A+
    //    Weight: n/a
    //    Color: n/a

    public class Program
    {
        static void Main()
        {
            List<Engine> engines = GetEngines();
            List<Car> cars = GetCars(engines);

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static List<Engine> GetEngines()
        {
            List<Engine> engines = new List<Engine>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = GetEngine(input);
                engines.Add(engine);
            }

            return engines;
        }

        private static Engine GetEngine(string[] input)
        {
            switch (input.Length)
            {
                case 3:
                    bool isNumber = int.TryParse(input[2], out int displacement);

                    if (isNumber)
                    {
                        return new Engine(input[0], int.Parse(input[1]), displacement);
                    }
                    else
                    {
                        return new Engine(input[0], int.Parse(input[1]), input[2]);
                    }

                case 4:
                    return new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]), input[3]);

                default:
                    return new Engine(input[0], int.Parse(input[1]));
            }
        }

        private static List<Car> GetCars(List<Engine> engines)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = GetCar(input, engines);
                cars.Add(car);
            }

            return cars;
        }

        private static Car GetCar(string[] input, List<Engine> engines)
        {
            Engine engine = engines
                .Where(e => e.Model == input[1])
                .FirstOrDefault();

            switch (input.Length)
            {
                case 3:
                    bool isNumber = int.TryParse(input[2], out int weight);

                    if (isNumber)
                    {
                        return new Car(input[0], engine, weight);
                    }
                    else
                    {
                        return new Car(input[0], engine, input[2]);
                    }

                case 4:
                    return new Car(input[0], engine, int.Parse(input[2]), input[3]);

                default:
                    return new Car(input[0], engine);
            }
        }
    }
}
