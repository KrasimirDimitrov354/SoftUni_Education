using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    //Military Elite
    //Create the following class hierarchy:
    //  •	Soldier - general class for Soldiers. Holds id (int), first name (string), and last name (string).
    //      •	Private - lowest base Soldier type. Holds the salary (decimal). 
    //      •	LieutenantGeneral - holds a set of Privates under his command.
    //      •	SpecialisedSoldier - general class for all specialized Soldiers. Holds the corps (string) of the Soldier.
    //          The corps can only be one of the following: Airforces or Marines.
    //          •	Engineer - holds a set of Repairs. A Repair holds a part name (string) and hours worked (int).
    //          •	Commando - holds a set of Missions. A Mission holds a code name (string) and a state (string, inProgress or Finished).
    //              A Mission can be finished through the method CompleteMission().
    //      •	Spy - holds the code number (int) of the Spy.
    //
    //Validate the input where necessary (corps, mission state) - input should match exactly one of the required values, otherwise it should be treated as invalid.
    //In case of invalid corps, the entire line should be skipped. In case of an invalid mission state, only the mission should be skipped.
    //
    //You will receive from the console an unknown amount of lines containing information about soldiers until the command "End" is received.
    //The information will be in one of the following formats:
    //  •	Private: "Private <id> <firstName> <lastName> <salary>"
    //  •	LeutenantGeneral: "LieutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>"
    //      where privateId will always be an Id of a Private already received through the input.
    //  •	Engineer: "Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>"
    //      where repairPart is the name of a repaired part and repairHours the hours it took to repair it (the two parameters will always come paired). 
    //  •	Commando: "Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>"
    //      where a missions code name and state will always come together.
    //  •	Spy: "Spy <id> <firstName> <lastName> <codeNumber>"
    //
    //Override ToString() in all classes to print detailed information about the object.
    //  •	Privates:
    //      Name: <firstName> <lastName> Id: <id> Salary: <salary>
    //  •	Spy:
    //      Name: <firstName> <lastName> Id: <id>
    //      Code Number: <codeNumber>
    //  •	LieutenantGeneral:
    //      Name: <firstName> <lastName> Id: <id> Salary: <salary>
    //      Privates:
    //      <private1 ToString()>
    //      <private2 ToString()>
    //      …
    //      <privateN ToString()>
    //  •	Engineer:
    //      Name: <firstName> <lastName> Id: <id> Salary: <salary>
    //      Corps: <corps>
    //      Repairs:
    //        <repair1 ToString()>
    //        <repair2 ToString()>
    //        …
    //        <repairN ToString()>
    //  •	Commando:
    //      Name: <firstName> <lastName> Id: <id> Salary: <salary>
    //      Corps: <corps>
    //      Missions:
    //        <mission1 ToString()>
    //        <mission2 ToString()>
    //        …
    //        <missionN ToString()>
    //  •	Repair:
    //      Part Name: <partName> Hours Worked: <hoursWorked>
    //  •	Mission:
    //      Code Name: <codeName> State: <state>
    //
    //NOTE: Salary should be rounded to two decimal places after the separator.
    //
    //Examples
    //Input
    //  Private 1 Peter Johnson 22.22
    //  Commando 13 Sam Peterson 13.1 Airforces
    //  Private 222 Tony Samthon 80.08
    //  LieutenantGeneral 3 George Stevenson 100 222 1
    //  End
    //Output
    //  Name: Peter Johnson Id: 1 Salary: 22.22
    //  Name: Sam Peterson Id: 13 Salary: 13.10
    //  Corps: Airforces
    //  Missions:
    //  Name: Tony Samthon Id: 222 Salary: 80.08
    //  Name: George Stevenson Id: 3 Salary: 100.00
    //  Privates:
    //    Name: Tony Samthon Id: 222 Salary: 80.08
    //    Name: Peter Johnson Id: 1 Salary: 22.22
    //
    //Input
    //  Engineer 7 Peter Johnson 12.23 Marines Boat 2 Crane 17
    //  Commando 19 George Stevenson 150.15 Airforces HairyFoot finished Freedom inProgress
    //  End
    //Output
    //  Name: Peter Johnson Id: 7 Salary: 12.23
    //  Corps: Marines
    //  Repairs:
    //    Part Name: Boat Hours Worked: 2
    //    Part Name: Crane Hours Worked: 17
    //  Name: George Stevenson Id: 19 Salary: 150.15
    //  Corps: Airforces
    //  Missions:
    //    Code Name: Freedom State: inProgress

    class Program
    {
        static void Main()
        {
            List<Soldier> soldiers = new List<Soldier>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Private":
                        soldiers.Add(new Private(input[1], input[2], input[3], decimal.Parse(input[4])));
                        break;
                    case "LieutenantGeneral":
                        soldiers.Add(GetGeneral(input, soldiers));
                        break;
                    case "Engineer":
                    case "Commando":
                        if (CorpsAreValid(input[5]))
                        {
                            switch (input[0])
                            {
                                case "Engineer":
                                    soldiers.Add(GetEngineer(input));
                                    break;
                                case "Commando":
                                    soldiers.Add(GetCommando(input));
                                    break;
                            }
                        }
                        break;
                    case "Spy":
                        soldiers.Add(new Spy(input[1], input[2], input[3], int.Parse(input[4])));
                        break;
                }

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }

        private static Soldier GetGeneral(string[] input, List<Soldier> soldiers)
        {
            var general = new LieutenantGeneral(input[1], input[2], input[3], decimal.Parse(input[4]));

            for (int i = 5; i < input.Length; i++)
            {
                general.AddSoldier((Private)soldiers.Find(s => s.Id == input[i]));
            }

            return general;
        }

        private static bool CorpsAreValid(string corps)
        {
            if (corps == "Airforces" || corps == "Marines")
            {
                return true;
            }

            return false;
        }

        private static Soldier GetEngineer(string[] input)
        {
            var engineer = new Engineer(input[1], input[2], input[3], decimal.Parse(input[4]), input[5]);

            for (int i = 6; i < input.Length; i += 2)
            {
                engineer.AddPart(new RepairPart(input[i], int.Parse(input[i + 1])));
            }

            return engineer;
        }

        private static Soldier GetCommando(string[] input)
        {
            var commando = new Commando(input[1], input[2], input[3], decimal.Parse(input[4]), input[5]);

            for (int i = 6; i < input.Length; i += 2)
            {
                string name = input[i];
                string state = input[i + 1];

                if (state == "inProgress" || state == "Finished")
                {
                    commando.AddMission(new Mission(name, state));
                }
            }

            return commando;
        }
    }
}
