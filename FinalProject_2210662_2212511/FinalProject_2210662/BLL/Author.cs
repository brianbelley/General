using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.DAL;

namespace FinalProject_2210662.BLL
{
    public class Author
    {
        private int authorId;
        private string firstName;
        private string lastName;
        private string email;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }


        // Custom method
        public List<Author> GetAllAuthors()
        {
            return AuthorDB.GetAllRecords();
        }

        public void SaveAuthor(Author author)
        {
            AuthorDB.SaveRecord(author);
        }

        public void DeleteRecord(int id)
        {
            AuthorDB.DeleteRecord(id);
        }

        public Author GetAuthorById(int id)
        {
            return AuthorDB.GetRecordById(id);
        }

        public void UpdateAuthor(Author author)
        {
            AuthorDB.UpdateRecord(author);
        }



        //Validation

        public bool Check_Duplicated_id(string id)
        {
            return AuthorDB.Duplicated_id_validation(id);
        }
    }
}
