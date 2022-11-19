using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double consumptionIncrease;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double consumptionIncrease, double tankCapacity)
        {
            this.tankCapacity = tankCapacity;
            this.consumptionIncrease = consumptionIncrease;
            this.fuelConsumption = fuelConsumption;
            SetFuelQuantity(fuelQuantity);
        }

        private void SetFuelQuantity(double value)
        {
            if (value > tankCapacity)
            {
                fuelQuantity = 0;
            }
            else
            {
                fuelQuantity = value;
            }
        }

        public virtual void Drive(double distance)
        {
            double travelDistance = (fuelConsumption * distance) + (consumptionIncrease * distance);

            if (travelDistance <= fuelQuantity)
            {
                fuelQuantity -= travelDistance;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        protected void ChangeConsumption(double newConsumption)
        {
            consumptionIncrease = newConsumption;
        }

        public void Refuel(double quantity)
        {
            if (quantity > 0)
            {
                double fuelAmount = 0;

                if (GetType().Name == "Truck")
                {
                    fuelAmount = quantity - (quantity - (quantity * 0.95));
                }
                else
                {
                    fuelAmount = quantity;

                }

                if (CanRefuel(fuelAmount))
                {
                    fuelQuantity += fuelAmount;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }

        private bool CanRefuel(double fuelAmount)
        {
            if (fuelAmount + fuelQuantity > tankCapacity)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Math.Round(fuelQuantity, 2):f2}";
        }
    }
}
