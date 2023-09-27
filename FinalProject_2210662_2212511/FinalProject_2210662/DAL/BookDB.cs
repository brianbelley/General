using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.BLL;
using System.Data.SqlClient;

namespace FinalProject_2210662.DAL
{
    public class BookDB
    {
        public static List<Book> GetAllRecords()
        {
            List<Book> listb = new List<Book>();
            Book book;

            using(SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM Books", conn);
                SqlDataReader dr = cmdAll.ExecuteReader();
                while (dr.Read())
                {
                    book = new Book();
                    book.ISBN = dr["ISBN"].ToString();
                    book.BookTitle = dr["BookTitle"].ToString();
                    book.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);
                    book.QOH = Convert.ToInt32(dr["QOH"]);
                    book.PublishedId = Convert.ToInt32(dr["PublisherId"]);
                    book.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    book.Status = Convert.ToInt32(dr["Status"]);
                    listb.Add(book);

                }
                return listb;
            }
        }


        public static void SaveRecord(Book book)
        {
            using(SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAdd = new SqlCommand("INSERT INTO Books VALUES (@ISBN, @BookTitle, @UnitPrice, @QOH, @PublisherId, @CategoryId, @Status); ",conn);
                cmdAdd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmdAdd.Parameters.AddWithValue("@BookTitle", book.BookTitle);
                cmdAdd.Parameters.AddWithValue("@UnitPrice", book.UnitPrice);
                cmdAdd.Parameters.AddWithValue("@PublisherId", book.PublishedId);
                cmdAdd.Parameters.AddWithValue("@CategoryId", book.CategoryId);
                cmdAdd.Parameters.AddWithValue("@QOH", book.QOH);
                cmdAdd.Parameters.AddWithValue("@Status", book.Status);
                cmdAdd.ExecuteNonQuery();
            }

        }

        public static Book GetRecordByISBN(string isbn)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdSelectByISBN = new SqlCommand("SELECT * FROM Books WHERE ISBN = @ISBN", conn);
                cmdSelectByISBN.Parameters.AddWithValue("@ISBN", isbn);
                SqlDataReader reader = cmdSelectByISBN.ExecuteReader();
                reader.Read();
                Book book = new Book();
                book.ISBN = reader["ISBN"].ToString();
                book.BookTitle = reader["BookTitle"].ToString();
                book.UnitPrice = Convert.ToDouble(reader["ISBN"]);
                book.PublishedId = Convert.ToInt32(reader["ISBN"]);
                book.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                book.QOH = Convert.ToInt32(reader["QOH"]);
                book.Status = Convert.ToInt32(reader["Status"]);

                return book;

            }
        }

        public static void DeleteRecord(string isbn)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM Books WHERE ISBN = @ISBN", conn);
                cmdDelete.Parameters.AddWithValue("@ISBN", isbn);
                cmdDelete.ExecuteNonQuery();

            }
        }

        public static void UpdateRecord(Book book)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand("UPDATE Books SET BookTitle = @BookTitle, " +
                    "UnitPrice = @UnitPrice, QOH = @QOH, PublisherId = @PublisherId, " +
                    "CategoryId = @CategoryId, Status = @Status WHERE ISBN = @ISBN;  ",conn);
                cmdUpdate.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmdUpdate.Parameters.AddWithValue("@BookTitle", book.BookTitle);
                cmdUpdate.Parameters.AddWithValue("@UnitPrice", book.UnitPrice);
                cmdUpdate.Parameters.AddWithValue("@QOH", book.QOH);
                cmdUpdate.Parameters.AddWithValue("@PublisherId", book.PublishedId);
                cmdUpdate.Parameters.AddWithValue("@CategoryId", book.CategoryId);
                cmdUpdate.Parameters.AddWithValue("@Status", book.Status);
                cmdUpdate.ExecuteNonQuery();

            }
        }




        public static bool Duplicated_ISBN_validation(string isbn)
        {
            List<Book> lBook = GetAllRecords();

            foreach (Book book in lBook)
            {
                if (book.ISBN == isbn)
                {
                    return false;
                }
            }

            return true;
        }







    }
}
