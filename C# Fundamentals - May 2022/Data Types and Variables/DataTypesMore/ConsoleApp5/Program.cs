using System;

namespace ConsoleApp5
{
    class Program
    {
        //5. Decrypting Messages
        //You will receive a key(integer) and n characters afterward. Add the key to each of the characters and append them to a message.
        //At the end print the message which you decrypted.
        //Input
        //•	On the first line, you will receive the key
        //•	On the second line, you will receive n – the number of lines which will follow
        //•	On the next n lines – you will receive lower and uppercase characters from the Latin alphabet
        //Output
        //Print the decrypted message.
        //Constraints
        //•	The key will be in the interval [0…20]
        //•	n will be in the interval [1…20]
        //•	The characters will always be upper or lower-case letters from the English alphabet
        //•	You will receive one letter per line
        //Examples
        //Input Output  Input   Output
        //3     SoftUni 1       Decrypt
        //7             7
        //P             C
        //l             d
        //c             b
        //q             q
        //R             x
        //k             o
        //f             s

        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 1; i <= n; i++)
            {
                char character = char.Parse(Console.ReadLine());
                int charValue = (int)(character) + key;
                message += (char)charValue;
            }

            Console.WriteLine(message);
        }
    }
}
