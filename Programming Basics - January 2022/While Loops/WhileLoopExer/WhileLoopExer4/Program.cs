using System;

namespace WhileLoopExer4
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int totalSteps = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input != "Going home")
                {
                    int currentSteps = int.Parse(input);
                    totalSteps += currentSteps;

                    if (totalSteps >= goal)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{totalSteps - goal} steps over the goal!");
                        break;
                    }
                }
                else
                {
                    int homeSteps = int.Parse(Console.ReadLine());
                    totalSteps += homeSteps;

                    if (totalSteps >= goal)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{totalSteps - goal} steps over the goal!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{goal - totalSteps} more steps to reach goal.");
                        break;
                    }
                }
            }
        }
    }
}
