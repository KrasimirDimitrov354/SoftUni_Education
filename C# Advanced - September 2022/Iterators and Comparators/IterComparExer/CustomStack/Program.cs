using System;
using System.Linq;

namespace CustomStack
{
    //Stack
    //Create your custom stack with your own implementation of the Push and Pop methods.
    //The Push method adds an element at the top of the collection, and the Pop method returns the top element and removes it.
    //
    //Push and Pop will be the only commands and they will come in the following format:
    //  "Push {element1}, {element2}, … {elementN}"
    //  "Pop"
    //
    //Write a custom implementation of Stack<T> and implement IEnumerable<T> interface.
    //The implementation of the GetEnumerator() method should follow the rules of the Abstract Data Type – Stack.
    //In other words, return the elements in reverse order of adding them to the stack.
    //
    //Input
    //  •	The input will come from the console as lines of commands.
    //  •	Push and Pop will be the only possible commands, followed by integers for the Push command and no other input for the Pop command.
    //Output
    //  •	When you receive END, the input is over. Foreach the stack twice and print all elements each on the new line.
    //Constraints
    //  •	The elements in the push command will be valid integers between [2 power -31 … 2 power 31 - 1].
    //  •	The commands will always be valid (always be either Push, Pop, or END).
    //  •	If the Pop command could not be executed as expected (e.g. no elements in the stack), print on the console: "No elements".
    //Examples
    //Input
    //  Push 1, 2, 3, 4
    //  Pop
    //  Pop
    //  END
    //Output
    //  2
    //  1
    //  2
    //  1
    //
    //Input
    //  Push 1, 2, 3, 4 
    //  Pop
    //  Push 1
    //  END
    //Output
    //  1
    //  3
    //  2
    //  1
    //  1
    //  3
    //  2
    //  1
    //
    //Input
    //  Push 1, 2, 3, 4 
    //  Pop
    //  Pop
    //  Pop
    //  Pop
    //  Pop
    //  END
    //Output
    //  No elements

    class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();

            string[] command = GetCommand();

            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Push":
                        {
                            int[] elementsToPush = GetNumbers(command.Skip(1).ToArray());

                            foreach (int element in elementsToPush)
                            {
                                stack.Push(element);
                            }

                            break;
                        }
                    case "Pop":
                        {
                            try
                            {
                                stack.Pop();
                            }
                            catch (InvalidOperationException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }

                            break;
                        }
                }

                command = GetCommand();
            }

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
            
            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
        }

        public static string[] GetCommand()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static int[] GetNumbers(string[] numsRaw)
        {
            return Array.ConvertAll(numsRaw, n => int.Parse(n));
        }
    }
}
