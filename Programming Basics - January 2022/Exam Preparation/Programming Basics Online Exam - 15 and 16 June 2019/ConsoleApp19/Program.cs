using System;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameActor = Console.ReadLine();
            double scoreActor = double.Parse(Console.ReadLine());
            int judges = int.Parse(Console.ReadLine());

            string nameJudge = "";
            double scoreJudge = 0;
            double goal = 1250.5;
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();
                counter++;

                bool isNumber = double.TryParse(input, out scoreJudge);

                if (!isNumber)
                {
                    nameJudge = input;
                }
                else
                {
                    scoreActor += (nameJudge.Length * scoreJudge) / 2;
                }

                if (counter == (judges * 2) || scoreActor >= goal)
                {
                    break;
                }
            }

            if (scoreActor >= goal)
            {
                Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {scoreActor:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {nameActor} you need {(goal - scoreActor):f1} more!");
            }
        }
    }
}
