using System;

namespace ForStatExerMore6
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthsCount = int.Parse(Console.ReadLine());

            double totalBills = 0;
            double totalElectricity = 0;
            double totalWater = 0;
            double totalInternet = 0;
            double totalOther = 0;

            for (int i = 1; i <= monthsCount; i++)
            {
                double electricityBill = double.Parse(Console.ReadLine());

                totalElectricity += electricityBill;
                totalWater += 20;
                totalInternet += 15;
                totalOther += (20 + 15 + electricityBill) + ((20 + 15 + electricityBill) * 0.2);
                totalBills += (electricityBill + 20 + 15) +
                    ((20 + 15 + electricityBill) + ((20 + 15 + electricityBill) * 0.2));
            }

            Console.WriteLine($"Electricity: {totalElectricity:f2} lv");
            Console.WriteLine($"Water: {totalWater:f2} lv");
            Console.WriteLine($"Internet: {totalInternet:f2} lv");
            Console.WriteLine($"Other: {totalOther:f2} lv");
            Console.WriteLine($"Average: {(totalBills / monthsCount):f2} lv");
        }
    }
}
