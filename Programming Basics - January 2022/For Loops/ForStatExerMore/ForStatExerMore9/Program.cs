using System;

namespace ForStatExerMore9
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = 0;
            int minutes = 0;

            while (hours < 24)
            {
                Console.WriteLine($"{hours} : {minutes}");
                minutes++;

                if (minutes == 60)
                {
                    hours++;
                    minutes = 0;
                }
            }
        }
    }
}
