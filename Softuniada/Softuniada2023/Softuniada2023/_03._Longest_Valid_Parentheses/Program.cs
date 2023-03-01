using System;

namespace _03._Longest_Valid_Parentheses
{
    //Най-дълга поредица от скоби
    //Даден е текст който е съвкупност от кръгли отворени скоби "(" и кръгли затворени скоби ")".
    //Всяка кръгла отворена скоба и последваща затворена кръгла скоба образуват валидна комбинация.
    //Намерете каква е дължината на най-дългата поредица от валидни комбинации.
    //
    //Вход
    //  От конзолата ще се въведе един ред:
    //  •	Текст който е съвкупност от кръгли скоби.
    //Изход
    //  Отпечатайте дължината на най-дългата поредица от валидни комбинации.
    //
    //Пример
    //Вход          Изход   Коментар
    //(()           2       Най-дългата поредица от валидни комбинации е: "()" и нейната дължина е 2 символа.
    //)()())        4	    Най-дългата поредица от валидни комбинации е: "()()" и нейната дължина е 4 символа.
    //()()()(       6	    Най-дългата поредица от валидни комбинации е: "()()()" и нейната дължина е 6 символа.
    //()(()()(()    4	    Налични са три поредици от валидни комбинации:
    //                      1. () -> 2 символа
    //                      2. ()() -> 4 символа
    //                      3. () -> 2 символа
    //                      Най-дългата поредица от валидни комбинации е: "()()" и нейната дължина е 4 символа.

    class Program
    {
        static void Main()
        {
            string brackets = Console.ReadLine();

            int longestSequence = 0;
            int currentSequence = 0;

            for (int i = 0; i < brackets.Length - 1; i++)
            {
                char currentSymbol = brackets[i];
                char nextSymbol = brackets[i + 1];

                if (currentSymbol == '(' && nextSymbol == ')')
                {
                    currentSequence += 2;

                    if (currentSequence > longestSequence)
                    {
                        longestSequence = currentSequence;
                    }

                    if (i < brackets.Length - 2)
                    {
                        i++;
                    }
                }
                else
                {
                    longestSequence = currentSequence;
                    currentSequence = 0;
                }
            }

            Console.WriteLine(longestSequence);
        }
    }
}
