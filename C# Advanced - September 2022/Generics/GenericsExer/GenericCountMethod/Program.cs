using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethod
{
    //Generic Count Method
    //Create a method that receives as an argument a list of any type that can be compared, and an element of the given type.
    //The method should return the count of elements that are greater than the value of the given element.
    //
    //Input
    //  •	 On the first line you will receive n - the number of elements to add to the list.
    //  •	 On the next n lines you will receive the actual elements.
    //  •	 On the last line you will get the value of the element for comparison.
    //Output
    //  •	Print the count of elements that are larger than the value of the given element.
    //Examples
    //Input     Output
    //3         2
    //aa
    //aaa
    //bb
    //aa
    //
    //Input     Output
    //1         1
    //aaa
    //aa
    //
    //Input     Output
    //3         2
    //7.13
    //123.22
    //42.78
    //7.55
    //
    //Input     Output
    //3         2
    //1.1
    //2.3
    //3.2
    //1.5

    public class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            //List<string> collection = new List<string>();
            List<double> collection = new List<double>();

            for (int i = 0; i < count; i++)
            {
                //collection.Add(Console.ReadLine());
                collection.Add(double.Parse(Console.ReadLine()));
            }

            //string comparer = Console.ReadLine();
            double comparer = double.Parse(Console.ReadLine());

            Console.WriteLine(GetGreaterThan(collection, comparer));
        }

        public static int GetGreaterThan<T>(List<T> collection, T comparer) where T : IComparable
        {
            return collection
                .Where(i => i.CompareTo(comparer) == 1)
                .Count();
        }
    }
}
