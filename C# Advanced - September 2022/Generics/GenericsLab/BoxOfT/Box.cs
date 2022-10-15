using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> genericCollection;

        public Box()
        {
            genericCollection = new Stack<T>();
        }

        public Stack<T> GenericCollection { get { return genericCollection; } set { genericCollection = value; } }
        public int Count { get { return genericCollection.Count; } }

        public void Add(T element)
        {
            genericCollection.Push(element);
        }

        public T Remove()
        {
            return genericCollection.Pop();
        }
    }
}
