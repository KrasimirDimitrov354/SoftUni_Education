using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    //Vehicle Catalogue
    //Your task is to create a Vehicle catalog which contains only Trucks and Cars.
    //
    //Define a class Truck with the following properties: Brand, Model, and Weight.
    //Define a class Car with the following properties: Brand, Model, and Horse Power.
    //Define a class Catalog with the following properties: Collections of Trucks and Cars.
    //
    //You must read the input until you receive the "end" command. It will be in following format: "{type}/{brand}/{model}/{horse power / weight}"
    //In the end you have to print all of the vehicles ordered alphabetical by brand, in the following format:
    //  "Cars:
    //  {Brand}: {Model} - {Horse Power}hp
    //  Trucks:
    //  {Brand}: {Model} - {Weight}kg"
    //Examples
    //Input
    //  Car/Audi/A3/110
    //  Car/Maserati/Levante/350
    //  Truck/Mercedes/Actros/9019
    //  Car/Porsche/Panamera/375
    //  end
    //Output
    //  Cars:
    //  Audi: A3 - 110hp
    //  Maserati: Levante - 350hp
    //  Porsche: Panamera - 375hp
    //  Trucks:
    //  Mercedes: Actros - 9019kg
    //
    //Input
    //  Car/Subaru/Impreza/152
    //  Car/Peugeot/307/109
    //  end
    //Output
    //  Cars:
    //  Peugeot: 307 - 109hp
    //  Subaru: Impreza - 152hp

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }

    class Catalog
    {
        public Catalog()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
        }

        public void PrintTrucks(List<Truck> trucks)
        {
            foreach (Truck truck in trucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }

    class Program
    {
        private static bool ListHasElements(int listCount)
        {
            if (listCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            Catalog catalog = new Catalog();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    if (ListHasElements(catalog.Cars.Count))
                    {
                        Console.WriteLine("Cars:");
                        List<Car> orderedCars = catalog.Cars.OrderBy(c => c.Brand).ToList();
                        catalog.PrintCars(orderedCars);
                    }

                    if (ListHasElements(catalog.Trucks.Count))
                    {
                        Console.WriteLine("Trucks:");
                        List<Truck> orderedTrucks = catalog.Trucks.OrderBy(t => t.Brand).ToList();
                        catalog.PrintTrucks(orderedTrucks);
                    }

                    break;
                }
                else
                {
                    string[] vehicleInfo = input.Split('/').ToArray();
                    string type = vehicleInfo[0];

                    switch (type)
                    {
                        case "Car":
                            {
                                Car car = new Car
                                {
                                    Brand = vehicleInfo[1],
                                    Model = vehicleInfo[2],
                                    HorsePower = int.Parse(vehicleInfo[3])
                                };

                                catalog.Cars.Add(car);
                                break;
                            }

                        case "Truck":
                            {
                                Truck truck = new Truck
                                {
                                    Brand = vehicleInfo[1],
                                    Model = vehicleInfo[2],
                                    Weight = int.Parse(vehicleInfo[3])
                                };

                                catalog.Trucks.Add(truck);
                                break;
                            }
                    }
                }
            }
        }
    }
}
