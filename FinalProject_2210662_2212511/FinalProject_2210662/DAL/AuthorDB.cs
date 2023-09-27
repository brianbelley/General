using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.BLL;
using System.Data.SqlClient;

namespace FinalProject_2210662.DAL
{
    public class AuthorDB
    {
        public static List<Author> GetAllRecords()
        {
            List<Author> listA = new List<Author>();
            Author author;

            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM Authors", conn);
                SqlDataReader dr = cmdAll.ExecuteReader();
                while (dr.Read())
                {
                    author = new Author();
                    author.AuthorId = Convert.ToInt32(dr["AuthorId"]);
                    author.FirstName = dr["FirstName"].ToString();
                    author.LastName = dr["LastName"].ToString();
                    author.Email = dr["Email"].ToString();

                    listA.Add(author);

                }
                return listA;
            }
        }
        public static Author GetRecordById(int id)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdSelectById = new SqlCommand("SELECT * FROM Authors WHERE AuthorId = @AuthorId", conn);
                cmdSelectById.Parameters.AddWithValue("@AuthorId", id);
                SqlDataReader reader = cmdSelectById.ExecuteReader();
                reader.Read();
                Author author = new Author();
                author.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                author.FirstName = reader["FirstName"].ToString();
                author.LastName = reader["LastName"].ToString();
                author.Email = reader["Email"].ToString();

                return author;

            }
        }

        public static void SaveRecord(Author author)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAdd = new SqlCommand("INSERT INTO Authors VALUES (@AuthorId, @FirstName, @LastName, @Email); ", conn);
                cmdAdd.Parameters.AddWithValue("@AuthorId", author.AuthorId);
                cmdAdd.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmdAdd.Parameters.AddWithValue("@LastName", author.LastName);
                cmdAdd.Parameters.AddWithValue("@Email", author.Email);
                cmdAdd.ExecuteNonQuery();
            }

        }
        public static void DeleteRecord(int id)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM Authors WHERE AuthorId = @AuthorId", conn);
                cmdDelete.Parameters.AddWithValue("@AuthorId", id);
                cmdDelete.ExecuteNonQuery();

            }
        }

        public static void UpdateRecord(Author author)
        {
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand("UPDATE Authors SET " +
                    "FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE AuthorId = @AuthorId;", conn);
                    
                cmdUpdate.Parameters.AddWithValue("@AuthorId", author.AuthorId);
                cmdUpdate.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmdUpdate.Parameters.AddWithValue("@LastName", author.LastName);
                cmdUpdate.Parameters.AddWithValue("@Email", author.Email);
                
                cmdUpdate.ExecuteNonQuery();

            }
        }




        public static bool Duplicated_id_validation(string id)
        {
            List<Author> lAuthor = GetAllRecords();

            foreach (Author author in lAuthor)
            {
                if (author.AuthorId == Convert.ToInt32(id))
                {
                    return false;
                }
            }

            return true;
        }




    }
}
