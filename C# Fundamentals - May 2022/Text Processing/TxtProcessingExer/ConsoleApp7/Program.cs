using System;
using System.Text;

namespace ConsoleApp7
{
    //String Explosion
    //Explosions are marked with '>'. Immediately after the mark there will be an integer which signifies the strength of the explosion.
    //You should remove x characters (where x is the strength of the explosion), starting after the explosion mark ('>').
    //If you find another explosion mark ('>') while you’re deleting characters, you should add the strength to your previous explosion.
    //When all characters are processed, print the string without the deleted characters.
    //You should not delete the explosion character – '>', but you should delete the integers which represent the strength.
    //
    //Input
    //  You will receive a single line with the string.
    //Output
    //  Print what is left from the string after explosions.
    //Constraints
    //  •	You will always receive strength for the explosions
    //  •	The path will consist only of letters from the Latin alphabet, integers, and the char '>'
    //  •	The strength of the explosions will be in the interval [0…9]
    //Examples
    //Input                 Output              Comments
    //abv>1>1>2>2asdasd     abv>>>>dasd	        1st explosion is at index 3 and it is with a strength of 1.
    //                                          We delete only the digit after the explosion character. We receive the string abv>>1>2>2asdasd.
    //                                          2nd explosion is with strength one and we transform the string to abv>>>2>2asdasd.
    //                                          3rd explosion is now with a strength of 2. We delete the digit and we find another explosion.
    //                                          At this point, the string is abv>>>>2asdasd.
    //                                          4th explosion is with strength 2. We have 1 strength left from the previous explosion.
    //                                          We add the strength of the current explosion to what is left, and that adds up to a total strength of 3.
    //                                          We delete the next three characters and we receive the string abv>>>>dasd.
    //                                          We do not have any more explosions and we print the result.
    //
    //Input                                     Output
    //peter>2sis>1a>2akarate>4hexmaster         peter>is>a>karate>master

    class Program
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder( Console.ReadLine() );

            for (int i = 0; i < input.Length; i++)
            {
                int explosionStrength = 0;

                if (input[i] == '>')
                {
                    explosionStrength = int.Parse(input[i + 1].ToString());

                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (explosionStrength == 0)
                        {
                            break;
                        }


                        if (input[j] == '>')
                        {
                            explosionStrength += int.Parse(input[j + 1].ToString());
                            i += 2;
                        }
                        else
                        {
                            input.Remove(j, 1);
                            explosionStrength--;
                            j--;
                        }
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}
