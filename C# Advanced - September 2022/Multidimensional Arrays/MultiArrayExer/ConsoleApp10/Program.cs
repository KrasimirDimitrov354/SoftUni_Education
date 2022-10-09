using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp10
{
    //Radioactive Mutant Vampire Bunnies - 80/100
    //Browsing through GitHub, you come across an old JS Basics teamwork game. It is about very nasty bunnies that multiply extremely fast.
    //There’s also a player that has to escape from their lair. You like the game, so you decide to port it to C# because that’s your language of choice.
    //The last thing that is left is the algorithm that decides if the player will escape the lair or not.
    //
    //First you will receive a line holding integers N and M, which represent the rows and columns in the lair. Then you receive N strings that can only consist of ".", "B", "P".
    //The bunnies are marked with "B", the player is marked with "P", and everything else is free space marked with a dot ".". They represent the initial state of the lair.
    //There will be only one player.
    //
    //Then you will receive a string with commands such as "LLRRUUDD", where each letter represents the next move of the player (Left, Right, Up, Down).
    //After each step of the player, each of the bunnies spread up, down, left and right - neighboring cells marked as "." change their value to "B".
    //If the player moves to a bunny cell or a bunny reaches the player, the player has lost. If the player goes out of the lair without encountering a bunny, the player has won.
    //
    //The game ends when the player loses or wins. All the activities for this turn continue (e.g. all the bunnies spread normally), but there are no more turns.
    //There will be no stalemates where the moves of the player end before he dies or escapes.
    //
    //Finally, print the final state of the lair with every row on a separate line. On the last line, print either "dead: {row} {col}" or "won: {row} {col}".
    //Row and col are the coordinates of the cell where the player has died or the last cell he has been in before escaping the lair.
    //
    //Input
    //  •	On the first line of input, the numbers N and M are received – the number of rows and columns in the lair.
    //  •	On the next N lines, each row is received in the form of a string. The string will contain only ".", "B" and "P".
    //      All strings will be the same length. There will be only one "P" for all the input.
    //  •	On the last line, the directions are received in the form of a string containing "R", "L", "U" or "D".
    //Output
    //  •	On the first N lines, print the final state of the bunny lair.
    //  •	On the last line, print the outcome – "won:" or "dead:" + {row} {col}.
    //Constraints
    //  •	The dimensions of the lair are in the range [3…20].
    //  •	The directions string length is in the range [1…20].
    //Examples
    //Input         Output
    //5 8           BBBBBBBB
    //.......B      BBBBBBBB
    //...B....      BBBBBBBB
    //....B..B      .BBBBBBB
    //........      ..BBBBBB
    //..P.....      won: 3 0
    //ULLL
    //
    //Input         Output
    //4 5           .B...
    //.....         BBB..
    //.....         BBBB.
    //.B...         BBB..
    //...P.         dead: 3 1
    //LLLLLLLL

    class Bunny
    {
        public Bunny(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }

    class Program
    {
        static bool RowIsValid(int dimension, char[,] matrix)
        {
            if (dimension >= 0 && dimension < matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }

        static bool ColIsValid(int dimension, char[,] matrix)
        {
            if (dimension >= 0 && dimension < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        static int CalculateDimension(int dimension, char direction, char[,] matrix)
        {
            switch (direction)
            {
                case 'U':
                    if (RowIsValid(dimension - 1, matrix))
                    {
                        dimension--;
                    }

                    break;
                case 'D':
                    if (RowIsValid(dimension + 1, matrix))
                    {
                        dimension++;
                    }

                    break;
                case 'L':
                    if (ColIsValid(dimension - 1, matrix))
                    {
                        dimension--;
                    }

                    break;
                case 'R':
                    if (ColIsValid(dimension + 1, matrix))
                    {
                        dimension++;
                    }

                    break;
            }

            return dimension;
        }

        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            char[,] rabbitValley = new char[size[0], size[1]];
            List<Bunny> bunnies = new List<Bunny>();

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size[0]; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < size[1]; col++)
                {
                    switch (currentRow[col])
                    {
                        case 'P':
                            playerRow = row;
                            playerCol = col;
                            break;
                        case 'B':
                            Bunny bunny = new Bunny(row, col);
                            bunnies.Add(bunny);
                            break;
                    }

                    rabbitValley[row, col] = currentRow[col];
                }
            }

            rabbitValley[playerRow, playerCol] = '.';
            char[] directions = Console.ReadLine().ToCharArray();
            bool eatenByBunnies = false;

            for (int i = 0; i < directions.Length; i++)
            {
                char currentDirection = directions[i];

                switch (currentDirection)
                {
                    case 'U':
                    case 'D':
                        playerRow = CalculateDimension(playerRow, currentDirection, rabbitValley);
                        break;
                    case 'L':
                    case 'R':
                        playerCol = CalculateDimension(playerCol, currentDirection, rabbitValley);
                        break;
                }

                foreach (Bunny bunny in bunnies)
                {
                    if (RowIsValid(bunny.Row + 1, rabbitValley))
                    {
                        rabbitValley[bunny.Row + 1, bunny.Col] = 'B';
                    }

                    if (RowIsValid(bunny.Row - 1, rabbitValley))
                    {
                        rabbitValley[bunny.Row - 1, bunny.Col] = 'B';
                    }

                    if (ColIsValid(bunny.Col + 1, rabbitValley))
                    {
                        rabbitValley[bunny.Row, bunny.Col + 1] = 'B';
                    }

                    if (ColIsValid(bunny.Col - 1, rabbitValley))
                    {
                        rabbitValley[bunny.Row, bunny.Col - 1] = 'B';
                    }
                }

                if (rabbitValley[playerRow, playerCol] == 'B')
                {
                    eatenByBunnies = true;
                    break;
                }

                bunnies.Clear();

                for (int row = 0; row < rabbitValley.GetLength(0); row++)
                {
                    for (int col = 0; col < rabbitValley.GetLength(1); col++)
                    {
                        if (rabbitValley[row, col] == 'B')
                        {
                            Bunny bunny = new Bunny(row, col);
                            bunnies.Add(bunny);
                        }
                    }
                }

            }

            for (int row = 0; row < rabbitValley.GetLength(0); row++)
            {
                for (int col = 0; col < rabbitValley.GetLength(1); col++)
                {
                    Console.Write(rabbitValley[row, col]);
                }
                Console.WriteLine();
            }

            if (eatenByBunnies)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }
    }
}
