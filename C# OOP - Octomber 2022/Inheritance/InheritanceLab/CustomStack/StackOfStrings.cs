using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public StackOfStrings() : base()
        {

        }

        public bool IsEmpty()
        {
            if (this.Count != 0)
            {
                return false;
            }

            return true;
        }

        public Stack<string> AddRange(IEnumerable<string> range)
        {
            foreach (string item in range)
            {
                this.Push(item);
            }

            return this;
        }

    }
}
