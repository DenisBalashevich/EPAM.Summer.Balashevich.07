using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    class BookSorter
    {
        public static void Sort(Book[] arr, IComparer<Book> comparer)
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
        }

        private static void Swap(ref Book arr1, ref Book arr2)
        {
            var temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
    }
}
