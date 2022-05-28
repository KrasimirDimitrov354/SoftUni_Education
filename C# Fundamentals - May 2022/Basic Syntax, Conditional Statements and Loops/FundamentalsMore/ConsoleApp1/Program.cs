using System;

namespace ConsoleApp1
{
    class Program
    {
        //1.	Sort Numbers
        // Create a program that receives three real numbers and sorts them in descending order. Print each number on a new line.
        //Examples
        //Input     Output
        //2         3
        //1         2
        //3         1
        //Input     Output                  
        //-2        3
        //1         1
        //3	        -2
        //Input     Output  
        //0         2
        //0         0
        //2         0

        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (num1 >= num2)
            {
                if (num1 >= num3)
                {
                    Console.WriteLine(num1);

                    if (num3 >= num2)
                    {
                        Console.WriteLine(num3);
                        Console.WriteLine(num2);
                    }
                    else
                    {
                        Console.WriteLine(num2);
                        Console.WriteLine(num3);
                    }
                }
                else
                {
                    Console.WriteLine(num3);
                    Console.WriteLine(num1);
                    Console.WriteLine(num2);
                }
            }
            else
            {
                if (num2 >= num3)
                {
                    Console.WriteLine(num2);

                    if (num3 >= num1)
                    {
                        Console.WriteLine(num3);
                        Console.WriteLine(num1);
                    }
                    else
                    {
                        Console.WriteLine(num1);
                        Console.WriteLine(num3);
                    }
                }
                else
                {
                    Console.WriteLine(num3);
                    Console.WriteLine(num2);
                    Console.WriteLine(num1);
                }
            }
        }
    }
}
