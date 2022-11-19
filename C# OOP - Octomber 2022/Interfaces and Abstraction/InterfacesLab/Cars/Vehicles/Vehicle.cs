using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Vehicle : ICar, IElectricCar
    {
        public Vehicle(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public Vehicle(string model, string color, int battery)
            : this(model, color)
        {
            Battery = battery;
        }

        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Battery { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
