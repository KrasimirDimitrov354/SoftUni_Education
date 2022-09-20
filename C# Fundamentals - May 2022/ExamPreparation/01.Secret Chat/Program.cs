using System;
using System.Linq;
using System.Text;

namespace _01.Secret_Chat
{
    //Secret Chat
    //Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
    //Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2307#0.
    //
    //You have plenty of free time, so you decide to write a program that conceals and reveals your received messages. Go ahead and type it in!
    //
    //On the first line of the input you will receive the concealed message.
    //Until the "Reveal" command is given, you will receive strings with instructions for different operations.
    //They need to be performed upon the concealed message to interpret it and reveal its actual content.
    //
    //There are several types of instructions, split by ":|:"
    //  •	"InsertSpace:|:{index}"
    //      o Inserts a single space at the given index. The given index will always be valid.
    //  •	"Reverse:|:{substring}"
    //      o If the message contains the given substring, cut it out, reverse it and add it at the end of the message.
    //      o If not, print "error".
    //      o This operation should replace only the first occurrence of the given substring if there are two or more occurrences.
    //  •	"ChangeAll:|:{substring}:|:{replacement}"
    //      o Changes all occurrences of the given substring with the replacement text.
    //
    //Input / Constraints
    //  •	On the first line, you will receive a string with a message.
    //  •	On the following lines, you will be receiving commands, split by ":|:".
    //Output
    //  •	After each set of instructions, print the resulting string. 
    //  •	After the "Reveal" command is received, print this message:
    //      "You have a new text message: {message}"
    //Examples
    //Input                 Output                                          Comments
    //heVVodar!gniV         hellodar!gnil                                   "ChangeAll:|:V:|:l" - We replace all occurrences of "V" with "l".
    //ChangeAll:|:V:|:l     hellodarling!                                   heVVodar!gniV -> hellodar!gnil 
    //Reverse:|:!gnil       hello darling!                                  "Reverse:|:!gnil" - We reverse !gnil to ling! And put it at the end of the string.
    //InsertSpace:|:5       You have a new text message: hello darling!     hellodar!gnil -> !gnil -> ling! -> hellodarling!
    //Reveal                                                                "InsertSpace:|:5" - We insert a space at index 5.
    //                                                                      hellodarling! -> hello.darling! 
    //                                                                      We print the resulting message after receiving the "Reveal" command.
    //
    //Input                 Output
    //Hiware? uiy           Howare? uoy
    //ChangeAll:|:i:|:o     Howareyou?
    //Reverse:|:? uoy       error
    //Reverse:|:jd          How areyou?
    //InsertSpace:|:3       How are you?
    //InsertSpace:|:7       You have a new text message: How are you?
    //Reveal 

    class Program
    {
        private static StringBuilder PrintMessage(StringBuilder message)
        {
            return message;
        }

        private static void InsertSpace(StringBuilder message, int index)
        {
            message.Insert(index, ' ');
            Console.WriteLine(PrintMessage(message));
        }

        private static void ReverseSubstring(StringBuilder message, string substring)
        {
            string convertedMessage = message.ToString();

            if (convertedMessage.Contains(substring))
            {
                int startIndex = convertedMessage.IndexOf(substring);
                message.Remove(startIndex, substring.Length);

                char[] reversedSubstring = substring.ToCharArray();
                Array.Reverse(reversedSubstring);
                message.Insert(message.Length, new string(reversedSubstring));

                Console.WriteLine(PrintMessage(message));
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        private static void ChangeAllSubstrings(StringBuilder message, string substring, string replacement)
        {
            string convertedMessage = message.ToString();

            if (convertedMessage.Contains(substring))
            {
                message.Replace(substring, replacement);
                Console.WriteLine(PrintMessage(message));
            }
        }

        static void Main()
        {
            StringBuilder message = new StringBuilder(Console.ReadLine());

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Reveal")
                {
                    Console.WriteLine($"You have a new text message: {PrintMessage(message)}");
                    break;
                }
                else
                {
                    switch (command[0])
                    {
                        case "InsertSpace":
                            InsertSpace(message, int.Parse(command[1]));
                            break;
                        case "Reverse":
                            ReverseSubstring(message, command[1]);
                            break;
                        case "ChangeAll":
                            ChangeAllSubstrings(message, command[1], command[2]);
                            break;
                    }
                }
            }
        }
    }
}
