using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject_2210662.BLL;
using FinalProject_2210662.DAL;

namespace FinalProject_2210662.GUI
{
    public partial class Customer_Form : Form
    {
        SqlDataAdapter da;
        DataSet dsHitechDB;
        DataTable dtCustomer;
        SqlCommandBuilder sqlBuilder;
        




        public Customer_Form()
        {
            InitializeComponent();
        }

        private void Customer_Form_Load(object sender, EventArgs e)
        {
            dsHitechDB = new DataSet("HiTechDS");
            dtCustomer = new DataTable("Customers");
            dtCustomer.Columns.Add("CustomerId", typeof(int));
            dtCustomer.Columns.Add("CustomerName", typeof(string));
            dtCustomer.Columns.Add("StreetName", typeof(string));
            dtCustomer.Columns.Add("Province", typeof(string));
            dtCustomer.Columns.Add("City", typeof(string));
            dtCustomer.Columns.Add("PostalCode", typeof(string));
            dtCustomer.Columns.Add("PhoneNumber", typeof(string));
            dtCustomer.Columns.Add("ContactName", typeof(string));
            dtCustomer.Columns.Add("ContactEmail", typeof(string));
            dtCustomer.Columns.Add("Status", typeof(int));
            dtCustomer.Columns.Add("CreditLimit", typeof(int));
            dtCustomer.PrimaryKey = new DataColumn[] { dtCustomer.Columns["CustomerId"] };
            da = new SqlDataAdapter();
            da.TableMappings.Add("Customers", "Customer");
            sqlBuilder= new SqlCommandBuilder(da);
            da.SelectCommand = new SqlCommand("SELECT * FROM Customers", Utility.GetDBConnection());
            da.Fill(dtCustomer);


            buttonSearch.Enabled = false;
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            dataGridViewCustomer.DataSource = dtCustomer;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string input = this.textBoxCustomerId.Text.Trim();

            if (!VALIDATION.Validator_Customer.CustomerId_validation(input))
            {
                MessageBox.Show("Customer ID must be 6 digits!!!", "Invalid Customer ID",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCustomerId.Focus();
                return;
            }

            foreach (DataRow dr in dtCustomer.Rows)
            {
                if (dr["CustomerId"].ToString() == this.textBoxCustomerId.Text)
                {
                    MessageBox.Show("Customer ID is already exist!!!", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBoxCustomerId.Focus();
                    return;
                }
            }

            input = this.textBoxCustomerName.Text.Trim();
            if (!VALIDATION.Validator_Customer.Name_validation(input))
            {
                MessageBox.Show("Customer Name can only contain letters and whitespace", "Invalid Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCustomerName.Focus();
                return;
            }

            input = this.textBoxContactName.Text.Trim();
            if (!VALIDATION.Validator_Customer.Name_validation(input))
            {
                MessageBox.Show("Contact Name can only contain letters and whitespace", "Invalid Contact Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxContactName.Focus();
                return;
            }

            input = this.textBoxContactEmail.Text.Trim();
            if (!VALIDATION.Validator_Customer.Email_validation(input))
            {
                MessageBox.Show("Contact Email can not contain any whitespace", "Invalid Contact Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxContactEmail.Focus();
                return;
            }

            input = this.textBoxPhoneNumber.Text.Trim();
            if (!VALIDATION.Validator_Customer.Missing_input_validation(input))
            {
                MessageBox.Show("Phone Number must be filled", "Missing Phone number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPhoneNumber.Focus();
                return;
            }

            input = this.textBoxCreditLimit.Text.Trim();
            if (!VALIDATION.Validator_Customer.Status_Validation(input))
            {
                MessageBox.Show("Credit Limit can only contain digits", "Invalid Credit Limit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCreditLimit.Focus();
                return;
            }

            input = this.textBoxStatus.Text.Trim();
            if (!VALIDATION.Validator_Customer.Status_Validation(input))
            {
                MessageBox.Show("Status can only contain digits", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxStatus.Focus();
                return;
            }

            input = this.textBoxStreetName.Text.Trim();
            if (!VALIDATION.Validator_User.Missing_input_validation(input))
            {
                MessageBox.Show("Street cannot be empty ", "Missing street name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxStreetName.Focus();
                return;
            }

            input = this.textBoxProvince.Text.Trim();
            if (!VALIDATION.Validator_Customer.Name_validation(input))
            {
                MessageBox.Show("Province can only contains letters and whitespace", "Invalid Province", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxProvince.Focus();
                return;
            }

            input = this.textBoxCity.Text.Trim();
            if (!VALIDATION.Validator_Customer.Name_validation(input))
            {
                MessageBox.Show("City can only contains letters and whitespace", "Invalid City", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCity.Focus();
                return;
            }

            input = this.textBoxPostalCode.Text.Trim();
            if (!VALIDATION.Validator_Customer.PostalCode_validation(input))
            {
                MessageBox.Show("Postal code is not true!", "Invalid Postal Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPostalCode.Focus();
                return;
            }

            dtCustomer.Rows.Add(Convert.ToInt32(this.textBoxCustomerId.Text), this.textBoxCustomerName.Text, 
                this.textBoxStreetName.Text, this.textBoxProvince.Text, this.textBoxCity.Text, this.textBoxPostalCode.Text, 
                this.textBoxPhoneNumber.Text, this.textBoxContactName.Text, this.textBoxContactEmail.Text,
                Convert.ToInt32(this.textBoxStatus.Text), Convert.ToInt32(this.textBoxCreditLimit.Text));

            MessageBox.Show("Customer with ID: " + this.textBoxCustomerId.Text + " has been added successfully!!!", "Successfully", MessageBoxButtons.OK);

            da.Update(dtCustomer);

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            string input = this.textBoxCustomerId.Text.Trim();
            bool existCId = false;

            if (!VALIDATION.Validator_Customer.CustomerId_validation(input))
            {
                MessageBox.Show("Customer ID must be 6 digits!!!", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCustomerId.Focus();
                return;
            }

            foreach (DataRow dr in dtCustomer.Rows)
            {
                if (dr["CustomerId"].ToString() == this.textBoxCustomerId.Text)
                {
                    existCId= true;
                }
            }

            if (!existCId)
            {
                MessageBox.Show("Customer ID is not existed!!!", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCustomerId.Focus();
                return;

            }

            input = this.textBoxCustomerName.Text.Trim();
            if (!VALIDATION.Validator_Customer.Name_validation(input))
            {
                MessageBox.Show("Customer Name can only contain letters and whitespace", "Invalid Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCustomerName.Focus();
                return;
            }

            input = this.textBoxContactName.Text.Trim();
            if (!VALIDATION.Validator_Customer.Name_validation(input))
            {
                MessageBox.Show("Contact Name can only contain letters and whitespace", "Invalid Contact Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxContactName.Focus();
                return;
            }

            input = this.textBoxContactEmail.Text.Trim();
            if (!VALIDATION.Validator_Customer.Email_validation(input))
            {
                MessageBox.Show("Contact Email can not contain any whitespace", "Invalid Contact Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxContactEmail.Focus();
                return;
            }

            input = this.textBoxPhoneNumber.Text.Trim();
            if (!VALIDATION.Validator_Customer.Missing_input_validation(input))
            {
                MessageBox.Show("Phone Number must be filled", "Missing Phone number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPhoneNumber.Focus();
                return;
            }

            input = this.textBoxCreditLimit.Text.Trim();
            if (!VALIDATION.Validator_Customer.Status_Validation(input))
            {
                MessageBox.Show("Credit Limit can only contain digits", "Invalid Credit Limit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCreditLimit.Focus();
                return;
            }

            input = this.textBoxStatus.Text.Trim();
            if (!VALIDATION.Validator_Customer.Status_Validation(input))
            {
                MessageBox.Show("Status can only contain digits", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxStatus.Focus();
                return;
            }

            input = this.textBoxStreetName.Text.Trim();
            if (!VALIDATION.Validator_User.Missing_input_validation(input))
            {
                MessageBox.Show("Street cannot be empty ", "Missing street name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxStreetName.Focus();
                return;
            }

            input = this.textBoxProvince.Text.Trim();
            if (!VALIDATION.Validator_Customer.Name_validation(input))
            {
                MessageBox.Show("Province can only contains letters and whitespace", "Invalid Province", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxProvince.Focus();
                return;
            }

            input = this.textBoxCity.Text.Trim();
            if (!VALIDATION.Validator_Customer.Name_validation(input))
            {
                MessageBox.Show("City can only contains letters and whitespace", "Invalid City", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCity.Focus();
                return;
            }

            input = this.textBoxPostalCode.Text.Trim();
            if (!VALIDATION.Validator_Customer.PostalCode_validation(input))
            {
                MessageBox.Show("Postal code is not true!", "Invalid Postal Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPostalCode.Focus();
                return;
            }


            DialogResult option = MessageBox.Show("Do you want to update Customer with ID: " + this.textBoxCustomerId.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                foreach (DataRow dr in dtCustomer.Rows)
                {
                    if (dr["CustomerId"].ToString()==this.textBoxCustomerId.Text)
                    {
                        dr["CustomerName"] = this.textBoxCustomerName.Text;
                        dr["StreetName"] = this.textBoxStreetName.Text;
                        dr["Province"] = this.textBoxProvince.Text;
                        dr["City"] = this.textBoxCity.Text;
                        dr["PostalCode"] = this.textBoxPostalCode.Text;
                        dr["PhoneNumber"] = this.textBoxPhoneNumber.Text;
                        dr["ContactName"] = this.textBoxContactName.Text;
                        dr["ContactEmail"] = this.textBoxContactEmail.Text;
                        dr["Status"] = Convert.ToInt32(this.textBoxStatus.Text);
                        dr["CreditLimit"] = Convert.ToInt32(this.textBoxCreditLimit.Text);


                    }
                }

                MessageBox.Show("Updated Successfully", "Successfully");
            }

            da.Update(dtCustomer);



        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string input = this.textBoxCustomerId.Text.Trim();
            bool existCId = false;

            if (!VALIDATION.Validator_Customer.CustomerId_validation(input))
            {
                MessageBox.Show("Customer ID must be 6 digits!!!", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCustomerId.Focus();
                return;
            }

            foreach (DataRow dr in dtCustomer.Rows)
            {
                if (dr["CustomerId"].ToString() == this.textBoxCustomerId.Text)
                {
                    existCId = true;
                }
            }

            if (!existCId)
            {
                MessageBox.Show("Customer ID is not existed!!!", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxCustomerId.Focus();
                return;

            }

            DialogResult option = MessageBox.Show("Do you want to Delete Customer with ID: " + this.textBoxCustomerId.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                foreach (DataRow dr in dtCustomer.Rows)
                {
                    if (dr["CustomerId"].ToString() == this.textBoxCustomerId.Text)
                    {
                        dtCustomer.Rows.Remove(dr);
                        MessageBox.Show("Deleted Successfully", "Successfully");
                        da.Update(dtCustomer);
                        return;
                    }
                } 
            }

            


        }

        private void comboBoxSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSearch.Enabled = true;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            

            List<Customer> lRow;
            Customer cus;
            switch (comboBoxSearchOption.SelectedIndex) 
            {
                case 0:

                    if (!VALIDATION.Validator_Customer.CustomerId_validation(this.textBoxSearch.Text))
                    {
                        MessageBox.Show("Invalid Customer ID");
                        break;
                    }

                    lRow = new List<Customer>();
                    
                    
                    foreach (DataRow dr in dtCustomer.Rows)
                    {

                        if (Convert.ToInt32(dr["CustomerID"]) == Convert.ToInt32(this.textBoxSearch.Text))
                        {

                            cus = new Customer();
                            cus.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                            cus.CustomerName = dr["CustomerName"].ToString();
                            cus.ContactEmail = dr["ContactEmail"].ToString();
                            cus.ContactName = dr["ContactName"].ToString();
                            cus.PhoneNumber = dr["PhoneNumber"].ToString();
                            cus.CreditLimit = Convert.ToInt32(dr["CreditLimit"]);
                            cus.Status = Convert.ToInt32(dr["Status"]);
                            cus.StreetName = dr["StreetName"].ToString();
                            cus.Province = dr["Province"].ToString();
                            cus.City = dr["City"].ToString();
                            cus.PostalCode = dr["PostalCode"].ToString();

                            lRow.Add(cus);
                        }
                    }
                    dataGridViewCustomer.DataSource = lRow;
                    break;

                    case 1:
                    lRow = new List<Customer>();


                    foreach (DataRow dr in dtCustomer.Rows)
                    {

                        if (dr["CustomerName"].ToString().Trim() == this.textBoxSearch.Text.Trim())
                        {

                            cus = new Customer();
                            cus.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                            cus.CustomerName = dr["CustomerName"].ToString();
                            cus.ContactEmail = dr["ContactEmail"].ToString();
                            cus.ContactName = dr["ContactName"].ToString();
                            cus.PhoneNumber = dr["PhoneNumber"].ToString();
                            cus.CreditLimit = Convert.ToInt32(dr["CreditLimit"]);
                            cus.Status = Convert.ToInt32(dr["Status"]);
                            cus.StreetName = dr["StreetName"].ToString();
                            cus.Province = dr["Province"].ToString();
                            cus.City = dr["City"].ToString();
                            cus.PostalCode = dr["PostalCode"].ToString();

                            lRow.Add(cus);
                        }
                    }
                    if (lRow.Count > 0)
                    {
                        dataGridViewCustomer.DataSource = lRow;
                    }
                    else
                    {
                        MessageBox.Show("No Customer founded!", "No data found");
                    }
                    


                    break;


                    case 2:
                    lRow = new List<Customer>();


                    foreach (DataRow dr in dtCustomer.Rows)
                    {

                        if (dr["ContactName"].ToString().Trim() == this.textBoxSearch.Text.Trim())
                        {

                            cus = new Customer();
                            cus.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                            cus.CustomerName = dr["CustomerName"].ToString();
                            cus.ContactEmail = dr["ContactEmail"].ToString();
                            cus.ContactName = dr["ContactName"].ToString();
                            cus.PhoneNumber = dr["PhoneNumber"].ToString();
                            cus.CreditLimit = Convert.ToInt32(dr["CreditLimit"]);
                            cus.Status = Convert.ToInt32(dr["Status"]);
                            cus.StreetName = dr["StreetName"].ToString();
                            cus.Province = dr["Province"].ToString();
                            cus.City = dr["City"].ToString();
                            cus.PostalCode = dr["PostalCode"].ToString();

                            lRow.Add(cus);
                        }
                    }
                    if (lRow.Count > 0)
                    {
                        dataGridViewCustomer.DataSource = lRow;
                    }
                    else
                    {
                        MessageBox.Show("No Customer founded!", "No data found");
                    }
                    break;


            }
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            LogIn_Form FL = new LogIn_Form();
            this.Hide();
            FL.ShowDialog();
            this.Close();
        }
    }
}
