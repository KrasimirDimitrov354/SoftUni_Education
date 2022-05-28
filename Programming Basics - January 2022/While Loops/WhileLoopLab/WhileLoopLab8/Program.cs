using System;

namespace WhileLoopLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int studentClass = 0;
            double totalScore = 0;

            while (true)
            {
                double studentScore = double.Parse(Console.ReadLine());
                studentClass++;

                if (studentScore < 3)
                {
                    Console.WriteLine($"{studentName} has been excluded at {studentClass} grade");
                    break;
                }
                else if (studentScore < 4)
                {
                    studentClass--;
                }
                else
                {
                    totalScore += studentScore;
                }

                if (studentClass == 12)
                {
                    Console.WriteLine($"{studentName} graduated. Average grade: {(totalScore / 12):f2}");
                    break;
                }
            }
        }
    }
}
