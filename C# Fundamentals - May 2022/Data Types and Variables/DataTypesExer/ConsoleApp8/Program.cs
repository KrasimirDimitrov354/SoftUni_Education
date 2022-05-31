using System;

namespace ConsoleApp8
{
    class Program
    {
        //8.	Beer Kegs
        //Create a program, which calculates the volume of n beer kegs. You will receive in total 3 * n lines.
        //Every three lines will hold information for a single keg.
        //First up is the model of the keg, after that is the radius of the keg, and lastly is the height of the keg.
        //Calculate the volume using the following formula: π * r^2 * h.
        //In the end, print the model of the biggest keg.
        //Input
        //You will receive 3 * n lines. Each group of lines will be on a new line:
        //•	First – model – string.
        //•	Second – radius – floating-point number
        //•	Third – height – integer number
        //Output
        //Print the model of the biggest keg.
        //Constraints
        //•	n will be in the interval [1…10]
        //•	The radius will be a floating-point number in the interval [1…3.402823E+38]
        //•	The height will be an integer in the interval [1…2147483647]
        //Examples
        //Input     Output      Input           Output
        //3         Keg 2       2               Bigger Keg
        //Keg 1                 Smaller Keg
        //10                    2.41
        //10                    10
        //Keg 2                 Bigger Keg
        //20                    5.12
        //20                    20
        //Keg 3
        //10
        //30 


        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string modelCurrent = "";
            string modelBiggest = "";

            double radius = 0.0;
            int height = 0;
            double volumeCurrent = 0.0;
            double volumeBiggest = 0.0;
            byte counter = 1;

            for (int i = 1; i <= n * 3; i++)
            {
                string input = Console.ReadLine();
                bool isNumber = double.TryParse(input, out double number);

                if (isNumber)
                {
                    switch (counter)
                    {
                        case 1:
                            radius = number;
                            counter++;
                            break;
                        case 2:
                            height = (int)number;
                            volumeCurrent = Math.PI * (Math.Pow(radius, 2)) * height;

                            if (volumeCurrent > volumeBiggest)
                            {
                                volumeBiggest = volumeCurrent;
                                modelBiggest = modelCurrent;
                            }
                            counter--;
                            break;
                    }
                }
                else
                {
                    modelCurrent = input;
                }
            }

            Console.WriteLine(modelBiggest);
        }
    }
}
