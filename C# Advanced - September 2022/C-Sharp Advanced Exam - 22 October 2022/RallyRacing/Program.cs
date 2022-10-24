using System;
using System.Collections.Generic;
using System.Text;

namespace RallyRacing
{
    //Rally Racing
    //It's time for one of the biggest races in the world, the Paris-Dakar race!
    //The organizers of the event want you to do a program that helps them track the cars through the separate stages in the event.
    //
    //On the first line you will be given an integer N, which represents the size of a square matrix.
    //On the second line you will receive the racing number of the tracked car.
    //
    //On the next N lines you will be given the rows of the matrix (string sequences separated by whitespace), which will be representing the race route.
    //The tracked car always starts with coordinates [0, 0].
    //
    //Thеre will be a tunnel somewhere across the race route. If the car runs into the tunnel, it goes through it and exits at the other end.
    //There will be always two positions marked with "T" (tunnel). The finish line will be marked with "F". All other positions will be marked with ".".
    //
    //Keep track of the kilometers passed. Every time the car receives a direction and moves to the next position of the race route, it covers 10 kilometers.
    //If the car goes through the tunnel, it covers 30 kilometers.
    //
    //After the matrix is given, you will be receiving commands for the car (left, right, up, down, End):
    //  •	If the car comes across a position marked with ".", it passes 10 kilometers and waits for the next command.
    //
    //  •	If the car comes across a position marked with "T", it moves to the other position marked with  "T" (the other end of the tunnel) and passes 30 kilometers.
    //      Both positions marked with "T" should be marked with "." and "C", respectively.
    //
    //  •	If the car reaches the "F" position, the race is over and the car has covered another 10 km.
    //      The following output should be printed on the Console: "Racing car {racing number} finished the stage!".
    //
    //  •	If you receive "End" command before the car manages to reach the finish line, the car is disqualified.
    //      The following output should be printed on the Console: "Racing car {racing number} DNF."
    //
    //Input
    //  •	On the first line you will receive N - the size of the square matrix (race route).
    //  •	On the second line you will receive the racing number of the tracked car.
    //  •	On the next N lines you will receive the race route (elements will be separated by a space).
    //  •	On the following lines you will receive commands (left, right, up, down, End).
    //Output
    //  •	If the racing car has reached the finish line before the "End" command is given, print on the Console: "Racing car {racing number} finished the stage!"
    //  •	If the "End" command is given and the racing car has not reached the finish line yet, the race ends.
    //      The following message is printed on the Console: "Racing car {racing number} DNF."
    //  •	On the second line, print the distance that the tracked race car has covered: "Distance covered {kilometers passed} km." 
    //  •	Mark the last known position of the race car with "C" and print the final state of the matrix (race route).
    //      If the race car hasn’t gone through the tunnel, the tunnel exits should be visualized in the final state of the matrix.
    //      The row elements in the output matrix should NOT be separated by a whitespace.
    //Constraints
    //  •	The directions will always lead to coordinates in the matrix.
    //  •	There will always be two positions marked with "T", representing the tunnel in the race route.
    //  •	The size of the square matrix (race route) will be between [4 … 10].
    //
    //Еxamples
    //Input                                 Comment
    //  5                                   The car starts moving from position [0, 0].
    //  01                                  The first command is "down". The car is in position [1, 0].
    //  . . . . .                           Next three commands are "right". The car comes across a tunnel entrance.
    //  . . . T .                           The current car position is [1, 3]. The car's next position is [3, 1].
    //  . . . . .                           Next command is "down". The car position is [4, 1].
    //  . T . . .                           Next command is "right". The car reaches the finish line before the "End" command.
    //  . . F . .                           The remaining commands will be ignored and no more moves are going to be executed.
    //  down
    //  right
    //  right
    //  right
    //  down
    //  right
    //  up
    //  down
    //  right
    //  up
    //  End
    //Output
    //  Racing car 01 finished the stage!
    //  Distance covered 80 km.
    //  .....
    //  .....
    //  .....
    //  .....
    //  ..C..
    //
    //Input
    //  10
    //  45
    //  . . . . . . . . . . 
    //  . . T . . . . . . .
    //  . . . . . . . . . .
    //  . . . . . . . . . .
    //  . . . . . . . . . .
    //  . . . . . . . . . .
    //  . . . . . . F . . .
    //  . . . . . . . . . .
    //  . . . . . . . . . .
    //  . . . . . . . T . .
    //  right
    //  down
    //  down
    //  right
    //  up
    //  left
    //  up
    //  up
    //  End
    //Output
    //  Racing car 45 DNF.
    //  Distance covered 100 km.
    //  ..........
    //  ..........
    //  ..........
    //  ..........
    //  ..........
    //  ..........
    //  ......F...
    //  ......C...
    //  ..........
    //  ..........

    class Program
    {
        static void Main()
        {
            int mapSize = int.Parse(Console.ReadLine());
            char[,] raceMap = new char[mapSize, mapSize];

            Car car = new Car(Console.ReadLine());
            List<Tunnel> tunnelEntrances = new List<Tunnel>();

            for (int row = 0; row < mapSize; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < mapSize; col++)
                {
                    if (currentRow[col] == "T")
                    {
                        Tunnel tunnel = new Tunnel(row, col);
                        tunnelEntrances.Add(tunnel);
                    }

                    raceMap[row, col] = char.Parse(currentRow[col]);
                }
            }

            raceMap[car.Row, car.Col] = 'C';

            string command = Console.ReadLine();

            while (command != "End" && !car.FinishedRace)
            {
                switch (command)
                {
                    case "left":
                        {
                            raceMap[car.Row, car.Col] = '.';
                            car.Col--;

                            raceMap = TrackRallyProgress(raceMap, car, tunnelEntrances);
                            break;
                        }
                    case "right":
                        {
                            raceMap[car.Row, car.Col] = '.';
                            car.Col++;

                            raceMap = TrackRallyProgress(raceMap, car, tunnelEntrances);
                            break;
                        }
                    case "up":
                        {
                            raceMap[car.Row, car.Col] = '.';
                            car.Row--;

                            raceMap = TrackRallyProgress(raceMap, car, tunnelEntrances);
                            break;
                        }
                    case "down":
                        {
                            raceMap[car.Row, car.Col] = '.';
                            car.Row++;

                            raceMap = TrackRallyProgress(raceMap, car, tunnelEntrances);
                            break;
                        }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(car.PrintResults());

            for (int row = 0; row < mapSize; row++)
            {
                for (int col = 0; col < mapSize; col++)
                {
                    Console.Write(raceMap[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] TrackRallyProgress(char[,] raceMap, Car car, List<Tunnel> tunnelEntrances)
        {
            switch (raceMap[car.Row, car.Col])
            {
                case 'T':
                    {
                        car.KilometersPassed += 30;
                        raceMap[car.Row, car.Col] = '.';

                        car.UseTunnel(raceMap, tunnelEntrances);
                        break;
                    }
                case 'F':
                    {
                        car.KilometersPassed += 10;
                        car.FinishedRace = true;

                        break;
                    }
                default:
                    car.KilometersPassed += 10;
                    break;
            }

            raceMap[car.Row, car.Col] = 'C';

            return raceMap;
        }
    }

    public class Car
    {
        private string number;

        public Car(string number)
        {
            Row = 0;
            Col = 0;
            this.number = number;
            KilometersPassed = 0;
            FinishedRace = false;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int KilometersPassed { get; set; }
        public bool FinishedRace { get; set; }

        public void UseTunnel(char[,] raceMap, List<Tunnel> tunnelEntrances)
        {
            for (int i = 0; i < tunnelEntrances.Count; i++)
            {
                if (raceMap[Row, Col] != raceMap[tunnelEntrances[i].Row, tunnelEntrances[i].Col])
                {
                    Row = tunnelEntrances[i].Row;
                    Col = tunnelEntrances[i].Col;
                    break;
                }
            }
        }

        public string PrintResults()
        {
            StringBuilder output = new StringBuilder();

            if (FinishedRace)
            {
                output.AppendLine($"Racing car {number} finished the stage!");
            }
            else
            {
                output.AppendLine($"Racing car {number} DNF.");
            }

            output.AppendLine($"Distance covered {KilometersPassed} km.");

            return output.ToString().TrimEnd();
        }
    }

    public class Tunnel
    {
        private int row;
        private int col;

        public Tunnel(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row { get { return row; } }
        public int Col { get { return col; } }
    }
}
