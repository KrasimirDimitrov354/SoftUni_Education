using System;

namespace ConsoleApp2
{
    class Program
    {
        //Common Elements
        //Create a program that prints out all common elements in two arrays.
        //You have to compare the elements of the second array to the elements of the first.
        //Examples
        //Input             Output
        //Hey hello 2 4     4 hello
        //10 hey 4 hello
        //Input             Output
        //S of t un i       of i un
        //of i 10 un
        //Input             Output
        //i love to code    code i love to
        //code i love to  

        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(' ');
            string[] secondArray = Console.ReadLine().Split(' ');

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (secondArray[i] == firstArray[j])
                    {
                        Console.Write($"{secondArray[i]} ");
                        break;
                    }
                }               
            }
        }
    }
}
