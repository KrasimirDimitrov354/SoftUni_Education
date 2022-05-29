using System;

namespace ConsoleApp3
{
    class Program
    {
        //3.	Elevator
        //Calculate how many courses will be needed to elevate n persons by using an elevator of the capacity of p persons.
        //The input holds two lines: the number of people n and the capacity p of the elevator.
        //Examples
        //Input     Output      Comments
        //17        6           5 courses * 3 people + 1 course * 2 persons
        //3		
        //Input     Output      Comments
        //4         1           All the persons fit inside in the elevator. Only one course is needed.
        //5
        //Input     Output      Comments                    
        //10        2           2 courses * 5 people
        //5		

        static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = 0;

            while (people > 0)
            {
                people -= capacity;
                courses++;
            }

            Console.WriteLine(courses);
        }
    }
}
