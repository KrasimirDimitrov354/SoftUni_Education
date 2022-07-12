using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatLogger
{
    //Input
    //  •	The possible commands are:
    //      o	"Chat {message}"
    //      o	"Delete {message}"
    //      o	"Edit {message} {editedVersion}"
    //      o	"Pin {message}"
    //      o	"Spam {message1} {message2} {messageN}"
    //      o	"end"
    //Examples
    //Input                   Input               Input
    //Chat Hello              Chat Hello          Chat John
    //Chat darling            Delete John         Spam Let's go to the zoo
    //Edit darling Darling    Pin Hi              Edit zoo cinema
    //Spam how are you        end                 Chat tonight
    //Delete Darling                              Pin John
    //end                                         end
    //Output                  Output              Output
    //Hello                   Hello               Let's
    //how                                         go
    //are                                         to
    //you                                         the
    //                                            cinema
    //                                            tonight
    //                                            John


    class Program
    {
        private static void ModifyMessageHistory(List<string> messageHistory, string command, string message)
        {
            if (command == "Chat")
            {
                messageHistory.Add(message);
            }
            else
            {
                for (int i = 0; i < messageHistory.Count; i++)
                {
                    string currentMessage = messageHistory[i];

                    if (currentMessage == message)
                    {
                        if (command == "Pin")
                        {
                            messageHistory.Add(message);
                        }

                        messageHistory.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private static void EditMessageHistory(List<string> messageHistory, string originalMessage, string modifiedMessage)
        {
            for (int i = 0; i < messageHistory.Count; i++)
            {
                string currentMessage = messageHistory[i];

                if (currentMessage == originalMessage)
                {
                    messageHistory[i] = modifiedMessage;
                }
            }
        }

        private static void SpamMessages(List<string> messageHistory, List<string> spam)
        {
            for (int i = 0; i < spam.Count; i++)
            {
                messageHistory.Add(spam[i]);
            }
        }

        static void Main()
        {
            List<string> messageHistory = new List<string>();

            while (true)
            {
                List<string> commands = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                string command = commands[0];

                if (command == "end")
                {
                    foreach (string message in messageHistory)
                    {
                        Console.WriteLine(message);
                    }

                    break;
                }
                else
                {
                    switch (command)
                    {
                        case "Chat":
                        case "Delete":
                        case "Pin":
                            string message = commands[1];
                            ModifyMessageHistory(messageHistory, command, message);
                            break;
                        case "Edit":
                            string originalMessage = commands[1];
                            string modifiedMessage = commands[2];
                            EditMessageHistory(messageHistory, originalMessage, modifiedMessage);
                            break;
                        case "Spam":
                            List<string> spam = commands.GetRange(1, commands.Count - 1);
                            SpamMessages(messageHistory, spam);
                            break;
                    }
                }
            }
        }
    }
}
