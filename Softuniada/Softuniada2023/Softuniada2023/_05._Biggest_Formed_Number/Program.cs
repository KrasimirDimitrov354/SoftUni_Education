using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Biggest_Formed_Number
{
    //Най-голямото образувано число - 90/100
    //Ще получите ред с цели положителни числа. Намерете кое е най-голямото число което може да се образува използвайки и размествайки подадените числа.
    //
    //Вход
    //  От конзолата ще се въведат цели числа разделени с интервал.
    //Изход
    //  Най-голямото образувано число получено чрез разместване на подадените числа.
    //
    //Пример
    //Вход          Изход
    //3 30 34 5 9   9534330
    //1 3 4 5 3 2   543321
    //9 5 6 4 3 2   965432

    class Program
    {
        static void Main()
        {
            List<string> nums = Console.ReadLine().Split(' ').ToList();

            StringBuilder output = new StringBuilder();
            int digitsCount = nums.Max(n => n.Length);

            for (int digitPosition = 0; digitPosition < digitsCount; digitPosition++)
            {
                nums = nums.OrderByDescending(n => n[digitPosition]).ToList();

                foreach (var num in nums)
                {
                    if (num.Length == digitPosition + 1)
                    {
                        output.Append(num);
                    }
                }

                nums.RemoveAll(n => n.Length == digitPosition + 1);
            }

            Console.WriteLine(output);
        }
    }
}
