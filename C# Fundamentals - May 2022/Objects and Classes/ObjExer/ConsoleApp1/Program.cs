using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    //Advertisement Message
    //Create a program that generates random fake advertisement messages to advertise a product.
    //The messages must consist of 4 parts: phrase + event + author + city. Use the following predefined parts:
    //  •	Phrases – {"Excellent product.", "Such a great product.", "I always use that product.",
    //              "Best product of its category.", "Exceptional product.", "I can’t live without this product."}
    //  •	Events – {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
    //              "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"}
    //  •	Authors – {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"}
    //  •	Cities – {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"}
    //The format of the output message is the following: "{phrase} {event} {author} – {city}."
    //You will receive the number of messages to be generated. Print each random message at a separate line.
    //Examples
    //Input     Output
    //3	        Such a great product. Now I feel good. Elena – Ruse.
    //          Excellent product. Makes miracles. I am happy of the results! Katya – Varna.
    //          Best product of its category. That makes miracles. Eva – Sofia.

    class Message
    {
        public Message()
        {
            this.Messages = new List<List<string>>();
        }

        public List<List<string>> Messages { get; set; }
    }

    class Program
    {
        static void Main()
        {
            int messagesCount = int.Parse(Console.ReadLine());
            Message message = new Message();

            List<string> phrases = new List<string>
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            List<string> events = new List<string>
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            List<string> authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cities = new List<string> { "- Burgas.", "- Sofia.", "- Plovdiv.", "- Varna.", "- Ruse." };

            message.Messages.Add(phrases);
            message.Messages.Add(events);
            message.Messages.Add(authors);
            message.Messages.Add(cities);

            Random rnd = new Random();

            for (int i = 0; i < messagesCount; i++)
            {
                List<string> currentMessage = new List<string>();

                for (int j = 0; j < message.Messages.Count; j++)
                {
                    int randomIndex = rnd.Next(0, message.Messages[j].Count);

                    string currentPartOfMessage = message.Messages[j][randomIndex];
                    currentMessage.Add(currentPartOfMessage);
                }

                Console.WriteLine(string.Join(' ', currentMessage));
            }
        }
    }

}
