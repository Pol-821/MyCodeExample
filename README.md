# public class Library
{
    // This class represents a simple library system.
    // It allows adding, searching, and borrowing books.
    List<string> books = new List<string>();
    List<string> borrowedBooks = new List<string>();
    int booksBorrowed = 0;
    public void AddBook(string book)
    {
        books.Add(book);
    }
    public bool SearchBook(string book)
    // This method checks if a book is in the library's collection.
    // It returns true if the book is found, otherwise false.
    {
        if (books.Contains(book))
        {
            System.Console.WriteLine($"Book found: {book}");
            return true;
        }
        else
        {
            System.Console.WriteLine($"Book not found: {book}");
            return false;
        }
    }

    public void BorrowBook(string book)
    {
        // This method allows borrowing a book if it exists in the library and the user has not borrowed more than 3 books.
        // If the book is not found, it will be added to the borrowed list and removed from the library's collection.
        // If the user has borrowed 3 books, it will not allow borrowing more.
        bool found = SearchBook(book);
        if (found && booksBorrowed <= 3)
        {
            borrowedBooks.Add(book);
            books.Remove(book);
            booksBorrowed++;
            System.Console.WriteLine($"You have borrowed: {book}");
        }
        else if (!found && borrowedBooks.Contains(book))
        {
            books.Add(book);
            borrowedBooks.Remove(book);
            booksBorrowed--;
            System.Console.WriteLine($"You have returned: {book}");
        }
        else
        {
            System.Console.WriteLine("You cannot borrow more than 3 books at a time or the book don't exist");
        }
        {
            
        }
    }
    public static void Main(string[] args)
    {
        // This is the main entry point of the program.
        // It creates an instance of the Library class and provides a simple command-line interface for interacting
        Library library = new Library();
        while (true)
        {
            System.Console.WriteLine("Enter a command ((1)=>add,(2)=> search,(3)=> borrow,(4)=> borrowNumber,(5)=> exit):");
            string command = System.Console.ReadLine();
            if (command == "5")
            {
                break;
            }
            else if (command == "1")
            {
                System.Console.WriteLine("Enter book name to add:");
                string bookName = System.Console.ReadLine();
                library.AddBook(bookName);
                System.Console.WriteLine($"Added book: {bookName}");
            }
            else if (command == "2")
            {
                System.Console.WriteLine("Enter book name to search:");
                string bookName = System.Console.ReadLine();
                library.SearchBook(bookName);
            }
            else if (command == "3")
            {
                System.Console.WriteLine("Enter book name to borrow:");
                string bookName = System.Console.ReadLine();
                library.BorrowBook(bookName);
            }
            else if (command == "4")
            {
                System.Console.WriteLine($"Total books borrowed: {library.booksBorrowed}");
                System.Console.WriteLine("Borrowed books:");
                foreach (var book in library.borrowedBooks)
                {
                    System.Console.WriteLine(book);
                }
            }
            else
            {
                System.Console.WriteLine("Unknown command.");
            }
        }
    }
}
