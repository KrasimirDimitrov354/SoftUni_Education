using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BorderControl
{
    //Border Control
    //It’s the future, you’re the ruler of a totalitarian dystopian society inhabited by citizens and robots.
    //You’re afraid of rebellions so you decide to implement strict control of who enters your city. Your security forces check the Ids of everyone who enters and leaves.
    //
    //You will receive an unknown amount of lines from the console until the command "End" is received.
    //On each line there will be a piece of information for either a citizen or a robot who tries to enter your city in the format:
    //  •	"{name} {age} {id}" for citizens.
    //  •	"{model} {id}" for robots.
    //
    //After the "End" command, you will receive a single line containing a number which represents the last digits of fake ids.
    //All citizens or robots whose Id ends with the specified digits must be detained.
    //
    //The output of your program should consist of all detained Ids each on a separate line in the order of input.
    //
    //Input
    //  The input comes from the console. The parameters of each line before the command "End" will be separated by a single space.
    //
    //Examples
    //Input                 Output
    //Peter 22 9010101122   9010101122
    //MK-13 558833251       33283122
    //MK-12 33283122
    //End
    //122
    //
    //Input                 Output
    //Teo 31 7801211340     7801211340
    //Peter 29 8007181534
    //IV-228 999999
    //Sam 54 3401018380
    //KKK-666 80808080
    //End
    //340
    //
    //Input                 Output
    //George 954614         954614
    //Ron 124610            7604128614
    //VI-228 999999         5602142414
    //Mike 13 7604128614
    //Peter 90 5602142414
    //T500 131313130
    //End
    //14
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Birthday Celebrations
    //Extend the program from your last task to add birthdates to citizens and include a class Pet. Pets have a name and a birthdate.
    //Encompass repeated functionality into interfaces and implement them in your classes.
    //
    //You will receive from the console an unknown number of lines. Until the command "End" is received, each line will contain information in one of the following formats:
    //  •	"Citizen <name> <age> <id> <birthdate>"
    //  •	"Robot <model> <id>"
    //  •	"Pet <name> <birthdate"
    //
    //After the "End" command is given, you will receive a single line with a number representing a specific year.
    //Your task is to print all birthdates (of both Citizen and Pet) in that year in their order of input.
    //
    //Examples
    //Input                                     Output
    //Citizen Peter 22 9010101122 10/10/1990    10/10/1990
    //Pet Sharo 13/11/2005
    //Robot MK-13 558833251
    //End
    //1990
    //
    //Input                                     Output
    //Citizen Stam 16 0041018380 01/01/2000     01/01/2000
    //Robot MK-10 12345678                      24/12/2000
    //Robot PP-09 00000001
    //Pet Topcho 24/12/2000
    //Pet Rex 12/06/2002 
    //End
    //2000
    //
    //Input                                     Output
    //Robot VV-XYZ 11213141                     <empty output>
    //Citizen Corso 35 7903210713 21/03/1979
    //Citizen Kane 40 7409073566 07/09/1974
    //End
    //1975
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Food Shortage
    //Your totalitarian dystopian society suffers a shortage of food, so many rebels appear. Extend the code from your previous task with new functionality to solve this task.
    //
    //Define a class Rebel which has a name, age, and group (string).
    //Names are unique - there will never be two Rebels/Citizens or a Rebel and Citizen with the same name.
    //
    //Define an interface IBuyer which defines a method BuyFood() and an integer property Food. Implement the IBuyer interface in the Citizen and Rebel class.
    //Both Rebels and Citizens start with 0 food. When a Rebel buys food, their Food increases by 5. When a Citizen buys food, their Food increases by 10.
    //
    //Input
    //  On the first line of the input you will receive an integer N - the number of people.
    //  On each of the next N lines you will receive information in one of the following formats:
    //      •	"<name> <age> <id> <birthdate>" for a Citizen;
    //      •	"<name> <age> <group>" for a Rebel.
    //
    //  Then, until the command "End" is received, you will receive names of people who bought food, each on a new line.
    //  Note that not all names will be valid. In case of an incorrect name nothing should happen.
    //Output
    //  The output consists of only one line on which you should print the total amount of food purchased.
    //
    //Examples
    //Input                             Output
    //2                                 20
    //Peter 25 8904041303 04/04/1989
    //Stan 27 WildMonkeys
    //Peter
    //George
    //Peter
    //End
    //
    //Input                             Output
    //4                                 15
    //Stam 23 TheSwarm
    //Ton 44 7308185527 18/08/1973
    //George 31 Terrorists
    //Pen 27 881222212 22/12/1988
    //John
    //Geo rge
    //John
    //Joro
    //Stam
    //Pen
    //End

    public class Program
    {
        static void Main()
        {
            //***FOR BORDER CONTROL***
            {
                //string[] input = Console.ReadLine().Split();
                //List<I_Identifiable> entities = new List<I_Identifiable>();

                //while (input[0] != "End")
                //{
                //    if (input.Length == 3)
                //    {
                //        entities.Add(new Citizen(input[0], int.Parse(input[1]), input[2]));
                //    }
                //    else
                //    {
                //        entities.Add(new Robot(input[0], input[1]));
                //    }

                //    input = Console.ReadLine().Split();
                //}

                //string identifier = Console.ReadLine();

                //foreach (var entity in entities)
                //{
                //    entity.Detain(identifier);
                //}
            }

            //***FOR BIRTHDAY CELEBRATIONS***
            {
                //string[] input = Console.ReadLine().Split();
                //List<IOrganic> organics = new List<IOrganic>();

                //while (input[0] != "End")
                //{
                //    switch (input[0])
                //    {
                //        case "Citizen":
                //            organics.Add(new Citizen(input[1], int.Parse(input[2]), input[3], input[4]));
                //            break;
                //        case "Pet":
                //            organics.Add(new Pet(input[1], input[2]));
                //            break;
                //        default:
                //            break;
                //    }

                //    input = Console.ReadLine().Split();
                //}

                //string year = Console.ReadLine();

                //foreach (var organic in organics)
                //{
                //    organic.Celebrate(year);
                //}
            }

            //***FOR FOOD SHORTAGE***
            {
                int count = int.Parse(Console.ReadLine());
                List<IBuyer> buyers = new List<IBuyer>();

                string validIDPattern = @"\b[0-9]+\b";

                for (int i = 0; i < count; i++)
                {
                    string[] input = Console.ReadLine().Split();

                    if (Regex.IsMatch(input[2], validIDPattern))
                    {
                        buyers.Add(new Citizen(input[2], int.Parse(input[1]), input[0], input[3]));
                    }
                    else
                    {
                        buyers.Add(new Rebel(input[2], int.Parse(input[1]), input[0]));
                    }
                }

                string possibleBuyer = Console.ReadLine();
                Predicate<IBuyer> validBuyer = buyer => buyer.Id == possibleBuyer;

                while (possibleBuyer != "End")
                {
                    if (buyers.Exists(validBuyer))
                    {
                        buyers.Find(validBuyer).BuyFood();
                    }

                    possibleBuyer = Console.ReadLine();
                }

                Console.WriteLine(buyers.Sum(s => s.Food));
            }
        }
    }
}
