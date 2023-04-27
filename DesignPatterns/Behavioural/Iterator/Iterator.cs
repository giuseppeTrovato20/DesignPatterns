using System;
namespace DesignPatterns.Behavioural.Iterator
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    public interface IAggregate<T>
    {
        IIterator<T> GetIterator();
    }


    public class Book
    {
        public string Title { get; set; }

        public Book(string title)
        {
            Title = title;
        }
    }

    public class Library : IAggregate<Book>
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public IIterator<Book> GetIterator()
        {
            return new LibraryIterator(_books);
        }
    }

    public class LibraryIterator : IIterator<Book>
    {
        private readonly List<Book> _books;
        private int _currentIndex;

        public LibraryIterator(List<Book> books)
        {
            _books = books;
            _currentIndex = 0;
        }

        public bool HasNext()
        {
            return _currentIndex < _books.Count;
        }

        public Book Next()
        {
            return HasNext() ? _books[_currentIndex++] : null;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Library library = new Library();
            library.AddBook(new Book("Il nome della rosa"));
            library.AddBook(new Book("1984"));
            library.AddBook(new Book("Il signore degli anelli"));

            IIterator<Book> iterator = library.GetIterator();

            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Title);
            }
        }
    }
}

