using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        //Students
        //Define a class called Student, which will hold the following information about some students: 
        //  •	first name
        //  •	last name
        //  •	age
        //  •	home town
        //Input / Constraints
        //If you receive a student which already exists (first name and last name should be unique) overwrite the information.
        //Read information about some students until you receive the "end" command. After that, you will receive a city name.
        //Output
        //Print the students who are from the given city in the following format: "{firstName} {lastName} is {age} years old."
        //Examples
        //Input                         Output                              Input                           Output
        //John Smith 15 Sofia           John Smith is 15 years old.         John Smith 15 Sofia             John Smith is 15 years old.
        //Peter Ivanov 14 Plovdiv       Linda Bridge is 16 years old.       Peter Johnson 14 Plovdiv        Linda Bridge is 27 years old.
        //Linda Bridge 16 Sofia                                             Peter Johnson 25 Plovdiv
        //Simon Stone 12 Varna                                              Linda Bridge 16 Sofia
        //end                                                               Linda Bridge 27 Sofia
        //Sofia                                                             Simon Stone 12 Varna
        //                                                                  end
        //Input                         Output                              Sofia
        //Anthony Taylor 15 Chicago     Anthony Taylor is 15 years old.     
        //David Anderson 16 Washington  Jack Lewis is 14 years old.         Input                           Output
        //Jack Lewis 14 Chicago         David Lee is 14 years old.          Anthony Taylor 15 Chicago       Anthony Taylor is 15 years old.
        //David Lee 14 Chicago                                              David Anderson 16 Washington    Jack Lewis is 26 years old.
        //end                                                               Jack Lewis 14 Chicago           David Lee is 18 years old.
        //Chicago                                                           David Lee 14 Chicago
        //                                                                  Jack Lewis 26 Chicago
        //                                                                  David Lee 18 Chicago
        //                                                                  end
        //                                                                  Chicago

        private class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

            public void Print()
            {
                Console.WriteLine($"{FirstName} {LastName} is {Age} years old.");
            }

            public void Overwrite(int age, string city)
            {
                this.Age = age;
                this.City = city;
            }

        }

        private static bool CitiesMatch(string cityToCompareTo, string studentCity)
        {
            if (cityToCompareTo == studentCity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool StudentExists(List<Student> students, Student studentToCompare)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == studentToCompare.FirstName)
                {
                    if (student.LastName == studentToCompare.LastName)
                    {
                        student.Overwrite(studentToCompare.Age, studentToCompare.City);
                        return true;
                    }
                }
            }

            return false;
        }

        static void Main()
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    string cityToCompareTo = Console.ReadLine();

                    foreach (Student student in students)
                    {
                        if (CitiesMatch(cityToCompareTo, student.City))
                        {
                            student.Print();
                        }
                    }

                    break;
                }
                else
                {
                    List<string> studentInfo = input.Split(' ').ToList();

                    string firstName = studentInfo[0];
                    string lastName = studentInfo[1];
                    int age = int.Parse(studentInfo[2]);
                    string city = studentInfo[3];

                    Student student = new Student();
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;

                    if (StudentExists(students, student) == false)
                    {
                        students.Add(student);
                    }
                }
            }
        }
    }
}
