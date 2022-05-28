using System;

namespace ForStatExer6
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double actorScore = double.Parse(Console.ReadLine());
            int juryCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= juryCount; i++)
            {
                string juryName = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());

                double juryScore = 0;
                juryScore = (juryName.Length * juryPoints) / 2;

                actorScore += juryScore;

                if (actorScore >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {actorScore:f1}!");
                    break;
                }
            }

            if (actorScore < 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {(1250.5 - actorScore):f1} more!");
            }
        }
    }
}
