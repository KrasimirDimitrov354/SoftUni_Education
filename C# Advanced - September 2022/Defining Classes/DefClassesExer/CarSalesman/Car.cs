using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = int.MinValue;
            Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            Color = color;
        }

        public string Model { get { return model; } set { model = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public int Weight { get { return weight; } set { weight = value; } }
        public string Color { get { return color; } set { color = value; } }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{Model}:");
            output.AppendLine($"  {Engine.Model}:");
            output.AppendLine(Engine.ToString());

            if (Weight == int.MinValue)
            {
                output.AppendLine("  Weight: n/a");
            }
            else
            {
                output.AppendLine($"  Weight: {Weight}");
            }

            output.AppendLine($"  Color: {Color}");

            return output.ToString().TrimEnd();
        }
    }
}
