using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.The_Pianist
{
    //The Pianist
    //Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
    //Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2525#2.
    //
    //You are a pianist and you like to keep a list of your favorite piano pieces. Create a program to help you organize it and add, change, remove pieces from it!
    //
    //On the first line of the standard input you will receive an integer n – the number of pieces you will initially have.
    //On the next n lines, you will receive the pieces themselves with their composer and key, separated by "|" in the following format:
    //  "{piece}|{composer}|{key}"
    //
    //Until the "Stop" command is given, you will be receiving different commands. Each will be on a new line, separated by "|":
    //  •	"Add|{piece}|{composer}|{key}":
    //      o You need to add the given piece with the information about it to the other pieces and print:
    //          "{piece} by {composer} in {key} added to the collection!"
    //      o If the piece is already in the collection, print:
    //          "{piece} is already in the collection!"
    //  •	"Remove|{piece}":
    //      o If the piece is in the collection, remove it and print:
    //          "Successfully removed {piece}!"
    //      o Otherwise, print:
    //          "Invalid operation! {piece} does not exist in the collection."
    //  •	"ChangeKey|{piece}|{new key}":
    //      o If the piece is in the collection, change its key with the given one and print:
    //          "Changed the key of {piece} to {new key}!"
    //      o Otherwise, print:
    //          "Invalid operation! {piece} does not exist in the collection."
    //
    //Upon receiving the "Stop" command, you need to print all pieces in your collection in the following format:
    //  "{Piece} -> Composer: {composer}, Key: {key}"
    //
    //Input/Constraints
    //  •	You will receive a single integer at first – the initial number of pieces in the collection
    //  •	For each piece, you will receive a single line of text with information about it.
    //  •	You will receive multiple commands in the way described above until the command "Stop".
    //Output
    //  •	All the output messages with the appropriate formats are described in the problem description.
    //
    //Examples
    //Input                                         Output
    //3                                             Sonata No.2 by Chopin in B Minor added to the collection!
    //Fur Elise|Beethoven|A Minor                   Hungarian Rhapsody No.2 by Liszt in C# Minor added to the collection!
    //Moonlight Sonata|Beethoven|C# Minor           Fur Elise is already in the collection!
    //Clair de Lune|Debussy|C# Minor                Successfully removed Clair de Lune!
    //Add|Sonata No.2|Chopin|B Minor                Changed the key of Moonlight Sonata to C# Major!
    //Add|Hungarian Rhapsody No.2|Liszt|C# Minor    Fur Elise -> Composer: Beethoven, Key: A Minor
    //Add|Fur Elise|Beethoven|C# Minor              Moonlight Sonata -> Composer: Beethoven, Key: C# Major
    //Remove|Clair de Lune                          Sonata No.2 -> Composer: Chopin, Key: B Minor
    //ChangeKey|Moonlight Sonata|C# Major           Hungarian Rhapsody No.2 -> Composer: Liszt, Key: C# Minor
    //Stop
    //
    //Comments
    //We receive the initial pieces with their information.
    //The first two commands are to Add a piece to the collection, and since the pieces are not already added, we add them.
    //The third Add command attempts to add a piece which is already in the collection, so we print a message and don't add the piece.
    //We receive the Remove command and since the piece is in the collection, we remove it.
    //The last command is to Change the key of a piece. Since the key is present in the collection, we modify its key.
    //We receive the Stop command, print the information about the pieces, and the program ends.
    //
    //Input                                         Output
    //4                                             Spring by Vivaldi in E Major added to the collection!
    //Eine kleine Nachtmusik|Mozart|G Major         Successfully removed The Marriage of Figaro!
    //La Campanella|Liszt|G# Minor                  Invalid operation! Turkish March does not exist in the collection.
    //The Marriage of Figaro|Mozart|G Major         Changed the key of Spring to C Major!
    //Hungarian Dance No.5|Brahms|G Minor           Nocturne by Chopin in C# Minor added to the collection!
    //Add|Spring|Vivaldi|E Major                    Eine kleine Nachtmusik -> Composer: Mozart, Key: G Major
    //Remove|The Marriage of Figaro                 La Campanella -> Composer: Liszt, Key: G# Minor
    //Remove|Turkish March                          Hungarian Dance No.5 -> Composer: Brahms, Key: G Minor
    //ChangeKey|Spring|C Major                      Spring -> Composer: Vivaldi, Key: C Major
    //Add|Nocturne|Chopin|C# Minor                  Nocturne -> Composer: Chopin, Key: C# Minor
    //Stop

    class Composition
    {
        public Composition(string piece, string composer, string key)
        {
            this.Piece = piece;
            this.Composer = composer;
            this.Key = key;
        }

        public string Piece { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }       
    }

    class Program
    {
        private static bool PieceExists(string[] pieces, string piece)
        {
            if (pieces.Contains(piece))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            List<Composition> compositions = new List<Composition>();

            for (int i = 0; i < count; i++)
            {
                string[] compositionInfo = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Composition composition = new Composition(compositionInfo[0], compositionInfo[1], compositionInfo[2]);
                compositions.Add(composition);
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Stop")
                {
                    foreach (Composition composition in compositions)
                    {
                        Console.WriteLine($"{composition.Piece} -> Composer: {composition.Composer}, Key: {composition.Key}");
                    }

                    break;
                }
                else
                {
                    string[] pieces = compositions
                        .Select(c => c.Piece)
                        .ToArray();

                    switch (command[0])
                    {
                        case "Add":
                            {
                                Composition composition = new Composition(command[1], command[2], command[3]);

                                if (PieceExists(pieces, composition.Piece))
                                {
                                    Console.WriteLine($"{composition.Piece} is already in the collection!");
                                }
                                else
                                {
                                    Console.WriteLine($"{composition.Piece} by {composition.Composer} in {composition.Key} added to the collection!");
                                    compositions.Add(composition);
                                }

                                break;
                            }                            
                        case "Remove":
                            {
                                string pieceToRemove = command[1];

                                if (PieceExists(pieces, pieceToRemove))
                                {
                                    var compositionToRemove = compositions.SingleOrDefault(c => c.Piece == pieceToRemove);
                                    compositions.Remove(compositionToRemove);
                                    Console.WriteLine($"Successfully removed {pieceToRemove}!");
                                }
                                else
                                {
                                    Console.WriteLine($"Invalid operation! {pieceToRemove} does not exist in the collection.");
                                }

                                break;
                            }                           
                        case "ChangeKey":
                            {
                                string pieceToChange = command[1];
                                string keyToChange = command[2];

                                if (PieceExists(pieces, pieceToChange))
                                {
                                    var compositionToChange = compositions.SingleOrDefault(c => c.Piece == pieceToChange);
                                    compositions[compositions.IndexOf(compositionToChange)].Key = keyToChange;
                                    Console.WriteLine($"Changed the key of {pieceToChange} to {keyToChange}!");
                                }
                                else
                                {
                                    Console.WriteLine($"Invalid operation! {pieceToChange} does not exist in the collection.");
                                }

                                break;
                            }
                    }
                }
            }
        }
    }
}
