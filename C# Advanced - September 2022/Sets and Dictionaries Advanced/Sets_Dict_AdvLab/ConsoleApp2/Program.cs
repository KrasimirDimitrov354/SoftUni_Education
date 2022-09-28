using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    //Average Student Grades
    //Create a program which reads a name of a student and his/her grades and adds them to the student record, then prints the students' names with their grades and their average grade.
    //
    //Examples
    //Input         Output
    //7             John -> 5.20 3.20 (avg: 4.20)
    //John 5.20     Maria -> 5.50 2.50 3.46 (avg: 3.82)
    //Maria 5.50    Sam -> 2.00 3.00 (avg: 2.50)
    //John 3.20
    //Maria 2.50
    //Sam 2.00
    //Maria 3.46
    //Sam 3.00
    //
    //Input         Output
    //4             Vlad -> 4.50 5.00 (avg: 4.75)
    //Vlad 4.50     Peter -> 3.00 3.66 (avg: 3.33)
    //Peter 3.00
    //Vlad 5.00
    //Peter 3.66
    //
    //Input         Output
    //5             George -> 6.00 5.50 6.00 (avg: 5.83)
    //George 6.00   John -> 4.40 (avg: 4.40)
    //George 5.50   Peter -> 3.30 (avg: 3.30)
    //George 6.00
    //John 4.40
    //Peter 3.30

    class Grades
    {
        public Grades(List<decimal> gradeValue, int gradeCount)
        {
            this.GradeValues = gradeValue;
            this.GradeCount = gradeCount;
        }

        public List<decimal> GradeValues { get; set; }
        public int GradeCount { get; set; }
    }

    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, Grades> gradesOfStudents = new Dictionary<string, Grades>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string student = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!gradesOfStudents.ContainsKey(student))
                {
                    gradesOfStudents.Add(student, new Grades(new List<decimal>(), 0));
                }

                gradesOfStudents[student].GradeValues.Add(grade);
                gradesOfStudents[student].GradeCount++;
            }

            foreach (var student in gradesOfStudents)
            {
                Console.Write($"{student.Key} -> ");

                foreach (double grade in student.Value.GradeValues)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {student.Value.GradeValues.Average():f2})");
                
            }
        }
    }
}
