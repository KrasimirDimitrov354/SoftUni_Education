using System;

namespace CondStatAdv4
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());

            if (age < 16)
            {
                switch (gender)
                {
                    case 'm':
                        Console.WriteLine("Master");
                        break;
                    case 'f':
                        Console.WriteLine("Miss");
                        break;
                }
            }
            else if (age >= 16)
            {
                switch (gender)
                {
                    case 'm':
                        Console.WriteLine("Mr.");
                        break;
                    case 'f':
                        Console.WriteLine("Ms.");
                        break;
                }
            }
        }
    }
}
