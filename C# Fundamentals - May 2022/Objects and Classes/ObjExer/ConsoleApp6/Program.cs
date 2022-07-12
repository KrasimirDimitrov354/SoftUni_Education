using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    //Vehicle Catalogue
    //Until you receive the "End" command, you will be receiving lines of input in the following format:
    //  "{typeOfVehicle} {model} {color} {horsepower}"
    //After you receive the "End" command, you will start receiving information about some vehicles.
    //For every vehicle, print out the information about it in the following format:
    //  "Type: {typeOfVehicle}
    //  Model: {modelOfVehicle}
    //  Color: {colorOfVehicle}
    //  Horsepower: {horsepowerOfVehicle}"
    //
    //When you receive the "Close the Catalogue" command, print out the average horsepower of the cars and the average horsepower of the trucks in the format:
    //  "{typeOfVehicles} have average horsepower of {averageHorsepower}."
    //The average horsepower is calculated by dividing the sum of the horsepower of all vehicles of the given type by the total count of all vehicles from that type.
    //Format the answer to the second digit after the decimal point.
    //Constraints
    //  •	The type of vehicle will always be either a car or a truck.
    //  •	You will not receive the same model twice.
    //  •	The received horsepower will be an integer in the range [1…1000]
    //  •	You will receive at most 50 vehicles.
    //  •	The separator will always be single whitespace.
    //Examples
    //Input                                                 Input
    //  truck Man red 200                                     truck Volvo blue 220
    //  truck Mercedes blue 300                               truck Man red 350
    //  car Ford green 120                                    car Tesla silver 450
    //  car Ferrari red 550                                   car Nio red 650
    //  car Lamborghini orange 570                            truck Mack white 430
    //  End                                                   car Koenigsegg orange 750
    //  Ferrari                                               End
    //  Ford                                                  Tesla
    //  Man                                                   Nio
    //  Close the Catalogue                                   Man
    //Output                                                  Mack
    //  Type: Car                                             Close the Catalogue
    //  Model: Ferrari                                      Output
    //  Color: red                                            Type: Car
    //  Horsepower: 550                                       Model: Tesla
    //  Type: Car                                             Color: silver
    //  Model: Ford                                           Horsepower: 450
    //  Color: green                                          Type: Car
    //  Horsepower: 120                                       Model: Nio
    //  Type: Truck                                           Color: red
    //  Model: Man                                            Horsepower: 650
    //  Color: red                                            Type: Truck
    //  Horsepower: 200                                       Model: Man
    //  Cars have average horsepower of: 413.33.              Color: red
    //  Trucks have average horsepower of: 250.00.            Horsepower: 350
    //                                                        Type: Truck
    //                                                        Model: Mack
    //                                                        Color: white
    //                                                        Horsepower: 430
    //                                                        Cars have average horsepower of: 616.67.
    //                                                        Trucks have average horsepower of: 333.33.

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Type: {char.ToUpper(this.Type[0]) + this.Type.Substring(1)}");
            Console.WriteLine($"Model: {this.Model}");
            Console.WriteLine($"Color: {this.Color}");
            Console.WriteLine($"Horsepower: {this.Horsepower}");
        }
    }

    class Program
    {
        private static void CheckForVehicle(List<Vehicle> vehicles, string input)
        {
            if (vehicles.Count != 0) //Check if collection is empty.
            {
                if (input == vehicles[0].Type)
                {
                    //Check if input is the collection type.
                    //If yes, print entire collection.

                    for (int i = 0; i < vehicles.Count; i++)
                    {
                        vehicles[i].PrintInfo();
                    }
                }
                else
                {
                    for (int i = 0; i < vehicles.Count; i++)
                    {
                        string currentVehicle = vehicles[i].Model;
                        string currentColor = vehicles[i].Color;
                        int currentHorsepower = vehicles[i].Horsepower;
                       
                        if (currentVehicle == input) 
                        {
                            //Check if input is collection member model.
                            //If yes, print collection member info and break.

                            vehicles[i].PrintInfo();
                            break;
                        }
                        else if (currentColor == input) 
                        {
                            //Check if input is collection member color.
                            //If yes, print collection member and search for another collection member that fits the criteria.

                            vehicles[i].PrintInfo();
                        }
                        else
                        {
                            bool isNumber = int.TryParse(input, out int result);

                            if (isNumber && currentHorsepower == result)
                            {
                                //Check if input is collection member horsepower.
                                //If yes, print collection member and search for another collection member that fits the criteria.

                                vehicles[i].PrintInfo();
                            }
                        }
                    }
                }
            }           
        }

        private static double CalculateAverageHorsepower(List<Vehicle> vehicles)
        {
            if (vehicles.Count == 0)
            {
                return 0.0;
            }
            else
            {
                double average = 0.0;

                for (int i = 0; i < vehicles.Count; i++)
                {
                    average += vehicles[i].Horsepower;
                }

                return average / vehicles.Count;
            }         
        }

        static void Main()
        {
            List<Vehicle> cars = new List<Vehicle>();
            List<Vehicle> trucks = new List<Vehicle>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    while (true)
                    {
                        string command = Console.ReadLine();

                        if (command != "Close the Catalogue")
                        {
                            CheckForVehicle(cars, command);
                            CheckForVehicle(trucks, command);
                        }
                        else
                        {
                            Console.WriteLine($"Cars have average horsepower of: {CalculateAverageHorsepower(cars):f2}.");
                            Console.WriteLine($"Trucks have average horsepower of: {CalculateAverageHorsepower(trucks):f2}.");
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    string[] vehicle = input.Split(' ').ToArray();

                    switch (vehicle[0])
                    {
                        case "car":
                            Vehicle car = new Vehicle(vehicle[0], vehicle[1], vehicle[2], int.Parse(vehicle[3]));
                            cars.Add(car);
                            break;
                        case "truck":
                            Vehicle truck = new Vehicle(vehicle[0], vehicle[1], vehicle[2], int.Parse(vehicle[3]));
                            trucks.Add(truck);
                            break;
                    }
                }
            }
        }
    }
}
