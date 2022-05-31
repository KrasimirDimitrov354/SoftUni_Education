using System;

namespace ConsoleApp8
{
    class Program
    {
        //BPM Counter
        //Write a program, which receives BPM(beats per minute) and number of beats from the console.
        //It must calculate how many bars (1 bar = 4 beats) the beats equal to, then calculate the length of the sequence in minutes and seconds.
        //The bars must always be rounded to the first digit after the decimal point (i.e. 1.75 bars - 1.8 bars).
        //Examples
        //Input     Output              Input   Output                  Input   Output
        //60        15 bars - 1m 0s     128     21.2 bars - 0m 39s      522     20 bars - 0m 9s
        //60                            85                              80

        static void Main()
        {
            int BPM = int.Parse(Console.ReadLine());
            int beats = int.Parse(Console.ReadLine());

            double bars = Math.Round(beats / 4.0, 1);

            int minutes = 0;
            double seconds = Math.Floor((beats * 1.0 / BPM * 1.0) * 60.0);

            while (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }

            Console.WriteLine($"{bars} bars - {minutes}m {seconds}s");
        }
    }
}
