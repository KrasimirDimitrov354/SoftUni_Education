using System;

namespace ConsoleApp10
{
    class Program
    {
        //Top Number
        //A top number is an integer that holds the following properties:
        //  •	Its sum of digits is divisible by 8, e.g. 8, 17, 88
        //  •	Holds at least one odd digit, e.g. 232, 707, 87578
        //Some examples of top numbers are: 17, 161, 251, 4310, 123200.
        //
        //Create a program to print all top numbers in the range[1…n].
        //You will receive a single integer from the console, representing the end value.
        //
        //Examples:
        //Input     Output  Input   Output
        //50	    17      100     17
        //          35		        35
        //                          53
        //                          71
        //                          79
        //                          97

        private static bool IsDivisibleBy8(int num)
        {
            bool result = false;

            if (num % 8 == 0)
            {
                result = true;
            }

            return result;
        }

        private static bool HasOdd(string num)
        {
            bool result = false;

            for (int i = 0; i < num.Length; i++)
            {
                if (int.Parse(num[i].ToString()) % 2 != 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static void FindTops(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                string currentNum = i.ToString();
                int currentSum = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDigit = int.Parse(currentNum[j].ToString());
                    currentSum += currentDigit;
                }

                if (IsDivisibleBy8(currentSum) && HasOdd(currentNum))
                {
                    Console.WriteLine(currentNum);
                }
            }
        }

        static void Main()
        {
            int endValue = int.Parse(Console.ReadLine());
            FindTops(endValue);
        }
    }
}
