using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.DAL;

namespace FinalProject_2210662.BLL
{
    public class Book
    {
        private string iSBN;
        private string bookTitle;
        private double unitPrice;
        private int qOH;
        private int publishedId;
        private int categoryId;
        private int status;

        public string ISBN { get => iSBN; set => iSBN = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int QOH { get => qOH; set => qOH = value; }
        public int PublishedId { get => publishedId; set => publishedId = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int Status { get => status; set => status = value; }


        // Custom Method
        public List<Book> GetAllBooks()
        {
            return BookDB.GetAllRecords();

        }

        public void SaveBook(Book book)
        {
            BookDB.SaveRecord(book);
        }

        public void DeleteBook(string isbn)
        {
            BookDB.DeleteRecord(isbn);
        }

        public void UpdateBook(Book book)
        {
            BookDB.UpdateRecord(book);
        }

        public Book GetBookByISBN(string isbn)
        {
            return BookDB.GetRecordByISBN(isbn);
        }






        // Validation

        public bool Check_duplicated_ISBN(string isbn)
        {
            return BookDB.Duplicated_ISBN_validation(isbn);

        }

    }
}
