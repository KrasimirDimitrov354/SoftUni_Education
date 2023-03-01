using System;

namespace _01._Sum_of_GCP_and_LCM
{
    //Сума на стойности
    //Да се напише програма която приема две числа N и М и намира сумата на техните НОД (най-голям общ делител) и НОК (най-малко общо кратно).
    //
    //Вход
    //  Входът се чете от конзолата и съдържа два реда:
    //  •	N - цяло число в интервала [1…1000].
    //  •	M - цяло число в интервала [1…1000].
    //Изход
    //  Да се отпечата на конзолата сумата на най-големия общ делител и най-малкото общо кратно на двете числа.
    //
    //Пример
    //Вход  Изход   Коментар
    //8     28      Всички делители на 8 са: 1, 2, 4, 8
    //12            Всички делители на 12 са: 1, 2, 3, 4, 6, 12
    //              НОД = 4
    //              Кратни на 8 са: 8, 16, 24, 32, ...
    //              Кратни на 12 са: 12, 24, 36, ...
    //              НОК = 24
    //              НОД + НОК = 28
    //
    //Вход  Изход   Коментар
    //18    182     Всички делители на 18 са: 1, 2, 3, 6, 9, 18
    //20            Всички делители на 20 са: 1, 2, 4, 5, 10, 20
    //              НОД = 2
    //              Кратни на 18 са: 18, 36, 54, 72, 90, 108, 126, 144, 162, 180, ...
    //              Кратни на 20 са: 20, 40, 60, 80, 100, 120, 140, 160, 180,...
    //              НОК = 180 
    //              НОД и НОК = 182
    //
    //Вход  Изход
    //15    45
    //30

    class Program
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int NOD = 1;
            int smallerNum = GetSmaller(firstNumber, secondNumber);

            if (smallerNum < 0)
            {
                for (int i = -1; i < smallerNum; i--)
                {
                    if (divisorIsValid(i, firstNumber, secondNumber))
                    {
                        NOD = i;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= smallerNum; i++)
                {
                    if (divisorIsValid(i, firstNumber, secondNumber))
                    {
                        NOD = i;
                    }
                }
            }

            int NOK = 0;
            int biggerNum = GetBigger(firstNumber, secondNumber);
            int multiplier = 1;

            while (true)
            {
                if (biggerNum * multiplier % smallerNum == 0 )
                {
                    NOK = biggerNum * multiplier;
                    break;
                }

                multiplier++;
            }

            Console.WriteLine(NOD + NOK);
        }

        private static int GetSmaller(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return secondNumber;
            }
            else
            {
                return firstNumber;
            }
        }

        private static int GetBigger(int firstNum, int secondNum)
        {
            if (firstNum > secondNum)
            {
                return firstNum;
            }
            else
            {
                return secondNum;
            }
        }

        private static bool divisorIsValid(int divisor, int firstNum, int secondNum)
        {
            if (firstNum % divisor == 0 && secondNum % divisor == 0)
            {
                return true;
            }

            return false;
        }
    }
}
