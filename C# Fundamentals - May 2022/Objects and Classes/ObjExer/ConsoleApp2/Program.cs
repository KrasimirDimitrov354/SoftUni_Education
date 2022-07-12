using System;
using System.Linq;

namespace ConsoleApp2
{
    //Articles
    //Create a class Article with the following properties:
    //  •	Title – a string
    //  •	Content – a string
    //  •	Author – a string
    //The class should have a constructor and the following methods:
    //  •	Edit (new content) – change the old content with the new one
    //  •	ChangeAuthor (new author) – change the author
    //  •	Rename (new title) – change the title of the article
    //  •	Override the ToString method – print the article in the following format: 
    //      "{title} - {content}: {author}"
    //Create a program that reads an article in the following format "{title}, {content}, {author}".
    //On the next line, you will receive a number n representing the number of commands which will follow after it.
    //On the next n lines, you will be receiving the following commands: 
    //  •	"Edit: {new content}"
    //  •	"ChangeAuthor: {new author}"
    //  •	"Rename: {new title}"
    //In the end, print the final state of the article.
    //Example
    //Input                                                     Output
    //some title, some content, some author                     better title - better content: better author
    //3
    //Edit: better content
    //ChangeAuthor:  better author
    //Rename: better title
    //Input                                                     Output
    //Fight club, love story, Martin Scorsese                   Fight club - underground fight club that evolves into much more: Chuck Palahniuk
    //2
    //Edit: underground fight club that evolves into much more
    //ChangeAuthor: Chuck Palahniuk

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void EditContent(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void RenameTitle(string newTitle)
        {
            this.Title = newTitle;
        }

        public new void ToString()
        {
            Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
        }
    }

    class Program
    {
        private static void EditArticle(Article article, string command, string change)
        {
            switch (command)
            {
                case "Edit":
                    article.EditContent(change);
                    break;
                case "ChangeAuthor":
                    article.ChangeAuthor(change);
                    break;
                case "Rename":
                    article.RenameTitle(change);
                    break;
            }
        }

        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();
            int commandsCount = int.Parse(Console.ReadLine());

            Article article = new Article(input[0], input[1], input[2]);

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commands = Console.ReadLine().Split(": ").ToArray();

                EditArticle(article, commands[0], commands[1]);
            }

            article.ToString();
        }
    }
}
