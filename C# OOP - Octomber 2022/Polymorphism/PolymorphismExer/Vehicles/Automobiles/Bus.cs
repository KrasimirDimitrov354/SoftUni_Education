using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, 1.4, tankCapacity)
        {
            
        }

        public void DriveEmpty(double distance)
        {
            ChangeConsumption(0);
            base.Drive(distance);
        }

        public override void Drive(double distance)
        {
            ChangeConsumption(1.4);
            base.Drive(distance);
        }
    }
}
