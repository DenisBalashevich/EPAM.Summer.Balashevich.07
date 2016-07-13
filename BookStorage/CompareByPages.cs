using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    class CompareByPages : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (ReferenceEquals(a, b))
                return 0;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                throw new ArgumentNullException();

            return a.PagesNumber - b.PagesNumber;
        }
    }
}
