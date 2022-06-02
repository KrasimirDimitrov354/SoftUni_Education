using System;

namespace ConsoleApp8
{
    class Program
    {
        //Condense Array to Number
        //Create a program to read an array of integers and condense them by summing all adjacent couples of elements until a single integer remains.
        //For example, let us say we have 3 elements - {2, 10, 3}. We sum the first two and the second two elements and get {2 + 10, 10 + 3} = { 12, 13 }.
        //Then we sum all adjacent elements again. This results in {12 + 13} = {25}.
        //Examples
        //Input	        Output	Comments
        //2 10 3	    25	    2 10 3 -> 2+10 10+3 -> 12 13 -> 12+13 -> 25
        //Input	        Output	Comments
        //5 0 4 1 2	    35	    5 0 4 1 2 -> 5+0 0+4 4+1 1+2 -> 5 4 5 3 -> 5+4 4+5 5+3 -> 9 9 8 -> 9+9 9+8 -> 18 17 -> 18+17 -> 35
        //Input	        Output	Comments
        //1	            1	    1 is already condensed to number

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];
            int[] condensed = new int[numbers.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            if (condensed.Length == 1)
            {
                condensed[0] = numbers[0];
            }
            else
            {
                while (condensed.Length > 1)
                {
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (k != numbers.Length - 1)
                        {
                            condensed[k] = numbers[k] + numbers[k + 1];
                        }
                    }

                    if (numbers.Length > 1)
                    {
                        Array.Resize(ref numbers, numbers.Length - 1);

                        if (condensed.Length > 1)
                        {
                            Array.Resize(ref condensed, condensed.Length - 1);
                            Array.Copy(condensed, numbers, condensed.Length);
                        }
                    }
                }
            }
            
            Console.WriteLine(condensed[0]);
        }
    }
}
