using System;

namespace NestedLoopMore11
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double paymentDay = 0;
            double paymentTotal = 0;

            for (int i = 1; i <= days; i++)
            {
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        paymentDay += 2.5;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        paymentDay += 1.25;
                    }
                    else
                    {
                        paymentDay += 1;
                    }                  
                }

                Console.WriteLine($"Day: {i} - {paymentDay:f2} leva");
                paymentTotal += paymentDay;
                paymentDay = 0;
            }

            Console.WriteLine($"Total: {paymentTotal:f2} leva");
        }
    }
}
