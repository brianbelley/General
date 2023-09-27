using FinalProject_2210662.MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace FinalProject_2210662.GUI
{
    public partial class Orders_Form_Entity : Form
    {
        public Orders_Form_Entity()
        {
            InitializeComponent();
        }

        //Initialize
        int OrdId = 0;
        HiTechDBEntities hiTechDBEntities = new HiTechDBEntities();
        Order order = new Order();
        OrderLine line = new OrderLine();

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            //list
           dataGridView1.AutoGenerateColumns = false;
           dataGridView1.DataSource = hiTechDBEntities.Orders.ToList<Order>();

            dataGridView1.Enabled = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Add
            int orderidcheck = Convert.ToInt32(textBoxOrderId.Text.Trim());
            var orderidverify = hiTechDBEntities.Orders.Any(o => o.OrderId == orderidcheck);

            if (orderidverify)
            {
                MessageBox.Show("Cannot add record due to it being a duplicate", "Error");
                return;
            }
            order.OrderId = Convert.ToInt32(textBoxOrderId.Text.Trim());
            OrdId = Convert.ToInt32(textBoxOrderId.Text.Trim());
            order.OrderDate = Convert.ToDateTime(dateTimePickerOrderDate.Text.Trim());
            order.OrderType = textBoxOrderType.Text.Trim();
            order.RequiredDate = Convert.ToDateTime(dateTimePickerReqDate.Text.Trim());
            order.ShippingDate = Convert.ToDateTime(dateTimePickerShipDate.Text.Trim());
            order.OrderStatus = Convert.ToInt32(comboBoxOrderStatus.Text.Trim());
            order.CustomerId = Convert.ToInt32(comboBoxCustomerID.Text.Trim());
            order.EmployeeId = Convert.ToInt32(comboBoxEmployeeID.Text.Trim());


            hiTechDBEntities.Orders.Add(order);
            hiTechDBEntities.SaveChanges();
            ClearData();
            MessageBox.Show("Information saved." , "Sucessful");

            buttonAdd.Enabled = false;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Orders_Form_Entity_Load(object sender, EventArgs e)
        {
            //Combobox
            ClearData();

            List<OrderLine> listlines = (from OrderLine in hiTechDBEntities.OrderLines select OrderLine).ToList();

            listlines.Insert(0, new OrderLine { OrderId = 0 });

            comboBoxISBN.DataSource = listlines;
            comboBoxISBN.DisplayMember = "ISBN";
            comboBoxISBN.ValueMember = "ISBN";


            List<Order> listorder = (from Order in hiTechDBEntities.Orders select Order).ToList();

            listorder.Insert(0, new Order { OrderStatus = 0 });

            comboBoxOrderStatus.DataSource = listorder;
            comboBoxOrderStatus.DisplayMember = "OrderStatus";
            comboBoxOrderStatus.ValueMember = "OrderStatus";

            List<Customer> listcust = (from Customer in hiTechDBEntities.Customers select Customer).ToList();

            listcust.Insert(0, new Customer { CustomerId = 0 });

            comboBoxCustomerID.DataSource = listcust;
            comboBoxCustomerID.DisplayMember = "CustomerId";
            comboBoxCustomerID.ValueMember = "CustomerId";


            List<Employee> listemp = (from Employee in hiTechDBEntities.Employees select Employee).ToList();

            listemp.Insert(0, new Employee { EmployeeId = 0 });

            comboBoxEmployeeID.DataSource = listemp;
            comboBoxEmployeeID.DisplayMember = "EmployeeId";
            comboBoxEmployeeID.ValueMember = "EmployeeId";



        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //update
            order.OrderDate = Convert.ToDateTime(dateTimePickerOrderDate.Text.Trim());
            order.OrderType = textBoxOrderType.Text.Trim();
            order.RequiredDate = Convert.ToDateTime(dateTimePickerReqDate.Text.Trim());
            order.ShippingDate = Convert.ToDateTime(dateTimePickerShipDate.Text.Trim());
            order.OrderStatus = Convert.ToInt32(comboBoxOrderStatus.Text.Trim());
            order.CustomerId = Convert.ToInt32(comboBoxCustomerID.Text.Trim());
            order.EmployeeId = Convert.ToInt32(comboBoxEmployeeID.Text.Trim());

            hiTechDBEntities.Entry(order).State = EntityState.Modified;
            ClearData();
            MessageBox.Show("Information updated.", "Sucessful");
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //delete
            if(MessageBox.Show("Are you sure you want to cancel this order? ", "Delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int custidcheck = Convert.ToInt32(comboBoxCustomerID.Text.Trim());
                int empidcheck = Convert.ToInt32(comboBoxEmployeeID.Text.Trim());
                var checkcustid = hiTechDBEntities.Orders.Any(o => o.CustomerId == custidcheck);
                var checkempid = hiTechDBEntities.Orders.Any(o => o.EmployeeId == empidcheck);
                if (checkcustid)
                {
                    MessageBox.Show("Cannot delete the current record due to it being connected to table Customer !", "Error");
                    return;
                }
                else if (checkempid)
                {
                    MessageBox.Show("Cannot delete the current record due to it being connected to table Employee !", "Error");
                    return;
                }
                else
                {
                    hiTechDBEntities.Entry(order).State = EntityState.Modified;
                    hiTechDBEntities.Orders.Remove(order);
                    hiTechDBEntities.SaveChanges();
                    ClearData();
                    MessageBox.Show("Order canceled Sucessfully.", "Sucessful");

                    buttonCancel.Enabled = false;
                }
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //select by gridview
            if (dataGridView1.CurrentCell.RowIndex != -1)
            {
                OrdId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderId"].Value);
                order = hiTechDBEntities.Orders.Where(x => x.OrderId == OrdId).FirstOrDefault();
                textBoxOrderId.Text = order.OrderId.ToString();
                dateTimePickerOrderDate.Text = order.OrderDate.ToString();
                textBoxOrderType.Text = order.OrderType.ToString();
                dateTimePickerReqDate.Text = order.RequiredDate.ToString();
                dateTimePickerShipDate.Text = order.ShippingDate.ToString();
                comboBoxOrderStatus.Text = order.OrderStatus.ToString();
                comboBoxCustomerID.Text = order.CustomerId.ToString();
                comboBoxEmployeeID.Text = order.EmployeeId.ToString();


                MessageBox.Show("Found the information from the Order Id: " + order.OrderId.ToString(), "Confirmation");
                hiTechDBEntities.Entry(order).State = EntityState.Detached;
                buttonCancel.Enabled = true;
                buttonAdd.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   //select by gridview
            if (dataGridView2.CurrentCell.RowIndex != -1)
            {
                OrdId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["OrderLineId"].Value);
                line = hiTechDBEntities.OrderLines.Where(x => x.OrderId == OrdId).FirstOrDefault();
                textBoxLineOrderId.Text = line.OrderId.ToString();
                comboBoxISBN.Text = line.ISBN.ToString();
                textBoxLineQtnOrdered.Text = line.QuantityOrdered.ToString();

                MessageBox.Show("Collect information from the Order Id: " + line.OrderId.ToString(), "Confirmation");

                hiTechDBEntities.Entry(line).State = EntityState.Detached;
                buttonOrderLineCancel.Enabled = true;
                buttonOrderLineAdd.Enabled = false;
            }
        }

        private void buttonOrderLineList_Click(object sender, EventArgs e)
        {   //list
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = hiTechDBEntities.OrderLines.ToList<OrderLine>();
            dataGridView2.Enabled = true;
        }

        private void buttonOrderLineCancel_Click(object sender, EventArgs e)
        {
            //delete
            if (MessageBox.Show("Are you sure you want to cancel this order? ", "Delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                hiTechDBEntities.Entry(line).State = EntityState.Modified;
                hiTechDBEntities.OrderLines.Remove(line);
                hiTechDBEntities.SaveChanges();
                ClearData();
                MessageBox.Show("Order canceled Sucessfully.", "Sucessful");

                buttonOrderLineCancel.Enabled = false;
            }

        }

        private void buttonOrderLineAdd_Click(object sender, EventArgs e)
        {   //Add
            int orderidlinecheck = Convert.ToInt32(textBoxLineOrderId.Text.Trim());
            var orderidlineverify = hiTechDBEntities.OrderLines.Any(o => o.OrderId == orderidlinecheck);

            if (orderidlineverify)
            {
                MessageBox.Show("Cannot add record due to it being a duplicate", "Error");
                return;
            }

            line.OrderId = Convert.ToInt32(textBoxLineOrderId.Text.Trim());
            line.ISBN = comboBoxISBN.Text.Trim();
            line.QuantityOrdered = Convert.ToInt32(textBoxLineQtnOrdered.Text.Trim());

            hiTechDBEntities.OrderLines.Add(line);
            hiTechDBEntities.SaveChanges();
            ClearData();
            MessageBox.Show("Information saved.", "Sucessful");

            OrdId = 0;

            buttonOrderLineAdd.Enabled = false;
        }

        private void buttonOrderLineUpdate_Click(object sender, EventArgs e)
        {
            //Update
            line.OrderId = Convert.ToInt32(textBoxLineOrderId.Text.Trim());
            line.ISBN = comboBoxISBN.Text.Trim();
            line.QuantityOrdered = Convert.ToInt32(textBoxLineQtnOrdered.Text.Trim());

            hiTechDBEntities.Entry(line).State = EntityState.Modified;

            ClearData();
            MessageBox.Show("Information updated.", "Sucessful");
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {   
            //Remove input data
            ClearData();
            MessageBox.Show("Information cleared", "Sucessful");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //searching by input
            int choice = comboBoxSearch.SelectedIndex;
            var inttext = Convert.ToInt32(textBoxSearch.Text.Trim());
            dataGridView1.AutoGenerateColumns = false;
            if (choice == -1)
            {
                MessageBox.Show("Please select an option", "Caution");
            }

            switch (choice)
            {
                case 0:
                    if (inttext != 0)
                    {
                        dataGridView1.DataSource = hiTechDBEntities.Orders.Where(x => x.OrderId == inttext).ToList<Order>();
                        dataGridView1.Enabled = true;
                        buttonSearch.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Order was not found", "Error");
                    }
                    break;
                case 1:
                    if(inttext != 0)
                    {
                        dataGridView1.DataSource = hiTechDBEntities.Orders.Where(x => x.CustomerId == inttext).ToList<Order>();
                        dataGridView1.Enabled = true;
                        buttonSearch.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Order was not found", "Error");
                    }
                    
                    break;
                case 2:
                    if(inttext != 0)
                    {
                        dataGridView1.DataSource = hiTechDBEntities.Orders.Where(x => x.EmployeeId == inttext).ToList<Order>();
                        dataGridView1.Enabled = true;
                        buttonSearch.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Order was not found", "Error");
                    }
                    
                    break;
            }
        }

        private void buttonLineSearch_Click(object sender, EventArgs e)
        {   //Search
            int choice = comboBoxLineSearch.SelectedIndex;
            var inttext = Convert.ToInt64(textBoxLineSearch.Text.Trim());
            dataGridView2.AutoGenerateColumns = false;
            if (choice == -1)
            {
                MessageBox.Show("Please select an option", "Caution");
            }

            switch (choice)
            {
                case 0:
                    if (inttext != 0)
                    {
                        dataGridView2.DataSource = hiTechDBEntities.OrderLines.Where(x => x.OrderId == inttext).ToList<OrderLine>();
                        dataGridView2.Enabled = true;
                        buttonLineSearch.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Order was not found", "Error");
                    }
                    break;
                case 1:
                    if (inttext != 0)
                    {
                        dataGridView2.DataSource = hiTechDBEntities.OrderLines.Where(x => x.ISBN == inttext.ToString()).ToList<OrderLine>();
                        dataGridView2.Enabled = true;
                        buttonLineSearch.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Order was not found", "Error");
                    }

                    break;
                case 2:
                    if (inttext != 0)
                    {
                        dataGridView2.DataSource = hiTechDBEntities.OrderLines.Where(x => x.QuantityOrdered == inttext).ToList<OrderLine>();
                        dataGridView2.Enabled = true;
                        buttonLineSearch.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Order was not found", "Error");
                    }

                    break;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {   
            //Exit
            if (MessageBox.Show("Are you sure you want to Exit?  ", "Exit ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBoxEmployeeId_Enter(object sender, EventArgs e)
        {
            
                buttonAdd.Enabled = true;

        }

        private void textBoxLineQtnOrdered_Enter(object sender, EventArgs e)
        {
            buttonOrderLineAdd.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            buttonSearch.Enabled = true;
        }

        private void textBoxLineSearch_Enter(object sender, EventArgs e)
        {
            buttonLineSearch.Enabled = true;
        }


        private void comboBoxEmployeeID_Enter(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LogIn_Form FL = new LogIn_Form();
            this.Hide();
            FL.ShowDialog();
            this.Close();
        }


        //Methods


        //Clearing Data

        public void ClearData()
        {
            //Order
            textBoxOrderId.Clear();
            dateTimePickerOrderDate.ResetText();
            comboBoxOrderStatus.SelectedIndex = -1;
            textBoxOrderType.Clear();
            comboBoxCustomerID.ResetText();
            dateTimePickerReqDate.ResetText();
            dateTimePickerShipDate.ResetText();
            comboBoxEmployeeID.ResetText();

            //OrderLine

            textBoxLineOrderId.Clear();
            comboBoxISBN.SelectedIndex = -1;
            textBoxLineQtnOrdered.Clear();

            OrdId = 0;
        }

        private void comboBoxOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
