using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListIterator
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        private int internalIndex;

        public ListyIterator(T[] collection)
        {
            this.collection = collection.ToList();
            internalIndex = 0;
        }

        public bool HasNext()
        {
            return internalIndex < collection.Count - 1;
        }

        public bool Move()
        {
            if (HasNext())
            {
                internalIndex++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(collection[internalIndex]);
        }
    }
}
