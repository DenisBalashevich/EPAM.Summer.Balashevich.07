using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    /// <summary>
    /// Class for work with books
    /// </summary>
    public class BookListService
    {
        public List<Book> bookList { get; }

        #region ctors
        public BookListService()
        {
            bookList = new List<Book>();
        }

        public BookListService(List<Book> books)
        {
            if (ReferenceEquals(books, null))
                bookList = new List<Book>();
            else bookList = books;
        }
        #endregion

        /// <summary>
        /// Add book in collection
        /// </summary>
        /// <param name="book">book</param>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();
            if (bookList.Contains(book))
                throw new ArgumentException("This book already have been added");
            bookList.Add(book);
        }

        /// <summary>
        /// Add collection of books
        /// </summary>
        /// <param name="books">books collection</param>
        public void AddBook(List<Book> books)
        {
            if (ReferenceEquals(books, null))
                throw new ArgumentNullException();
            foreach (var b in books)
                if (bookList.Contains(b))
                    throw new ArgumentException("This book already have been added");
            bookList.AddRange(books);
        }

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();
            if (!bookList.Contains(book))
                throw new ArgumentException("This book collection doesn't have that book");
            bookList.Remove(book);
        }

        /// <summary>
        /// Remove book collection
        /// </summary>
        /// <param name="books"></param>
        public void RemoveBook(List<Book> books)
        {
            if (ReferenceEquals(books, null))
                throw new ArgumentNullException();
            foreach (var b in books)
                RemoveBook(b);
        }

        /// <summary>
        /// find books by tag
        /// </summary>
        /// <param name="match">tag</param>
        /// <returns>all finding books</returns>
        public List<Book> FindBookByTag(Predicate<Book> match) => bookList.FindAll(match);

        /// <summary>
        /// Sort by tag
        /// </summary>
        /// <param name="comparer"></param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                bookList.Sort();
            else bookList.Sort(comparer);
        }

        /// <summary>
        /// sort by tag
        /// </summary>
        /// <param name="comparer"></param>
        public void SortBooksByTag(Comparison<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                bookList.Sort();
            else bookList.Sort(comparer);
        }

    }
}
