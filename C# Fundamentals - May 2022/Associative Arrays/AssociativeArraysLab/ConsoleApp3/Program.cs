using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    //Word Synonyms
    //Create a program which keeps a dictionary with synonyms.
    //The key of the dictionary will be the word. The value will be a list of all the synonyms of that word.
    //
    //You will be given a number n – the count of the words.
    //After each word you will be given a synonym, so the count of lines you have to read from the console is 2 * n.
    //
    //You will be receiving a word and a synonym each on a separate line like this:
    //  •	{ word}
    //  •	{synonym}
    //If you get the same word twice, just add the new synonym to the list.
    //
    //Print the words in the following format:
    //  "{word} - {synonym1, synonym2… synonymN}"
    //Examples
    //Input         Output
    //3             cute - adorable, charming
    //cute          smart - clever
    //adorable
    //cute
    //charming
    //smart
    //clever
    //
    //Input         Output
    //2             task – problem, assignment
    //task
    //problem
    //task
    //assignment  

    class Program
    {
        static void Main()
        {
            byte lines = byte.Parse(Console.ReadLine());

            Dictionary<string, List<string>> collectionOfSynonyms = new Dictionary<string, List<string>>();

            for (byte i = 0; i < lines; i++)
            {
                string currentWord = Console.ReadLine();
                string currentSynonym = Console.ReadLine();

                if (collectionOfSynonyms.ContainsKey(currentWord) == false)
                {
                    collectionOfSynonyms.Add(currentWord, new List<string>());
                }

                collectionOfSynonyms[currentWord].Add(currentSynonym);
            }

            foreach (var synonyms in collectionOfSynonyms)
            {
                Console.WriteLine($"{synonyms.Key} - {string.Join(", ", synonyms.Value)}");
            }
        }
    }
}
