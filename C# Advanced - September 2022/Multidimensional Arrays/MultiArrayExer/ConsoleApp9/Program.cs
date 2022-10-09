using System;
using System.Linq;

namespace ConsoleApp9
{
    //Miner
    //We get as input the size of the field in which our miner moves. The field is always a square.
    //After that we will receive the commands which represent the directions in which the miner should move.
    //
    //The miner starts from position {s}. The commands will be: left, right, up, and down.
    //If the miner has reached a side edge of the field and the next command indicates that he has to get out of the field, he must remain in his current position and ignore the current command.
    //
    //The possible characters that may appear on the screen are:
    //  •	c - coal.
    //  •	s - the place where the miner starts.
    //  •	e - the end of the route.
    //  •	* - a regular position on the field.
    //
    //Each time when the miner finds coal, he collects it and replaces it with an asterisk symbol - *. Keep track of the count of the collected coals.
    //If the miner collects all of the coals in the field, the program stops and you have to print the following message: "You collected all coals! ({indexCurrentRow}, {indexCurrentCol})".
    //If the miner steps at position {e}, the game is over and the program stops. You have to print the following message: "Game over! ({indexCurrentRow}, {indexCurrentCol})".
    //If there are no more commands and none of the above cases have happened, you have to print the following message: "{remainingCoals} coals left. ({indexCurrentRow}, {indexCurrentCol})".
    //
    //Input
    //  •	Field size - an integer number.
    //  •	Commands to move the miner - an array of strings separated by a single whitespace.
    //  •	The field - any number of the following characters - *, e, c, s - separated by a single whitespace.
    //Output
    //  •	As defined in the conditions above.
    //
    //Examples
    //Input
    //  5                             
    //  up right right up right
    //  * * * c *
    //  * * * e *
    //  * * c * *
    //  s * * c *
    //  * * c * *
    //Output
    //  Game over! (1, 3)
    //
    //Input
    //  4
    //  up right right right down
    //  * * * e
    //  * * c *
    //  * s * c
    //  * * * *
    //Output
    //  You collected all coals! (2, 3)
    //
    //Input
    //  6
    //  left left down right up left left down down down
    //  * * * * * *
    //  e * * * c *
    //  * * c s * *
    //  * * * * * *
    //  c * * * c *
    //  * * c * * *
    //Output
    //  3 coals left. (5, 0)

    class Program
    {
        static bool CellIsValid(int dimension, char[,] matrix)
        {
            if (dimension >= 0 && dimension < matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }

        static int CalculateDimension(int dimension, string direction, char[,] matrix)
        {
            switch (direction)
            {
                case "up":
                case "left":
                    if (CellIsValid(dimension - 1, matrix))
                    {
                        dimension--;
                    }

                    break;
                case "down":
                case "right":
                    if (CellIsValid(dimension + 1, matrix))
                    {
                        dimension++;
                    }

                    break;
            }

            return dimension;
        }

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] mine = new char[size, size];

            int coalTotal = 0;
            int minerRow = 0;
            int minerCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => char.Parse(c))
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    switch (currentRow[col])
                    {
                        case 'c':
                            coalTotal++;
                            break;
                        case 's':
                            minerRow = row;
                            minerCol = col;
                            break;
                    }

                    mine[row, col] = currentRow[col];
                }
            }

            bool exitReached = false;
            bool mineEmpty = false;

            for (int i = 0; i < directions.Length; i++)
            {
                if (exitReached || mineEmpty)
                {
                    break;
                }

                string currentDirection = directions[i];

                switch (currentDirection)
                {
                    case "up":
                    case "down":
                        minerRow = CalculateDimension(minerRow, currentDirection, mine);
                        break;
                    case "left":
                    case "right":
                        minerCol = CalculateDimension(minerCol, currentDirection, mine);
                        break;
                }

                switch (mine[minerRow, minerCol])
                {
                    case 'c':
                        coalTotal--;
                        mine[minerRow, minerCol] = '*';

                        if (coalTotal == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            mineEmpty = true;
                        }
                        break;
                    case 'e':
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        exitReached = true;
                        break;
                }
            }

            if (!mineEmpty && !exitReached)
            {
                Console.WriteLine($"{coalTotal} coals left. ({minerRow}, {minerCol})");
            }
        }
    }
}
