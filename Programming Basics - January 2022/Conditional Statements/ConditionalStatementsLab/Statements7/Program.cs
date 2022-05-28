using System;

namespace Statements7
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double value1 = 0;
            double value2 = 0;
            double pi = Math.PI;
            double area = 0;

            if (figure == "square" | figure == "circle")
            {
                value1 = double.Parse(Console.ReadLine());

                if (figure == "square")
                {
                    area = value1 * value1;
                }
                else
                {
                    area = (value1 * value1) * pi;
                }
            }
            else
            {
                value1 = double.Parse(Console.ReadLine());
                value2 = double.Parse(Console.ReadLine());

                if (figure == "rectangle")
                {
                    area = value1 * value2;
                }
                else
                {
                    area = (value1 * value2) / 2;
                }
            }

            Console.WriteLine($"{area:f3}");
        }
    }
}
