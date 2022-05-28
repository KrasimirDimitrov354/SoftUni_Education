using System;

namespace ConsoleApp5
{
    class Program
    {
        //5.	Messages
        //Create a program, which emulates typing an SMS, following this guide:
        //1	    2   3
        //     abc def
        // 4    5   6
        //ghi  jkl mno
        // 7    8   9
        //pqrs tuv wxyz
        //	    0
        //    space
        //Following the guide, 2 becomes “a”, 22 becomes “b” and so on.
        //Examples
        //Input     Output
        //5         hello
        //44
        //33
        //555
        //555
        //666	    		
        //Input     Output
        //9        hey there
        //44
        //33
        //999
        //0
        //8
        //44
        //33
        //777
        //33	    
        //Input     Output
        //7         meet me
        //6
        //33
        //33
        //8
        //0
        //6
        //33	    

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                int button = (int)char.GetNumericValue(input[0]);
                int symbolButton = 0;
                int symbolASCII = 0;

                if (button == 0)
                {
                    message += " ";
                }
                else
                {
                    if (button == 8 || button == 9)
                    {
                        symbolButton = 1 + (button - 2) * 3;
                    }
                    else
                    {
                        symbolButton = (button - 2) * 3;
                    }

                    symbolASCII = (symbolButton + input.Length - 1) + 97;
                    message += (char)symbolASCII;
                }
            }

            Console.WriteLine(message);
        }
    }
}
