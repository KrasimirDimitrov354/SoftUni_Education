using System;

namespace NestedLoopLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            string currentFloor = "";

            for (int i = floors; i >= 1; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i == floors)
                    {
                        currentFloor += "L" + i + j + " ";
                    }
                    else
                    {
                        if (i % 2 != 0)
                        {
                            currentFloor += "A" + i + j + " ";
                        }
                        else
                        {
                            currentFloor += "O" + i + j + " ";
                        }
                    }

                    if (j == rooms - 1)
                    {
                        Console.WriteLine(currentFloor);
                        currentFloor = "";
                    }                   
                }
            }
        }
    }
}
