using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    //Cards
    //Create a class Card to hold a card’s face and suit.
    //  •	Valid card faces are: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A.
    //  •	Valid card suits are: S (♠), H(♥), D(♦), C(♣).
    //
    //Both face and suit are expected as an uppercase string.
    //The class also needs to have a ToString() method that prints the card’s face and suit as a string in the following format:
    //	"[{face}{suit}]"
    //Use the following UTF code literals to represent the suits:
    //  •	\u2660 – Spades(♠)
    //  •	\u2665 – Hearts(♥)
    //  •	\u2666 – Diamonds(♦)
    //  •	\u2663 – Clubs(♣)
    //
    //Write a program that takes a deck of cards as a string array and prints them as a sequence of cards (space separated).
    //Print an exception message "Invalid card!" when an invalid card definition is passed as input.
    //
    //Input
    //  •	A single line with the faces and suits of the cards in the format:
    //  "{face} {suit}, {face} {suit}, ..."
    //Output
    //  •	Print the list of cards as strings separated by space.
    //Examples
    //Input                                     Output
    //A S, 10 D, K H, 2 C                       [A♠] [10♦] [K♥] [2♣]
    //
    //Input                                     Output
    //5 C, 10 D, king C, K C, Q heart, Q H      Invalid card!
    //                                          Invalid card!
    //                                          [5♣] [10♦] [K♣] [Q♥]

    class Program
    {
        static void Main()
        {
            List<Card> cards = new List<Card>();
            string[] input = Console.ReadLine().Split(", ");

            for (int i = 0; i < input.Length; i++)
            {
                string[] currentCard = input[i].Split(' ');

                try
                {
                    cards.Add(new Card(currentCard[0], currentCard[1]));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(String.Join(' ', cards));
        }
    }

    class Card
    {
        private static readonly string[] VALID_FACES = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private static readonly string[] VALID_SUITS = { "S", "H", "D", "C" };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get { return face; }
            private set
            {
                if (VALID_FACES.Contains(value))
                {
                    face = value;
                }
                else
                {
                    throw new ArgumentException("Invalid card!");
                }
            }
        }

        public string Suit
        {
            get { return suit; }
            private set
            {
                if (VALID_SUITS.Contains(value))
                {
                    suit = value;
                }
                else
                {
                    throw new ArgumentException("Invalid card!");
                }
            }
        }

        private string GetSuit()
        {
            switch (Suit)
            {
                case "S":
                    return "\u2660";
                case "H":
                    return "\u2665";
                case "D":
                    return "\u2666";
                case "C":
                    return "\u2663";
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            return $"[{Face}{GetSuit()}]";
        }
    }
}
