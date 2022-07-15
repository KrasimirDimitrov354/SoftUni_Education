using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    //Student Academy
    //Create a program that keeps the information about students and their grades.
    //You will receive n pair of rows. First, you will receive the student's name. After that, you will receive their grade.
    //Check if the student already exists and if not, add him. Keep track of all grades for each student.
    //
    //When you finish reading the data, keep the students with an average grade higher than or equal to 4.50.
    //Print the students and their average grade in the following format:
    //  "{name} –> {averageGrade}"
    //Format the average grade to the 2nd decimal place.
    //Examples
    //Input     Output
    //5         John -> 5.00
    //John      Alice -> 4.50
    //5.5       George -> 5.00
    //John
    //4.5
    //Alice
    //6
    //Alice
    //3
    //George
    //5	
    //
    //Input     Output
    //5         Rob -> 5.50
    //Amanda    Christian -> 5.00
    //3.5       Robert -> 6.00
    //Amanda
    //4
    //Rob
    //5.5
    //Christian
    //5
    //Robert
    //6

    class Program
    {
        private static double Average(List<double> grades)
        {
            double average = 0.0;

            foreach (double grade in grades)
            {
                average += grade;
            }

            return average / grades.Count;
        }

        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> gradesOfStudents = new Dictionary<string, List<double>>();

            for (int i = 0; i < linesCount; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (gradesOfStudents.ContainsKey(student) == false)
                {
                    gradesOfStudents.Add(student, new List<double>());
                }

                gradesOfStudents[student].Add(grade);
            }

            foreach (var student in gradesOfStudents)
            {
                double average = Average(student.Value);

                if (average >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {average:f2}");
                }
            }
        }
    }
}
