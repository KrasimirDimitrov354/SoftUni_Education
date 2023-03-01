using System;
using System.Collections.Generic;

namespace _01._Row_in__Pascal_s_Triangle
{
    //Ред в триъгълник на Паскал
    //Да се напише програма която получава цяло число N и отпечатва (N + 1)-вия ред в триъгълника на Паскал.
    //
    //Вход
    //  Входът се чете от конзолата и съдържа един ред:
    //  •	N - цяло число в интервала [1…50].
    //Изход
    //  Да се отпечатат на конзолата числата от (N + 1)-вия ред в триъгълника на Паскал, разделени с интервал.
    //
    //Пример
    //Вход  Изход       Вход  Изход             Вход    Изход                   Вход    Изход
    //3     1 3 3 1     5     1 5 10 10 5 1     7       1 7 21 35 35 21 7 1     9       1 9 36 84 126 126 84 36 9 1
    //
    //Вход  Изход
    //14    1 14 91 364 1001 2002 3003 3432 3003 2002 1001 364 91 14 1
    //
    //Вход  Изход
    //22    1 22 231 1540 7315 26334 74613 170544 319770 497420 646646 705432 646646 497420 319770 170544 74613 26334 7315 1540 231 22 1

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> previousRow = new List<int>();

            for (int i = 0; i < n + 1; i++)
            {
                int[] currentRow = new int[i + 1];

                if (i == 0)
                {
                    currentRow[0] = 1;
                    previousRow = new List<int>(currentRow);
                }
                else
                {
                    int numLeft = 0;

                    for (int j = 0; j < currentRow.Length; j++)
                    {
                        if (j != 0 && j < previousRow.Count)
                        {
                            numLeft = previousRow[j - 1];
                            currentRow[j] = numLeft + previousRow[j];
                        }
                        else
                        {
                            currentRow[j] = 1;
                        }
                    }

                    previousRow = new List<int>(currentRow);
                }
            }

            Console.WriteLine(String.Join(' ', previousRow));
        }
    }
}
