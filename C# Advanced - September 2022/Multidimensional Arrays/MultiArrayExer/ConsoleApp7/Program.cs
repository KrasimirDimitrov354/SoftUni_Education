using System;

namespace ConsoleApp7
{
    //Knight Game
    //The knight moves to the nearest square but not on the same row, column or diagonally.
    //This can be thought of as moving two squares horizontally, then one square vertically, or moving one square horizontally then two squares vertically — i.e. in a "L" pattern.
    //
    //The knight game is played on a board with dimensions N x N and a total of 0 <= K <= N * N knights.
    //
    //You will receive a board with K for knights and '0' for empty cells. Your task is to remove a minimum of the knights so there will be no knights left that can attack another knight.
    //
    //Input
    //  - On the first line you will receive the N side of the board.
    //  - On the next N lines you will receive strings with Ks and 0s.
    //Output
    //  - Print a single integer with the minimum number of knights that needs to be removed.
    //Constraints
    //  •	Size of the board will be 0 < N < 30.
    //  •	Time limit: 0.3 sec. Memory limit: 16 MB.
    //
    //Examples
    //Input     Output
    //5         1
    //0K0K0
    //K000K
    //00K00
    //K000K 
    //0K0K0
    //Input     Output
    //2         0
    //KK
    //KK
    //Input     Output
    //8         12
    //0K0KKK00
    //0K00KKKK
    //00K0000K
    //KKKKKK0K
    //K0K0000K
    //KK00000K
    //00K0K000
    //000K00KK

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                }
            }

            if (size <= 2)
            {
                Console.WriteLine(0);
            }
            else
            {
                bool knightsUnderAttack = true;
                int removedKnights = 0;

                while (knightsUnderAttack)
                {
                    int mostAttacks = 0;
                    int rowBiggestThreat = 0;
                    int colBiggestThreat = 0;

                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (board[row, col] == 'K')
                            {
                                int currentAttacks = CalculateVerticalAttacks(row, col, size, board) +
                                    CalculateHorizontalAttacks(row, col, size, board);

                                if (currentAttacks > mostAttacks)
                                {
                                    mostAttacks = currentAttacks;
                                    rowBiggestThreat = row;
                                    colBiggestThreat = col;
                                }
                            }
                        }
                    }

                    if (mostAttacks != 0)
                    {
                        board[rowBiggestThreat, colBiggestThreat] = '0';
                        removedKnights++;
                    }
                    else
                    {
                        knightsUnderAttack = false;
                    }
                }

                Console.WriteLine(removedKnights);
            }
        }

        static int CalculateVerticalAttacks(int row, int col, int size, char[,] board)
        {
            int currentAttacks = 0;

            if (AreCoordinatesValid(row - 2, col - 1, size))
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    currentAttacks++;
                }
            }

            if (AreCoordinatesValid(row - 2, col + 1, size))
            {
                if (board[row - 2, col + 1] == 'K')
                {
                    currentAttacks++;
                }
            }

            if (AreCoordinatesValid(row + 2, col - 1, size))
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    currentAttacks++;
                }
            }

            if (AreCoordinatesValid(row + 2, col + 1, size))
            {
                if (board[row + 2, col + 1] == 'K')
                {
                    currentAttacks++;
                }
            }

            return currentAttacks;
        }

        private static int CalculateHorizontalAttacks(int row, int col, int size, char[,] board)
        {
            int currentAttacks = 0;

            if (AreCoordinatesValid(row - 1, col - 2, size))
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    currentAttacks++;
                }
            }

            if (AreCoordinatesValid(row - 1, col + 2, size))
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    currentAttacks++;
                }
            }

            if (AreCoordinatesValid(row + 1, col - 2, size))
            {
                if (board[row + 1, col - 2] == 'K')
                {
                    currentAttacks++;
                }
            }

            if (AreCoordinatesValid(row + 1, col + 2, size))
            {
                if (board[row + 1, col + 2] == 'K')
                {
                    currentAttacks++;
                }
            }

            return currentAttacks;
        }

        static bool AreCoordinatesValid(int row, int col, int size)
        {
            if (row >= 0 && row < size)
            {
                if (col >= 0 && col < size)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
