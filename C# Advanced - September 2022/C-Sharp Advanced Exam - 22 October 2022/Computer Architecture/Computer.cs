using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Multiprocessor = new List<CPU>();
            Model = model;
            Capacity = capacity;
        }

        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Capacity > 0)
            {
                Multiprocessor.Add(cpu);
                Capacity--;
            }
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.Exists(c => c.Brand == brand))
            {
                Multiprocessor.RemoveAll(c => c.Brand == brand);
                Capacity++;

                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            return Multiprocessor.Find(c => c.Frequency == Multiprocessor.Max(c => c.Frequency));
        }

        public CPU GetCPU(string brand)
        {
            if (Multiprocessor.Exists(c => c.Brand == brand))
            {
                int cpuIndex = Multiprocessor.FindIndex(c => c.Brand == brand);
                return Multiprocessor[cpuIndex];
            }

            return null;
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                output.AppendLine(cpu.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
