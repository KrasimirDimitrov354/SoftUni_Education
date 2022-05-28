using System;

namespace WhileLoopMore
{
    class Program
    {
        static void Main(string[] args)
        {
            int soapBottles = int.Parse(Console.ReadLine());
            int soapTotal = soapBottles * 750;

            int dishesTotal = 0;
            int potsTotal = 0;
            int counter = 0;

            while (soapTotal >= 0)
            {
                string input = Console.ReadLine();

                if (input != "End")
                {
                    int tableware = int.Parse(input);
                    counter++;

                    if (counter != 3)
                    {
                        soapTotal -= tableware * 5;
                        dishesTotal += tableware;
                    }
                    else
                    {
                        soapTotal -= tableware * 15;
                        potsTotal += tableware;
                        counter = 0;
                    }
                }
                else
                {
                    break;
                }
            }

            if (soapTotal >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishesTotal} dishes and {potsTotal} pots were washed.");
                Console.WriteLine($"Leftover detergent {soapTotal} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(soapTotal)} ml. more necessary!");
            }
        }
    }
}
