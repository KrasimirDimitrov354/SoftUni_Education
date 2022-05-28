using System;

namespace ForStatExerMore5
{
    class Program
    {
        static void Main(string[] args)
        {
            int roundsCount = int.Parse(Console.ReadLine());

            double totalScore = 0;
            double from0To9 = 0;
            double from10To19 = 0;
            double from20To29 = 0;
            double from30To39 = 0;
            double from40To50 = 0;
            double invalidNumbers = 0;

            for (int i = 1; i <= roundsCount; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input >= 0 && input <= 9)
                {
                    totalScore += input * 0.2;
                    from0To9++;
                }
                else if (input >= 10 && input <= 19)
                {
                    totalScore += input * 0.3;
                    from10To19++;
                }
                else if (input >= 20 && input <= 29)
                {
                    totalScore += input * 0.4;
                    from20To29++;
                }
                else if (input >= 30 && input <= 39)
                {
                    totalScore += 50;
                    from30To39++;
                }
                else if (input >= 40 && input <= 50)
                {
                    totalScore += 100;
                    from40To50++;
                }
                else
                {
                    totalScore /= 2;
                    invalidNumbers++;
                }
            }

            Console.WriteLine($"{totalScore:f2}");
            Console.WriteLine($"From 0 to 9: {((from0To9 / roundsCount) * 100):f2}%");
            Console.WriteLine($"From 10 to 19: {((from10To19 / roundsCount) * 100):f2}%");
            Console.WriteLine($"From 20 to 29: {((from20To29 / roundsCount) * 100):f2}%");
            Console.WriteLine($"From 30 to 39: {((from30To39 / roundsCount) * 100):f2}%");
            Console.WriteLine($"From 40 to 50: {((from40To50 / roundsCount) * 100):f2}%");
            Console.WriteLine($"Invalid numbers: {((invalidNumbers / roundsCount) * 100):f2}%");
        }
    }
}
