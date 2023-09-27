using FinalProject_2210662.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_2210662.GUI
{
    public partial class UsersAccount_Form : Form
    {
        public UsersAccount_Form()
        {
            InitializeComponent();
        }



        #region Button_Click_UserAccount

        private void buttonListUser_Click(object sender, EventArgs e)
        {
            UserAccount account= new UserAccount();
            DisplayData(listViewUserAccount,account.Get_all_user_account());
            
        
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            UserAccount newAcc = new UserAccount();
            Employee emp = new Employee();

            
            if(comboBoxUser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an User", "Missing user", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            string input = this.textBoxPassword.Text.Trim();

            // Check if password is in proper format
            if (!VALIDATION.Validator_User.Password_validation(input))
            {
                MessageBox.Show("Password must be 8 letter!!!", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPassword.Focus();
                return;

            }

            


            // create a new user account and add it into the database
            List<Employee> emps = emp.GetAllEmplooyee();
            newAcc.UserId = emps[this.comboBoxUser.SelectedIndex].EmployeeId;
            newAcc.Password = this.textBoxPassword.Text.Trim();
            newAcc.EmployeeId = emps[this.comboBoxUser.SelectedIndex].EmployeeId;
            newAcc.AddUserAccount(newAcc);
            MessageBox.Show("Account with User ID: " + newAcc.UserId + " has been created successfully. Click OK to return to LOG IN!!!", "Sign Up successfully");

        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            UserAccount acc = new UserAccount();

            // Check if userId is in proper format 
            if (comboBoxUser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an User", "Missing user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee emp = new Employee();
            List<Employee> emps = emp.GetAllEmplooyee();
            acc.UserId = emps[this.comboBoxUser.SelectedIndex].EmployeeId;

            DialogResult dr = MessageBox.Show("Do you want to DELETE User account with User ID: " + acc.UserId, "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                acc.RemoveUserAccount(Convert.ToInt32(acc.UserId));
                MessageBox.Show(" User account with ID: " + acc.UserId + " has been removed successfully", "Successfully", MessageBoxButtons.OK);
                return;
            }
            else
            {
                return;
            }



        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            UserAccount acc = new UserAccount();
            // Check if userId is in proper format 
            
            if (comboBoxUser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an User", "Missing user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string input = this.textBoxPassword.Text.Trim();

            // Check if password is in proper format
            if (!VALIDATION.Validator_User.Password_validation(input))
            {
                MessageBox.Show("Password must be 8 letter!!!", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPassword.Focus();
                return;

            }

            Employee emp = new Employee();
            List<Employee> emps = emp.GetAllEmplooyee();
            acc.UserId = emps[this.comboBoxUser.SelectedIndex].EmployeeId;

            DialogResult dr = MessageBox.Show("Do you want to UPDATE PASSWORD for User account with ID: " + acc.UserId, "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                acc.UpdateUserAccount(Convert.ToInt32(input),this.textBoxPassword.Text);
                MessageBox.Show(" User account with ID: " + input + " has been updated password successfully", "Successfully", MessageBoxButtons.OK);
                return;
            }
            else
            {
                return;
            }

        }

        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            UserAccount acc = new UserAccount();
            List<UserAccount> accs = acc.Get_all_user_account();
            if (comboBoxUser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an User", "Missing user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            acc = accs[this.comboBoxUserSearch.SelectedIndex];

            listViewUserAccount.Items.Clear();
            ListViewItem item = new ListViewItem(acc.UserId.ToString());
            item.SubItems.Add(acc.Password.ToString());
            item.SubItems.Add(acc.EmployeeId.ToString());
            listViewUserAccount.Items.Add(item);

        }

        #endregion


        #region Button_Click_Employee


        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            string input = this.textBoxEmployeeId.Text.Trim();

            if (!VALIDATION.Validator_User.UserId_validation(input))
            {
                MessageBox.Show("Employee ID must be 4 digits!!!", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxEmployeeId.Focus();
                return;
            }

            if (emp.CheckExistedEmployee(Convert.ToInt32(input)))
            {
                MessageBox.Show("Employee ID is already existed!!!", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxEmployeeId.Focus();
                return;
            }

            input = this.textBoxLastName.Text.Trim();

            if (!VALIDATION.Validator_User.Employee_Name_validation(input))
            {
                MessageBox.Show("Employee Last Name must contain only character and white space!!!", "Invalid Employee Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxLastName.Focus();
                return;
            }


            input = this.textBoxFirstName.Text.Trim();

            if (!VALIDATION.Validator_User.Employee_Name_validation(input))
            {
                MessageBox.Show("Employee First Name must contain only character and white space!!!", "Invalid Employee Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxFirstName.Focus();
                return;
            }


            input = this.textBoxPhoneNumber.Text.Trim();

            if (!VALIDATION.Validator_User.Missing_input_validation(input))
            {
                MessageBox.Show("Missing Employee Phone Number !!!", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPhoneNumber.Focus();
                return;
            }

            input = this.textBoxEmail.Text.Trim();

            if (!VALIDATION.Validator_User.Email_validation(input))
            {
                MessageBox.Show("Email must not contain white space !!!", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxEmail.Focus();
                return;
            }


            if(this.comboBoxJob.SelectedIndex == -1)
            {
                MessageBox.Show("Please select employee job !!!", "Invalid job", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            emp.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text.Trim());
            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLastName.Text.Trim();
            emp.PhoneNumber = textBoxPhoneNumber.Text.Trim();
            emp.Email = textBoxEmail.Text.Trim();

            Job job = new Job();
            List<Job> jobs = job.GetAllJobs();
            emp.JobId = jobs[this.comboBoxJob.SelectedIndex].JobId;
           



            emp.SaveEmployees(emp);
            MessageBox.Show("Employee data saved", "Saved");

        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            if(this.textBoxEmployeeId.Text.Length == 0)
            {
                MessageBox.Show("Please eneter an employee ID", "Error");
                return;

            }
            if (emp.CheckExistedEmployee(Convert.ToInt32(Convert.ToInt32(this.textBoxEmployeeId.Text))))
            {
                var result = MessageBox.Show("Would you like to remove employee" + textBoxEmployeeId.Text.ToString() + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    emp.DeleteRecord(Convert.ToInt32(textBoxEmployeeId.Text));

                    MessageBox.Show("The employee is removed from the system", "Confirmation");
                }
            }
            else
            {
                MessageBox.Show("Please select an employee in the system", "Error");
            }
        }

        private void buttonListEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> ListE = emp.GetAllEmplooyee();
            listViewEmployee.Items.Clear();
            foreach (Employee anEmp in ListE)
            {
                ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                item.SubItems.Add(anEmp.FirstName);
                item.SubItems.Add(anEmp.LastName);
                item.SubItems.Add(anEmp.PhoneNumber);
                item.SubItems.Add(anEmp.Email);
                item.SubItems.Add(anEmp.JobId.ToString());
                listViewEmployee.Items.Add(item);
            }
        }

        private void buttonSearchEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            int choice = comboBoxSearchOption.SelectedIndex;
           
            if (choice == -1)
            {
                MessageBox.Show("Please select an option", "Reminder");
                return;
            }

           

            switch (choice)
            {

                case 0: //Search by Employee ID
                    if (textBox1.Text.Length == 0)
                    {
                        MessageBox.Show("Please Enter Employee Id", "Reminder");
                        this.textBox1.Focus();
                        return;
                    }
                    string input = this.textBoxEmployeeId.Text.Trim();

                    if (!VALIDATION.Validator_User.UserId_validation(input))
                    {
                        MessageBox.Show("Employee ID must be 4 digits!!!", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.textBox1.Focus();
                        return;
                    }

                    emp = emp.SearchEmployee(Convert.ToInt32(textBox1.Text));
                    if (emp != null)
                    {
                        textBoxEmployeeId.Text = emp.EmployeeId.ToString();
                        textBoxFirstName.Text = emp.FirstName.ToString();
                        textBoxLastName.Text = emp.LastName.ToString();
                        textBoxPhoneNumber.Text = emp.PhoneNumber.ToString();
                        textBoxEmail.Text = emp.Email.ToString();

                        Job job = new Job();
                        List <Job> jobs= job.GetAllJobs();
                        int jobIndex = 0;
                        foreach (Job j in jobs)
                        {
                            if(j.JobId == emp.JobId)
                            {
                                jobIndex = jobs.IndexOf(j);
                            }
                        }
                        this.comboBoxJob.SelectedIndex = jobIndex;
                        listViewEmployee.Items.Clear();
                        ListViewItem item = new ListViewItem(Convert.ToString(emp.EmployeeId));
                        item.SubItems.Add(Convert.ToString(emp.FirstName));
                        item.SubItems.Add(Convert.ToString(emp.LastName));
                        item.SubItems.Add(Convert.ToString(emp.PhoneNumber));
                        item.SubItems.Add(Convert.ToString(emp.Email));
                        item.SubItems.Add(Convert.ToString(emp.JobId));
                        listViewEmployee.Items.Add(item);
                        
                        

                    }
                    else
                    {
                        MessageBox.Show("Employee not found", "Invalid Id");
                        
                    }
                   
                    break;

                case 1: //Search by FirstName
                    if (textBox1.Text.Length == 0)
                    {
                        MessageBox.Show("Please Enter Employee last name", "Reminder");
                        this.textBox1.Focus();
                        return;
                    }

                    List<Employee> list = emp.SearchEmployeeByName(textBox1.Text.Trim());
                    if (list.Count >0)
                    { 
                        DisplayDataEmp(listViewEmployee, list);

                       
                    }
                    else
                    {
                        MessageBox.Show("no employee with this first name", "Invalid first name");
                    }

                    break;

                case 2: //Search by LastName
                    if (textBox1.Text.Length == 0)
                    {
                        MessageBox.Show("Please Enter Employee last name", "Reminder");
                        this.textBox1.Focus();
                        return;
                    }
                    List<Employee> lista = emp.SearchEmployeeByName(textBox1.Text.Trim());
                    if (lista.Count > 0)
                    {
                        DisplayDataEmp(listViewEmployee, lista);

                       
                    }
                    else
                    {
                        MessageBox.Show("no employee with this last name", "Invalid last name");
                    }
                    break;
            }
        }

        

        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            string input = this.textBoxEmployeeId.Text.Trim();

            if (!VALIDATION.Validator_User.UserId_validation(input))
            {
                MessageBox.Show("Employee ID must be 4 digits!!!", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxEmployeeId.Focus();
                return;
            }

            if (!emp.CheckExistedEmployee(Convert.ToInt32(input)))
            {
                MessageBox.Show("Employee ID is not existed!!!", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxEmployeeId.Focus();
                return;
            }

            input = this.textBoxLastName.Text.Trim();

            if (!VALIDATION.Validator_User.Employee_Name_validation(input))
            {
                MessageBox.Show("Employee Last Name must contain only character and white space!!!", "Invalid Employee Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxLastName.Focus();
                return;
            }


            input = this.textBoxFirstName.Text.Trim();

            if (!VALIDATION.Validator_User.Employee_Name_validation(input))
            {
                MessageBox.Show("Employee First Name must contain only character and white space!!!", "Invalid Employee Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxFirstName.Focus();
                return;
            }


            input = this.textBoxPhoneNumber.Text.Trim();

            if (!VALIDATION.Validator_User.Missing_input_validation(input))
            {
                MessageBox.Show("Missing Employee Phone Number !!!", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPhoneNumber.Focus();
                return;
            }

            input = this.textBoxEmail.Text.Trim();

            if (!VALIDATION.Validator_User.Email_validation(input))
            {
                MessageBox.Show("Email must not contain white space !!!", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxEmail.Focus();
                return;
            }




            if (this.comboBoxJob.SelectedIndex == -1)
            {
                MessageBox.Show("Please select employee job !!!", "Invalid job", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            emp.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text.Trim());

            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLastName.Text.Trim();
            emp.PhoneNumber = textBoxPhoneNumber.Text.Trim();
            emp.Email = textBoxEmail.Text.Trim();
            Job job = new Job();
            List<Job> jobs = job.GetAllJobs();
            emp.JobId = jobs[this.comboBoxJob.SelectedIndex].JobId;
            emp.UpdateEmployee(emp);
            MessageBox.Show("Employee data has been updated successfully.", "Confirmation");
        }


        #endregion

        #region Custom Method

        private void DisplayData(ListView listV, List<UserAccount> lUser)
        {
            listV.Items.Clear();
            foreach (UserAccount account in lUser)
            {
                ListViewItem item = new ListViewItem(account.UserId.ToString());
                item.SubItems.Add(account.Password.ToString());
                item.SubItems.Add(account.EmployeeId.ToString());
                listV.Items.Add(item);
            }
        }

        private void DisplayDataEmp(ListView ListV, List<Employee> ListE)
        {
            ListV.Items.Clear();
            foreach (Employee emp in ListE)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.LastName);
                item.SubItems.Add(emp.PhoneNumber);
                item.SubItems.Add(emp.Email);
                item.SubItems.Add(emp.JobId.ToString());
                ListV.Items.Add(item);
            }
        }





        #endregion

        private void UsersAccount_Form_Load(object sender, EventArgs e)
        {
            Job job = new Job();
            List<Job> jobs = job.GetAllJobs();

            UserAccount acc = new UserAccount();
            List<UserAccount> accs = acc.Get_all_user_account();

            Employee emp = new Employee();
            List<Employee> emps = emp.GetAllEmplooyee();

            this.comboBoxUser.Items.Clear();
            this.comboBoxUserSearch.Items.Clear();

            foreach(UserAccount u in accs)
            {
                this.comboBoxUserSearch.Items.Add(u.EmployeeId);
            }

            foreach(Employee em in emps)
            {
                if(em.JobId != 55555)
                {
                    string text = em.EmployeeId.ToString() + " - " + em.FirstName;
                    this.comboBoxUser.Items.Add(text);
                }
                
            }

            foreach (Job j in jobs)
            {
                
                this.comboBoxJob.Items.Add(j.JobTitle);

            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UsersAccount_Form_Load(sender, e);
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            LogIn_Form FL = new LogIn_Form();
            this.Hide();
            FL.ShowDialog();
            this.Close();
        }

        private void comboBoxUserSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

   




}
