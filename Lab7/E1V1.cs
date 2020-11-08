using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab7
{
    class Book
    {
        string title;
        string author;
        uint pages;

        public Book():this("null", "null", 0) {}

        public Book(string title, string author, uint pages)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
        }

        public string Title {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public uint Pages
        {
            get { return pages; }
            set {
                if(pages == 0) throw new ArgumentOutOfRangeException("'Pages' should be > 0");
                pages = value;
            }
        }

        public void SaveTo(string path)
        {
            using (StreamWriter ma = new StreamWriter(path))
            {
                ma.Write(ToString());
            }
        }

        public override string ToString()
        {
            return string.Format("author: {0}, title: {1}, pages: {2}, identifier: {3}", author, title, pages, Identifier);
        }

        public static string ToString(List<Book> books)
        {
            string res = "";
            foreach (var b in books) res += b + "\n";
            return res;
        }

        public static List<Book> operator + (Book o, Book other)
        {
            var l = new List<Book>();
            l.Add(o);
            l.Add(other);
            return l;
        }

        private string Identifier
        {
            get { return title + "_" + author + "_" + pages; }
        }

        public static bool operator > (Book o, Book other)
        {
            return string.Compare(o.Identifier, other.Identifier) > 0;
        }

        public static bool operator < (Book o, Book other)
        {
            return string.Compare(o.Identifier, other.Identifier) < 0;
        }
    }
    class E1V1
    {
        static void Main(string[] args)
        {
            Book def = new Book();
            Book lotr = new Book("the Lord of The Rings", "J.R.R. Tolkien", 0);

            List<Book> books = def + lotr;
            Console.WriteLine("sum type: " + books);
            Console.WriteLine("books in list:\n" + Book.ToString(books));

            Console.WriteLine(def.Title + " " + (def > lotr ? ">" : "<") + " " + lotr.Title);

            Console.ReadKey();
        }
    }
}
