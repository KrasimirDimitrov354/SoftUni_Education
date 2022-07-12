using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp11
{
    class Program
    {
        //Shopping List
        //You will receive an initial list with groceries separated by an exclamation mark "!". After that, you will be receiving 4 types of commands until you receive "Go Shopping!".
        //  •	"Urgent {item}" - add the item at the start of the list. If the item already exists, skip this command.
        //  •	"Unnecessary {item}" - remove the item with the given name only if it exists in the list. Otherwise, skip this command.
        //  •	"Correct {oldItem} {newItem}" - if the item with the given old name exists, change its name with the new one. Otherwise, skip this command.
        //  •	"Rearrange {item}" - if the grocery exists in the list, remove it from its current position and add it at the end of the list. Otherwise, skip this command.
        //Constraints
        //  •	There won't be any duplicate items in the initial list
        //Output
        //  •	Print the list with all the groceries, joined by ", ":
        //      "{firstGrocery}, {secondGrocery}, … {nthGrocery}"
        //
        //Examples
        //Input                         Output                      Input                               Output
        //Tomatoes!Potatoes!Bread       Tomatoes, Potatoes, Bread   Milk!Pepper!Salt!Water!Banana       Milk, Onion, Salt, Water, Banana
        //Unnecessary Milk                                          Urgent Salt
        //Urgent Tomatoes                                           Unnecessary Grapes
        //Go Shopping!                                              Correct Pepper Onion
        //                                                          Rearrange Grapes
        //                                                          Correct Tomatoes Potatoes
        //                                                          Go Shopping!

        private static bool ItemChecker(List<string> items, string item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        private static void ModifyGroceries(List<string> groceries, string command, string item)
        {
            switch (command)
            {
                case "Urgent":
                    if (ItemChecker(groceries, item) == false)
                    {
                        groceries.Insert(0, item);
                    }
                    break;
                case "Unnecessary":
                    if (ItemChecker(groceries, item) == true)
                    {
                        groceries.Remove(item);
                    }
                    break;
                case "Rearrange":
                    if (ItemChecker(groceries, item) == true)
                    {
                        groceries.Remove(item);
                        groceries.Add(item);
                    }
                    break;
            }
        }

        private static void CorrectGroceries(List<string> groceries, string oldItem, string newItem)
        {
            if (ItemChecker(groceries, oldItem) == true)
            {
                int index = groceries.IndexOf(oldItem);
                groceries[index] = newItem;
            }
        }

        static void Main()
        {
            List<string> groceries = Console.ReadLine()
                .Split('!')
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Go Shopping!")
                {
                    Console.WriteLine(string.Join(", ", groceries));
                    break;
                }
                else
                {
                    List<string> commands = input.Split(' ').ToList();

                    string command = commands[0];

                    if (command == "Correct")
                    {
                        string oldItem = commands[1];
                        string newItem = commands[2];

                        CorrectGroceries(groceries, oldItem, newItem);
                    }
                    else
                    {
                        string item = commands[1];

                        ModifyGroceries(groceries, command, item);
                    }
                }
            }
        }
    }
}
