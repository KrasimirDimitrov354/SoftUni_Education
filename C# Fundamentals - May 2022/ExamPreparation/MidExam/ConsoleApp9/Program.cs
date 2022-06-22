using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9
{
    class Program
    {
        //Moving Target
        //You are at the shooting gallery again and you need a program that helps you keep track of moving targets.
        //
        //On the first line you will receive a sequence of targets with their integer values split by a single space.
        //Then you will start receiving commands for manipulating the targets until the "End" command. The commands are the following:
        //  •	"Shoot {index} {power}"
        //      o Shoot the target at the index if it exists by reducing its value by the given power (integer value). 
        //      o Remove the target if it is shot. A target is considered shot when its value reaches 0.
        //  •	"Add {index} {value}"
        //      o Insert a target with the received value at the received index if it exists. 
        //      o If not, print: "Invalid placement!"
        //  •	"Strike {index} {radius}"
        //      o Remove the target at the given index and the ones before and after it depending on the radius.
        //      o If any of the indices in the range is invalid, print: "Strike missed!" and skip this command.
        //      Example:  "Strike 2 2"
        //      {radius}{radius}{strikeIndex}{radius}{radius}		
        //  •	"End"
        //      o Print the sequence with targets in the following format and end the program:
        //      "{target 1}|{target 2}…|{target n}"
        //
        //Input / Constraints
        //  •	On the first line, you will receive the sequence of targets – integer values [1-10000].
        //  •	On the following lines, until the "End" will be receiving the commands described above – strings.
        //  •	There will never be a case when the "Strike" command would empty the whole sequence.
        //Output
        //  •	Print the appropriate message in case of any command if necessary.
        //  •	In the end, print the sequence of targets in the format described above.
        //
        //Examples
        //Input	                Output	                Comments
        //52 74 23 44 96 110    Invalid placement!      The first command is "Shoot", so we reduce the target on index 5, which is valid, with the given power – 10.
        //Shoot 5 10            52|100                  Then we receive the same command, but we need to reduce the target on the 1st index, with power 80.
        //Shoot 1 80                                    The value of this target is 74, so it is considered shot, and we remove it.
        //Strike 2 1                                    Then we receive the "Strike" command on the 2nd index, and we need to check if the range with radius 1 is within:
        //Add 22 3                                      52 23 44 96 100
        //End                                           And it is, so we remove the targets.
        //                                              We receive the "Add" command, but the index is invalid, so we print the appropriate message.
        //                                              The final result is:
        //                                              52|100
        //
        //Input         Output
        //1 2 3 4 5     Strike missed!
        //Strike 0 1    1|2|3|4|5	
        //End

        private static void ShootTarget(List<int> targets, int index, int shot)
        {
            if (index >= 0 && index <= targets.Count - 1)
            {
                targets[index] -= shot;

                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }
        }

        private static void AddTarget(List<int> targets, int index, int value)
        {
            if (index < 0 || index > targets.Count - 1)
            {
                Console.WriteLine("Invalid placement!");
            }
            else
            {
                targets.Insert(index, value);
            }
        }

        private static void StrikeTarget(List<int> targets, int targetIndex, int radius)
        {
            int firstIndex = targetIndex - radius;
            int lastIndex = targetIndex + radius;

            if (firstIndex < 0 || lastIndex > targets.Count - 1)
            {
                Console.WriteLine("Strike missed!");
            }
            else
            {
                for (int i = 0; i < (2 * radius) + 1; i++)
                {
                    targets.RemoveAt(targetIndex - radius);
                }
            }
        }

        static void Main()
        {
            List<int> targets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine()
                .Split(' ')
                .ToList();

                string command = commands[0];

                if (command == "End")
                {
                    Console.WriteLine(string.Join('|', targets));
                    break;
                }
                else
                {
                    int index = int.Parse(commands[1]);

                    switch (command)
                    {
                        case "Shoot":
                            int shot = int.Parse(commands[2]);
                            ShootTarget(targets, index, shot);
                            break;
                        case "Add":
                            int value = int.Parse(commands[2]);
                            AddTarget(targets, index, value);
                            break;
                        case "Strike":
                            int radius = int.Parse(commands[2]);
                            StrikeTarget(targets, index, radius);
                            break;
                    }
                }
            }
        }
    }
}
