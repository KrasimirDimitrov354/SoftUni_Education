using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    //SoftUni Party
    //Many guests are invited to the party and there are two types of them: VIP and Regular. When a guest comes, check if they exist in any of the two reservation lists.
    //
    //All reservation numbers will be with the length of 8 chars.
    //All VIP numbers start with a digit.
    //
    //First, you will be receiving the reservation numbers of the guests. You can also receive 2 possible commands:
    //  •	"PARTY" – After this command, you will begin receiving the reservation numbers of the people who came to the party.
    //  •	"END" – The party is over and you have to stop the program and print the appropriate output.
    //
    //Print the count of the guests who didn't come to the party, and afterward print their reservation numbers. The VIP guests must be first.
    //
    //Examples
    //Input         Output
    //7IK9Yo0h      2
    //9NoBUajQ      7IK9Yo0h
    //Ce8vwPmE      tSzE5t0p
    //SVQXQCbc
    //tSzE5t0p
    //PARTY
    //9NoBUajQ
    //Ce8vwPmE
    //SVQXQCbc
    //END
    //
    //Input         Output
    //m8rfQBvl      2
    //fc1oZCE0      xys2FYzn
    //UgffRkOn      MDzcM9ZK
    //7ugX7bm0
    //9CQBGUeJ
    //2FQZT3uC
    //dziNz78I
    //mdSGyQCJ
    //LjcVpmDL
    //fPXNHpm1
    //HTTbwRmM
    //B5yTkMQi
    //8N0FThqG
    //xys2FYzn
    //MDzcM9ZK
    //PARTY
    //2FQZT3uC
    //dziNz78I
    //mdSGyQCJ
    //LjcVpmDL
    //fPXNHpm1
    //HTTbwRmM
    //B5yTkMQi
    //8N0FThqG
    //m8rfQBvl
    //fc1oZCE0
    //UgffRkOn
    //7ugX7bm0
    //9CQBGUeJ
    //END

    class Program
    {
        static void Main()
        {
            HashSet<string> guestsVIP = new HashSet<string>();
            HashSet<string> guestsRegular = new HashSet<string>();

            string reservation = Console.ReadLine();

            while (reservation != "PARTY")
            {
                if (Char.IsDigit(reservation[0]))
                {
                    guestsVIP.Add(reservation);
                }
                else
                {
                    guestsRegular.Add(reservation);
                }

                reservation = Console.ReadLine();
            }

            string partyGoer = Console.ReadLine();

            while (partyGoer != "END")
            {
                if (Char.IsDigit(partyGoer[0]))
                {
                    guestsVIP.Remove(partyGoer);
                }
                else
                {
                    guestsRegular.Remove(partyGoer);
                }

                partyGoer = Console.ReadLine();
            }

            Console.WriteLine(guestsRegular.Count + guestsVIP.Count);

            if (guestsVIP.Count > 0)
            {
                foreach (string VIP in guestsVIP)
                {
                    Console.WriteLine(VIP);
                }
            }

            if (guestsRegular.Count > 0)
            {
                foreach (string regular in guestsRegular)
                {
                    Console.WriteLine(regular);
                }
            }
        }
    }
}
