using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer9
{
    //Simple Text Editor
    //You are given an empty text. Your task is to implement 4 commands related to manipulating the text:
    //  •	1 {string} - appends a string to the end of the text.
    //  •	2 {count} - erases the last count elements from the text.
    //  •	3 {index} - returns the element at position index from the text.
    //  •	4 - undoes the last not undone command of type 1 or 2 and returns the text to the state before that operation
    //
    //Input
    //  •	The first line contains n - the number of operations.
    //  •	Each of the following n lines contains the name of the operation followed by the command argument, if any, separated by space in the following format: "CommandName Argument".
    //Output
    //  •	For each operation of type 3 print a single line with the returned character of that operation.
    //Constraints
    //  •	1 ≤ N ≤ 105
    //  •	The length of the text will not exceed 1000000.
    //  •	All input characters are English letters.
    //  •	It is guaranteed that the sequence of input operations is possible to perform.
    //
    //Examples
    //Input     Output      Explanation
    //8         c           In the first operation we append 'abc' to the empty text.
    //1 abc     y           Then we print its 3rd character - 'c'.
    //3 3       a           Next we erase its last 3 characters - 'abc'. The text becomes empty.
    //2 3                   After that we append 'xy' to the empty text.
    //1 xy                  Then we print the 2nd character of the text - 'y'.
    //3 2                   After that we undo the last update to the text, so it becomes empty again.
    //4                     With the next operation we undo the update before that, so the text becomes 'abc' again.
    //4                     Finally we print the 1st character, which at this point is 'a'.
    //3 1
    //
    //Input             Output
    //9                 h
    //1 HelloThere      o
    //3 7               h
    //2 2               P
    //3 5
    //4
    //3 7
    //4
    //1 TestPassed
    //3 5

    class Program
    {
        static void Main()
        {
            int countOperations = int.Parse(Console.ReadLine());
            Stack<string> stackOfStrings = new Stack<string>();

            for (int i = 0; i < countOperations; i++)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();

                switch (command[0])
                {
                    case "1":
                        string currentString = command[1];

                        if (stackOfStrings.Count == 0)
                        {
                            stackOfStrings.Push(currentString);
                        }
                        else
                        {
                            string newString = stackOfStrings.Peek() + currentString;
                            stackOfStrings.Push(newString);
                        }
                        break;
                    case "2":
                        int removeCount = int.Parse(command[1]);
                        string currentStackString = stackOfStrings.Peek();
                        stackOfStrings.Push(currentStackString.Substring(0, currentStackString.Length - removeCount));
                        break;
                    case "3":
                        int index = int.Parse(command[1]);
                        Console.WriteLine(stackOfStrings.Peek()[index - 1]);
                        break;
                    case "4":
                        stackOfStrings.Pop();
                        break;
                }
            }
        }
    }
}
