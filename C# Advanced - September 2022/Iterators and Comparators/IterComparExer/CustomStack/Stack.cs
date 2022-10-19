using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;

        public Stack()
        {
            this.stack = new List<T>();
        }

        public int Count { get { return stack.Count; } private set { } }

        public void Push(T item)
        {
            stack.Add(item);
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T removedItem = stack[Count - 1];

            stack.RemoveAt(Count - 1);
            Count--;

            return removedItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
