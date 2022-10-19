using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListIteratorEnumerable
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public void PrintAll()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            StringBuilder output = new StringBuilder();

            foreach (T item in collection)
            {
                output.Append($"{item} ");
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
