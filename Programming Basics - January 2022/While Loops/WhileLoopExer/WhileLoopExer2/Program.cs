using System;

namespace WhileLoopExer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int failLimit = int.Parse(Console.ReadLine());

            int failedTasks = 0;
            int totalTasks = 0;
            double totalScore = 0;

            string lastTask = "default";

            while (true)
            {
                string currentTask = Console.ReadLine();

                if (currentTask != "Enough")
                {
                    int score = int.Parse(Console.ReadLine());

                    lastTask = currentTask;
                    totalScore += score;                   
                    totalTasks++;

                    if (score <= 4)
                    {
                        failedTasks++;

                        if (failedTasks == failLimit)
                        {
                            Console.WriteLine($"You need a break, {failedTasks} poor grades.");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Average score: {(totalScore / totalTasks):f2}");
                    Console.WriteLine($"Number of problems: {totalTasks}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    break;
                }
            }
        }
    }
}
