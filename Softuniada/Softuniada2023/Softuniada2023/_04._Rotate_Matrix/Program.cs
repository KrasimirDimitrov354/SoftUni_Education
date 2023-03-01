using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Rotate_Matrix
{
    //Завърти матрицата
    //Дадена е квадратна матрица (N x N) от цели числа с N на брой редове и колони. Матрицата ще се въвежда от конзолата.
    //Задачате е матрицата да се завърти на 90 градуса по часовниковата стрелка.
    //
    //Вход
    //  От конзолата ще се въведат:
    //  •	на първия ред – брой редове и колони на матрицата – цяло число в интервала [1…100].
    //  •	на следващите редове – елементите на матрицата, разделени с интервал – цели числа в интервала [1…1000].
    //Изход
    //  Отпечатайте матрицата след завъртането на 90 градуса по часовниковата стрелка.
    //
    //Пример
    //Вход
    //  3
    //  3 11 7
    //  14 6 9
    //  10 5 2
    //Изход
    //  10 14 3
    //  5 6 11
    //  2 9 7
    //
    //Вход
    //  4
    //  1 2 3 4
    //  5 6 7 8
    //  9 10 11 12
    //  13 14 15 16
    //Изход
    //  13 9 5 1
    //  14 10 6 2
    //  15 11 7 3
    //  16 12 8 4
    //
    //Вход
    //  5
    //  1 3 4 5 6
    //  7 9 2 12 45
    //  98 56 34 23 65
    //  34 54 99 86 43
    //  12 23 45 67 89
    //Изход
    //  12 34 98 7 1
    //  23 54 56 9 3
    //  45 99 34 2 4
    //  67 86 23 12 5
    //  89 43 65 45 6

    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            Dictionary<int, int[]> rowsOfNumbers = new Dictionary<int, int[]>();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < matrixSize; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ')
                    .Select(n => int.Parse(n))
                    .ToArray();

                rowsOfNumbers.Add(i, currentRow);
            }

            for (int numberPosition = 0; numberPosition < matrixSize; numberPosition++)
            {
                for (int rowPosition = matrixSize - 1; rowPosition >= 0; rowPosition--)
                {
                    output.Append(rowsOfNumbers[rowPosition][numberPosition]);

                    if (rowPosition != 0)
                    {
                        output.Append(' ');
                    }
                }

                output.AppendLine();
            }

            Console.WriteLine(output);
        }
    }
}
