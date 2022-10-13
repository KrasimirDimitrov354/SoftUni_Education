using System;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private double distanceTraveled;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            DistanceTraveled = 0;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKm
        {
            get { return fuelConsumptionPerKm; }
            set { fuelConsumptionPerKm = value; }
        }

        public double DistanceTraveled
        {
            get { return distanceTraveled; }
            set { distanceTraveled = value; }
        }

        public void Drive(double amountOfKm)
        {
            double fuelNeeded = FuelConsumptionPerKm * amountOfKm;

            if (FuelAmount >= fuelNeeded)
            {
                FuelAmount -= fuelNeeded;
                DistanceTraveled += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public void Print()
        {
            Console.WriteLine($"{Model} {FuelAmount:f2} {DistanceTraveled}");
        }
    }
}
