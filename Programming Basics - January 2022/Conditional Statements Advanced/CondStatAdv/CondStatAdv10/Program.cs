using System;

namespace CondStatAdv10
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 0:
                    break;
                default:
                    if (input < 100 || input > 200)
                    {
                        Console.WriteLine("invalid");
                    }
                    break;
            }
        }
    }
}
