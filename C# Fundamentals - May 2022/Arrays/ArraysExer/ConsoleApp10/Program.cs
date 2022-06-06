using System;

namespace ConsoleApp10
{
    class Program
    {
        //Ladybugs (80/100, to fix)
        //You are given a field size and the indexes where ladybugs can be found on the field.
        //On every new line until the "end" command is given, a ladybug changes its position either to its left or to its right by a given fly length.
        //A movement description command looks like this: "0 right 1". This means that the little insect placed on index 0 should fly one index to its right.
        //If the ladybug lands on another ladybug, it continues to fly in the same direction repeating the specified flight length. If the ladybug flies out of the field, it is gone.
        //
        //For example, you are given a field of size 3 there are ladybugs on indexes 0 and 1.
        //If the ladybug on index 0 needs to fly to its right by the length of 1 (0 right 1) it will attempt to land on index 1.
        //As there is another ladybug there, it will continue further to the right passing 1 index in length, landing on index 2.
        //After that if the same ladybug needs to fly to its right passing 1 index (2 right 1), it will land somewhere outside of the field, so it flies away.
        //
        //If we receive an initial index that does not contain a ladybug nothing happens. If you are given a ladybug index that is outside the field, nothing happens.
        //In the end, print all cells of the field separated by blank spaces. For each cell that has a ladybug in it print '1' and for each empty cell print '0'.
        //The output of the example above should be '0 1 0'.
        //
        //Input
        //  •	On the first line, you will receive an integer - the size of the field
        //  •	On the second line, you will receive the initial indexes of all ladybugs separated by a blank space
        //  •	On the next lines, until you get the "end" command you will receive commands in the format: "{ladybug index} {direction} {fly length}"
        //Output
        //  •	Print all field cells in format: "{cell} {cell} … {cell}"
        //      o If a cell has a ladybug in it, print '1'
        //      o If a cell is empty, print '0'
        //Constraints
        //  •	The size of the field will be in the range [0 … 1000]
        //  •	The ladybug indexes will be in the range [-2,147,483,647 … 2,147,483,647]
        //  •	The number of commands will be in the range [0 … 100]
        //  •	The fly length will be in the range [-2,147,483,647 … 2,147,483,647]
        //Examples
        //Input         Output      Comments
        //3             0 1 0       1 1 0 - Initial field
        //0 1                       0 1 1 - field after "0 right 1"
        //0 right 1                 0 1 0 - field after "2 right 1"
        //2 right 1
        //end
        //Input         Output      Input       Output
        //3             0 0 0       5           0 0 0 1 0
        //0 1 2                     3
        //0 right 1                 3 left 2
        //1 right 1                 1 left -2
        //2 right 1                 end
        //end

        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] positions = Console.ReadLine().Split(' ');

            int[] field = new int[fieldSize];

            for (int i = 0; i < positions.Length; i++)
            {
                int currentPosition = int.Parse(positions[i]);
                for (int j = 0; j < field.Length; j++)
                {
                    if (j == currentPosition)
                    {
                        field[j] = 1;
                        break;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                else
                {
                    string[] command = input.Split(' ', 3);

                    int indexOfPosition = int.Parse(command[0]);
                    string indexOfDirection = command[1];
                    int indexOfSpaces = int.Parse(command[2]);

                    bool withinField = indexOfPosition >= 0 && indexOfPosition <= field.Length - 1;

                    if (withinField)
                    {
                        bool isMoving = field[indexOfPosition] == 1 && indexOfSpaces != 0;

                        if (isMoving)
                        {
                            field[indexOfPosition] = 0;

                            switch (indexOfDirection)
                            {
                                case "right":
                                    if (indexOfSpaces < 0)
                                    {
                                        for (int i = indexOfPosition - Math.Abs(indexOfSpaces); i >= 0; i--)
                                        {
                                            if (field[i] == 0)
                                            {
                                                field[i] = 1;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int i = indexOfPosition + indexOfSpaces; i < field.Length; i++)
                                        {
                                            if (field[i] == 0)
                                            {
                                                field[i] = 1;
                                                break;
                                            }
                                        }
                                    }
                                    break;

                                case "left":
                                    if (indexOfSpaces < 0)
                                    {
                                        for (int i = indexOfPosition + Math.Abs(indexOfSpaces); i < field.Length; i++)
                                        {
                                            if (field[i] == 0)
                                            {
                                                field[i] = 1;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int i = indexOfPosition - indexOfSpaces; i >= 0; i--)
                                        {
                                            if (field[i] == 0)
                                            {
                                                field[i] = 1;
                                                break;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            foreach (var index in field)
            {
                Console.Write($"{index} ");
            }
        }
    }
}
