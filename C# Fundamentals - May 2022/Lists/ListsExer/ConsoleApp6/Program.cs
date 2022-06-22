using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
        //Cards Game
        //You will be given two hands of cards, which will be represented by integers. Assume each one is held by a different player.
        //You have to find which one has the winning deck. You start from the beginning of both hands of cards.
        //
        //Compare the cards from the first deck to the cards from the second deck.
        //The player who holds the more powerful card on the current iteration takes both cards and puts them at the back of his hand.
        //The second player's card is placed last and the first person's card (the winning one) comes before it (second to last).
        //If both players' cards have the same values, no one wins and the two cards must be removed from both hands.
        //
        //The game is over when only one of the decks is left without any cards.
        //You have to display the result on the console and the sum of the remaining cards: "{First/Second} player wins! Sum: {sum}".
        //Examples
        //Input             Output                          Input               Output
        //20 30 40 50       First player wins! Sum: 240     10 20 30 40 50      Second player wins! Sum: 50
        //10 20 30 40                                       50 40 30 30 10	

        static void Main()
        {
            List<int> playerOneDeck = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();
            List<int> playerTwoDeck = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

            while (true)
            {
                if (playerOneDeck.Count == 0 || playerTwoDeck.Count == 0)
                {
                    int deckSum = 0;
                    if (playerOneDeck.Count != 0)
                    {
                        foreach (int card in playerOneDeck)
                        {
                            deckSum += card;
                        }

                        Console.WriteLine($"First player wins! Sum: {deckSum}");
                    }
                    else
                    {
                        foreach (int card in playerTwoDeck)
                        {
                            deckSum += card;
                        }

                        Console.WriteLine($"Second player wins! Sum: {deckSum}");
                    }

                    break;
                }
                else
                {
                    int playerOneCard = playerOneDeck[0];
                    int playerTwoCard = playerTwoDeck[0];

                    if (playerOneCard > playerTwoCard)
                    {
                        playerOneDeck.Add(playerOneCard);
                        playerOneDeck.Add(playerTwoCard);
                    }
                    else if (playerTwoCard > playerOneCard)
                    {
                        playerTwoDeck.Add(playerTwoCard);
                        playerTwoDeck.Add(playerOneCard);
                    }

                    playerOneDeck.RemoveAt(0);
                    playerTwoDeck.RemoveAt(0);
                }
            }
        }
    }
}
