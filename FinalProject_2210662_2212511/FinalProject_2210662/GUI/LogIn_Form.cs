using FinalProject_2210662.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_2210662.GUI
{
    public partial class LogIn_Form : Form
    {
        public LogIn_Form()
        {
            InitializeComponent();
        }

        

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string input = this.textBoxUserId.Text.Trim();
            if (!VALIDATION.Validator_User.UserId_validation(input))
            {
                MessageBox.Show("User ID must be 4 digits!!!", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxUserId.Focus();
                return;
            }

            input = this.textBoxPassword.Text.Trim();

            if (!VALIDATION.Validator_User.Password_validation(input))
            {
                MessageBox.Show("Password must be 8 letter!!!", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPassword.Focus();
                return;

            }


            UserAccount acc = new UserAccount();
            int id = Convert.ToInt32(this.textBoxUserId.Text.Trim()); 
            string pass = this.textBoxPassword.Text.Trim();
            if (!acc.Check_existed_account(id,pass))
            {
                MessageBox.Show("Incorrect User ID or Password, Please try again","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee emp = new Employee();

            emp = emp.GetEmployeeById(id);

            this.Hide();
            switch (emp.JobId)
            {
                case 11111:
                    UsersAccount_Form fUA = new UsersAccount_Form();
                    fUA.ShowDialog();
                    break;
                case 22222:
                    Customer_Form fC = new Customer_Form();
                    fC.ShowDialog();
                    break;
                case 33333:
                    Book_Form FB = new Book_Form();
                    FB.ShowDialog();
                    break;
                case 44444:
                    Orders_Form_Entity OfE = new Orders_Form_Entity();
                    OfE.ShowDialog();
                    break;
                case 5555:
                    Orders_Form_Entity OfEJ = new Orders_Form_Entity();
                    OfEJ.ShowDialog();
                    break;
                
            }

            
            this.Close();



            




        }

        private void buttonshow_Click(object sender, EventArgs e)
        {
            if (buttonshow.Text == "Show")
            {
                this.textBoxPassword.PasswordChar = '\0';
                buttonshow.Text = "Hide";
                
            }
            else if (buttonshow.Text == "Hide")
            {
                this.textBoxPassword.PasswordChar = '*';
                buttonshow.Text = "Show";
            }
            
            
        }
    }
}
