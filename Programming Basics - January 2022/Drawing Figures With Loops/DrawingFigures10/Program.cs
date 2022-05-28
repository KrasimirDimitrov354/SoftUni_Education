using System;

namespace DrawingFigures10
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int rows = 0;
            int counterStars = 0;
            int counterDashesOuter = (input - 1) / 2;
            int counterDashesInner = 0;
            int middle = 0;

            if (input % 2 == 0)
            {
                counterStars = 2;
                rows = input - 1;
                middle = input / 2;

                if (input > 2)
                {
                    counterDashesInner = 2;
                }
            }
            else
            {
                counterStars = 1;
                rows = input;
                middle = (input + 1) / 2;

                if (input > 2)
                {
                    counterDashesInner = 1;
                }
            }

            string stars = new String('*', counterStars);
            string dashesOuter = new String('-', counterDashesOuter);
            string dashesInner = new String('-', counterDashesInner);

            for (int i = 1; i <= rows; i++)
            {
                if (i == 1 || i == rows)
                {
                    Console.Write(dashesOuter);
                    Console.Write(stars);
                    Console.WriteLine(dashesOuter);
                }
                else
                {
                    if (i < middle)
                    {
                        counterDashesOuter--;
                        dashesOuter = dashesOuter.Substring(0, counterDashesOuter);
                        Console.Write(dashesOuter);
                        Console.Write("*");
                        Console.Write(dashesInner);
                        Console.Write("*");
                        Console.WriteLine(dashesOuter);
                        dashesInner += "--";
                    }
                    else if (i == middle)
                    {
                        Console.Write("*");
                        Console.Write(dashesInner);
                        Console.WriteLine("*");
                        counterDashesInner = input - 2;
                    }
                    else
                    {
                        counterDashesInner -= 2;
                        dashesInner = dashesInner.Substring(0, counterDashesInner);
                        Console.Write(dashesOuter);
                        Console.Write("*");
                        Console.Write(dashesInner);
                        Console.Write("*");
                        Console.WriteLine(dashesOuter);
                        dashesOuter += "-";                       
                    }
                }
            }
        }
    }
}
