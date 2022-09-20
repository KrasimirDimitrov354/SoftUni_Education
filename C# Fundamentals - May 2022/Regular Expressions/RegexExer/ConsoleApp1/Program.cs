using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    //Race
    //Write a program that processes information about a race.
    //On the first line, you will be given a list of participants separated by ", ".
    //On the next few lines until you receive a line "end of the race" you will be given some info which will be some alphanumeric characters.
    //In between them you could have some extra characters which you should ignore. For example: "G!32e%o7r#32g$235@!2e".
    //The letters are the name of the person and the sum of the digits is the distance he ran. In the above example we have George who ran 29 km.
    //Store the information about the person only if the list of racers contains the name of the person.
    //If you receive the same person more than once just add the distance to his old distance. At the end print the top 3 racers in the format:
    //  "1st place: {first racer}
    //  2nd place: {second racer}
    //  3rd place: {third racer}"
    //
    //Examples
    //Input                         Comment
    //  George, Peter, Bill, Tom    On the 3rd input line, we have Ray. He is not on the list, so we do not count his result.
    //  G4e@55or%6g6!68e!!@         The other ones are valid. George has a total of 55 km, Peter has 25 and Tom has 19.
    //  R1@!3a$y4456@               We do not print Bill because he is in 4th place.
    //  B5@i@#123ll
    //  G@e54o$r6ge#
    //  7P%et^#e5346r
    //  T$o553m&6
    //  end of race
    //Output
    //  1st place: George
    //  2nd place: Peter
    //  3rd place: Tom
    //
    //Input
    //  Ivan, Peter, James, Kyle
    //  I4v@43an%66?77!!@
    //  G1@!3u$s445s6@
    //  B3@i@#245ll
    //  I&v54a%66n@
    //  7P%et^#e5346r
    //  J$a553m&e6s
    //  K2y3=l/^e23
    //  end of race
    //Output
    //  1st place: Ivan
    //  2nd place: Peter
    //  3rd place: James

    class Participant
    {
        public Participant(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public int Distance { get; set; }

        public static int CalculateDistance(string input, string pattern)
        {
            int distance = 0;

            MatchCollection digitsMatches = Regex.Matches(input, pattern);
            string distanceDigits = string.Concat(digitsMatches);

            for (int i = 0; i < distanceDigits.Length; i++)
            {
                distance += int.Parse(distanceDigits[i].ToString());
            }

            return distance;
        }

        public static void PrintTopThree(List<Participant> participants)
        {
            List<Participant> orderedParticipants = participants
                        .OrderByDescending(p => p.Distance)
                        .ToList();

            Console.WriteLine($"1st place: {orderedParticipants[0].Name}");
            Console.WriteLine($"2nd place: {orderedParticipants[1].Name}");
            Console.WriteLine($"3rd place: {orderedParticipants[2].Name}");
        }
    }

    class Program
    {
        static void Main()
        {
            string[] participantsSigned = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string patternLetters = @"[A-Za-z]";
            string patternDigits = @"[0-9]";

            List<Participant> participantsPresent = new List<Participant>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    Participant.PrintTopThree(participantsPresent);
                    break;
                }
                else
                {
                    MatchCollection lettersMatches = Regex.Matches(input, patternLetters);
                    string name = string.Concat(lettersMatches);

                    if (participantsSigned.Contains(name))
                    {
                        Participant participant = new Participant(name);
                        participant.Distance = Participant.CalculateDistance(input, patternDigits);

                        if (participantsPresent.Count == 0)
                        {
                            participantsPresent.Add(participant);
                        }
                        else
                        {
                            for (int i = 0; i < participantsPresent.Count; i++)
                            {
                                if (participantsPresent[i].Name == participant.Name)
                                {
                                    participantsPresent[i].Distance += participant.Distance;
                                    break;
                                }

                                if (i == participantsPresent.Count - 1)
                                {
                                    participantsPresent.Add(participant);
                                    break;
                                }
                            }
                        }  
                    }
                }
            }
        }
    }
}
