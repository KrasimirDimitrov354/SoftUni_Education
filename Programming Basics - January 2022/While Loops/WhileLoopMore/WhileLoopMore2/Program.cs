using System;

namespace WhileLoopMore2
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = int.Parse(Console.ReadLine());

            double cashTotal = 0;
            int paymentsCash = 0;
            double cardTotal = 0;
            int paymentsCard = 0;
            int fundsTotal = 0;

            int counter = 1;

            while (true)
            {
                string input = Console.ReadLine();

                if (input != "End")
                {
                    int payment = int.Parse(input);

                    if (counter == 1)
                    {
                        if (payment > 100)
                        {
                            Console.WriteLine("Error in transaction!");
                        }
                        else
                        {
                            Console.WriteLine("Product sold!");
                            cashTotal += payment;
                            paymentsCash++;
                            fundsTotal += payment;
                        }

                        counter++;
                    }
                    else
                    {
                        if (payment < 10)
                        {
                            Console.WriteLine("Error in transaction!");
                        }
                        else
                        {
                            Console.WriteLine("Product sold!");
                            cardTotal += payment;
                            paymentsCard++;
                            fundsTotal += payment;
                        }

                        counter--;
                    }

                    if (fundsTotal >= goal)
                    {
                        Console.WriteLine($"Average CS: {(cashTotal / paymentsCash):f2}");
                        Console.WriteLine($"Average CC: {(cardTotal / paymentsCard):f2}");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    break;
                }
            }
        }
    }
}
