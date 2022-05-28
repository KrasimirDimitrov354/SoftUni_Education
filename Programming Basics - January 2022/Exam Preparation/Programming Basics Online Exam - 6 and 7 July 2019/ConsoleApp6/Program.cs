using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            double toNotPaint = double.Parse(Console.ReadLine());

            double toPaint = (height * width * 4) - ((height * width * 4) * (toNotPaint / 100));
            toPaint = Math.Ceiling(toPaint);
            bool leftToPaint = true;

            while (leftToPaint)
            {
                string input = Console.ReadLine();

                if (input == "Tired!")
                {
                    break;
                }
                else
                {
                    int painted = int.Parse(input);
                    toPaint -= painted;

                    if (toPaint <= 0)
                    {
                        leftToPaint = false;
                    }
                }
            }

            if (toPaint > 0)
            {
                Console.WriteLine($"{toPaint} quadratic m left.");
            }
            else if (toPaint == 0)
            {
                Console.WriteLine("All walls are painted! Great job, Pesho!");
            }
            else
            {
                Console.WriteLine($"All walls are painted and you have {Math.Abs(toPaint)} l paint left!");
            }
        }
    }
}
