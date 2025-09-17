using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;

namespace Sally__Task1
{
	public interface IBookRepository
	{
        void SaveBooksToFile();

        void LoadBooksFromFile();
    }

    public class BookRepository : IBookRepository 
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
                    Book b = new Book(parts[0], int.Parse(parts[1]), int.Parse(parts[3]), int.Parse(parts[2]));
                    books.Add(b);
                }
            }
        }
    }
}
