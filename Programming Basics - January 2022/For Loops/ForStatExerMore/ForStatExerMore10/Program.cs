using System;

namespace ForStatExerMore10
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            while (hours < 24)
            {
                Console.WriteLine($"{hours} : {minutes} : {seconds}");
                seconds++;

                if (seconds == 60)
                {
                    minutes++;
                    seconds = 0;
                }

                if (minutes == 60)
                {
                    hours++;
                    minutes = 0;
                }
            }
        }
    }
}
