using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.Mirror_Words
{
    //Mirror words
    //Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
    //Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2307#1.
    //
    //The SoftUni Spelling Bee competition is here. But it`s not like any other Spelling Bee competition out there. It`s different and a lot more fun!
    //You, of course, are a participant, and you are eager to show the competition that you are the best. So go ahead, learn the rules and win!
    //
    //On the first line of the input you will be given a text string.
    //To win the competition you have to find all hidden word pairs, read them, and mark the ones that are mirror images of each other.
    //
    //First, you have to extract the hidden word pairs. Hidden word pairs are:
    //  •	Surrounded by "@" or "#" (only one of the two) in the pattern #wordOne##wordTwo# or @wordOne@@wordTwo@.
    //  •	At least 3 characters long each (without the surrounding symbols).
    //  •	Made up of letters only.
    //
    //If the second word is the same as the first word spelled backward (case sensitive), they are a match and you have to store them somewhere.
    //Examples of mirror words: #Part##traP#, @leveL@@Level@, #sAw##wAs#
    //  •	If you don`t find any valid pairs, print: "No word pairs found!".
    //  •	If you find valid pairs print their count: "{valid pairs count} word pairs found!".
    //  •	If there are no mirror words, print: "No mirror words!".
    //  •	If there are mirror words print:
    //      "The mirror words are:
    //      {wordOne} <=> {wordtwo}, {wordOne} <=> {wordtwo}, … {wordOne} <=> {wordtwo}"
    //
    //Input / Constraints
    //  •	You will recieve a string.
    //Output
    //  •	Print the proper output messages in the proper cases as described in the problem description.
    //  •	If there are pairs of mirror words, print them in the end, each pair separated by ", ".
    //  •	Each pair of mirror word must be printed with " <=> " between the words.
    //
    //Examples
    //Input
    //  @mix#tix3dj#poOl##loOp#wl@@bong&song%4very$long@thong#Part##traP##@@leveL@@Level@##car#rac##tu@pack@@ckap@#rr#sAw##wAs#r#@w1r
    //Output
    //  5 word pairs found!
    //  The mirror words are:
    //  Part <=> traP, leveL <=> Level, sAw <=> wAs
    //Comments
    //  There are 5 green and yellow pairs that meet all requirements and thus are valid. 
    //  #poOl##loOp# is valid and looks very much like a mirror words pair, but it isn`t because the casings don`t match.
    //  #car#rac# "rac" spelled backward is "car", but this is not a valid pair because there is only one "#" between the words.
    //  @pack@@ckap@ is also valid, but "ckap" backward is "pakc" which is not the same as "pack", so they are not mirror words.
    //
    //Input
    //  #po0l##l0op# @bAc##cAB@ @LM@ML@ #xxxXxx##xxxXxx# @aba@@ababa@
    //Output
    //  2 word pairs found!
    //  No mirror words!
    //Comments
    //  "xxxXxx" backward is not the same as "xxxXxx".
    //  @aba@@ababa@ is a valid pair, but the word lengths are different.
    //
    //Input
    //  #lol#lol# @#God@@doG@# #abC@@Cba# @Xyu@#uyX#
    //Output
    //  No word pairs found!
    //  No mirror words!	

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pairPattern = @"(?<splitter>#|@)(?<firstWord>[a-zA-Z]{3,})\k<splitter>\k<splitter>(?<secondWord>[a-zA-Z]{3,})\k<splitter>";

            MatchCollection pairMatches = Regex.Matches(input, pairPattern);

            if (pairMatches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{pairMatches.Count} word pairs found!");
            }

            Dictionary<string, string> mirroredWords = new Dictionary<string, string>();

            foreach (Match pairMatch in pairMatches)
            {
                string firstWord = pairMatch.Groups["firstWord"].Value;
                string secondWord = pairMatch.Groups["secondWord"].Value;

                char[] secondWordReversed = secondWord.ToCharArray();
                Array.Reverse(secondWordReversed);

                if (firstWord == new string(secondWordReversed))
                {
                    mirroredWords.Add(firstWord, secondWord);
                }
            }

            if (mirroredWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");

                int counter = 0;

                foreach (var mirrorMatch in mirroredWords)
                {
                    counter++;

                    if (counter == mirroredWords.Count)
                    {
                        Console.WriteLine($"{mirrorMatch.Key} <=> {mirrorMatch.Value}");
                    }
                    else
                    {
                        Console.Write($"{mirrorMatch.Key} <=> {mirrorMatch.Value}, ");
                    }
                }
            }
        }
    }
}
