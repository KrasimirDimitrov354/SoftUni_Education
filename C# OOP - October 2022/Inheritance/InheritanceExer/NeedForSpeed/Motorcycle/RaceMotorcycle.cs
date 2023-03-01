using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Motorcycle
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 8.0d;
            FuelConsumption = DefaultFuelConsumption;
        }
    }
}
