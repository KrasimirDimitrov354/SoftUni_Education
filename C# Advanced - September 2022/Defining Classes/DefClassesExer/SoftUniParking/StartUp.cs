using System;

namespace SoftUniParking
{
    //SoftUni Parking
    //Your task is to create a repository which stores cars by creating the classes described below.
    //
    //First, write a class Car with the following properties:
    //  •	Make - string
    //  •	Model - string
    //  •	HorsePower - int
    //  •	RegistrationNumber - string
    //
    //The class' constructor should receive make, model, horsePower, and registrationNumber.
    //The class must also override the ToString() method in the following format:
    //  "Make: {make}"
    //  "Model: {model}"
    //  "HorsePower: {horse power}"
    //  "RegistrationNumber: {registration number}"
    //
    //Then, create a class Parking with the following properties:
    //  •	Cars –  a collection that holds added cars.
    //  •	Capacity – int, accessed only by the base class. Responsible for the parking capacity.
    //
    //The class' constructor should initialize the Cars with a new instance of the collection and accept capacity as a parameter.
    //
    //Implement the following property:
    //  •	Count - Returns the number of stored cars.
    //
    //Implement the following methods:
    //  • AddCar(Car car)
    //      1) Check first if there is already a Car object with the provided registration number.
    //         If there is, the method must return the following message:
    //          "Car with that registration number, already exists!"
    //      2) Next, check if the count of the Car objects in the parking would become bigger than the capacity if another Car object is added.
    //         If it would, return the following message:
    //          "Parking is full!"
    //      3) If none of the previous conditions are true, simply add the current Car object to the collection.
    //         Return the following message:
    //          "Successfully added new car {Make} {RegistrationNumber}"
    //  • RemoveCar(string registrationNumber)
    //      1) If a Car object with the provided registration number does not exist, return the message: 
    //          "Car with that registration number, doesn't exist!"
    //      2) If it exists, remove the Car object and return the message:
    //          "Successfully removed {registrationNumber}"
    //  • GetCar(string registrationNumber)
    //      1) Return the Car object with the provided registration number. 
    //  • RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
    //      1) A void method which removes all Car objects that have the provided registration numbers.
    //         Each object is removed only if the registration number exists.

    public class StartUp
    {
        public static void Main()
        {
            //Sample code usage
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());
            //Make: Skoda
            //Model: Fabia
            //HorsePower: 65
            //RegistrationNumber: CC1856BG

            var parking = new Parking(5);
            Console.WriteLine(parking.AddCar(car));
            //Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.AddCar(car));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            //Make: Audi
            //Model: A3
            //HorsePower: 110
            //RegistrationNumber: EB8787MN

            Console.WriteLine(parking.RemoveCar("EB8787MN"));
            //Successfullyremoved EB8787MN

            Console.WriteLine(parking.Count); //1
        }
    }
}
