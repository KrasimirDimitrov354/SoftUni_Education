using System;

namespace CondStatAdvExer6
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0;

            if ((N1 == 0 || N2 == 0) & (operation == '/' || operation == '%'))
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
            else
            {
                switch (operation)
                {
                    case '+':
                        result = N1 + N2;
                        break;
                    case '-':
                        result = N1 - N2;
                        break;
                    case '*':
                        result = N1 * N2;
                        break;
                    case '/':
                        result = N1 / N2;
                        break;
                    case '%':
                        result = N1 % N2;
                        break;
                }

                if (operation == '+' | operation == '-' | operation == '*')
                {
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{N1} {operation} {N2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} {operation} {N2} = {result} - odd");
                    }
                }
                else if (operation == '/')
                {
                    Console.WriteLine($"{N1} {operation} {N2} = {result:f2}");
                }
                else if (operation == '%')
                {
                    Console.WriteLine($"{N1} {operation} {N2} = {result}");
                }
            }           
        }
    }
}
