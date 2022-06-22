using System;
using System.Linq;

namespace ConsoleApp8
{
    class Program
    {
        //Shoot for the Win
        //Write a program that helps you keep track of your shot targets.
        //You will receive a sequence with integers separated by a single space, representing targets and their value.
        //Afterward you will be receiving indices until the "End" command is given, and you need to print the targets and the count of shot targets.
        //
        //Every time you receive an index, if it is possible you need to shoot the target on that index.
        //Every time you shoot a target its value becomes -1 and it is considered shot. Along with that you also need to:
        //  •	Reduce all other targets which have greater values than your current target with your current target's value.
        //  •	Increase all other targets which have less than or equal value to the shot target with the shot target's value.
        //Keep in mind that you can't shoot a target which is already shot. You also can't increase or reduce a target which is considered shot.
        //
        //When you receive the "End" command, print the targets in their current state and the count of shot targets in the following format:
        //  "Shot targets: {count} -> {target 1} {target 2}… {target n}"
        //
        //Input / Constraints
        //  •	On the first line of input you will receive a sequence of integers separated by a single space – the targets sequence.
        //  •	Until the "End" command on the following lines you'll be receiving integers each on a single line – the index of the target to be shot.
        //Output
        //  •	The format of the output is described above in the problem description.
        //
        //Examples
        //Input             Output                                  Comments
        //24 50 36 70       Shot targets 3 -> -1 -1 130 -1          First we shoot the target on index 0. It becomes equal to -1 and we start going through the rest of the targets.
        //0                                                         50 is more than 24 so we reduce it to 26 and 36 to 12 and 70 to 46. The sequence looks like that:
        //4                                                         -1 26 12 46
        //3                                                         The following index is invalid, so we don't do anything.
        //1                                                         Index 3 is valid. After the operations our sequence should look like that:
        //End                                                       -1 72 58 -1
        //                                                          Then we take the first index with value 72 and our sequence looks like that:
        //                                                          -1 -1 130 -1
        //                                                          Then we print the result after the "End" command.
        //
        //Input                 Output 
        //30 30 12 60 54 66     Shot targets: 4 -> -1 120 -1 66 -1 -1
        //5
        //2
        //4
        //0
        //End

        private static bool TargetIsValid(int[] targets, int indexOfTarget)
        {
            bool indexLessThanZero = indexOfTarget < 0;
            bool indexBiggerThanArrayLength = indexOfTarget > targets.Length - 1;

            if (indexLessThanZero || indexBiggerThanArrayLength)
            {
                return false;
            }

            return true;
        }

        private static bool TargetNotShot(int[] targets, int indexOfTarget)
        {
            if (targets[indexOfTarget] == -1)
            {
                return false;
            }

            return true;
        }

        private static void AdjustTargets(int[] targets, int indexOfTarget)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                bool targetNotAlreadyShot = targets[i] != -1;
                bool differentThanShotTarget = i != indexOfTarget;

                if (targetNotAlreadyShot && differentThanShotTarget)
                {
                    if (targets[i] > targets[indexOfTarget])
                    {
                        targets[i] -= targets[indexOfTarget];
                    }
                    else
                    {
                        targets[i] += targets[indexOfTarget];
                    }
                }
            }

            targets[indexOfTarget] = -1;
        }

        static void Main()
        {
            int[] targets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            byte targetsShot = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    Console.Write($"Shot targets: {targetsShot} -> ");
                    Console.WriteLine(string.Join(' ', targets));
                    break;
                }
                else
                {
                    int indexOfTarget = int.Parse(input);

                    if (TargetIsValid(targets, indexOfTarget) && TargetNotShot(targets, indexOfTarget))
                    {
                        targetsShot++;
                        AdjustTargets(targets, indexOfTarget);
                    }
                }
            }
        }
    }
}
