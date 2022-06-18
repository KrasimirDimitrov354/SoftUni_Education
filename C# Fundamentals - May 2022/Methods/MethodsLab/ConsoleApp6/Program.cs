using System;

namespace ConsoleApp6
{
    class Program
    {
        //Calculate Rectangle Area
        //Create a method that calculates and returns the area of a rectangle.
        //Examples

        //Input     Output
        //3         12
        //4
        //Input     Output
        //6         12
        //2

        private static int CalculateArea(int num1, int num2)
        {
            int sum = num1 * num2;
            return sum;
        }

        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateArea(num1, num2));        
        }
    }
}
