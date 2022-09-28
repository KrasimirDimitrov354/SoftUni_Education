using System;
using System.Collections.Generic;

namespace Stack_QueueExer10
{
    //Crossroads
    //Your job is to keep track of traffic at the crossroads and report whether a crash happened or everyone passed the crossroads safely.
    //
    //The road has a single lane where cars queue up until the light goes green.
    //When it does, they start passing one by one during the green light and the free window before the intersecting road’s light goes green.
    //
    //During one second only one part of a car (a single character) passes the crossroads.
    //If a car is still at the crossroads when the free window ends, it will get hit at the first character that is still in the crossroads.
    //
    //Input
    //  •	On the first line you will receive the duration of the green light in seconds – an integer in the range [1-100].
    //  •	On the second line you will receive the duration of the free window in seconds – an integer in the range [0-100].
    //  •	Until you receive the "END" command, on the following lines you will receive:
    //      -	A car – a string containing any ASCII character.
    //      -	The command "green", which indicates the start of a green light cycle. A green light cycle goes as follows:
    //          •	During the green light, cars will enter and exit the crossroads one by one.
    //          •	During the free window, cars will only exit the crossroads.
    //Output
    //  •	If a crash happens, end the program and print:
    //      "A crash happened!"
    //      "{car} was hit at {characterHit}."
    //  •	If everything goes smoothly and you receive an "END" command, print:
    //      "Everyone is safe."
    //      "{totalCarsPassed} total cars passed the crossroads."
    //Constraints
    //  •	The input will be within the constraints specified above and will always be valid. There is no need to check it explicitly.
    //
    //Examples
    //Input         Output                                  Comments
    //10            Everyone is safe.                       During the first green light (10 seconds), the Mercedes (8 characters) passes safely.
    //5             3 total cars passed the crossroads.     During the second green light, the Mercedes (8) passes safely and there are 2 seconds left.
    //Mercedes                                              The BMW enters the crossroads and when the green light ends, it still has 1 part inside ('W').
    //green                                                 The free time is 5 seconds, so the 'W' passes successfully as well.
    //Mercedes                                              The Skoda never enters the crossroads so 3 cars passed successfully.
    //BMW
    //Skoda
    //green
    //END
    //
    //Input         Output                  Comments
    //9             A crash happened!       Mercedes (8) passes successfully and Hummer (6) enters the crossroads but only the 'H' passes during the green light.
    //3             Hummer was hit at e.    There are 3 seconds of a free window, so "umm" passes and the Hummer gets hit at 'e'. The program ends with a crash.
    //Mercedes
    //Hummer
    //green
    //Hummer
    //Mercedes
    //green
    //END

    class Program
    {
        static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> queueOfCars = new Queue<string>();
            int passedCars = 0;
            bool hasCrashed = false;

            while (!hasCrashed)
            {
                string input = Console.ReadLine();

                if (input != "END")
                {
                    switch (input)
                    {
                        case "green":
                            int currentLight = greenLight;

                            while (currentLight > 0 && queueOfCars.Count > 0)
                            {
                                string currentCar = queueOfCars.Dequeue();

                                if (currentCar.Length <= currentLight)
                                {
                                    currentLight -= currentCar.Length;
                                    passedCars++;
                                }
                                else
                                {
                                    string restOfCurrentCar = currentCar.Substring(currentLight, currentCar.Length - currentLight);
                                    currentLight = 0;

                                    if (restOfCurrentCar.Length <= freeWindow)
                                    {
                                        passedCars++;
                                    }
                                    else
                                    {
                                        hasCrashed = true;
                                        Console.WriteLine("A crash happened!");
                                        Console.WriteLine($"{currentCar} was hit at {restOfCurrentCar[freeWindow]}.");
                                    }
                                }
                            }                            
                            break;
                        default:
                            queueOfCars.Enqueue(input);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
                    break;
                }
            }
        }
    }
}
