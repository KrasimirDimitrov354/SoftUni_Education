using System;

namespace ConsoleAppExercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            double yearTax = double.Parse(Console.ReadLine());

            double shoes = yearTax * 0.6;
            double clothes = shoes * 0.8;
            double ball = clothes / 4;
            double accessories = ball / 5;

            double total = yearTax + shoes + clothes + ball + accessories;

            Console.WriteLine(total);
        }
    }
}
