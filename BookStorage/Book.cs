using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    public class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        private int year;
        private int pagesNumber;
        public string Author { get; set; }

        public string Title { get; set; }

        public int Year
        {
            get { return year; }
            set
            {
                if (value < 1500 || value > 2016)
                {
                    throw new ArgumentException();
                }
                year = value;
            }
        }

        public int PagesNumber
        {
            get { return pagesNumber; }
            set
            {
                if (value < 0 || value > 10000)
                    throw new ArgumentException();
                pagesNumber = value;
            }
        }

        public Book(string author, string title, int year, int pages)
        {
            Author = author;
            Title = title;
            Year = year;
            PagesNumber = pages;
        }

        public bool Equals(Book b)
        {
            if (ReferenceEquals(b, null))
                return false;
            if (ReferenceEquals(this, b))
                return true;
            if (!Author.Equals(b.Author) || !Title.Equals(b.Title) || Year != b.Year || PagesNumber != b.PagesNumber)
                return false;
            return true;
        }

        public int CompareTo(Book b)
        {
            if (ReferenceEquals(b, null))
                return -1;
            if (ReferenceEquals(this, b))
                return 1;
            return Author.CompareTo(b.Author);
        }
        int IComparable.CompareTo(object b)
        {
            if (ReferenceEquals(b, null))
                return -1;
            if (ReferenceEquals(this, b))
                return 1;
            return CompareTo((Book)b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() != this.GetType() && Equals((Book)obj);

        }

        public override int GetHashCode() => Author[0] * Author.Length + Title[0] * Title.Length + Year * PagesNumber;

        public override string ToString() => string.Format("{0}: {1}, {2} year, {3} pages", Author, Title, Year, PagesNumber);
    }
}
