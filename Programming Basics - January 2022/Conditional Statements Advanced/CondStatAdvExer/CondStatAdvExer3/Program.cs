using System;

namespace CondStatAdvExer3
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowersPrice = 0.0;
            double rosesPrice = 5;
            double dahliasPrice = 3.8;
            double tulipsPrice = 2.8;
            double narcissusPrice = 3;
            double gladiolusPrice = 2.5;

            switch (flowersType)
            {
                case "Roses":
                    flowersPrice = flowersCount * rosesPrice;

                    if (flowersCount > 80)
                    {
                        flowersPrice = flowersPrice - (flowersPrice * 0.1);
                    }
                    break;
                case "Dahlias":
                    flowersPrice = flowersCount * dahliasPrice;

                    if (flowersCount > 90)
                    {
                        flowersPrice = flowersPrice - (flowersPrice * 0.15);
                    }
                    break;
                case "Tulips":
                    flowersPrice = flowersCount * tulipsPrice;

                    if (flowersCount > 80)
                    {
                        flowersPrice = flowersPrice - (flowersPrice * 0.15);
                    }
                    break;
                case "Narcissus":
                    flowersPrice = flowersCount * narcissusPrice;

                    if (flowersCount < 120)
                    {
                        flowersPrice = flowersPrice + (flowersPrice * 0.15);
                    }
                    break;
                case "Gladiolus":
                    flowersPrice = flowersCount * gladiolusPrice;

                    if (flowersCount < 80)
                    {
                        flowersPrice = flowersPrice + (flowersPrice * 0.20);
                    }
                    break;
            }

            if (budget >= flowersPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowersType} and {(budget - flowersPrice):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(flowersPrice - budget):f2} leva more.");
            }
        }
    }
}
