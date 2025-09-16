using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;

namespace Sally__Task1
{
    public interface IBookManager
    {
         void SaveBooksToFile();

         void LoadBooksFromFile();
    }
    internal class BookManager : IBookManager
    {
        static List<Book> books = new List<Book>();
        static string filePath = "BooksData.csv";

        public void SaveBooksToFile()
        {

            List<string> lines = new List<string>();
            lines.Add($"Title,ID,Available,Reserved");

            foreach (Book b in books)
            {
                lines.Add($"{b.Title},{b.ID},{b.AvailableCount},{b.ReservedCount}");
            }
            File.WriteAllLines(filePath, lines);
        }

        public void LoadBooksFromFile()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                
                foreach (string line in lines.Skip(1))
                {
                    var parts = line.Split(',');
                    Book b = new Book(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                    books.Add(b);
                }
            }
        }

        public void AddBook(Book b)
        {
            bool found = false;
            foreach(Book b2 in books)
            {
                if (b.Title == b2.Title)
                {
                    found = true;
                    b2.bookCount++;
                    b2.AvailableCount++;
                    break;
                }
            }
            if(found != true)
            {
                books.Add(b);
            }
            SaveBooksToFile();
        }

        public void ReserveBook(int num)
        {
            foreach (Book b in books)
            {
                if (b.ID == num)
                {
                    if (b.AvailableCount >0)
                    {
                        b.ReservedCount++;
                        b.AvailableCount--;
                        Console.WriteLine("Book Reserved Successfully !!\n");
                    }
                    else
                        Console.WriteLine("Book Can Not be Resered\n");
                }
            }
            SaveBooksToFile();
        }

        public override string ToString()
        {
            if (books.Count == 0)
                return "No books available.";

            StringBuilder sb = new StringBuilder();
            foreach (Book b in books)
            {
                sb.AppendLine($"ID: {b.ID}, Title: {b.Title}, Reserved: {b.ReservedCount}, Available: {b.AvailableCount}");
            }
            return sb.ToString();

        }

        public void ReleaseBook(int num)
        {
            foreach (Book b in books)
            {
                if (b.ID == num)
                {
                    if (b.ReservedCount > 0)
                    {
                        b.ReservedCount--;
                        b.AvailableCount++;
                        Console.WriteLine("Book Reserved Successfully !!\n");
                    }
                    else
                        Console.WriteLine("There is NO Book to Release\n");
                }
            }
            SaveBooksToFile();
        }

    }
}
