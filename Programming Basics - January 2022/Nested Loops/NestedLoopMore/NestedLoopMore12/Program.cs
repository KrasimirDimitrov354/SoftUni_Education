using System;

namespace NestedLoopMore12
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());

            int counter = 0;
            string password = "";
            bool targetFound = false;

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    bool firstCondition = (i < j);

                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            bool secondCondition = (k > l);
                            bool thirdCondition = ((i * j) + (k * l) == target);

                            if (firstCondition && secondCondition && thirdCondition)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                                counter++;

                                if (counter == 4)
                                {
                                    targetFound = true;
                                    password = i.ToString() + j.ToString() + k.ToString() + l.ToString();
                                }
                            }
                        }
                    }
                }
            }

            if (counter > 0)
            {
                Console.WriteLine();
            }

            if (targetFound)
            {               
                Console.WriteLine($"Password: {password}");
            }
            else
            {                
                Console.WriteLine("No!");
            }
        }
    }
}
