class Library
{
    List<string> books = new List<string>();
    List<string> borrowedBooks = new List<string>();
    int booksBorrowed = 0;
    public void AddBook(string book)
    {
        books.Add(book);
    }
    public bool SearchBook(string book)
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
        if (SearchBook(book) && booksBorrowed <= 3)
        {
            borrowedBooks.Add(book);
            books.Remove(book);
            booksBorrowed++;
            System.Console.WriteLine($"You have borrowed: {book}");
        }
        else
        {
            System.Console.WriteLine($"Cannot borrow {book} as it is not available.");
        }
    }
    public static void Main(string[] args)
    {
        Library library = new Library();
        library.AddBook("1984");
        library.AddBook("To Kill a Mockingbird");
        library.AddBook("The Great Gatsby");

        library.SearchBook("1984");
        library.BorrowBook("1984");
        library.BorrowBook("To Kill a Mockingbird");
        library.BorrowBook("The Great Gatsby");
        library.BorrowBook("1984"); // Attempt to borrow again
    }
}