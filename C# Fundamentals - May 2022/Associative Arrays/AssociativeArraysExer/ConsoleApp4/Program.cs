using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    //SoftUni Parking
    //Write a program which validates a parking place for an online service. Users can register to park and unregister to leave.
    //
    //The program receives 2 commands:	
    //  •	"register {username} {licensePlateNumber}":
    //      o The system only supports one car per user at the moment, so if a user tries to register another license plate using the same username, the system should print:
    //          "ERROR: already registered with plate number {licensePlateNumber}"
    //      o If the aforementioned check passes successfully, the plate can be registered. The system should print:
    //          "{username} registered {licensePlateNumber} successfully"
    //  •	"unregister {username}":
    //      o If the user is not present in the database, the system should print:
    //          "ERROR: user {username} not found"
    //      o If the aforementioned check passes successfully, the system should print:
    //          "{username} unregistered successfully"
    //
    //After you execute all of the commands, print all of the currently registered users and their license plates in the format: 
    //  •	"{username} => {licensePlateNumber}"
    //Input
    //  •	First line: n - number of commands – integer.
    //  •	Next n lines: commands in one of the two possible formats:
    //      o Register: "register {username} {licensePlateNumber}"
    //      o Unregister: "unregister {username}"
    //The input will always be valid and you do not need to check it explicitly.
    //
    //Examples
    //Input
    //  5
    //  register John CS1234JS
    //  register George JAVA123S
    //  register Andy AB4142CD
    //  register Jesica VR1223EE
    //  unregister Andy
    //Output
    //  John registered CS1234JS successfully
    //  George registered JAVA123S successfully
    //  Andy registered AB4142CD successfully
    //  Jesica registered VR1223EE successfully
    //  Andy unregistered successfully
    //  John => CS1234JS
    //  George => JAVA123S
    //  Jesica => VR1223EE
    //
    //Input
    //  4
    //  register Jony AA4132BB
    //  register Jony AA4132BB
    //  register Linda AA9999BB
    //  unregister Jony
    //Output
    //  Jony registered AA4132BB successfully
    //  ERROR: already registered with plate number AA4132BB
    //  Linda registered AA9999BB successfully
    //  Jony unregistered successfully
    //  Linda => AA9999BB
    //
    //Input
    //  6
    //  register Jacob MM1111XX
    //  register Anthony AB1111XX
    //  unregister Jacob
    //  register Joshua DD1111XX
    //  unregister Lily
    //  register Samantha AA9999BB
    //Output
    //  Jacob registered MM1111XX successfully
    //  Anthony registered AB1111XX successfully
    //  Jacob unregistered successfully
    //  Joshua registered DD1111XX successfully
    //  ERROR: user Lily not found
    //  Samantha registered AA9999BB successfully
    //  Joshua => DD1111XX
    //  Anthony => AB1111XX
    //  Samantha => AA9999BB

    class Program
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            Dictionary<string, string> registerOfVehicles = new Dictionary<string, string>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();

                string command = input[0];
                string username = input[1];

                switch (command)
                {
                    case "register":
                        {                            
                            string licensePlate = input[2];

                            if (registerOfVehicles.ContainsKey(username))
                            {
                                Console.WriteLine($"ERROR: already registered with plate number {registerOfVehicles[username]}");
                            }
                            else
                            {
                                registerOfVehicles.Add(username, licensePlate);
                                Console.WriteLine($"{username} registered {licensePlate} successfully");
                            }

                            break;
                        }
                    case "unregister":
                        {
                            if (registerOfVehicles.ContainsKey(username) == false)
                            {
                                Console.WriteLine($"ERROR: user {username} not found");
                            }
                            else
                            {
                                registerOfVehicles.Remove(username);
                                Console.WriteLine($"{username} unregistered successfully");
                            }

                            break;
                        }
                }
            }

            foreach (var username in registerOfVehicles)
            {
                Console.WriteLine($"{username.Key} => {username.Value}");
            }
        }
    }
}
