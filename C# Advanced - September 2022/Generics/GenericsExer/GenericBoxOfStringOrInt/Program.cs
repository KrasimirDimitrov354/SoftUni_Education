using System;
using System.Collections.Generic;

namespace GenericBoxOfString
{
    //Generic Box of String or Int
    //Create a generic class Box that can be initialized with any type and store the value.
    //Override the ToString() method and print the type and stored value.
    //
    //Input
    //  •	On the first line you will get n - the number of strings or ints to read from the console.
    //  •	On the next n lines you will get the actual strings or ints.
    //      o Create a box for each of them and call its ToString() method to print its data on the console.
    //Output
    //  •	The output should be in the given format:
    //      "{class full name: value}"
    //Examples
    //Input             Output
    //2                 System.String: life in a box
    //life in a box     System.String: box in a life
    //box in a life
    //
    //Input             Output
    //3                 System.String: Peter
    //Peter             System.String: Simon
    //Simon             System.String: Griffin
    //Griffin
    //
    //Input             Output
    //1                 System.Int32: 1001
    //1001
    //
    //Input             Output
    //3                 System.Int32: 7
    //7                 System.Int32: 123
    //123               System.Int32: 42
    //42

    public class Program
    {
        static void Main()
        {
            List<Box<int>> boxOfInts = new List<Box<int>>();
            List<Box<string>> boxOfStrings = new List<Box<string>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                bool isNumber = int.TryParse(input, out int num);

                if (isNumber)
                {
                    Box<int> newInt = new Box<int>(num);
                    boxOfInts.Add(newInt);
                }
                else
                {
                    Box<string> newString = new Box<string>(input);
                    boxOfStrings.Add(newString);
                }
            }

            foreach (var box in boxOfInts)
            {
                Console.WriteLine(box.ToString());
            }

            foreach (var box in boxOfStrings)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
