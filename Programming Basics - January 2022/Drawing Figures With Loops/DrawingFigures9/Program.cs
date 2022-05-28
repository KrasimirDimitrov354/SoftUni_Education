using System;

namespace DrawingFigures9
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int roof = (input + 1) / 2;
            int roofTilesCounter = 0;
            int roofStarsCounter = 0;
            int house = 0;
            int houseStarsCounter = input - 2;

            if (input % 2 == 0)
            {
                roofStarsCounter = 2;
                house = input / 2;

                if (input != 2)
                {
                    roofTilesCounter = (input - 2) / 2;
                }               
            }
            else
            {
                roofStarsCounter = 1;
                roofTilesCounter = (input - 1) / 2;
                house = ((input + 1) / 2) - 1;
            }

            string roofStars = new String('*', roofStarsCounter);
            string roofTiles = new String('-', roofTilesCounter);
            string houseStars = new String('*', houseStarsCounter);

            for (int i = 1; i <= roof; i++)
            {
                if (roofTilesCounter > 0)
                {
                    Console.Write(roofTiles);
                    Console.Write(roofStars);
                    Console.WriteLine(roofTiles);
                }
                else
                {
                    Console.WriteLine(roofStars);
                }

                roofStars += "**";
                roofTilesCounter--;

                if (roofTilesCounter > -1)
                {
                    roofTiles = roofTiles.Substring(0, roofTilesCounter);
                }
            }

            for (int j = 1; j <= house; j++)
            {
                Console.Write("|");
                Console.Write(houseStars);
                Console.WriteLine("|");
            }
        }
    }
}
