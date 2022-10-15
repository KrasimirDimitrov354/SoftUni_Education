using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T genericValue;

        public Box(T genericValue)
        {
            GenericValue = genericValue;
        }

        public T GenericValue { get { return genericValue; } set { genericValue = value; } }

        public override string ToString()
        {
            return $"{GenericValue.GetType()}: {GenericValue}";
        }
    }
}
