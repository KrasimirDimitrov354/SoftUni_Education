using System;
using System.Linq;

namespace GenericSwapMethodStringOrInt
{
    //Generic Swap Method for Strings and Int
    //Create a generic method that receives an array containing any type of data and swaps the elements at two given indexes.
    //
    //Input
    //  •	On the first line you will read n number of boxes of type string or int, and add them to an array.
    //  •	Then you will receive a swap command consisting of two indexes.
    //Output
    //  •	Use the method you've created to swap the elements that correspond to the given indexes and print each element in the array.
    //
    //Examples
    //Input                 Output
    //3                     System.String: Swap me with Peter
    //Peter                 System.String: George
    //George                System.String: Peter
    //Swap me with Peter
    //0 2
    //
    //Input                 Output
    //2                     System.String: Hello
    //SoftUni               System.String: SoftUni
    //Hello
    //0 1
    //
    //Input                 Output
    //3                     System.Int32: 42
    //7                     System.Int32: 123
    //123                   System.Int32: 7
    //42
    //0 2
    //
    //Input                 Output
    //3                     System.Int32: 2
    //1                     System.Int32: 1
    //2                     System.Int32: 3
    //3
    //0 1

    public class Program
    {
        static void Main()
        {
            int arraySize = int.Parse(Console.ReadLine());

            //string[] array = new  string[arraySize];
            int[] array = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                //array[i] = Console.ReadLine();
                array[i] = int.Parse(Console.ReadLine());
            }

                Swap(array);
                PrintAll(array);
        }

        public static void Swap<T>(T[] array)
        {
            int[] swapIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(index => int.Parse(index))
                .ToArray();

            T temp = array[swapIndexes[0]];
            array[swapIndexes[0]] = array[swapIndexes[1]];
            array[swapIndexes[1]] = temp;
        }

        public static void PrintAll<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
}
