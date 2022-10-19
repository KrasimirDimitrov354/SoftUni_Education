using System;

namespace IteratorsAndComparators
{
    //Library
    //Create a class Book with three public properties:
    //  •	string Title
    //  •	int Year
    //  •	List<string> Authors
    //
    //Authors can be anonymous, one or many. A Book must have only one constructor.
    //
    //Create a class Library, which should store a collection of books and implement the IEnumerable<Book> interface.
    //Add the private property List<Book> books.
    //
    //A Library must be able to be initialized without books or with any number of books, and must have only one constructor.
    //
    //Create a nested class LibraryIterator inside the Library class and implement it with the IEnumerator<Book> interface.
    //You will need two more properties:
    //  •	List<Book> books
    //  •	int currentIndex
    //
    //Implement the IComparable<Book> interface in the existing class Book. The comparison between the two books should happen in the following order:
    //  •	First, sort them in ascending chronological order(by year).
    //  •	If two books are published in the same year, sort them alphabetically.
    //Have your Library class store the books in the correct order.
    //
    //Override the ToString() method in your Book class so it returns a string in the format:
    //  •	"{title} - {year}"
    //
    //Create a class BookComparator that implements the IComparer<Book> interface and thus include the following method: 
    //  •	int Compare(Book, Book)
    //BookComparator must compare two books by:
    //  1.	Book title - alphabetical order.
    //  2.	Year of publishing a book - from the newest to the oldest.
    //
    //Modify your Library class once again to implement the new sorting.

    public class StartUp
    {
        static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
