using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy
{
    public class Frog
    {
        private string path;

        public Frog(string path)
        {
            this.path = path;
        }

        public void ShowPath()
        {
            Console.WriteLine(path);
        }
    }
}
