using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.BLL;
using System.Data.SqlClient;

namespace FinalProject_2210662.DAL
{
    public class AuthorBookDB
    {

        public static List<AuthorBook> GetAllRecords()
        {
            List<AuthorBook> listAB = new List<AuthorBook>();
            AuthorBook authorBook;

            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM AuthorsBooks", conn);
                SqlDataReader dr = cmdAll.ExecuteReader();
                while (dr.Read())
                {
                    authorBook = new AuthorBook();
                    authorBook.AuthorId = Convert.ToInt32(dr["AuthorId"]);
                    authorBook.ISBN = dr["ISBN"].ToString();
                    authorBook.YearPublished = dr["YearPublished"].ToString();
                    authorBook.Edition = dr["Edition"].ToString();

                    listAB.Add(authorBook);

                }
                return listAB;
            }
        }

        public static void AddRecord( AuthorBook authorBook)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAdd = new SqlCommand("INSERT INTO AuthorsBooks VALUES(@AuthorId, @ISBN, @YearPublished, @Edition);",conn);
                cmdAdd.Parameters.AddWithValue("@AuthorId", authorBook.AuthorId);
                cmdAdd.Parameters.AddWithValue("@ISBN", authorBook.ISBN);
                cmdAdd.Parameters.AddWithValue("@YearPublished", authorBook.YearPublished);
                cmdAdd.Parameters.AddWithValue("@Edition", authorBook.Edition);
                cmdAdd.ExecuteNonQuery();

            }
        }

        public static void UpdateRecord(AuthorBook authorBook)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand("UPDATE AuthorsBooks SET YearPublished = @YearPublished, Edition = @Edition WHERE AuthorId = @AuthorId AND ISBN = @ISBN;", conn);
                cmdUpdate.Parameters.AddWithValue("@AuthorId", authorBook.AuthorId);
                cmdUpdate.Parameters.AddWithValue("@ISBN", authorBook.ISBN);
                cmdUpdate.Parameters.AddWithValue("@YearPublished", authorBook.YearPublished);
                cmdUpdate.Parameters.AddWithValue("@Edition", authorBook.Edition);
                cmdUpdate.ExecuteNonQuery();

            }
        }

        public static void DeleteRecord(AuthorBook authorBook)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM AuthorsBooks WHERE AuthorId = @AuthorId AND ISBN = @ISBN;", conn);
                cmdDelete.Parameters.AddWithValue("@AuthorId", authorBook.AuthorId);
                cmdDelete.Parameters.AddWithValue("@ISBN", authorBook.ISBN);
                cmdDelete.ExecuteNonQuery();

            }
        }

        public static void DeleteRecordByISBN(AuthorBook authorBook)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM AuthorsBooks WHERE ISBN = @ISBN;", conn);
                cmdDelete.Parameters.AddWithValue("@ISBN", authorBook.ISBN);
                cmdDelete.ExecuteNonQuery();

            }
        }

        public static void DeleteRecordByAuthorId(AuthorBook authorBook)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM AuthorsBooks WHERE AuthorId = @AuthorId;", conn);
                cmdDelete.Parameters.AddWithValue("@AuthorId", authorBook.AuthorId);
                cmdDelete.ExecuteNonQuery();

            }
        }

        public static List<AuthorBook> GetRecordByISBN(AuthorBook authorBook)
        {
            using(SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdGet= new SqlCommand("SELECT * FROM AuthorsBooks Where ISBN = @ISBN;", conn);
                cmdGet.Parameters.AddWithValue("@ISBN",authorBook.ISBN);
                SqlDataReader reader = cmdGet.ExecuteReader();
                List<AuthorBook> listAB = new List<AuthorBook>();
                AuthorBook ab;
                while (reader.Read())
                {
                    ab = new AuthorBook();
                    ab.ISBN = reader["ISBN"].ToString();
                    ab.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                    ab.YearPublished = reader["YearPublished"].ToString();
                    ab.Edition = reader["Edition"].ToString();
                    listAB.Add(ab);

                }
                return listAB;

            }
        }

        public static List<AuthorBook> GetRecordByAuthorId(AuthorBook authorBook)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdGet = new SqlCommand("SELECT * FROM AuthorsBooks Where AuthorId = @AuthorId;", conn);
                cmdGet.Parameters.AddWithValue("@AuthorId", authorBook.AuthorId);
                SqlDataReader reader = cmdGet.ExecuteReader();
                List<AuthorBook> listAB = new List<AuthorBook>();
                AuthorBook ab;
                while (reader.Read())
                {
                    ab = new AuthorBook();
                    ab.ISBN = reader["ISBN"].ToString();
                    ab.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                    ab.YearPublished = reader["YearPublished"].ToString();
                    ab.Edition = reader["Edition"].ToString();
                    listAB.Add(ab);

                }
                return listAB;

            }
        }
    }
}
