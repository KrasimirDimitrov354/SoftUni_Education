namespace AsynchronousProcessingExample;

//Implement a program which provides a Chronometer functionality that responds to several commands from the user input:
//  • start – starts counting time in milliseconds, seconds and minutes
//  • stop – stops the process of counting time, but the counted timeremains
//  • lap – creates a lap at the current time
//  • laps – returns all of the currently recorded laps
//  • time – returns the currently recorded time
//  • reset – stops the Chronometer, resets the currently recorded time and deletes all of the currently recoded laps
//  • exit – stops and exits the program

public class Program
{
    static void Main()
    {
        Chronometer chronometer = new Chronometer();

        string command = Console.ReadLine()!;

        while (command != "exit")
        {
            switch (command)
            {
                case "start":
                    chronometer.Start();
                    break;
                case "stop":
                    chronometer.Stop();
                    break;
                case "lap":
                    Console.WriteLine(chronometer.Lap());
                    break;
                case "laps":
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                    else
                    {
                        for (int i = 0; i < chronometer.Laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {chronometer.Laps[i]}");
                        }
                    }
                    break;
                case "time":
                    Console.WriteLine(chronometer.GetTime);
                    break;
                case "reset":
                    chronometer.Reset();
                    break;
            }

            command = Console.ReadLine()!;
        }
    }
}