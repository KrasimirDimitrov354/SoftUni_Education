using System;

namespace ForStatExerMore4
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            double totalScore = 0;
            double topStudents = 0;
            double goodStudents = 0;
            double averageStudents = 0;
            double failedStudents = 0;

            for (int i = 1; i <= studentsCount; i++)
            {
                double studentScore = double.Parse(Console.ReadLine());
                totalScore += studentScore;

                if (studentScore >= 5)
                {
                    topStudents++;
                }
                else if (studentScore >= 4)
                {
                    goodStudents++;
                }
                else if (studentScore >= 3)
                {
                    averageStudents++;
                }
                else
                {
                    failedStudents++;
                }
            }

            Console.WriteLine($"Top students: {((topStudents / studentsCount) * 100):f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {((goodStudents / studentsCount) * 100):f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {((averageStudents / studentsCount) * 100):f2}%");
            Console.WriteLine($"Fail: {((failedStudents / studentsCount) * 100):f2}%");
            Console.WriteLine($"Average: {(totalScore / studentsCount):f2}");
        }
    }
}
