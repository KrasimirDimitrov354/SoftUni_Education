﻿using System;

namespace ConsoleApp2
{
    class Program
    {
        //Grades
        //Create a method that receives a grade between 2.00 and 6.00 and prints the corresponding grade definition:
        //  •	2.00 – 2.99 - "Fail"
        //  •	3.00 – 3.49 - "Poor"
        //  •	3.50 – 4.49 - "Good"
        //  •	4.50 – 5.49 - "Very good"
        //  •	5.50 – 6.00 - "Excellent"
        //Examples
        //Input     Output
        //3.33	    Poor
        //4.50	    Very good
        //2.99	    Fail

        private static void GradeCheck(double grade)
        {
            if (grade >= 5.5)
            {
                Console.WriteLine("Excellent");
            }
            else if (grade >= 4.5)
            {
                Console.WriteLine("Very good");
            }
            else if (grade >= 3.5)
            {
                Console.WriteLine("Good");
            }
            else if (grade >= 3)
            {
                Console.WriteLine("Poor");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

        static void Main()
        {
            double grade = double.Parse(Console.ReadLine());
            GradeCheck(grade);
        }
    }
}
