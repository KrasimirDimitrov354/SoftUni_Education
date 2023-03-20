namespace BookShop;

using System;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        //2. Age Restriction
        //string ageRestriction = Console.ReadLine()!;
        //Console.WriteLine(GetBooksByAgeRestriction(db, ageRestriction));

        //3. Golden Books
        //Console.WriteLine(GetGoldenBooks(db));

        //4. Books by Price
        //Console.WriteLine(GetBooksByPrice(db));

        //5. Not Released In
        //int year = int.Parse(Console.ReadLine()!);
        //Console.WriteLine(GetBooksNotReleasedIn(db, year));

        //6. Book Titles by Category
        //string categories = Console.ReadLine()!;
        //Console.WriteLine(GetBooksByCategory(db, categories));

        //7. Released Before Date - 25/100
        //string date = Console.ReadLine()!;
        //Console.WriteLine(GetBooksReleasedBefore(db, date));

        //8. Author Search
        //string authorFirstNameToEndWith = Console.ReadLine()!;
        //Console.WriteLine(GetAuthorNamesEndingIn(db, authorFirstNameToEndWith));

        //9. Book Search
        //string bookTitleToEndWith = Console.ReadLine()!;
        //Console.WriteLine(GetBookTitlesContaining(db, bookTitleToEndWith));

        //10. Book Search by Author
        //string authorLastNameToEndWith = Console.ReadLine()!;
        //Console.WriteLine(GetBooksByAuthor(db, authorLastNameToEndWith));

        //11. Count Books
        //int lengthCheck = int.Parse(Console.ReadLine()!);
        //Console.WriteLine(CountBooks(db, lengthCheck));

        //12. Total Book Copies
        Console.WriteLine(CountCopiesByAuthor(db));
    }

    //2. Age Restriction
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        string[] ageRestrictedBooks = context.Books
            .ToArray()
            .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray();

        return String.Join(Environment.NewLine, ageRestrictedBooks);
    }

    //3. Golden Books
    public static string GetGoldenBooks(BookShopContext context)
    {
        string[] goldenBooks = context.Books
            .Where(b => (int)b.EditionType == 2 && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, goldenBooks);
    }

    //4. Books by Price
    public static string GetBooksByPrice(BookShopContext context)
    {
        var booksOver40USD = context.Books
            .Where(b => b.Price > 40.0m)
            .OrderByDescending(b => b.Price)
            .Select(b => new
            {
                TitleAndPrice = String.Concat(b.Title, " - $", b.Price.ToString("f2"))
            })
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var b in booksOver40USD)
        {
            output.AppendLine(b.TitleAndPrice);
        }

        return output.ToString().TrimEnd();
    }

    //5. Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        string[] books = context.Books
            .Where(b => b.ReleaseDate!.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, books);
    }

    //6. Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToArray();

        string[] booksByCategories = context.Books
            .Where(b => categories.Contains(b.BookCategories
                                  .Select(bc => bc.Category.Name.ToLower())
                                  .First()))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray();

        return String.Join(Environment.NewLine, booksByCategories);
    }

    //7. Released Before Date - 25/100
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        StringBuilder output = new StringBuilder();

        if (DateTime.TryParse(date, out DateTime convertedDate))
        {
            var booksBefore = context.Books
                .Where(b => b.ReleaseDate != null &&
                            DateTime.Compare(b.ReleaseDate!.Value, convertedDate) < 0)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var b in booksBefore)
            {
                output.AppendLine($"{b.Title} - {b.EditionType} - ${Math.Round(b.Price, 2):f2}");
            }
        }

        return output.ToString().TrimEnd();
    }

    //8. Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authors = context.Authors
            .AsNoTracking()
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => new
            {
                FullName = String.Concat(a.FirstName, " ", a.LastName)
            })
            .OrderBy(a => a.FullName)
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var a in authors)
        {
            output.AppendLine(a.FullName);
        }

        return output.ToString().TrimEnd();
    }

    //9. Book Search
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        string[] books = context.Books
            .AsNoTracking()
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray();

        return String.Join(Environment.NewLine, books);
    }

    //10. Book Search by Author
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                TitleAndAuthor = $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})"
            })
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var b in books)
        {
            output.AppendLine(b.TitleAndAuthor);
        }

        return output.ToString().TrimEnd();
    }

    //11. Count Books
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        int booksCount = context.Books
            .AsNoTracking()
            .Where(b => b.Title.Length > lengthCheck)
            .ToArray()
            .Count();

        return booksCount;
    }

    //12. Total Book Copies
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var totalCopies = context.Authors
            .AsNoTracking()
            .ToArray()
            .Select(a => new
            {
                FullName = $"{a.FirstName} {a.LastName}",
                TotalCopies = a.Books.Select(b => b.Copies)
            })
            //.OrderByDescending(b => b.TotalCopies)
            .ToArray();


        Console.WriteLine();
        throw new NotImplementedException();
    }
}
