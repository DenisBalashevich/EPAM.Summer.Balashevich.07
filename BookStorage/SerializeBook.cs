using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    public class SerializeBook : IBookListStorage
    {
        private string filename;


        public SerializeBook(string filename)
        {
            this.filename = filename;
        }


        public void SaveBooks(IEnumerable<Book> items)
        {
            FileMode fileMode = File.Exists(filename) ? FileMode.Open : FileMode.Create;
            var formatter = new BinaryFormatter();
            using (var s = new FileStream(filename, fileMode))
            {
                formatter.Serialize(s, items);
            }

        }

        List<Book> IBookListStorage.LoadBooks()
        {
            var books = new List<Book>();
            var formatter = new BinaryFormatter();
            using (var s = new FileStream(filename, FileMode.Open))
            {
                books = (List<Book>)formatter.Deserialize(s);
            }
            return books;
        }
    }
}
