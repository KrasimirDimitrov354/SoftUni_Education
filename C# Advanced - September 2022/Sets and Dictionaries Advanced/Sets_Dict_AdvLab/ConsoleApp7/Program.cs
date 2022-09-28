using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    //Parking Lot
    //Create a program that:
    //  •	Records a car number for every car that enters the parking lot.
    //  •	Removes a car number when the car leaves the parking lot.
    //
    //The input will be a string in the format: "direction, carNumber". You will be receiving commands until the "END" command is given.
    //Print the car numbers of the cars which are still in the parking lot.
    //
    //Examples
    //Input             Output
    //IN, CA2844AA      CA9999TT
    //IN, CA1234TA      CA2844AA
    //OUT, CA2844AA     CA9876HH
    //IN, CA9999TT      CA2822UU
    //IN, CA2866HI
    //OUT, CA1234TA
    //IN, CA2844AA
    //OUT, CA2866HI
    //IN, CA9876HH
    //IN, CA2822UU
    //END
    //
    //Input             Output
    //IN, CA2844AA      Parking Lot is Empty
    //IN, CA1234TA
    //OUT, CA2844AA
    //OUT, CA1234TA
    //END

    class Program
    {
        static void Main()
        {
            HashSet<string> carsInParking = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ");

            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "IN":
                        carsInParking.Add(input[1]);
                        break;
                    case "OUT":
                        if (carsInParking.Contains(input[1]))
                        {
                            carsInParking.Remove(input[1]);
                        }
                        break;
                }

                input = Console.ReadLine().Split(", ");
            }

            if (carsInParking.Count > 0)
            {
                foreach (string car in carsInParking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
