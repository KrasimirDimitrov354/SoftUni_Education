using System;

namespace ExperienceGaining
{
    class Program
    {
        //Output:
        //The possible outputs are:
        //  •	"Player successfully collected his needed experience for {battleCount} battles."
        //  •	"Player was not able to collect the needed experience, {neededExperience} more needed."
        //Examples
        //Input     Output                                                                  Comments
        //500       Player successfully collected his needed experience for 5 battles.      The first line is the amount of the wanted experience – "500"
        //5                                                                                 The second line is the expected battles for which he has to collect the experience – "5"
        //50                                                                                After that is the experience received for every battle:
        //100                                                                               50 + 100 + (200 + (200 * 15 %)) + 100 + (30 – (30 * 10 %)) = 507
        //200                                                                               Output is printed on the console.
        //100
        //30
        //
        //Input     Output
        //500       Player was not able to collect the needed experience, 2.00 more needed.
        //5
        //50
        //100
        //200
        //100
        //20
        //Input     Output
        //400       Player successfully collected his needed experience for 4 battles.
        //5
        //50
        //100
        //200
        //100
        //20


        static void Main()
        {
            decimal expTarget = decimal.Parse(Console.ReadLine());
            int battles = int.Parse(Console.ReadLine());

            decimal expAcquired = 0;

            for (int i = 1; i <= battles; i++)
            {
                decimal experience = decimal.Parse(Console.ReadLine());

                if (i % 15 == 0)
                {
                    expAcquired += experience + (experience * 0.05m);
                }
                else if (i % 5 == 0)
                {
                    expAcquired += experience - (experience * 0.1m);
                }
                else if (i % 3 == 0)
                {
                    expAcquired += experience + (experience * 0.15m);
                }
                else
                {
                    expAcquired += experience;
                }

                if (expAcquired >= expTarget)
                {
                    battles = i;
                    break;
                }
            }

            if (expAcquired >= expTarget)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battles} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {expTarget - expAcquired:f2} more needed.");
            }
        }
    }
}
