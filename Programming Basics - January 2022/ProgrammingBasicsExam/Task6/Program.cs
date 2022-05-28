using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int x = int.Parse(input.Substring(2));
            int y = int.Parse(input.Substring(1, 1));
            int z = int.Parse(input.Substring(0, 1));

            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= y; j++)
                {
                    for (int k = 1; k <= z; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
                    }
                }
            }
        }
    }
}
