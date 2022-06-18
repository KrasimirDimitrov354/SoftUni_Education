using System;

namespace ConsoleApp11
{
    class Program
    {
        //Math Operations
        //Write a method that receives two numbers and an operator, calculates the result and returns it.
        //You will be given three lines of input. The first will be the first number, the second one will be the operator and the last one will be the second number.
        //The possible operators are: /, *, + and -.
        //Example
        //Input     Output  Input       Output
        //5         25      4           12
        //*                 +
        //5                 8

        private static double Calculate(double num1, double num2, char operation)
        {
            double result = 0.0;

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
            }

            return result;
        }

        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double result = Calculate(firstNumber, secondNumber, symbol);

            Console.WriteLine(result);
        }
    }
}
