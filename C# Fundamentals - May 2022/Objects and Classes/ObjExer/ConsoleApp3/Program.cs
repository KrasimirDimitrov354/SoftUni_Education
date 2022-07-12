using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    //Articles 2.0
    //Change the program in such a way that you will be able to store a list of articles.
    //You will not need to use the previous methods anymore (except the ToString()).
    //
    //On the first line you will receive the number of articles.
    //On the next lines you will receive the articles in the same format as in the previous problem:
    //  "{title}, {content}, {author}"
    //
    //Finally, you will receive a string:
    //  "title", "content" or an "author"
    //
    //Print the articles.
    //Example
    //Input   
    //  2
    //  Science, planets, Bill
    //  Article, content, Johnny
    //  title
    //Output
    //  Science - planets: Bill
    //  Article - content: Johnny
    //
    //Input
    //  3
    //  title1, C, author1
    //  title2, B, author2
    //  title3, A, author3
    //  content
    //Output
    //  title1 - C: author1
    //  title2 - B: author2
    //  title3 - A: author3

    class Articles
    {
        public Articles()
        {
            this.Article = new List<Article>();
        }

        public List<Article> Article { get; set; }

        public List<Article> Sort(string sorter)
        {
            List<Article> sortedArticles = new List<Article>();

            switch (sorter)
            {
                case "title":
                    sortedArticles = this.Article.OrderByDescending(a => a.Title).ToList();
                    break;
                case "content":
                    sortedArticles = this.Article.OrderByDescending(a => a.Content).ToList();
                    break;
                case "author":
                    sortedArticles = this.Article.OrderByDescending(a => a.Author).ToList();
                    break;
            }

            return sortedArticles;
        }
    }

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

        public new void ToString()
        {
            Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
        }
    }

    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            Articles articles = new Articles();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                Article article = new Article(input[0], input[1], input[2]);
                articles.Article.Add(article);
            }

            for (int i = 0; i < articles.Article.Count; i++)
            {
                articles.Article[i].ToString();
            }

            //string sorter = Console.ReadLine();
            //List<Article> sortedArticles = articles.Sort(sorter);
            //
            //foreach (Article article in sortedArticles)
            //{
            //    article.ToString();
            //}
        }
    }
}
