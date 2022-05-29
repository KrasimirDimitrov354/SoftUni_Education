using System;

namespace ConsoleApp4
{
    class Program
    {
        //4.	Sum of Chars
        //Create a program, which sums the ASCII codes of n characters and prints the sum on the console.
        //Input
        //•	On the first line, you will receive n – the number of lines, which will follow
        //•	On the next n lines – you will receive letters from the Latin alphabet
        //Output
        //Print the total sum in the following format:
        //"The sum equals: {totalSum}"
        //Constraints
        //•	n will be in the interval [1…20].
        //•	The characters will always be either upper or lower-case letters from the English alphabet
        //•	You will always receive one letter per line
        //Examples
        //Input     Output 
        //5         The sum equals: 399
        //A
        //b
        //C
        //d
        //E 		
        //Input     Output
        //12        The sum equals: 1263
        //S
        //o
        //f
        //t
        //U
        //n
        //i
        //R
        //u
        //l
        //z
        //z   

        static void Main()
        {
            int charactersCount = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= charactersCount; i++)
            {
                int character = (int)char.Parse(Console.ReadLine());
                sum += character;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
