using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    //Students
    //Create a program that sorts some students by their grade in descending order. Each student should have:
    //  •	First name (String)
    //  •	Last name (String)
    //  •	Grade (a floating-point number)
    //Input
    //  •	On the first line, you will receive a number n - the count of all students
    //  •	On the next n lines, you will be receiving information about these students in the following format: "{first name} {second name} {grade}"
    //Output
    //  •	Print out the information about each student in the following format: "{first name} {second name}: {grade}"
    //Example
    //Input   
    //  4
    //  Lakia Eason 3.90
    //  Prince Messing 5.49
    //  Akiko Segers 4.85
    //  Rocco Erben 6.00
    //Output
    //  Rocco Erben: 6.00
    //  Prince Messing: 5.49
    //  Akiko Segers: 4.85
    //  Lakia Eason: 3.90
    //
    //Input
    //  3
    //  Mary Elizabeth 4.22
    //  Li Xiao 5.74
    //  Liz Smith 4.87
    //Output
    //  Li Xiao: 5.74
    //  Liz Smith: 4.87
    //  Mary Elizabeth: 4.22

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }

    class Program
    {
        static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                Student student = new Student(input[0], input[1], double.Parse(input[2]));
                students.Add(student);
            }

            List<Student> orderedStudents = students.OrderByDescending(s => s.Grade).ToList();

            foreach (Student student in orderedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
