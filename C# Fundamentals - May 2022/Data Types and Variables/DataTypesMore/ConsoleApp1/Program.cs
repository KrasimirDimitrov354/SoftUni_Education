using System;

namespace ConsoleApp1
{
    class Program
    {
        //1.	Data Type Finder
        //You will receive input until you receive "END". Find what data type is the input.
        //Possible data types are:
        //•	Integer
        //•	Floating point 
        //•	Characters
        //•	Boolean
        //•	Strings
        //Print the result in the following format: "{input} is {data type} type"
        //Examples
        //Input     Output                          Input   Output
        //5         5 is integer type               a       a is character type
        //2.5       2.5 is floating point type      asd     asd is string type
        //true      true is boolean type            -5      -5 is integer type
        //END                                       END

        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    bool isNumber = double.TryParse(input, out double number);

                    if (isNumber)
                    {
                        if (number % 1 == 0)
                        {
                            Console.WriteLine($"{input} is integer type");
                        }
                        else
                        {
                            Console.WriteLine($"{input} is floating point type");
                        }
                    }
                    else
                    {
                        if (input.Length == 1)
                        {
                            Console.WriteLine($"{input} is character type");
                        }
                        else if (input == "true" || input == "false")
                        {
                            Console.WriteLine($"{input} is boolean type");
                        }
                        else
                        {
                            Console.WriteLine($"{input} is string type");
                        }
                    }
                }
            }
        }
    }
}
