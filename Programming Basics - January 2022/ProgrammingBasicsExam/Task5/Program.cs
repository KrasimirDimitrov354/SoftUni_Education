using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = "";
            string bestPlayer = "";
            int goals = 0;
            int topGoals = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END" )
                {
                    Console.WriteLine($"{bestPlayer} is the best player!");

                    if (topGoals >= 3)
                    {
                        Console.WriteLine($"He has scored {topGoals} goals and made a hat-trick !!!");
                    }
                    else
                    {
                        Console.WriteLine($"He has scored {topGoals} goals.");
                    }

                    break;
                }
                else
                {
                    bool isNumber = int.TryParse(input, out goals);

                    if (!isNumber)
                    {
                        player = input;
                    }
                    else
                    {
                        if (goals > topGoals)
                        {
                            topGoals = goals;
                            bestPlayer = player;
                        }
                    }
                }
            }
        }
    }
}
