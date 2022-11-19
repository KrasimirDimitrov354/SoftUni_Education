using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : Vehicle
    {
        public Tesla(string model, string color, int battery)
            : base(model, color, battery)
        {

        }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine($"{Color} {GetType().Name} {Model} with {Battery} Batteries")
                .AppendLine(Start())
                .AppendLine(Stop())
                .ToString()
                .TrimEnd();
        }
    }
}
