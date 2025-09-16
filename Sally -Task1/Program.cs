using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sally__Task1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            BookManager bookMng = new BookManager();
            bookMng.LoadBooksFromFile();
            int id = 1;

            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1- Add Book");
                Console.WriteLine("2- Reserve Book");
                Console.WriteLine("3- List All Books");
                Console.WriteLine("4- Exit");
                Console.WriteLine("Enter your Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter a Book Title : ");
                            string t = Console.ReadLine();
                            id++;
                            Book b = new Book(t,id,0,1);
                            bookMng.AddBook(b);
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine("Enter a Book Number to Reseve : ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            bookMng.ReserveBook(num);
                        }
                        break;

                    case 3:
                        {
                            
                            Console.WriteLine(bookMng.ToString());
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
