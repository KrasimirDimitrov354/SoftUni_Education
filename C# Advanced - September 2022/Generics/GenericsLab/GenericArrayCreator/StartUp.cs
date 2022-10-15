using System;

namespace GenericArrayCreator
{
    //Generic Array Creator
    //Create a public StartUp class with the namespace GenericArrayCreator.
    //Create a class ArrayCreator with a method and a single overload to it:
    //  •	static T[] Create(int length, T item)
    //The method should return an array with the given length and every element should be set to the given default item.

    public class StartUp
    {
        static void Main()
        {
            string[] strings = ArrayCreator.Create(5, "test");
            int[] integers = ArrayCreator.Create(10, 10);
        }
    }
}
