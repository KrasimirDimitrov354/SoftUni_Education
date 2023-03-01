using System;
using System.Text;

namespace _02._Coffee_Cups
{
    //Чаши за кафе
    //Да се напише програма която чертае чаша с кафе с надпис както примерите по-долу.
    //Чашата е с ширина: 3 * n + 6 и височина: 3 * n + 1, където n е цяло число прочетено от конзолата.
    //
    //Вход
    //  Входът се чете от конзолата и съдържа два реда:
    //  •	n - цяло число в интервала [3…27].
    //  •	надпис на чашата - текст.
    //Изход
    //  Да се отпечата на конзолата чашата кафе с надпис, точно както в примерите.
    //
    //Пример
    //Вход
    //  3
    //  Java
    //Изход
    //     ~ ~ ~
    //     ~ ~ ~
    //     ~ ~ ~
    //  ==============
    //  |~~~JAVA~~~|  |
    //  ==============
    //  \@@@@@@@@@@/
    //   \@@@@@@@@/
    //    \@@@@@@/
    //  --------------
    //Вход
    //  5
    //  Desi
    //Изход
    //       ~ ~ ~
    //       ~ ~ ~
    //       ~ ~ ~
    //       ~ ~ ~
    //       ~ ~ ~
    //  ====================
    //  |~~~~~~~~~~~~~~|    |
    //  |~~~~~DESI~~~~~|    |
    //  |~~~~~~~~~~~~~~|    |
    //  ====================
    //  \@@@@@@@@@@@@@@/
    //   \@@@@@@@@@@@@/
    //    \@@@@@@@@@@/
    //     \@@@@@@@@/
    //      \@@@@@@/
    //  --------------------
    //Вход
    //  8
    //  Vili
    //Изход
    //          ~ ~ ~
    //          ~ ~ ~
    //          ~ ~ ~
    //          ~ ~ ~
    //          ~ ~ ~
    //          ~ ~ ~
    //          ~ ~ ~
    //          ~ ~ ~
    //  =============================
    //  |~~~~~~~~~~~~~~~~~~~~|       |
    //  |~~~~~~~~~~~~~~~~~~~~|       |
    //  |~~~~~~~~~~~~~~~~~~~~|       |
    //  |~~~~~~~~VILI~~~~~~~~|       |
    //  |~~~~~~~~~~~~~~~~~~~~|       |
    //  |~~~~~~~~~~~~~~~~~~~~|       |
    //  =============================
    //  \@@@@@@@@@@@@@@@@@@@@/
    //   \@@@@@@@@@@@@@@@@@@/
    //    \@@@@@@@@@@@@@@@@/
    //     \@@@@@@@@@@@@@@/
    //      \@@@@@@@@@@@@/
    //       \@@@@@@@@@@/
    //        \@@@@@@@@/
    //         \@@@@@@/
    //  -----------------------------

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();

            StringBuilder cup = new StringBuilder();
            int cupWidth = 3 * n + 6;

            for (int steamRow = 0; steamRow < n; steamRow++)
            {
                cup.Append(' ', n);
                cup.Append("~ ~ ~");
                cup.Append(' ', n);
                cup.AppendLine();
            }

            for (int coffeeRow = 0; coffeeRow < n; coffeeRow++)
            {
                if (coffeeRow == 0 || coffeeRow == n - 1)
                {
                    cup.Append('=', cupWidth - 1);
                }
                else
                {
                    cup.Append('|');
                    cup.Append('~', n);

                    if (coffeeRow == n / 2)
                    {
                        cup.Append(name.ToUpper());
                    }
                    else
                    {
                        cup.Append('~', 4);
                    }

                    cup.Append('~', n);
                    cup.Append('|');
                    cup.Append(' ', n - 1);
                    cup.Append('|');
                }

                cup.AppendLine();
            }

            int emptySpaceFront = 0;
            int emptySpaceBack = n;
            int baseWidth = cupWidth - (n + 2);

            for (int cupRow = 0; cupRow < n; cupRow++)
            {
                cup.Append(' ', emptySpaceFront);
                cup.Append('\\');
                cup.Append('@', baseWidth);
                cup.Append('/');
                cup.Append(' ', emptySpaceBack);

                emptySpaceFront++;
                emptySpaceBack++;
                baseWidth -= 2;

                cup.AppendLine();
            }

            cup.Append('-', cupWidth - 1);
            Console.WriteLine(cup);
        }
    }
}
