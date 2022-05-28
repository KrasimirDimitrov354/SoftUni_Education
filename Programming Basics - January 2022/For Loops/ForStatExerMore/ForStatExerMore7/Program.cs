using System;

namespace ForStatExerMore7
{
    class Program
    {
        static void Main(string[] args)
        {
            double stadiumSize = double.Parse(Console.ReadLine());
            double fansCount = double.Parse(Console.ReadLine());

            double fansA = 0;
            double fansB = 0;
            double fansV = 0;
            double fansG = 0;

            for (int i = 1; i <= fansCount; i++)
            {
                char sector = char.Parse(Console.ReadLine());

                switch (sector)
                {
                    case 'A':
                        fansA++;
                        break;
                    case 'B':
                        fansB++;
                        break;
                    case 'V':
                        fansV++;
                        break;
                    case 'G':
                        fansG++;
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"{((fansA / fansCount) * 100):f2}%");
            Console.WriteLine($"{((fansB / fansCount) * 100):f2}%");
            Console.WriteLine($"{((fansV / fansCount) * 100):f2}%");
            Console.WriteLine($"{((fansG / fansCount) * 100):f2}%");
            Console.WriteLine($"{((fansCount / stadiumSize) * 100):f2}%");
        }
    }
}
