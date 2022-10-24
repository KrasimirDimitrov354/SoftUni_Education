using System;
using System.Collections.Generic;

namespace Help_A_Mole
{
    //Help-A-Mole
    //Everybody knows the famous Whac-A-Mole game, where you have to hit the mole and earn points.
    //This time you are going to play Help-A-Mole, because the Mole is tired of being chased and hit and he asked you to help him survive the next game.
    //
    //You will be given a number n, which will represent the size of the playing field (square shape).
    //On the next n lines, you will receive the rows of the field.
    //
    //The Mole will be placed on a random position marked with the letter 'M'.
    //At random positions there will be single digits representing points that the Mole earns.
    //
    //There will be two special locations which help the Mole move faster around the field. They will be marked with 'S'.
    //If the Mole lands on a special location, he will be teleported to the other one.
    //After the Mole is teleported to the other special location, he loses three points and both of the special locations disappear.
    //
    //All of the other locations will be marked with a dash - '-'.
    //
    //On each turn you will be given commands that guide the Mole through the playing field in order to escape the hits.
    //The commands will be 'up', 'down', 'left' and 'right'.
    //
    //If you receive a command that guides the Mole out of the playing field, you must print "Don't try to escape the playing field!" and continue with the next command.
    //After the Mole moves to the new position, you should mark the previous one with a dash '-'.
    //
    //The program ends when the "End" command is given or when the Mole collects at least 25 points.
    //
    //Input
    //  •	On the first line you are given the integer n – the size of the matrix (playing field).
    //  •	The next n lines hold the values for every row.
    //  •	Until you receive the "End" command, on each of the next lines you will get a move command.
    //Output
    //  •	On the first line print:
    //      o If the Mole collected 25 points or more: "Yay! The Mole survived another game!"
    //      o If the Mole didn't collect 25 points or more: "Too bad! The Mole lost this battle!"
    //  •	On the second line, depending on whether the Mole won the game or not, print:
    //      o If the Mole won the game: "The Mole managed to survive with a total of {totalAmountOfCollectedPoints} points."
    //      o If the Mole lost the game: "The Mole lost the game with a total of {totalAmountOfCollectedPoints} points."
    //  •	If the direction commands guide the Mole out of the playing field, print "Don't try to escape the playing field!".
    //  •	At the end, print the final state of the matrix (playing field) with the Mole's position on it.
    //Constraints
    //  •	The size of the square matrix (playing field) will be between [2 … 10].
    //  •	There will always be 2 special places on the wall marked with 'S'.
    //  •	The Mole's starting position will always be marked with an 'M'.
    //  •	There may be cases where the given directions will be outside of the matrix.
    //  •	There will be no cases in which the Mole's points will be below zero (0).
    //  •	There will be always two output scenarios: 
    //      o The Mole collects at least 25 points and the program ends;
    //      o The program receives the "End" command before the Mole manages to collect 25 points.
    //
    //Examples
    //Input     Output                                              Comments
    //5         Don't try to escape the playing field!              We move the Mole to the right. The new position is the number 9.
    //----S     Too bad! The Mole lost this battle!                 Current points - 9. Current matrix:
    //--M9-     The Mole lost the game with a total of 20 points.   ----S
    //-S-73     -----                                               ---M-
    //--4-4     -----                                               -S-73
    //-----     -----                                               --4-4
    //right     --4-M                                               -----
    //down      -----                                               We move the Mole to down. The new position is the number 7.
    //left                                                          Current points - 16. Current matrix:
    //left                                                          ----S
    //right                                                         -----
    //down                                                          -S-M3
    //down                                                          --4-4
    //down                                                          -----
    //End                                                           Third command is "left". The new position contains no numbers.
    //                                                              Next command is again "left". The new position is the special location S.
    //                                                              Current points - 13. Current matrix:
    //                                                              ----M
    //                                                              -----
    //                                                              ----3
    //                                                              --4-4
    //                                                              -----
    //                                                              Next command is "right" - outside of the playing field.
    //                                                              Next command is "down". Position contains no numbers.
    //                                                              "Down" again. Current points - 16.
    //                                                              "Down" again. Current points - 20.
    //                                                              Final command is "End". 25 points were not reached, so the Mole lost the game.
    //
    //Input     Output
    //5         Yay! The Mole survived another game!
    //----S     The Mole managed to survive with a total of 27 points.
    //--M97     -----
    //-S-77     -----
    //--4-4     ----M
    //-----     --4-4
    //right     -----
    //down
    //left
    //left
    //down
    //down
    //down
    //End
    //
    //Input     Output
    //5         Too bad! The Mole lost this battle!
    //----M     The Mole lost the game with a total of 5 points.
    //--5-S     -----
    //--5-S     --M-S
    //-5---     --5-S
    //5----     -5---
    //left      5----
    //left
    //left
    //down
    //right
    //End

    class Program
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            char[,] playingField = new char[fieldSize, fieldSize];

            List<SpecialSymbol> specialSymbols = new List<SpecialSymbol>();
            Mole mole = new Mole(0, 0, 0);

            for (int row = 0; row < fieldSize; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    switch (currentRow[col])
                    {
                        case 'M':
                            mole.Row = row;
                            mole.Col = col;
                            break;
                        case 'S':
                            SpecialSymbol special = new SpecialSymbol(row, col);
                            specialSymbols.Add(special);
                            break;
                    }

                    playingField[row, col] = currentRow[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "End" && mole.Points < 25)
            {
                switch (command)
                {
                    case "left":
                        if (CoordinatesValidation(mole.Row, mole.Col - 1, playingField))
                        {
                            playingField[mole.Row, mole.Col] = '-';
                            mole.Col--;

                            playingField = ModifyField(playingField, mole, specialSymbols);                         
                        }
                        break;
                    case "right":
                        if (CoordinatesValidation(mole.Row, mole.Col + 1, playingField))
                        {
                            playingField[mole.Row, mole.Col] = '-';
                            mole.Col++;

                            playingField = ModifyField(playingField, mole, specialSymbols);
                        }
                        break;
                    case "up":
                        if (CoordinatesValidation(mole.Row - 1, mole.Col, playingField))
                        {
                            playingField[mole.Row, mole.Col] = '-';
                            mole.Row--;

                            playingField = ModifyField(playingField, mole, specialSymbols);
                        }
                        break;
                    case "down":
                        if (CoordinatesValidation(mole.Row + 1, mole.Col, playingField))
                        {
                            playingField[mole.Row, mole.Col] = '-';
                            mole.Row++;

                            playingField = ModifyField(playingField, mole, specialSymbols);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            PrintResult(mole, playingField);
        }

        private static bool CoordinatesValidation(int row, int col, char[,] playingField)
        {
            if (row >= 0 && row < playingField.GetLength(0))
            {
                if (col >= 0 && col < playingField.GetLength(1))
                {
                    return true;
                }
            }

            Console.WriteLine("Don't try to escape the playing field!");
            return false;
        }

        private static char[,] ModifyField(char[,] playingField, Mole mole, List<SpecialSymbol> specialSymbols)
        {
            if (playingField[mole.Row, mole.Col] == 'S')
            {
                playingField[mole.Row, mole.Col] = '-';
                mole.Points -= 3;

                mole.DigTunnel(playingField, specialSymbols);
            }
            else if (Char.IsDigit(playingField[mole.Row, mole.Col]))
            {
                mole.Points += (int)Char.GetNumericValue(playingField[mole.Row, mole.Col]);
            }

            playingField[mole.Row, mole.Col] = 'M';

            return playingField;
        }

        public static void PrintResult(Mole mole, char[,] playingField)
        {
            if (mole.Points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {mole.Points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {mole.Points} points.");
            }

            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    Console.Write(playingField[row, col]);
                }

                Console.WriteLine();
            }
        }
    }

    public class Mole
    {
        private int row;
        private int col;
        private int points;

        public Mole(int row, int col, int points)
        {
            Row = row;
            Col = col;
            Points = points;
        }

        public int Row { get { return row; } set { row = value; } }
        public int Col { get { return col; } set { col = value; } }
        public int Points { get { return points; } set { points = value; } }

        public void DigTunnel(char[,] playingField, List<SpecialSymbol> specialSymbols)
        {
            for (int i = 0; i < specialSymbols.Count; i++)
            {
                if (playingField[Row, Col] != playingField[specialSymbols[i].Row, specialSymbols[i].Col])
                {
                    Row = specialSymbols[i].Row;
                    Col = specialSymbols[i].Col;
                    break;
                }
            }
        }
    }

    public class SpecialSymbol
    {
        private int row;
        private int col;

        public SpecialSymbol(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get { return row; }  set{ row = value; } }
        public int Col { get { return col; }  set{ col = value; } }
    }
}
