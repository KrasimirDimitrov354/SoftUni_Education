using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    //Word Count
    //Write a program that reads a list of words from a given file (e.g. words.txt) and finds how many times each of the words occurs in another file (e.g. text.txt).
    //Matching should be case-insensitive. The result should be written to an output text file (e.g. output.txt). Sort the words by frequency in descending order.

    public class Word
    {
        public Word(string wordValue, int wordOccurence)
        {
            this.WordValue = wordValue;
            this.WordOccurence = wordOccurence;
        }

        public string WordValue { get; set; }
        public int WordOccurence { get; set; }
    }

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] words = File.ReadAllText(wordsFilePath)
                .ToLower()
                .Split(' ');

            string[] text = File.ReadAllLines(textFilePath);

            List<Word> wordOccurences = new List<Word>();
            Regex regex = new Regex(@"[^a-zA-Z0-9]");

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                Word word = new Word(currentWord, 0);
                wordOccurences.Add(word);

                currentWord = regex.Replace(currentWord, "");

                for (int j = 0; j < text.Length; j++)
                {
                    string currentLine = text[j].ToLower();
                    currentLine = regex.Replace(currentLine, " ");

                    string[] wordsOnLine = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < wordsOnLine.Length; k++)
                    {
                        if (currentWord == wordsOnLine[k])
                        {
                            wordOccurences[i].WordOccurence++;
                        }
                    }
                }
            }

            wordOccurences = wordOccurences
                .OrderByDescending(w => w.WordOccurence)
                .ToList();

            StreamWriter writer = new StreamWriter(outputFilePath);

            using (writer)
            {
                foreach (Word word in wordOccurences)
                {
                    writer.WriteLine($"{word.WordValue} - {word.WordOccurence}");
                }
            }
        }
    }
}
