using System;

namespace CondStatAdvExer8
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            double minutesLeft = 0;
            double hoursLeft = 0;

            //При една и съща стойност на променливите за час examHour и arrivalHour се проверяват само стойностите на променливите за минути examMinutes и arrivalMinutes.
            //Разликата в минутите се запазва в променливата minutesLeft.
            //
            //Ако стойността на променливата за минути на пристигане arrivalMinutes е по-малка или равна на стойността на променливата за минути на започване examMinutes,
            //то тогава студента е дошъл навреме за изпита.
            //Примерни входни данни за влизане в този случай - examHour = 8; examMinutes = 45; arrivalHour = 8; arrivalMinutes = 35;
            //
            //Ако стойността на arrivalMinutes е по-голяма от examMinutes, то тогава студента е закъснял.
            //Примерни вх. данни - examHour = 8; examMinutes = 45; arrivalHour = 8; arrivalMinutes = 55;
            if (examHour == arrivalHour)
            {
                if (examMinutes >= arrivalMinutes)
                {
                    minutesLeft = examMinutes - arrivalMinutes;

                    if (minutesLeft <= 30)
                    {
                        Console.WriteLine("On time");

                        if (minutesLeft > 0)
                        {
                            Console.WriteLine($"{minutesLeft} minutes before the start");
                        }
                    }
                    else if (minutesLeft > 30)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{minutesLeft} minutes before the start");
                    }
                }
                else if (examMinutes < arrivalMinutes)
                {
                    minutesLeft = arrivalMinutes - examMinutes;

                    Console.WriteLine("Late");
                    Console.WriteLine($"{minutesLeft} minutes after the start");
                }
            }

            //Ако examHour има по-голяма стойност от arrivalHour, студента ще е или дошъл на време за изпита, или дошъл по-рано за него.
            //Разликата в часовете се запазва в променливата hoursLeft.
            //
            //Ако examMinutes има по-голяма или равна стойност на arrivalMinutes, hoursLeft винаги ще има стойност поне 1.
            //Примерни вх. данни - examHour = 10; examMinutes = 30; arrivalHour = 8; arrivalMinutes = 30;
            //
            //Ако examMinutes има по-малка стойност от arrivalMinutes се прави проверка дали hoursLeft има стойност поне едно, и ако не се прави проверка за стойността на minutesLeft.
            //Примерни вх. данни - examHour = 10; examMinutes = 30; arrivalHour = 9; arrivalMinutes = 40;
            else if (examHour > arrivalHour)
            {
                if (examMinutes >= arrivalMinutes)
                {
                    minutesLeft = examMinutes - arrivalMinutes;
                    hoursLeft = examHour - arrivalHour;

                    Console.WriteLine("Early");
                    Console.WriteLine($"{hoursLeft}:{minutesLeft.ToString("00")} hours before the start");
                }
                else if (examMinutes < arrivalMinutes)
                {
                    minutesLeft = examMinutes + (60 - arrivalMinutes);
                    hoursLeft = (examHour - arrivalHour) - 1;

                    if (minutesLeft == 60)
                    {
                        minutesLeft = 0;
                    }

                    if (hoursLeft >= 1)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{hoursLeft}:{minutesLeft.ToString("00")} hours before the start");
                    }
                    else
                    {
                        if (minutesLeft <= 30)
                        {
                            Console.WriteLine("On time");

                            if (minutesLeft > 0)
                            {
                                Console.WriteLine($"{minutesLeft} minutes before the start");
                            }
                        }
                        else if (minutesLeft > 30)
                        {
                            Console.WriteLine("Early");
                            Console.WriteLine($"{minutesLeft} minutes before the start");
                        }
                    }
                }
            }

            //Ако examHour има по-малка стойност от arrivalHour, студента винаги ще е закъснял.
            //
            //Проверките са идентични като при горния случай.
            //Примерни вх. данни:
            //examHour = 10;
            //examMinutes = 30;
            //arrivalHour = 12;
            //arrivalMinutes = 30;
            //
            //examHour = 10;
            //examMinutes = 30;
            //arrivalHour = 11;
            //arrivalMinutes = 20;
            //
            //examHour = 10;
            //examMinutes = 30;
            //arrivalHour = 12;
            //arrivalMinutes = 45;
            else if (examHour < arrivalHour)
            {
                if (examMinutes >= arrivalMinutes)
                {
                    minutesLeft = arrivalMinutes + (60 - examMinutes);
                    hoursLeft = (arrivalHour - examHour) - 1;

                    if (minutesLeft == 60)
                    {
                        minutesLeft = 0;
                        hoursLeft++;
                    }

                    if (hoursLeft >= 1)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{hoursLeft}:{minutesLeft.ToString("00")} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{minutesLeft} minutes after the start");
                    }
                }
                else if (examMinutes < arrivalMinutes)
                {
                    minutesLeft = arrivalMinutes - examMinutes;
                    hoursLeft = arrivalHour - examHour;

                    Console.WriteLine("Late");
                    Console.WriteLine($"{hoursLeft}:{minutesLeft.ToString("00")} hours after the start");
                }
            }
        }
    }
}
