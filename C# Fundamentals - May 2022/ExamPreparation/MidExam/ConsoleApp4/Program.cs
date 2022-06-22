using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        //SoftUni Reception
        //Three employees are working on the reception all day. Each of them can handle a different number of students per hour.
        //Your task is to calculate how much time it will take to answer all the questions of a given number of students.
        //
        //First you will receive 3 lines with integers, representing the number of students that each employee can help per hour.
        //On the following line, you will receive students count as a single integer.
        //Every fourth hour all employees have a break, so they don't work for an hour.
        //It is the only break for the employees, because they don't need rest nor have a personal life.
        //Calculate the time needed to answer all the student's questions and print it in the following format: "Time needed: {time}h."
        //
        //Input / Constraints
        //  •	On the first three lines -  each employee efficiency -  integer in the range [1 - 100]
        //  •	On the fourth line - students count – integer in the range [0 – 10000]
        //  •	Input will always be valid and in the range specified
        //Output
        //  •	Print a single line: "Time needed: {time}h."
        //  •	Allowed working time / memory: 100ms / 16MB
        //
        //Examples
        //Input     Output              Comment
        //5         Time needed: 2h.    All employees can answer 15 students per hour. After the first hour, there are 5 students left to be answered.
        //6                             All students will be answered in the second hour.
        //4
        //20
        //
        //Input     Output              Comment
        //1         Time needed: 10h.   All employees can answer 6 students per hour. In the first 3 hours, they have answered 6 * 3 = 18 students.
        //2                             Then they have a break for an hour. After the next 3 hours, there are 18 + 6 * 3 = 36 answered students.
        //3                             After the break for an hour, there are only 9 students to answer.
        //45                            So in the 10th hour, all of the student's questions would be answered.
        //
        //Input     Output
        //3         Time needed: 5h.
        //2
        //5
        //40	

        static void Main()
        {
            List<int> employees = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                int employeeEfficiency = int.Parse(Console.ReadLine());
                employees.Add(employeeEfficiency);
            }

            int studentsCount = int.Parse(Console.ReadLine());
            int hours = 0;

            while (studentsCount > 0)
            {
                hours++;

                if (hours % 4 != 0)
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        int currentEmployee = employees[i];
                        studentsCount -= currentEmployee;

                        if (studentsCount <= 0)
                        {                           
                            break;
                        }
                    }
                }               
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
