using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp10
{
    //SoftUni Course Planning
    //Help plan the next Programming Fundamentals course by keeping track of the lessons that are going to be included in the course, as well as all the exercises for the lessons.
    //
    //On the first input line, separated by a comma and a space (", "), you will receive the initial schedule of lessons and exercises that are going to be part of the next course.
    //There are some changes to be made before the course starts. Until you receive the "course start" command, you will be given some commands to modify the course schedule.
    //
    //The possible commands are:
    //  •	Add:{lessonTitle} – add the lesson to the end of the schedule, if it does not exist
    //  •	Insert:{lessonTitle}:{index} – insert the lesson to the given index, if it does not exist
    //  •	Remove:{lessonTitle} – remove the lesson, if it exists.
    //  •	Swap:{lessonTitle}:{lessonTitle} – swap the position of the two lessons, if they exist
    //  •   Exercise:{lessonTitle} – add Exercise in the schedule right after the lesson index, if the lesson exists and there is no exercise already.
    //      The format for exercises is "{lessonTitle}-Exercise".
    //      If the lesson doesn`t exist, add the lesson at the end of the course schedule, followed by the Exercise.
    //Note: Each time you swap or remove a lesson, you should do the same with the exercises, if there are any following the lessons.
    //
    //Input / Constraints
    //  •	First line – the initial schedule lessons – strings, separated by comma and space ", ".
    //  •	Until "course start" you will receive commands in the format described above.
    //Output
    //  •	Print the whole course schedule, each lesson on a new line with its number(index) in the schedule: 
    //      "{lesson index}.{lessonTitle}"
    //  •	Allowed working time / memory: 100ms / 16MB.
    //
    //Examples
    //Input                             Comment
    //  Data Types, Objects, Lists      We receive the initial schedule.
    //  Add:Databases                   We add the Databases lesson because it doesn`t exist.
    //  Insert:Arrays:0                 At index 0 we insert lesson Arrays because it's not present in the schedule.
    //  Remove:Lists                    After removing lesson Lists, we print the whole schedule.
    //  course start
    //Output
    //  1.Arrays
    //  2.Data Types
    //  3.Objects
    //  4.Databases
    //
    //Input                             Comment
    //  Arrays, Lists, Methods          We swap the given lessons because both exist.
    //  Swap:Arrays:Methods             After receiving the Exercise command, we see that a lesson Databases doesn`t exist.
    //  Exercise:Databases              We add the lesson at the end, followed by the exercise.
    //  Swap:Lists:Databases            We swap lessons Lists and Databases, the Databases-Exercise is moved after the Databases lesson.
    //  Insert:Arrays:0                 We skip the next command because we already have such a lesson in our schedule.
    //  course start
    //Output
    //  1.Methods
    //  2.Databases
    //  3.Databases-Exercise
    //  4.Arrays
    //  5.Lists

    class Program
    {
        private static void AddLesson(List<string> course, string lesson)
        {
            if (course.Contains(lesson) == false)
            {
                course.Add(lesson);
            }
        }

        private static void RemoveLesson(List<string> course, string lesson)
        {
            if (course.Contains(lesson))
            {
                course.Remove(lesson);

                if (course.Contains($"{lesson}-Exercise"))
                {
                    course.Remove($"{lesson}-Exercise");
                }
            }
        }

        private static void InsertLesson(List<string> course, string lesson, int index)
        {
            if (index >= 0 && index <= course.Count - 1)
            {
                if (course.Contains(lesson) == false)
                {
                    course.Insert(index, lesson);
                }
            }          
        }

        private static void SwapLesson(List<string> course, string lessonA, string lessonB)
        {
            if (course.Contains(lessonA) && course.Contains(lessonB))
            {
                int indexA = course.IndexOf(lessonA);
                int indexB = course.IndexOf(lessonB);
                course[indexA] = lessonB;
                course[indexB] = lessonA;

                if (course.Contains($"{lessonA}-Exercise"))
                {
                    SwapExercise(course, lessonA, indexB);
                }
                
                if (course.Contains($"{lessonB}-Exercise"))
                {
                    SwapExercise(course, lessonB, indexA);
                }
            }
        }

        private static void SwapExercise(List<string> course, string lesson, int indexLesson)
        {
            int indexExercise = course.IndexOf($"{lesson}-Exercise");
            course.Insert(indexLesson + 1, course[indexExercise]);

            if (indexLesson < indexExercise)
            {
                indexExercise++;
            }

            course.RemoveAt(indexExercise);
        }

        private static void InsertExercise(List<string> course, string lesson)
        {
            if (course.Contains($"{lesson}-Exercise") == false)
            {
                if (course.Contains(lesson) == false)
                {
                    course.Add(lesson);
                }

                course.Insert(course.IndexOf(lesson) + 1, $"{lesson}-Exercise");
            }
        }

        private static void PrintCourse(List<string> course)
        {
            for (int i = 0; i < course.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{course[i]}");
            }
        }

        static void Main()
        {
            List<string> course = new List<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "course start")
                {
                    PrintCourse(course);
                    break;
                }
                else
                {
                    string[] command = input.Split(':');

                    switch (command[0])
                    {
                        case "Add":
                            AddLesson(course, command[1]);
                            break;
                        case "Insert":
                            InsertLesson(course, command[1], int.Parse(command[2]));
                            break;
                        case "Remove":
                            RemoveLesson(course, command[1]);
                            break;
                        case "Swap":
                            SwapLesson(course, command[1], command[2]);
                            break;
                        case "Exercise":
                            InsertExercise(course, command[1]);
                            break;
                    }
                }
            }
        }
    }
}
