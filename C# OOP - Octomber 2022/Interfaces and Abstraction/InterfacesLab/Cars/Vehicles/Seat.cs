using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Seat : Vehicle
    {
        public Seat(string model, string color)
            : base(model, color)
        {

        }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine($"{Color} {GetType().Name} {Model}")
                .AppendLine(Start())
                .AppendLine(Stop())
                .ToString()
                .TrimEnd();
        }
    }
}
