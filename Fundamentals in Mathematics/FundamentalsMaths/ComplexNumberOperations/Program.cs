using System;
using System.Linq;

namespace ComplexNumberOperations
{
    class Program
    {
        static void Main()
        {
            ComplexNumber[] complexNumbers = GetNumbers();

            Console.WriteLine("Choose operation to perform - sum, difference, multiplication, division:");
            string operation = Console.ReadLine();

            Console.Write("Your number is ");
            switch (operation)
            {
                case "sum":
                    Console.WriteLine(GetComplexSum(complexNumbers));
                    break;
                case "difference":
                    Console.WriteLine(GetComplexDifference(complexNumbers));
                    break;
                case "multiplication":
                    Console.WriteLine(GetComplexMultiplication(complexNumbers));
                    break;
                case "division":
                    Console.WriteLine(GetComplexDivision(complexNumbers));
                    break;
            }
        }

        private static ComplexNumber[] GetNumbers()
        {
            ComplexNumber[] complexNumbers = new ComplexNumber[2];

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter complex number values in the format [a, b]:");
                double[] values = Console.ReadLine()
                    .Split(", ")
                    .Select(v => double.Parse(v))
                    .ToArray();

                complexNumbers[i] = new ComplexNumber(values[0], values[1]);
            }

            return complexNumbers;
        }

        private static string GetComplexSum(ComplexNumber[] complexNumbers)
        {
            return new ComplexNumber(complexNumbers[0].A + complexNumbers[1].A,
                complexNumbers[0].B + complexNumbers[1].B).ToString();
        }

        private static string GetComplexDifference(ComplexNumber[] complexNumbers)
        {
            return new ComplexNumber(complexNumbers[0].A - complexNumbers[1].A,
                complexNumbers[0].B - complexNumbers[1].B).ToString();
        }

        private static string GetComplexMultiplication(ComplexNumber[] complexNumbers)
        {
            double multipliedA = (complexNumbers[0].A * complexNumbers[1].A)
                - (complexNumbers[0].B * complexNumbers[1].B);
            double multipliedB = (complexNumbers[0].A * complexNumbers[1].B)
                + (complexNumbers[0].B * complexNumbers[1].A);

            return new ComplexNumber(multipliedA, multipliedB).ToString();
        }

        private static string GetComplexDivision(ComplexNumber[] complexNumbers)
        {
            double dividedA = (complexNumbers[0].A * complexNumbers[1].A)
                + (complexNumbers[0].B * complexNumbers[1].B);
            double dividedB = (complexNumbers[0].B * complexNumbers[1].A)
                - (complexNumbers[0].A * complexNumbers[1].B);

            return $"({new ComplexNumber(dividedA, dividedB).ToString()}) / " +
                $"{Math.Pow(complexNumbers[1].A, 2) + Math.Pow(complexNumbers[1].B, 2)}";
        }

        class ComplexNumber
        {
            public ComplexNumber(double a, double b)
            {
                A = a;
                B = b;
            }

            public double A { get; private set; }
            public double B { get; private set; }

            public override string ToString()
            {
                if (B < 0)
                {
                    return $"{A} - {Math.Abs(B)}i";
                }
                else
                {
                    return $"{A} + {B}i";
                }
            }
        }
    }
}
