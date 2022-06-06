using System;

namespace ConsoleApp4
{
    class Program
    {
        //Array Rotation
        //Create a program that receives an array and several rotations that you have to perform.
        //The rotations are done by moving the first element of the array from the front to the back. Print the resulting array.
        //Examples
        //Input             Output
        //51 47 32 61 21    32 61 21 51 47
        //2
        //Input             Output
        //32 21 61 1        32 21 61 1
        //4
        //Input             Output
        //2 4 15 31         4 15 31 2
        //5	


        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rotations; i++)
            {
                var currentlyMoved = input[0];

                for (int j = 1; j < input.Length; j++)
                {
                    input[j - 1] = input[j];
                }

                input[input.Length - 1] = currentlyMoved;
            }

            foreach (var element in input)
            {
                Console.Write(element + ' ');
            }
        }
    }
}
