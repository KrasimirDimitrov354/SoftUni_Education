using System;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelName = Console.ReadLine();
            double fuelAmount = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();

            double priceGasoline = 2.22;
            double priceDiesel = 2.33;
            double priceGas = 0.93;
            double priceFinal = 0;

            if (clubCard == "Yes")
            {
                priceGasoline = priceGasoline - 0.18;
                priceDiesel = priceDiesel - 0.12;
                priceGas = priceGas - 0.08;
            }

            if (fuelName == "Gasoline")
            {
                priceFinal = fuelAmount * priceGasoline;
            }
            else if (fuelName == "Diesel")
            {
                priceFinal = fuelAmount * priceDiesel;
            }
            else
            {
                priceFinal = fuelAmount * priceGas;
            }

            if (fuelAmount > 25)
            {
                priceFinal = priceFinal - (priceFinal * 0.1);
            }
            else if (fuelAmount >= 20 & fuelAmount <= 25)
            {
                priceFinal = priceFinal - (priceFinal * 0.08);
            }

            Console.WriteLine($"{priceFinal:f2} lv.");
        }
    }
}
