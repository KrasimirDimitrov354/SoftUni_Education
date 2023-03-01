using System;
using System.Linq;

namespace _04._Spiral_Matrix
{
    //Спираловидна матрица - 60/100
    //Дадена е матрица от цели числа с R на брой редове и C на брой колони. Матрицата ще се въвежда от конзолата.
    //Отпечатайте елементите на матрицата в спираловиден ред.
    //
    //Вход
    //  От конзолата ще се въведат:
    //  •	на първия ред – брой редове на матрицата – цяло число в интервала [1…100].
    //  •	на втория ред – брой колони на матрицата – цяло число в интервала [1…100].
    //  •	на следващите редове – елементите на матрицата, разделени с интервал – цели числа в интервала [1…1000].
    //Изход
    //  Отпечатайте елементите на матрицата, разделени с интервал, в спираловиден ред в примерите по-долу.
    //
    //Пример
    //Вход          Изход
    //3             8 12 4 3 61 14 92 13 43 19 34 48
    //4
    //8 12 4 3
    //19 34 48 61
    //43 13 92 14
    //
    //Вход          Изход
    //4             2 9 14 99 81 21 7 9 6 1 3 4
    //3
    //2 9 14
    //1 3 99
    //6 4 81
    //9 7 21

    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = GetMatrix(rows, cols);
            int[] output = new int[rows * cols];

            int currentPositionRow = 0;
            int currentPositionCol = 0;
            int rowsBorder = rows - 1;
            int colsBorder = cols - 1;

            int rowsToRemoveFromTop = 1;

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = matrix[currentPositionRow, currentPositionCol];

                if (i == output.Length - 1)
                {
                    break;
                }

                if (currentPositionCol < colsBorder && (currentPositionRow < rowsBorder || rowsBorder == 1))
                {
                    currentPositionCol++;
                }
                else
                {
                    if (currentPositionRow < rowsBorder)
                    {
                        currentPositionRow++;
                    }
                    else
                    {
                        if (currentPositionCol > 0)
                        {
                            currentPositionCol--;
                        }
                        else
                        {
                            rowsBorder--;
                            currentPositionRow--;

                            while (currentPositionRow > rowsToRemoveFromTop)
                            {
                                i++;
                                output[i] = matrix[currentPositionRow, currentPositionCol];

                                currentPositionRow--;
                            }

                            colsBorder--;
                            rowsToRemoveFromTop++;
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(' ', output));
        }

        private static int[,] GetMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(' ')
                    .Select(n => int.Parse(n))
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            return matrix;
        }
    }
}
