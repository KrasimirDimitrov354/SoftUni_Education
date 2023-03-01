using System;

namespace ClassBoxData
{
    //Class Box Data
    //Create a class Box with the following properties:
    //  •	Length - double, should not be zero or negative number.
    //  •	Width - double, should not be zero or negative number.
    //  •	Height - double, should not be zero or negative number.
    //
    //If one of the properties is a zero or negative number, throw ArgumentException with the message: "{propertyName} cannot be zero or negative."
    //Use try-catch block to process the error. All properties are set by the constructor and cannot be modified once set.
    //
    //Behavior
    //  •	double SurfaceArea() - Calculate and return the surface area of the Box.
    //  •	double LateralSurfaceArea() - Calculate and return the lateral surface area of the Box.
    // •	double Volume() - Calculate and return the volume of the Box.
    //
    //Input
    //  •	On the first three lines you will get the length, width, and height. 
    //Output
    //  •	On the next three lines, print the surface area, lateral surface area, and the volume of the box.
    //Examples
    //Input     Output
    //2         Surface Area - 52.00
    //3         Lateral Surface Area - 40.00
    //4         Volume - 24.00
    //
    //Input     Output
    //1.3       Surface Area - 30.20
    //1         Lateral Surface Area - 27.60
    //6         Volume - 7.80
    //
    //Input     Output
    //2         Width cannot be zero or negative.
    //-3
    //4

    public class Program
    {
        static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine(box.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
