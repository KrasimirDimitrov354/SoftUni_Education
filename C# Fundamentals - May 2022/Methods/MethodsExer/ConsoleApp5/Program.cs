using System;

namespace ConsoleApp5
{
    class Program
    {
        //Add and Subtract
        //You will receive 3 integers.
        //Create a method that returns the sum of the first two integers and another method that subtracts the third integer from the result of the sum method.
        //Examples
        //Input     Output
        //23        19
        //6
        //10
        //Input     Output	
        //1         -12
        //17
        //30
        //Input     Output
        //42        0
        //58
        //100	

        private static int SumOfFirstTwo(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        private static int SubstractThirdFromSum(int[] numbers)
        {
            return SumOfFirstTwo(numbers[0], numbers[1]) - numbers[2];
        }

        static void Main()
        {
            int[] numbers = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(SubstractThirdFromSum(numbers));
        }
    }
}
