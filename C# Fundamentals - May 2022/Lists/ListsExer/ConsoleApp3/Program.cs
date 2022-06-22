using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        //House Party
        //Create a program that keeps track of the guests that are going to a house party.
        //On the first line of input you are going to receive the number of commands that will follow.
        //On the next lines, you are going to receive some of the following:
        //  - "{name} is going!"
        //      •	You have to add the person if they are not on the guestlist already.
        //      •	If the person is on the list print the following to the console: "{name} is already in the list!"
        //  - "{name} is not going!"
        //  •	You have to remove the person if they are on the list.
        //  •	If not, print out: "{name} is not in the list!"
        //Finally, print all of the guests, each on a new line.
        //Examples
        //Input                 Output
        //4                     John is not in the list!
        //Allie is going!       Allie
        //George is going!
        //John is not going!
        //George is not going!
        //
        //Input                 Output
        //5                     Tom is already in the list!
        //Tom is going!         Tom
        //Annie is going!       Annie
        //Tom is going!         Garry
        //Garry is going!       Jerry
        //Jerry is going!	

        private static void IsGoing(List<string> guests, string comingGuest)
        {
            bool notOnList = true;

            for (int i = 0; i < guests.Count; i++)
            {
                string presentGuest = guests[i];

                if (presentGuest == comingGuest)
                {
                    notOnList = false;
                    break;
                }
            }

            if (notOnList)
            {
                guests.Add(comingGuest);
            }
            else
            {
                Console.WriteLine($"{comingGuest} is already in the list!");
            }
        }

        private static void IsNotGoing(List<string> guests, string notComingGuest)
        {
            bool onList = false;

            for (int i = 0; i < guests.Count; i++)
            {
                string presentGuest = guests[i];

                if (presentGuest == notComingGuest)
                {
                    onList = true;
                    break;
                }
            }

            if (onList)
            {
                guests.Remove(notComingGuest);
            }
            else
            {
                Console.WriteLine($"{notComingGuest} is not in the list!");
            }
        }

        static void Main()
        {
            List<string> guests = new List<string>();
            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                List<string> command = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                string guest = command[0];

                if (command.Count == 3)
                {
                    IsGoing(guests, guest);
                }
                else
                {
                    IsNotGoing(guests, guest);
                }
            }

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
