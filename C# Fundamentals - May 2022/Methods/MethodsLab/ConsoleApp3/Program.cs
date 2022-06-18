using System;

namespace ConsoleApp3
{
    class Program
    {
        //Calculations
        //Create a program that receives three lines of input:
        //  •	On the first line, a string - "add", "multiply", "subtract", "divide"
        //  •	On the second line, a number
        //  •	On the third line, another number
        //You should create four methods (for each calculation) and invoke the corresponding method depending on the command.
        //The method should also print the result (needs to be void).
        //Example
        //Input     Output  Input       Output
        //subtract  1       divide      2
        //5                 8
        //4                 4

        private static void Add(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine(result);
        }
        private static void Multiply(int num1, int num2)
        {
            int result = num1 * num2;
            Console.WriteLine(result);
        }
        private static void Subtract(int num1, int num2)
        {
            int result = num1 - num2;
            Console.WriteLine(result);
        }
        private static void Divide(int num1, int num2)
        {
            int result = num1 / num2;
            Console.WriteLine(result);
        }


        static void Main()
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    Add(firstNumber, secondNumber);
                    break;
                case "multiply":
                    Multiply(firstNumber, secondNumber);
                    break;
                case "subtract":
                    Subtract(firstNumber, secondNumber);
                    break;
                case "divide":
                    Divide(firstNumber, secondNumber);
                    break;
            }
        }
    }
}
