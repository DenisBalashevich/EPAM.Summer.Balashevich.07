using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStorage
{
    class XMLBook: IBookListStorage
    {
        private string filename;

        public XMLBook(string filename)
        {
            this.filename = filename;
        }



        public void SaveBooks(IEnumerable<Book> items)
        {
            var xml = new XElement("Books",
                items.Select((book) => new XElement("Book",
                    new XElement("author", book.Author),
                    new XElement("title", book.Title),
                    new XElement("year", book.Year),
                    new XElement("pages", book.PagesNumber))));
            xml.Save(filename);
        }

        List<Book> IBookListStorage.LoadBooks()
        {
            var books = new List<Book>();
            if (!File.Exists(filename))
                return books;
            var document = XDocument.Load(filename);
            foreach (var book in document.Root.Elements("Book"))
            {
                books.Add(new Book(book.Element("author").Value, book.Element("title").Value, int.Parse(book.Element("year").Value), int.Parse(book.Element("pages").Value)));
            }
            return books;
        }
    }
}
