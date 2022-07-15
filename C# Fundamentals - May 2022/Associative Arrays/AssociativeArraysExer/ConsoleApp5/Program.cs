using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    //Courses
    //Create a program that keeps the information about courses. Each course has a name and registered students.
    //
    //You will be receiving a course name and a student name until you receive the command "end".
    //Check if such a course already exists. If it does not, add the course and register the user into the course.
    //
    //When you receive the command "end", print the courses with their names and total registered users. For each contest print the registered users.
    //
    //Input
    //  •	Until the "end" command is received, you will be receiving input in the format: "{courseName} : {studentName}".
    //  •	The product data is always delimited by " : ".
    //Output
    //  •	Print the information about each course in the following the format: 
    //      "{courseName}: {registeredStudents}"
    //  •	Print the information about each student in the following the format:
    //      "-- {studentName}"
    //Examples
    //Input
    //  Programming Fundamentals : John Smith
    //  Programming Fundamentals : Linda Johnson
    //  JS Core : Will Wilson
    //  Java Advanced : Harrison White
    //  end
    //Output
    //  Programming Fundamentals: 2
    //  -- John Smith
    //  -- Linda Johnson
    //  JS Core: 1
    //  -- Will Wilson
    //  Java Advanced: 1
    //  -- Harrison White
    //
    //Input
    //  Algorithms : Jay Moore
    //  Programming Basics : Martin Taylor
    //  Python Fundamentals : John Anderson
    //  Python Fundamentals : Andrew Robinson
    //  Algorithms : Bob Jackson
    //  Python Fundamentals : Clark Lewis
    //  end
    //Output
    //  Algorithms: 2
    //  -- Jay Moore
    //  -- Bob Jackson
    //  Programming Basics: 1
    //  -- Martin Taylor
    //  Python Fundamentals: 3
    //  -- John Anderson
    //  -- Andrew Robinson
    //  -- Clark Lewis

    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> informationForCourses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" : ").ToArray();

                if (input[0] == "end")
                {
                    foreach (var course in informationForCourses)
                    {
                        Console.WriteLine($"{course.Key}: {course.Value.Count}");

                        foreach (string student in course.Value)
                        {
                            Console.WriteLine($"-- {student}");
                        }
                    }

                    break;
                }
                else
                {
                    string course = input[0];
                    string student = input[1];

                    if (informationForCourses.ContainsKey(course) == false)
                    {
                        informationForCourses.Add(course, new List<string>());
                    }

                    informationForCourses[course].Add(student);
                }
            }
        }
    }
}
