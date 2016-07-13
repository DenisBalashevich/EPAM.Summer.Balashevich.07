using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    public class Book : IEquatable<Book>, IComparable<Book>
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
                year = Year;
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
            int n = Author.CompareTo(b.Author);
            if (n != 0)
                return n;
            n = Title.CompareTo(b.Title);
            if (n != 0)
                return n;
            if (Year - b.Year != 0)
                return Year - b.Year;
            else return PagesNumber - b.PagesNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(this, obj))

                if (obj.GetType() != this.GetType())
                    return false;

            return Equals((Book)obj);

        }

        public override int GetHashCode() => Author[0] * Author.Length + Title[0] * Title.Length + Year * PagesNumber;

        public override string ToString() => string.Format("{0}: {1}, {2} year, {3} pages", Author, Title, Year, PagesNumber);

        public static Book[] Sort(Book[] arr, IComparer<Book> comparer)
        {
            foreach (var a in arr)
            {
                if (a == null)
                    throw new ArgumentNullException();
            }
            if (comparer == null)
                throw new ArgumentNullException();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (comparer.Compare(arr[i], arr[j]) > 0)
                    {
                        Swap(ref arr[i], ref arr[j]);
                    }
                }
            }
            return arr;
        }

        private static void Swap(ref Book arr1, ref Book arr2)
        {
            var temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
    }
}
