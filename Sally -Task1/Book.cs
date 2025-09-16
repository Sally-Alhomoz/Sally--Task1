using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sally__Task1
{
    internal class Book
    {
        public string Title { get; set; }
        public int ID { get; set; }
        public int bookCount { get; set; } = 0;
        public int ReservedCount { get; set; }
        public int AvailableCount { get; set; }


        public Book()
        {
            Title = "None";
            ID = -1;
            bookCount = 1;
            AvailableCount = 1;
            ReservedCount = 0;
        }

        public Book(string title,int id,int reservedCount , int availableCount)
        {
            Title = title ;
            ID = id;
            bookCount=1;
            AvailableCount = availableCount;
            ReservedCount = reservedCount;
        }

        



    }
}
