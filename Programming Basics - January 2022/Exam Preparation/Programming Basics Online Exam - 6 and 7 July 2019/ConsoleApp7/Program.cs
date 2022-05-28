using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            int sales = int.Parse(Console.ReadLine());

            int countHeartstone = 0;
            int countFornite = 0;
            int countOverwatch = 0;
            int countOthers = 0;
            int counter = 1;

            while (counter <= sales)
            {
                string game = Console.ReadLine();

                switch (game)
                {
                    case "Hearthstone":
                        countHeartstone++;
                        break;
                    case "Fornite":
                        countFornite++;
                        break;
                    case "Overwatch":
                        countOverwatch++;
                        break;
                    default:
                        countOthers++;
                        break;
                }

                counter++;
            }

            Console.WriteLine($"Hearthstone - {(((countHeartstone * 1.0) / sales ) * 100):f2}%");
            Console.WriteLine($"Fornite - {(((countFornite * 1.0) / sales ) * 100):f2}%");
            Console.WriteLine($"Overwatch - {(((countOverwatch * 1.0) / sales ) * 100):f2}%");
            Console.WriteLine($"Others - {(((countOthers * 1.0) / sales ) * 100):f2}%");
        }
    }
}
