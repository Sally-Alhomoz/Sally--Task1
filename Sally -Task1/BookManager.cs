﻿using System;
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

    }
    internal class BookManager : IBookManager
    {
        BookRepository repo = new BookRepository();
        List<Book> books = new List<Book>();

        public BookManager()
        {
            books = repo.LoadBooksFromFile();
        }
        public void Add(Book b)

        {
            bool found = false;
            foreach(Book b2 in books)
            {
                if (b.Title == b2.Title)
                {
                    found = true;
                    b2.AvailableCount++;
                    b.ID = b2.ID;
                    break;
                }
            }
            if(found != true)
            {
                if (books.Count > 0)
                {
                    var maxId = books.Max(i => i.ID);
                    b.ID = maxId+1;
                }
                else
                {
                    b.ID = 1;
                }
                books.Add(b);
            }
            repo.SaveBooksToFile();

        }

        public void ReserveBook(string title)
        {
            foreach (Book b in books)
            {
                if (b.Title == title)
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
            repo.SaveBooksToFile();
        }

        public override string ToString()
        {
            if (books.Count == 0)
                return "No books available.":

            StringBuilder sb = new StringBuilder();
            foreach (Book b in books)
            {
                sb.AppendLine($"ID: {b.ID}, Title: {b.Title}, Reserved: {b.ReservedCount}, Available: {b.AvailableCount}");
            }
            return sb.ToString();

        }

        public void ReleaseBook(string title)
        {
            //comment
            foreach (Book b in books)
            {
                if (b.Title == title)
                {
                    if (b.ReservedCount > 0)
                    {
                        b.ReservedCount--;
                        b.AvailableCount++;
                        Console.WriteLine("Book Released Successfully !!\n");
                    }
                    else
                        Console.WriteLine("There is NO Book to Release\n");
                }
            }
            repo.SaveBooksToFile();
        }

    }
}
