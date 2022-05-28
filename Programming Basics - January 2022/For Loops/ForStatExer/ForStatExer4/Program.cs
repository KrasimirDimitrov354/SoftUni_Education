using System;

namespace ForStatExer4
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalBirthdays = int.Parse(Console.ReadLine());
            double machinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int evenBirthdays = 0;
            int oddbirthdays = 0;
            int giftMoney = 0;
            int toyMoney = 0;
            double totalMoney = 0;

            for (int i = 1; i <= totalBirthdays; i++)
            {
                double currentBirthday = i;

                if (currentBirthday % 2 == 0)
                {
                    evenBirthdays++;
                }
                else
                {
                    oddbirthdays++;
                }
            }

            for (int j = 1; j <= evenBirthdays; j++)
            {
                giftMoney += (j * 10) - 1;
            }

            toyMoney = toyPrice * oddbirthdays;
            totalMoney = giftMoney + toyMoney;

            if (totalMoney >= machinePrice)
            {
                Console.WriteLine($"Yes! {(totalMoney - machinePrice):f2}");
            }
            else
            {
                Console.WriteLine($"No! {(machinePrice - totalMoney):f2}");
            }

        }
    }
}
