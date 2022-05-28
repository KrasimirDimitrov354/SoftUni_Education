using System;

namespace NestedLoopExer5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            bool hasRemainder = false;

            for (int i = 1111; i <= 9999; i++)
            {
                string number = i.ToString();

                for (int j = 0; j < 4; j++)
                {
                    int digit = int.Parse(number[j].ToString());
                    
                    if ((digit == 0) || (input % digit != 0))
                    {
                        hasRemainder = true;
                        break;
                    }
                }

                if (!hasRemainder)
                {
                    Console.Write($"{number} ");
                }

                hasRemainder = false;
            }
        }
    }
}
