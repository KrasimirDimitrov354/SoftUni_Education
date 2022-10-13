using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = int.MinValue;
            Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power, displacement)
        {
            Efficiency = efficiency;
        }

        public string Model { get { return model; } set { model = value; } }
        public int Power { get { return power; } set { power = value; } }
        public int Displacement { get { return displacement; } set { displacement = value; } }
        public string Efficiency { get { return efficiency; } set { efficiency = value; } }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"    Power: {Power}");

            if (Displacement == int.MinValue)
            {
                output.AppendLine("    Displacement: n/a");
            }
            else
            {
                output.AppendLine($"    Displacement: {Displacement}");
            }

            output.AppendLine($"    Efficiency: {Efficiency}");

            return output.ToString().TrimEnd();
        }
    }
}
