using System;

namespace GenericScale
{
    //Generic Scale
    //Create a public StartUp class with the namespace GenericScale.
    //Create a class EqualityScale<T> that holds two elements - left and right.
    //
    //The scale should receive the elements through its single constructor:
    //  •	EqualityScale(T left, T right)
    //
    //The scale should have a single method: 
    //  •	bool AreEqual()
    //The method should return true if the elements are equal, otherwise it should return false.

    public class StartUp
    {
        static void Main()
        {
            EqualityScale<int> intScale = new EqualityScale<int>(3, 8);
            Console.WriteLine(intScale.AreEqual());

            EqualityScale<string> stringScale = new EqualityScale<string>("abc", "abc");
            Console.WriteLine(stringScale.AreEqual());
        }
    }
}
