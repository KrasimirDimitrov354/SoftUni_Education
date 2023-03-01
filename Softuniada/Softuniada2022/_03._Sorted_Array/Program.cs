using System;
using System.Linq;

namespace _03._Sorted_Array
{
    //Сортиране на масив
    //Даден е масив от цели числа. От конзолата ще получите броя и елементите на масива.
    //Сортирайте масива по следния начин:
    //  първи елемент >= втори елемент <= трети елемент >= четвърти елемент <= пети елемент ...
    //
    //Редът на получаване на елементите спрямо големината им трябва да се запазва.
    //
    //Вход
    //  От конзолата ще се въведат:
    //  •	на първи ред – брой на елементите на масива – цяло число в интервала [1…100].
    //  •	на втори ред – елементите на масива – цели числа, разделени с интервал.
    //Изход
    //  Отпечатайте елементите на сортирания масив, разделени с интервал.
    //
    //Пример
    //Вход                      Изход
    //5                         22 13 49 35 51
    //13 22 35 49 51
    //
    //Вход                      Изход
    //6                         40 22 87 76 123 91
    //22 40 76 87 91 123
    //
    //Вход                      Изход
    //7                         234 34 98 34 56 12 45
    //34 234 98 34 56 12 45
    //
    //Вход                      Изход
    //4                         2 1 5 3
    //1 2 3 5

    class Program
    {
        static void Main()
        {
            int arrayLength = int.Parse(Console.ReadLine());

            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToArray();

            for (int i = 0; i < arrayLength; i++)
            {
                int currentNum = array[i];

                if (i != arrayLength - 1)
                {
                    int nextNum = array[i + 1];

                    if (i == 0)
                    {
                        if (!LeftIsBigger(currentNum, nextNum))
                        {
                            int temp = currentNum;
                            array[i] = nextNum;
                            array[i + 1] = temp;
                        }
                    }
                    else
                    {
                        int previousNum = array[i - 1];

                        if (i % 2 != 0)
                        {
                            if (LeftIsBigger(previousNum, currentNum))
                            {
                                if (LeftIsBigger(currentNum, nextNum))
                                {
                                    int temp = currentNum;
                                    array[i] = nextNum;
                                    array[i + 1] = temp;
                                }
                            }
                            else
                            {
                                int temp = currentNum;
                                array[i] = previousNum;
                                array[i - 1] = currentNum;
                            }
                        }
                        else
                        {
                            if (!LeftIsBigger(previousNum, currentNum))
                            {
                                if (!LeftIsBigger(currentNum, nextNum))
                                {
                                    int temp = currentNum;
                                    array[i] = nextNum;
                                    array[i + 1] = temp;
                                }
                            }
                            else
                            {
                                int temp = currentNum;
                                array[i] = previousNum;
                                array[i - 1] = currentNum;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(' ', array));
        }

        private static bool LeftIsBigger(int numA, int numB)
        {
            if (numA >= numB)
            {
                return true;
            }

            return false;
        }
    }
}
