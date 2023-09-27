using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FinalProject_2210662.BLL;

namespace FinalProject_2210662.GUI
{
    public partial class Book_Form : Form
    {
        public Book_Form()
        {
            InitializeComponent();
        }

        #region Button_Click_Book
        private void buttonListBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            DisplayData_Book(listViewBook, book.GetAllBooks());
            
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            Category cate = new Category();
            Publisher pub = new Publisher();



            if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxISBN.Text))
            {
                MessageBox.Show("ISBN  must be filled","Invalid ISBN");
                return;
            }

            if (!book.Check_duplicated_ISBN(this.textBoxISBN.Text))
            {
                MessageBox.Show("ISBN  is already existed", "Invalid ISBN");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxBookTitle.Text))
            {
                MessageBox.Show("Book Title must be filled", "Invalid Book Title");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.decimal_validation(this.textBoxUnitPrice.Text))
            {
                MessageBox.Show("Unit Price is in wrong format", "Invalid Unit Price");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxQOH.Text))
            {
                MessageBox.Show("QOH must be interger", "Invalid QOH");
                return;
            }

            
            if(comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category", "Invalid Category");
                return;
            }

            
            if(comboBoxPublisher.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a publisher", "Invalid Publisher");
                return;
            }



            if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxStatus.Text))
            {
                MessageBox.Show("Status must be interger", "Invalid ISBN");
                return;
            }

            book.ISBN = this.textBoxISBN.Text;
            book.BookTitle = this.textBoxBookTitle.Text;
            book.UnitPrice = Convert.ToDouble(this.textBoxUnitPrice.Text);
            book.QOH = Convert.ToInt32(this.textBoxQOH.Text);


            
            List<Publisher> pubs = pub.GetAllPublisher();
            pub.PublisherId = pubs[comboBoxPublisher.SelectedIndex].PublisherId;
            book.PublishedId = pub.PublisherId;


            List<Category> categories = cate.GetAllCategories();
            cate.CategoryId = categories[comboBoxCategory.SelectedIndex].CategoryId;
            book.CategoryId = cate.CategoryId;


            book.Status = Convert.ToInt32(this.textBoxStatus.Text);
            book.SaveBook(book);
            MessageBox.Show("Book with ISBN: " + this.textBoxISBN.Text + " has been saved successfully","Successfully");












        }


        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();

             
            if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxISBN.Text))
            {
                MessageBox.Show("Book ISBN must be filled!!!", "Invalid Book ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxISBN.Focus();
                return;
            }

            if (book.Check_duplicated_ISBN(this.textBoxISBN.Text))
            {
                MessageBox.Show("Book ISBN is not existed!!!", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxISBN.Focus();
                return;

            }

            AuthorBook authorBook = new AuthorBook();
            authorBook.ISBN = this.textBoxISBN.Text;
            List<AuthorBook> listAB = authorBook.GetAuthorBookByISBN(authorBook);
            
            string text ="";
            if (listAB.Count > 0)
            {
                foreach (AuthorBook ab in listAB)
                {
                    text = text + "\n Author: " + Convert.ToString(ab.AuthorId); 
                }
                DialogResult dr1 = MessageBox.Show("Book with ISBN: " + this.textBoxISBN.Text + " is related to:\n" + text + "\n Do you still want to delete this book?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr1 == DialogResult.Yes)
                {
                    authorBook.DeleteAuthorBookByISBN(authorBook);
                    book.DeleteBook(this.textBoxISBN.Text);
                    MessageBox.Show(" Book with ISBN: " + this.textBoxISBN.Text + " has been removed successfully", "Successfully", MessageBoxButtons.OK);
                    return;
                }
                if(dr1 == DialogResult.No)
                {
                    return;
                }

            }
            DialogResult dr = MessageBox.Show("Do you want to DELETE Book with ISBN: " + this.textBoxISBN.Text, "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

                book.DeleteBook(this.textBoxISBN.Text);
                MessageBox.Show(" Book with ISBN: " + this.textBoxISBN.Text + " has been removed successfully", "Successfully", MessageBoxButtons.OK);
                return;
            }
            else
            {
                return;
            }


        }


        private void buttonUpdateBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            Category cate = new Category();
            Publisher pub = new Publisher();



            if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxISBN.Text))
            {
                MessageBox.Show("ISBN  must be filled", "Invalid ISBN");
                return;
            }

            if (book.Check_duplicated_ISBN(this.textBoxISBN.Text))
            {
                MessageBox.Show("ISBN  is not existed", "Invalid ISBN");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxBookTitle.Text))
            {
                MessageBox.Show("Book Title must be filled", "Invalid Book Title");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.decimal_validation(this.textBoxUnitPrice.Text))
            {
                MessageBox.Show("Unit Price is in wrong format", "Invalid Unit Price");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxQOH.Text))
            {
                MessageBox.Show("QOH must be interger", "Invalid QOH");
                return;
            }

            //if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxCategoryId.Text))
            //{
            //    MessageBox.Show("Category must be interger", "Invalid Category");
            //    return;
            //}

            //if (cate.Check_Existed_id(Convert.ToInt32(this.textBoxCategoryId.Text)))
            //{
            //    MessageBox.Show("Category is not existed", "Invalid Category");
            //    return;
            //}

            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category", "Invalid Category");
                return;
            }

            //if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxPublisherId.Text))
            //{
            //    MessageBox.Show("Published ID must be interger", "Invalid Published ID");
            //    return;
            //}

            //if (pub.Check_existed_id(Convert.ToInt32(this.textBoxPublisherId.Text)))
            //{
            //    MessageBox.Show("Publisher is not existed", "Invalid Publisher");
            //    return;
            //}

            if (comboBoxPublisher.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a publisher", "Invalid Publisher");
                return;
            }



            if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxStatus.Text))
            {
                MessageBox.Show("Status must be interger", "Invalid ISBN");
                return;
            }

            DialogResult dr = MessageBox.Show("Do you want to UPDATE Book with ISBN: " + this.textBoxISBN.Text, "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                book.ISBN = this.textBoxISBN.Text;
                book.BookTitle = this.textBoxBookTitle.Text;
                book.UnitPrice = Convert.ToDouble(this.textBoxUnitPrice.Text);
                book.QOH = Convert.ToInt32(this.textBoxQOH.Text);
                
                List<Publisher> pubs = pub.GetAllPublisher();
                pub.PublisherId = pubs[comboBoxPublisher.SelectedIndex].PublisherId;
                book.PublishedId = pub.PublisherId;

                List<Category> categories = cate.GetAllCategories();
                cate.CategoryId = categories[comboBoxCategory.SelectedIndex].CategoryId;
                book.CategoryId = cate.CategoryId;

                book.Status = Convert.ToInt32(this.textBoxStatus.Text);
                book.UpdateBook(book);
                MessageBox.Show("Book with ISBN: " + this.textBoxISBN.Text + " has been updated successfully", "Successfully");
                return;
            }
            else
            {
                return;
            }

        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            List<Book> listB = book.GetAllBooks();
            switch (this.comboBoxSearchOptionBook.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Please select Book search option", "Reminder");
                    break;
                case 0:
                    
              
                    if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxOptionBook.Text))
                    {
                        MessageBox.Show("ISBN  must be filled", "Invalid ISBN");
                        this.textBoxOptionBook.Focus();
                        return;
                    }

                    

                    foreach(Book b in listB)
                    {
                        if(b.ISBN == this.textBoxOptionBook.Text)
                        {
                            book = b;
                            
                            this.textBoxISBN.Text = book.ISBN;
                            this.textBoxBookTitle.Text = book.BookTitle;
                            this.textBoxUnitPrice.Text = book.UnitPrice.ToString();
                            this.textBoxQOH.Text = book.QOH.ToString();
                            Category cate = new Category();
                            List<Category> cates = cate.GetAllCategories();
                            int cateIndex = 0;
                            foreach(Category c in cates)
                            {
                                if (c.CategoryId == b.CategoryId)
                                {
                                    cateIndex = cates.IndexOf(c);
                                }
                            }
                            this.comboBoxCategory.SelectedIndex = cateIndex;

                            Publisher pub = new Publisher();
                            List<Publisher> pubs = pub.GetAllPublisher();
                             int pubIndex = 0;
                            foreach(Publisher p in pubs)
                            {
                                if (p.PublisherId == b.PublishedId)
                                {
                                    pubIndex = pubs.IndexOf(p);
                                }
                            }
                            this.comboBoxPublisher.SelectedIndex = pubIndex;
                            
                            this.textBoxStatus.Text = book.Status.ToString();

                            listViewBook.Items.Clear();
                            ListViewItem item = new ListViewItem(book.ISBN.ToString());
                            item.SubItems.Add(book.BookTitle.ToString());
                            item.SubItems.Add(book.UnitPrice.ToString());
                            item.SubItems.Add(book.QOH.ToString());
                            item.SubItems.Add(book.PublishedId.ToString());
                            item.SubItems.Add(book.CategoryId.ToString());
                            item.SubItems.Add(book.Status.ToString());
                            listViewBook.Items.Add(item);
                            return;
                        }
                    }
                    MessageBox.Show("Book is not found", "Not found");
                    
                    break;

                case 1:
                   
                    if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxOptionBook.Text))
                    {
                        MessageBox.Show("Book Title must be filled", "Invalid Book Title");
                        return;
                    }
                    List<Book> books = new List<Book>();
                    foreach(Book b in listB)
                    {
                        if(b.BookTitle == this.textBoxOptionBook.Text)
                        {
                            books.Add(b);
                        }

                    }
                    if(books.Count > 0)
                    {
                        listViewBook.Items.Clear();
                        foreach (Book b in books)
                        {
                            ListViewItem item1 = new ListViewItem(b.ISBN.ToString());
                            item1.SubItems.Add(b.BookTitle.ToString());
                            item1.SubItems.Add(b.UnitPrice.ToString());
                            item1.SubItems.Add(b.QOH.ToString());
                            item1.SubItems.Add(b.PublishedId.ToString());
                            item1.SubItems.Add(b.CategoryId.ToString());
                            item1.SubItems.Add(b.Status.ToString());
                            listViewBook.Items.Add(item1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Book is not found", "Not found");
                    }
                    
                   
                    break;

            }
        }
        #endregion


        #region Button_Click_Author

        private void buttonListAuthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            DisplayData_Author(listViewAuthor, author.GetAllAuthors());

        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();



            if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxAuthorId.Text))
            {
                MessageBox.Show("Author ID must be interger", "Invalid Author ID");
                return;
            }

            if (!author.Check_Duplicated_id(this.textBoxAuthorId.Text))
            {
                MessageBox.Show("Author ID is already existed", "Invalid Author ID");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.Name_validation(this.textBoxFirstName.Text))
            {
                MessageBox.Show("Author first name must contain only letter", "Invalid Author ID");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.Name_validation(this.textBoxLastName.Text))
            {
                MessageBox.Show("Author last name must contain only letter", "Invalid Author ID");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.Email_validation(this.textBoxEmail.Text))
            {
                MessageBox.Show("Author email cannot contain white space", "Invalid Author ID");
                return;
            }


            author.AuthorId = Convert.ToInt32(this.textBoxAuthorId.Text);
            author.FirstName = this.textBoxFirstName.Text;
            author.LastName = this.textBoxLastName.Text;
            author.Email = this.textBoxEmail.Text;

            author.SaveAuthor(author);
            MessageBox.Show("author with ID: " + this.textBoxAuthorId.Text + " has been saved successfully", "Successfully");





        }

        private void buttonDeleteAuthor_Click(object sender, EventArgs e)
        {
             Author author = new Author();


            if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxAuthorId.Text))
            {
                MessageBox.Show("Author ID must be interger!!!", "Invalid Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxAuthorId.Focus();
                return;
            }

            if (author.Check_Duplicated_id(this.textBoxAuthorId.Text))
            {
                MessageBox.Show("Author ID is not existed!!!", "Invalid Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxAuthorId.Focus();
                return;

            }

            AuthorBook authorBook = new AuthorBook();
            authorBook.AuthorId = Convert.ToInt32(this.textBoxAuthorId.Text);
            List<AuthorBook> listAB = authorBook.GetAuthorBookByAuthorId(authorBook);

            string text = "";
            if (listAB.Count > 0)
            {
                foreach (AuthorBook ab in listAB)
                {
                    text = text + "\n Book: " + Convert.ToString(ab.ISBN);
                }
                DialogResult dr1 = MessageBox.Show("Author with ID: " + this.textBoxAuthorId.Text + " is related to:\n" + text + "\n Do you still want to delete this book?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr1 == DialogResult.Yes)
                {
                    authorBook.DeleteAuthorBookByAuthorId(authorBook);
                    author.DeleteRecord(Convert.ToInt32(this.textBoxAuthorId.Text));
                    MessageBox.Show(" Author with ID: " + this.textBoxAuthorId.Text + " has been removed successfully", "Successfully", MessageBoxButtons.OK);
                    return;
                }
                if (dr1 == DialogResult.No)
                {
                    return;
                }

            }

            DialogResult dr = MessageBox.Show("Do you want to DELETE Author with ID: " + this.textBoxAuthorId.Text, "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                author.DeleteRecord(Convert.ToInt32(this.textBoxAuthorId.Text));
                MessageBox.Show(" Author with ID: " + this.textBoxAuthorId.Text + " has been removed successfully", "Successfully", MessageBoxButtons.OK);
                return;
            }
            else
            {
                return;
            }

        }

        private void buttonUpdateAuthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();



            if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxAuthorId.Text))
            {
                MessageBox.Show("Author ID must be interger", "Invalid Author ID");
                return;
            }

            if (author.Check_Duplicated_id(this.textBoxAuthorId.Text))
            {
                MessageBox.Show("Author ID is not existed", "Invalid Author ID");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.Name_validation(this.textBoxFirstName.Text))
            {
                MessageBox.Show("Author first name must contain only letter", "Invalid Author ID");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.Name_validation(this.textBoxLastName.Text))
            {
                MessageBox.Show("Author last name must contain only letter", "Invalid Author ID");
                return;
            }

            if (!VALIDATION.Validator_BookAuthor.Email_validation(this.textBoxEmail.Text))
            {
                MessageBox.Show("Author email cannot contain white space", "Invalid Author ID");
                return;
            }
            
            DialogResult dr = MessageBox.Show("Do you want to UPDATE Author with ID: " + this.textBoxAuthorId.Text, "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                author.AuthorId = Convert.ToInt32(this.textBoxAuthorId.Text);
                author.FirstName = this.textBoxFirstName.Text;
                author.LastName = this.textBoxLastName.Text;
                author.Email = this.textBoxEmail.Text;

                author.UpdateAuthor(author);
                MessageBox.Show("author with ID: " + this.textBoxAuthorId.Text + " has been updated successfully", "Successfully");
                return;
            }
            else
            {
                return;
            }

            

        }

        private void buttonSearchAuthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            List<Author> listA = author.GetAllAuthors();

            switch (comboBoxSearchOptionAuthor.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Please select Book search option", "Reminder");
                    break;

                case 0:
                    if (!VALIDATION.Validator_BookAuthor.int_validation(this.textBoxOptionAuthor.Text))
                    {
                        MessageBox.Show("Author ID must be interger", "Invalid Author ID");
                        return;
                    }

                    if (!author.Check_Duplicated_id(this.textBoxOptionAuthor.Text))
                    {
                        foreach (Author a in listA)
                        {
                            if (a.AuthorId == Convert.ToInt32(this.textBoxOptionAuthor.Text))
                            {
                                this.listViewAuthor.Items.Clear();
                                ListViewItem item = new ListViewItem(a.AuthorId.ToString());
                                item.SubItems.Add(a.FirstName.ToString());
                                item.SubItems.Add(a.LastName.ToString());
                                item.SubItems.Add(a.Email.ToString());
                                listViewAuthor.Items.Add(item);

                                this.textBoxAuthorId.Text = a.AuthorId.ToString();
                                this.textBoxFirstName.Text = a.FirstName.ToString();
                                this.textBoxLastName.Text = a.LastName.ToString();
                                this.textBoxEmail.Text = a.Email.ToString();
                                return;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Author is not found", "Invalid Author ID");

                    }


                    break;

                case 1:

                    if (!VALIDATION.Validator_BookAuthor.Name_validation(this.textBoxOptionAuthor.Text))
                    {
                        MessageBox.Show("Author first name must contain only letter", "Invalid Author ID");
                        return;
                    }
                    List<Author> authors = new List<Author>();
                    foreach (Author a in listA)
                    {
                        if (a.FirstName == this.textBoxOptionAuthor.Text)
                        {
                            authors.Add(a);
                        }
                    }
                    this.listViewAuthor.Items.Clear();
                    if (authors.Count > 0)
                    {
                        foreach (Author a in authors)
                        {


                            ListViewItem item = new ListViewItem(a.AuthorId.ToString());
                            item.SubItems.Add(a.FirstName.ToString());
                            item.SubItems.Add(a.LastName.ToString());
                            item.SubItems.Add(a.Email.ToString());
                            listViewAuthor.Items.Add(item);

                            this.textBoxAuthorId.Text = a.AuthorId.ToString();
                            this.textBoxFirstName.Text = a.FirstName.ToString();
                            this.textBoxLastName.Text = a.LastName.ToString();
                            this.textBoxEmail.Text = a.Email.ToString();


                        }
                    }
                    else
                    {
                        MessageBox.Show("Author is not found", "Invalid Author ID");
                    }
                    break;

                case 2:
                    if (!VALIDATION.Validator_BookAuthor.Name_validation(this.textBoxOptionAuthor.Text))
                    {
                        MessageBox.Show("Author last name must contain only letter", "Invalid Author name");
                        return;
                    }
                    List<Author> authors2 = new List<Author>();
                    foreach (Author a in listA)
                    {
                        if (a.LastName == this.textBoxOptionAuthor.Text)
                        {
                            authors2.Add(a);
                        }
                    }
                    this.listViewAuthor.Items.Clear();
                    if (authors2.Count > 0)
                    {
                        foreach (Author a in authors2)
                        {


                            ListViewItem item = new ListViewItem(a.AuthorId.ToString());
                            item.SubItems.Add(a.FirstName.ToString());
                            item.SubItems.Add(a.LastName.ToString());
                            item.SubItems.Add(a.Email.ToString());
                            listViewAuthor.Items.Add(item);

                            this.textBoxAuthorId.Text = a.AuthorId.ToString();
                            this.textBoxFirstName.Text = a.FirstName.ToString();
                            this.textBoxLastName.Text = a.LastName.ToString();
                            this.textBoxEmail.Text = a.Email.ToString();


                        }
                    }
                    else
                    {
                        MessageBox.Show("Author is not found", "Invalid Author ID");
                    }
                    break;


            }
        }
        #endregion


        #region Button_Click_AuthorBook

        private void buttonListAuthorBook_Click(object sender, EventArgs e)
        {
            AuthorBook authorbook = new AuthorBook();
            DisplayData_AuthorBook(listViewAuthorBook, authorbook.GetAllAuthorBooks());
            
        }

        private void buttonAddAuthorBook_Click(object sender, EventArgs e)
        {
            if(comboBoxAuthorId.SelectedIndex == -1 || comboBoxISBN.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Author and Book ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!VALIDATION.Validator_BookAuthor.year_validation(this.textBoxYearPublished.Text))
            {
                MessageBox.Show("Please input a valid year published", "Invalid year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxYearPublished.Focus();
                return;
            
            }

            if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxEdition.Text))
            {
                MessageBox.Show("Please input the edition", "Invalid edition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxEdition.Focus();
                return;
            }
            AuthorBook authorBook = new AuthorBook();
            Book book = new Book();
            Author author = new Author();
            
            List<Author> authors = author.GetAllAuthors();
            List<Book> books = book.GetAllBooks();

            foreach (Author a in authors)
            {
                if(a.FirstName == comboBoxAuthorId.Text)
                {
                    authorBook.AuthorId = a.AuthorId;
                    break;
                }
            }

            foreach (Book b in books)
            {
                if (b.BookTitle == comboBoxISBN.Text)
                {
                    authorBook.ISBN = b.ISBN;
                    break;
                }
            }

            List<AuthorBook> authorBookL = authorBook.GetAllAuthorBooks();

            foreach (AuthorBook ab in authorBookL)
            {
                if (ab.ISBN == authorBook.ISBN && ab.AuthorId == authorBook.AuthorId)
                {
                    MessageBox.Show("This author has already assigned to this book","Duplicated value");
                    return;
                }
            }

            authorBook.YearPublished = this.textBoxYearPublished.Text;
            authorBook.Edition = this.textBoxEdition.Text;
            authorBook.AddAuthorBook(authorBook);

            MessageBox.Show("Author Book is added succesffult", "successfully added");

        }

        private void buttonUpdateAuthorBook_Click(object sender, EventArgs e)
        {
            if (!VALIDATION.Validator_BookAuthor.year_validation(this.textBoxYearPublished.Text))
            {
                MessageBox.Show("Please input a valid year published", "Invalid year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxYearPublished.Focus();
                return;

            }

            if (!VALIDATION.Validator_BookAuthor.null_validation(this.textBoxEdition.Text))
            {
                MessageBox.Show("Please input the edition", "Invalid edition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxEdition.Focus();
                return;
            }
            AuthorBook authorBook = new AuthorBook();
            Book book = new Book();
            Author author = new Author();

            List<Author> authors = author.GetAllAuthors();
            List<Book> books = book.GetAllBooks();

            foreach (Author a in authors)
            {
                if (a.FirstName == comboBoxAuthorId.Text)
                {
                    authorBook.AuthorId = a.AuthorId;
                    break;
                }
            }

            foreach (Book b in books)
            {
                if (b.BookTitle == comboBoxISBN.Text)
                {
                    authorBook.ISBN = b.ISBN;
                    break;
                }
            }

            List<AuthorBook> authorBookL = authorBook.GetAllAuthorBooks();

            foreach (AuthorBook ab in authorBookL)
            {
                if (ab.ISBN == authorBook.ISBN && ab.AuthorId == authorBook.AuthorId)
                {
                    authorBook.YearPublished = this.textBoxYearPublished.Text;
                    authorBook.Edition = this.textBoxEdition.Text;
                    authorBook.UpdateAuthorBook(authorBook);

                    MessageBox.Show("Author Book is updated succesffult", "successfully updated");
                    return;
                }
            }

            MessageBox.Show("Author Book is not found", "Error");




        }

        private void buttonDeleteAuthorBook_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            Book book = new Book();
            AuthorBook authorbook = new AuthorBook();

            List < Author > authors = author.GetAllAuthors();
            List<Book> books = book.GetAllBooks();
            List < AuthorBook > listAB = authorbook.GetAllAuthorBooks();

            book = books[comboBoxISBN.SelectedIndex];
            author = authors[comboBoxAuthorId.SelectedIndex];

            foreach (AuthorBook ab in listAB)
            {
                if(ab.ISBN == book.ISBN && ab.AuthorId == author.AuthorId)
                {
                    authorbook.ISBN = book.ISBN;
                    authorbook.AuthorId = author.AuthorId;
                    DialogResult dr = MessageBox.Show("Do you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        authorbook.DeleteAuthorBook(authorbook);
                        MessageBox.Show("This row has been successfully removed!", "Confirmation", MessageBoxButtons.OK);

                    }
                    else return;


                }
            }
        }

        private void buttonSearchAuthorBook_Click(object sender, EventArgs e)
        {
            int searchOption = comboBoxSearchOptionAuthorBook.SelectedIndex;
            string input = textBoxOptionAuthorBook.Text;
            Book book;
            Author author;
            AuthorBook authorBook;
            List<AuthorBook> listAB;
            listViewAuthorBook.Items.Clear();

            if(textBoxOptionAuthorBook.TextLength == 0)
            {
                MessageBox.Show("Please enter the search input", "Invalid");
                this.textBoxOptionAuthorBook.Focus();
                return;

            }

            switch (searchOption)
            {
                case 0:
                    if (!VALIDATION.Validator_BookAuthor.int_validation(input))
                    {
                        MessageBox.Show("Author ID must be interger", "Invalid Author ID");
                        return;
                    }

                    authorBook = new AuthorBook();
                    authorBook.AuthorId = Convert.ToInt32(input);
                    listAB = authorBook.GetAuthorBookByAuthorId(authorBook);
                    if(listAB.Count() > 0)
                    {
                        foreach (AuthorBook ab in listAB)
                        {
                            ListViewItem item = new ListViewItem(ab.AuthorId.ToString());
                            item.SubItems.Add(ab.ISBN);
                            item.SubItems.Add(ab.YearPublished);
                            item.SubItems.Add(ab.Edition);
                            listViewAuthorBook.Items.Add(item);



                        }
                    }
                    else
                    {
                        MessageBox.Show("Author ID is not found", "Invalid Author ID");
                        return;
                    }

                    break;

                case 1:

                    authorBook = new AuthorBook();
                    authorBook.ISBN = input;
                    listAB = authorBook.GetAuthorBookByISBN(authorBook);
                    if (listAB.Count() > 0)
                    {
                        foreach (AuthorBook ab in listAB)
                        {
                            ListViewItem item = new ListViewItem(ab.AuthorId.ToString());
                            item.SubItems.Add(ab.ISBN);
                            item.SubItems.Add(ab.YearPublished);
                            item.SubItems.Add(ab.Edition);
                            listViewAuthorBook.Items.Add(item);



                        }
                    }
                    else
                    {
                        MessageBox.Show("Book ISBN is not found", "Invalid Book ISBN");
                        return;
                    }
                    break;
            }
        }
        #endregion


        #region Custom method
        private void DisplayData_Book(ListView listV, List<Book> lBook)
        {
            listV.Items.Clear();
            foreach (Book book in lBook)
            {
                ListViewItem item = new ListViewItem(book.ISBN.ToString());
                item.SubItems.Add(book.BookTitle.ToString());
                item.SubItems.Add(book.UnitPrice.ToString());
                item.SubItems.Add(book.QOH.ToString());
                item.SubItems.Add(book.PublishedId.ToString());
                item.SubItems.Add(book.CategoryId.ToString());
                item.SubItems.Add(book.Status.ToString());
                listV.Items.Add(item);
            }
        }

        private void DisplayData_Author(ListView listV, List<Author> lAuthor)
        {
            listV.Items.Clear();
            foreach (Author author in lAuthor)
            {
                ListViewItem item = new ListViewItem(author.AuthorId.ToString());
                item.SubItems.Add(author.FirstName.ToString());
                item.SubItems.Add(author.LastName.ToString());
                item.SubItems.Add(author.Email.ToString());
                
                listV.Items.Add(item);
            }


        }

        private void DisplayData_AuthorBook(ListView listV, List<AuthorBook> lAuthorBook)
        {
            listV.Items.Clear();
            foreach (AuthorBook authorBook in lAuthorBook)
            {
                ListViewItem item = new ListViewItem(authorBook.AuthorId.ToString());
                item.SubItems.Add(authorBook.ISBN.ToString());
                item.SubItems.Add(authorBook.YearPublished.ToString());
                item.SubItems.Add(authorBook.Edition.ToString());

                listV.Items.Add(item);
            }
        }
            #endregion


        private void Book_Form_Load(object sender, EventArgs e)
        {
            Book book = new Book();
            List<Book> books = book.GetAllBooks();

            Author author = new Author();
            List<Author> authors = author.GetAllAuthors();

            Category category = new Category();
            List<Category> categories = category.GetAllCategories();

            Publisher publisher = new Publisher();
            List<Publisher> publishers = publisher.GetAllPublisher();
            this.comboBoxAuthorId.Items.Clear();
            this.comboBoxISBN.Items.Clear();

            foreach (Book b in books)
            {
                this.comboBoxISBN.Items.Add(b.BookTitle);
            }
            foreach (Author a in authors)
            {
                this.comboBoxAuthorId.Items.Add(a.FirstName);
            }
            foreach (Category c in categories)
            {
                this.comboBoxCategory.Items.Add(c.CategoryName);

            }
            foreach (Publisher p in publishers)
            {
                this.comboBoxPublisher.Items.Add(p.PublisherName);
            }

                
        }

        

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Book_Form_Load(sender , e);
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            LogIn_Form FL = new LogIn_Form();
            this.Hide();
            FL.ShowDialog();
            this.Close();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
