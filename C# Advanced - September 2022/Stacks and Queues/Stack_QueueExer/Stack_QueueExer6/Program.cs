using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer6
{
    //Songs Queue
    //Write a program that keeps track of a song's queue. The first song that is put in the queue should be the first that gets played. A song cannot be added if it is currently in the queue.
    //
    //You will be given a sequence of songs separated by a comma and a single space. After that you will be given commands until there are no songs enqueued.
    //When there are no more songs in the queue print "No more songs!" and stop the program.
    //
    //The possible commands are:
    //  •	"Play" - plays a song and removes it from the queue.
    //  •	"Add {song}" - adds the song to the queue if it isn’t contained already, otherwise print "{song} is already contained!".
    //  •	"Show" - prints all songs in the queue separated by a comma and a white space. Start from the first song in the queue to the last.
    //
    //Input
    //  •	On the first line you will be given a sequence of strings separated by a comma and a white space.
    //  •	On the next lines you will be given commands until there are no songs in the queue.
    //Output
    //  •	Print the proper messages described above while receiving the commands.
    //  •	Print the songs from the first to the last after the command "Show".
    //Constraints
    //  •	The input will always be valid and in the formats described above.
    //  •	There might be commands even after there are no songs in the queue. Ignore them.
    //  •	There will never be duplicate songs in the initial queue.
    //Examples
    //Input                         Output
    //All Over Again, Watch Me      Watch Me is already contained!
    //Play                          Watch Me, Love Me Harder, Promises
    //Add Watch Me                  No more songs!
    //Add Love Me Harder
    //Add Promises
    //Show
    //Play
    //Play
    //Play
    //Play

    class Program
    {
        static void Main()
        {
            Queue<string> queueOfSongs = new Queue<string>(Console.ReadLine()
                .Split(", ")
                .ToList());

            while (queueOfSongs.Count > 0)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();

                switch (command[0])
                {
                    case "Play":
                        queueOfSongs.Dequeue();
                        break;
                    case "Add":
                        string song = String.Join(' ', command, 1, command.Length - 1);

                        if (queueOfSongs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            queueOfSongs.Enqueue(song);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", queueOfSongs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
