using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.DAL;

namespace FinalProject_2210662.BLL
{
    public class AuthorBook
    {
        private int authorId;
        private string iSBN;
        private string yearPublished;
        private string edition;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string ISBN { get => iSBN; set => iSBN = value; }
        public string YearPublished { get => yearPublished; set => yearPublished = value; }
        public string Edition { get => edition; set => edition = value; }



        public List<AuthorBook> GetAllAuthorBooks()
        {
            return AuthorBookDB.GetAllRecords();
        }

        public void AddAuthorBook(AuthorBook ab)
        {
            AuthorBookDB.AddRecord(ab);
        }

        public void UpdateAuthorBook(AuthorBook ab)
        {
            AuthorBookDB.UpdateRecord(ab);
        }

        public void DeleteAuthorBook(AuthorBook ab)
        {
            AuthorBookDB.DeleteRecord(ab);
        }
        public void DeleteAuthorBookByAuthorId(AuthorBook ab)
        {
            AuthorBookDB.DeleteRecordByAuthorId(ab);
        }
        public void DeleteAuthorBookByISBN(AuthorBook ab)
        {
            AuthorBookDB.DeleteRecordByISBN(ab);
        }

        public List<AuthorBook> GetAuthorBookByISBN(AuthorBook ab)
        {
            return AuthorBookDB.GetRecordByISBN(ab);
        }

        public List<AuthorBook> GetAuthorBookByAuthorId(AuthorBook ab)
        {
            return AuthorBookDB.GetRecordByAuthorId(ab);
        }

    }
}
