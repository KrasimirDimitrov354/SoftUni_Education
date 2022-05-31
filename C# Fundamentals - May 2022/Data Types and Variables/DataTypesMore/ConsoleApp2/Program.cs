using System;

namespace ConsoleApp2
{
    class Program
    {
        //2.        From Left to the Right
        //You will receive a number that represents how many lines we will get as input.
        //On the next N lines, you will receive a string with 2 numbers separated by a single space. You need to compare them.
        //If the left number is greater than the right number, you need to print the sum of all digits in the left number.
        //Otherwise, print the sum of all digits in the right number.
        //Examples
        //Input         Output  Input                   Output
        //2             2       4                       46
        //1000 2000     2       123456 2147483647       5
        //2000 1000	            5000000 -500000         49
        //                      97766554 97766554       90
        //                      9999999999 8888888888

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');

                decimal num1 = decimal.Parse(numbers[0]);
                decimal num2 = decimal.Parse(numbers[1]);

                if (num1 > num2)
                {
                    for (int j = 0; j < numbers[0].Length; j++)
                    {
                        string currentSymbol = numbers[0][j].ToString();
                        bool isNumber = int.TryParse(currentSymbol, out int digit);

                        if (isNumber)
                        {
                            sum += digit;
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < numbers[1].Length; k++)
                    {
                        string currentSymbol = numbers[1][k].ToString();
                        bool isNumber = int.TryParse(currentSymbol, out int digit);

                        if (isNumber)
                        {
                            sum += digit;
                        }
                    }
                }

                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
