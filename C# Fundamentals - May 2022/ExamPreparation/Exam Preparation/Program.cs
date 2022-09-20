using System;
using System.Linq;
using System.Text;

namespace _01.The_Imitation_Game
{
    //The Imitation Game
    //Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
    //Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2525#0.
    //
    //You are a mathematician who has joined the cryptography team to decipher the enemy's enigma code. Your job is to create a program to crack the codes.
    //
    //On the first line of the input you will receive the encrypted message.
    //Until the "Decode" command is given, you will be receiving strings with instructions for different operations that need to be performed upon the concealed message.
    //There are several types of instructions, split by '|':
    //  •	"Move {number of letters}":
    //      o Moves the first n letters to the back of the string.
    //  •	"Insert {index}{value}":
    //      o Inserts the given value before the given index in the string.
    //  •	"ChangeAll {substring}{replacement}":
    //      o Changes all occurrences of the given substring with the replacement text.
    //
    //Input / Constraints
    //  •	On the first line, you will receive a string with a message.
    //  •	On the following lines, you will be receiving commands, split by '|'.
    //Output
    //  •	After the "Decode" command is received, print this message:
    //      "The decrypted message is: {message}"
    //Examples
    //Input             Output                              Comments
    //zzHe              The decrypted message is: Hello     "ChangeAll|z|l"
    //ChangeAll|z|l                                         zzHe → llHe - We replace all occurrences of 'z' with 'l'.
    //Insert|2|o                                            "Insert|2|o"
    //Move|3                                                llHe → lloHe - We add an 'o' before the character on index 2.
    //Decode                                                "Move|3"
    //                                                      lloHe → Hello - We take the first three characters and move them to the end of the string.
    //                                                      After receiving the "Decode" command we print the resulting message.
    //
    //Input             Output
    //owyouh            The decrypted message is: howareyou?
    //Move|2
    //Move|3
    //Insert|3|are
    //Insert|9|?
    //Decode 

    class Program
    {
        private static void MoveSymbols(StringBuilder message, int count)
        {
            for (int i = 0; i < count; i++)
            {
                message.Append(message[0]);
                message.Remove(0, 1);
            }
        }

        private static void InsertSymbol(StringBuilder message, int index, string value)
        {
            message.Insert(index, value);
        }

        private static void ChangeSymbols(StringBuilder message, string toBeReplaced, string replacement)
        {
            message.Replace(toBeReplaced, replacement);
        }

        private static void DecodeMessage(StringBuilder message)
        {
            Console.WriteLine($"The decrypted message is: {message}");
        }

        static void Main()
        {
            StringBuilder message = new StringBuilder(Console.ReadLine());

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Decode")
                {
                    DecodeMessage(message);
                    break;
                }
                else
                {
                    switch (command[0])
                    {
                        case "Move":
                            MoveSymbols(message, int.Parse(command[1]));
                            break;
                        case "Insert":
                            InsertSymbol(message, int.Parse(command[1]), command[2]);
                            break;
                        case "ChangeAll":
                            ChangeSymbols(message, command[1], command[2]);
                            break;
                    }
                }
            }
        }
    }
}
