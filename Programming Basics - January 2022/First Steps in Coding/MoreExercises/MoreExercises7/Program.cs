using System;

namespace MoreExercises7
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double roofHeight = double.Parse(Console.ReadLine());

            double priceGreen = 3.4;
            double priceRed = 4.3;
            double areaDoor = 1.2 * 2;
            double areaWindow = 1.5 * 1.5;

            double houseSide = ((height * width) * 2) - (areaWindow * 2);
            double houseFrontBack = ((height * height) * 2) - areaDoor;
            double areaHouse = houseSide + houseFrontBack;
            double paintHouse = areaHouse / priceGreen;

            double roofSide = (height * width) * 2;
            double roofFrontBack = (((height * roofHeight) / 2) * 2);
            double areaRoof = roofSide + roofFrontBack;
            double paintRoof = areaRoof / priceRed;

            Console.WriteLine(paintHouse.ToString("0.00"));
            Console.WriteLine(paintRoof.ToString("0.00"));
        }
    }
}
