namespace ooptask
{

    class Book
    {
        string title;
        string author;
        string ISBN;
        bool availability;

        public Book(string title, string author, string ISBN, bool availability = true)
        {
            this.title = title;
            this.author = author;
            this.ISBN = ISBN;
            this.availability = availability;
        }

        public string Title
        {
            get => this.title;
            set => this.title = value;
        }

        public string Author
        {
            get => this.author;
            set => this.author = value;
        }

        public string I_S_B_N
        {
            get => this.ISBN;
            set => this.ISBN = value;
        }

        public bool Availability
        {
            get => this.availability;
            set => this.availability = value;
        }



    }

    class Library
    {
        List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {

            books.Add(book);
        }

        public bool SearchBook(string title, string author, string ISBN)
        {
            for (int i = 0; i < books.Count; i++)
            {

                if (books[i].Title == title && books[i].Author == author && books[i].I_S_B_N == ISBN && books[i].Availability == true)
                {
                    Console.WriteLine($"book {books[i].Title} is available u can borrow it");
                    return true;
                }
            }
            Console.WriteLine($"book with tiltle = {title} is not available in library ");
            return false;
        }

        public bool BorrowBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == title && books[i].Availability == true)
                {
                    Console.WriteLine($"book {books[i].Title} is available u can borrow it");
                    books[i].Availability = false;
                    return true;
                }
            }
            Console.WriteLine($"book {title} is not available in lib");
            return false;

        }

        public bool ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == title && books[i].Availability == false)
                {
                    Console.WriteLine($"book {books[i].Title} is returned successfully");
                    books[i].Availability = true;
                    return true;
                }
            }
            Console.WriteLine($"book {title} is not borrowed");
            return false;

        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {


            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}

