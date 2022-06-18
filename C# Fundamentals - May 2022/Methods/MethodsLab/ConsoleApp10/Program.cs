using System;

namespace ConsoleApp10
{
    class Program
    {
        //Multiply Evens by Odds
        //Create a program that multiplies the sum of all even digits of a number by the sum of all odd digits of the same number:
        //  •	Create a method called GetMultipleOfEvenAndOdds()
        //  •	Create a method GetSumOfEvenDigits()
        //  •	Create GetSumOfOddDigits()
        //  •	You may need to use Math.Abs() for negative numbers
        //Examples
        //Input     Output  Comment
        //-12345	54	    Evens: 2 4
        //                  Odds: 1 3 5
        //                  Even sum: 6
        //                  Odd sum: 9
        //                  6 * 9 = 54
        //Input     Output
        //3453466	220	

        private static int[][] GetAllOddAndEven(int input)
        {
            int[][] oddAndEven = new int[2][];

            if (input < 0)
            {
                input = Math.Abs(input);
            }

            string convertedInput = input.ToString();
            byte counterOdd = 0;
            byte counterEven = 0;

            for (int i = 0; i < convertedInput.Length; i++)
            {
                int currentDigit = int.Parse(convertedInput[i].ToString());

                if (currentDigit % 2 != 0)
                {
                    counterOdd++;
                    Array.Resize<int>(ref oddAndEven[0], counterOdd);
                    oddAndEven[0][counterOdd - 1] = currentDigit;                  
                }
                else
                {
                    counterEven++;
                    Array.Resize<int>(ref oddAndEven[1], counterEven);
                    oddAndEven[1][counterEven - 1] = currentDigit;                    
                }
            }

            return oddAndEven;
        }

        private static int MultiplyOddAndEven(int[] odd, int[] even)
        {
            int oddResult = 0;
            int evenResult = 0;

            if (odd != null)
            {
                foreach (var number in odd)
                {
                    oddResult += number;
                }
            }

            if (even != null)
            {
                foreach (var number in even)
                {
                    evenResult += number;
                }
            }           

            return oddResult * evenResult;
        }

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[][] oddAndEven = GetAllOddAndEven(number);
            int result = MultiplyOddAndEven(oddAndEven[0], oddAndEven[1]);

            Console.WriteLine(result);
        }
    }
}
