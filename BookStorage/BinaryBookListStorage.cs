using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookStorage
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private string filename = string.Empty;

        public BinaryBookListStorage(string fileName)
        {
            filename = fileName;
        }
        public List<Book> LoadBooks()
        {
            var books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                try
                {
                    while (reader.PeekChar() > -1)
                    {
                        var author = reader.ReadString();
                        var title = reader.ReadString();
                        var year = reader.ReadInt32();
                        var pages = reader.ReadInt32();
                        books.Add(new Book(author, title, year, pages));
                    }
                    return books;
                }
                catch (Exception)
                {
                    throw;
                }

                finally
                {
                    reader.Dispose();
                }
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException();
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate)))
                try
                {
                    foreach (var b in books)
                    {
                        writer.Write(b.Author);
                        writer.Write(b.Title);
                        writer.Write(b.Year);
                        writer.Write(b.PagesNumber);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                finally
                {
                    writer.Dispose();
                }
        }

    }
}
