using System;

namespace NestedLoopExer4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string subject = "";
            double score = 0;
            double subjectScores = 0;
            double totalScores = 0;
            int counterSubjects = 0;
            int counterScores = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {(totalScores / counterSubjects):f2}.");
                    break;
                }
                else
                {
                    bool isNumber = double.TryParse(input, out score);

                    if (isNumber)
                    {
                        subjectScores += score;
                        counterScores++;
                    }
                    else
                    {
                        subject = input;
                        counterSubjects++;
                    }

                    if (counterScores == n)
                    {
                        Console.WriteLine($"{subject} - {(subjectScores / n):f2}.");
                        totalScores += (subjectScores / n);
                        subjectScores = 0;
                        counterScores = 0;
                    }                   
                }
            }
        }
    }
}
