using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }

        public List<Car> Cars { get { return cars; } set { cars = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count { get { return Cars.Count; } }

        public string AddCar(Car car)
        {
            if (Cars.Exists(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else
            {
                if (Cars.Count == Capacity)
                {
                    return "Parking is full!";
                }
                else
                {
                    Cars.Add(car);

                    return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
            }         
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.Exists(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);

                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.Find(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string number in registrationNumbers)
            {
                if (Cars.Exists(c => c.RegistrationNumber == number))
                {
                    Cars.RemoveAll(c => c.RegistrationNumber == number);
                }
            }
        }
    }
}
