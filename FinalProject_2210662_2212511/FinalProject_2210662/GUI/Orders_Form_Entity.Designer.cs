namespace FinalProject_2210662.GUI
{
    partial class Orders_Form_Entity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxEmployeeID = new System.Windows.Forms.ComboBox();
            this.comboBoxCustomerID = new System.Windows.Forms.ComboBox();
            this.comboBoxOrderStatus = new System.Windows.Forms.ComboBox();
            this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerShipDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerReqDate = new System.Windows.Forms.DateTimePicker();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxOrderType = new System.Windows.Forms.TextBox();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxLineSearch = new System.Windows.Forms.TextBox();
            this.buttonLineSearch = new System.Windows.Forms.Button();
            this.comboBoxLineSearch = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxISBN = new System.Windows.Forms.ComboBox();
            this.buttonOrderLineUpdate = new System.Windows.Forms.Button();
            this.buttonOrderLineList = new System.Windows.Forms.Button();
            this.buttonOrderLineCancel = new System.Windows.Forms.Button();
            this.buttonOrderLineAdd = new System.Windows.Forms.Button();
            this.textBoxLineQtnOrdered = new System.Windows.Forms.TextBox();
            this.textBoxLineOrderId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.OrderLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSignOut = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.comboBoxEmployeeID);
            this.groupBox1.Controls.Add(this.comboBoxCustomerID);
            this.groupBox1.Controls.Add(this.comboBoxOrderStatus);
            this.groupBox1.Controls.Add(this.dateTimePickerOrderDate);
            this.groupBox1.Controls.Add(this.dateTimePickerShipDate);
            this.groupBox1.Controls.Add(this.dateTimePickerReqDate);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.buttonList);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.textBoxOrderType);
            this.groupBox1.Controls.Add(this.textBoxOrderId);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orders";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(213, 210);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Select";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(213, 184);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Select";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(170, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Select";
            // 
            // comboBoxEmployeeID
            // 
            this.comboBoxEmployeeID.FormattingEnabled = true;
            this.comboBoxEmployeeID.Location = new System.Drawing.Point(133, 207);
            this.comboBoxEmployeeID.Name = "comboBoxEmployeeID";
            this.comboBoxEmployeeID.Size = new System.Drawing.Size(74, 21);
            this.comboBoxEmployeeID.TabIndex = 23;
            this.comboBoxEmployeeID.Enter += new System.EventHandler(this.comboBoxEmployeeID_Enter);
            // 
            // comboBoxCustomerID
            // 
            this.comboBoxCustomerID.FormattingEnabled = true;
            this.comboBoxCustomerID.Location = new System.Drawing.Point(133, 181);
            this.comboBoxCustomerID.Name = "comboBoxCustomerID";
            this.comboBoxCustomerID.Size = new System.Drawing.Size(74, 21);
            this.comboBoxCustomerID.TabIndex = 22;
            // 
            // comboBoxOrderStatus
            // 
            this.comboBoxOrderStatus.FormattingEnabled = true;
            this.comboBoxOrderStatus.Location = new System.Drawing.Point(133, 153);
            this.comboBoxOrderStatus.Name = "comboBoxOrderStatus";
            this.comboBoxOrderStatus.Size = new System.Drawing.Size(32, 21);
            this.comboBoxOrderStatus.TabIndex = 21;
            this.comboBoxOrderStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderStatus_SelectedIndexChanged);
            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.Location = new System.Drawing.Point(133, 49);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.Size = new System.Drawing.Size(150, 20);
            this.dateTimePickerOrderDate.TabIndex = 9;
            // 
            // dateTimePickerShipDate
            // 
            this.dateTimePickerShipDate.Location = new System.Drawing.Point(133, 127);
            this.dateTimePickerShipDate.Name = "dateTimePickerShipDate";
            this.dateTimePickerShipDate.Size = new System.Drawing.Size(150, 20);
            this.dateTimePickerShipDate.TabIndex = 20;
            // 
            // dateTimePickerReqDate
            // 
            this.dateTimePickerReqDate.Location = new System.Drawing.Point(133, 101);
            this.dateTimePickerReqDate.Name = "dateTimePickerReqDate";
            this.dateTimePickerReqDate.Size = new System.Drawing.Size(150, 20);
            this.dateTimePickerReqDate.TabIndex = 11;
            this.dateTimePickerReqDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(208, 286);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 19;
            this.buttonUpdate.Text = "&UPDATE";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonList
            // 
            this.buttonList.Location = new System.Drawing.Point(29, 286);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(75, 23);
            this.buttonList.TabIndex = 18;
            this.buttonList.Text = "&LIST";
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Location = new System.Drawing.Point(208, 257);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "&CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(29, 257);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 16;
            this.buttonAdd.Text = "&ADD";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxOrderType
            // 
            this.textBoxOrderType.Location = new System.Drawing.Point(133, 75);
            this.textBoxOrderType.Name = "textBoxOrderType";
            this.textBoxOrderType.Size = new System.Drawing.Size(115, 20);
            this.textBoxOrderType.TabIndex = 10;
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.Location = new System.Drawing.Point(133, 23);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(100, 20);
            this.textBoxOrderId.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Employee ID: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Customer ID: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Order Status: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Shipping Date: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Required Date: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Order Type: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order Date: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order ID: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 570);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 126);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(319, 101);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxSearch);
            this.tabPage1.Controls.Add(this.buttonSearch);
            this.tabPage1.Controls.Add(this.comboBoxSearch);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(311, 75);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Orders";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(123, 42);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(156, 20);
            this.textBoxSearch.TabIndex = 18;
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(19, 42);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 19;
            this.buttonSearch.Text = "&SEARCH";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "OrderId",
            "CustomerId",
            "EmployeeId"});
            this.comboBoxSearch.Location = new System.Drawing.Point(123, 15);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(156, 21);
            this.comboBoxSearch.TabIndex = 17;
            this.comboBoxSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearch_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Search Orders: ";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxLineSearch);
            this.tabPage2.Controls.Add(this.buttonLineSearch);
            this.tabPage2.Controls.Add(this.comboBoxLineSearch);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 75);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Order Line";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxLineSearch
            // 
            this.textBoxLineSearch.Location = new System.Drawing.Point(123, 45);
            this.textBoxLineSearch.Name = "textBoxLineSearch";
            this.textBoxLineSearch.Size = new System.Drawing.Size(156, 20);
            this.textBoxLineSearch.TabIndex = 21;
            this.textBoxLineSearch.Enter += new System.EventHandler(this.textBoxLineSearch_Enter);
            // 
            // buttonLineSearch
            // 
            this.buttonLineSearch.Enabled = false;
            this.buttonLineSearch.Location = new System.Drawing.Point(19, 43);
            this.buttonLineSearch.Name = "buttonLineSearch";
            this.buttonLineSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonLineSearch.TabIndex = 20;
            this.buttonLineSearch.Text = "&SEARCH";
            this.buttonLineSearch.UseVisualStyleBackColor = true;
            this.buttonLineSearch.Click += new System.EventHandler(this.buttonLineSearch_Click);
            // 
            // comboBoxLineSearch
            // 
            this.comboBoxLineSearch.FormattingEnabled = true;
            this.comboBoxLineSearch.Items.AddRange(new object[] {
            "OrderId",
            "ISBN",
            "QuantityOrdered"});
            this.comboBoxLineSearch.Location = new System.Drawing.Point(123, 16);
            this.comboBoxLineSearch.Name = "comboBoxLineSearch";
            this.comboBoxLineSearch.Size = new System.Drawing.Size(156, 21);
            this.comboBoxLineSearch.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Search OrderLine: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.comboBoxISBN);
            this.groupBox3.Controls.Add(this.buttonOrderLineUpdate);
            this.groupBox3.Controls.Add(this.buttonOrderLineList);
            this.groupBox3.Controls.Add(this.buttonOrderLineCancel);
            this.groupBox3.Controls.Add(this.buttonOrderLineAdd);
            this.groupBox3.Controls.Add(this.textBoxLineQtnOrdered);
            this.groupBox3.Controls.Add(this.textBoxLineOrderId);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(13, 355);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 213);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order Line";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(264, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Select";
            // 
            // comboBoxISBN
            // 
            this.comboBoxISBN.FormattingEnabled = true;
            this.comboBoxISBN.Items.AddRange(new object[] {
            "Please Select"});
            this.comboBoxISBN.Location = new System.Drawing.Point(132, 53);
            this.comboBoxISBN.Name = "comboBoxISBN";
            this.comboBoxISBN.Size = new System.Drawing.Size(126, 21);
            this.comboBoxISBN.TabIndex = 23;
            this.comboBoxISBN.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonOrderLineUpdate
            // 
            this.buttonOrderLineUpdate.Location = new System.Drawing.Point(207, 169);
            this.buttonOrderLineUpdate.Name = "buttonOrderLineUpdate";
            this.buttonOrderLineUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonOrderLineUpdate.TabIndex = 20;
            this.buttonOrderLineUpdate.Text = "&UPDATE";
            this.buttonOrderLineUpdate.UseVisualStyleBackColor = true;
            this.buttonOrderLineUpdate.Click += new System.EventHandler(this.buttonOrderLineUpdate_Click);
            // 
            // buttonOrderLineList
            // 
            this.buttonOrderLineList.Location = new System.Drawing.Point(28, 169);
            this.buttonOrderLineList.Name = "buttonOrderLineList";
            this.buttonOrderLineList.Size = new System.Drawing.Size(75, 23);
            this.buttonOrderLineList.TabIndex = 20;
            this.buttonOrderLineList.Text = "&LIST";
            this.buttonOrderLineList.UseVisualStyleBackColor = true;
            this.buttonOrderLineList.Click += new System.EventHandler(this.buttonOrderLineList_Click);
            // 
            // buttonOrderLineCancel
            // 
            this.buttonOrderLineCancel.Enabled = false;
            this.buttonOrderLineCancel.Location = new System.Drawing.Point(207, 140);
            this.buttonOrderLineCancel.Name = "buttonOrderLineCancel";
            this.buttonOrderLineCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonOrderLineCancel.TabIndex = 20;
            this.buttonOrderLineCancel.Text = "&CANCEL";
            this.buttonOrderLineCancel.UseVisualStyleBackColor = true;
            this.buttonOrderLineCancel.Click += new System.EventHandler(this.buttonOrderLineCancel_Click);
            // 
            // buttonOrderLineAdd
            // 
            this.buttonOrderLineAdd.Enabled = false;
            this.buttonOrderLineAdd.Location = new System.Drawing.Point(28, 140);
            this.buttonOrderLineAdd.Name = "buttonOrderLineAdd";
            this.buttonOrderLineAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonOrderLineAdd.TabIndex = 20;
            this.buttonOrderLineAdd.Text = "&ADD";
            this.buttonOrderLineAdd.UseVisualStyleBackColor = true;
            this.buttonOrderLineAdd.Click += new System.EventHandler(this.buttonOrderLineAdd_Click);
            // 
            // textBoxLineQtnOrdered
            // 
            this.textBoxLineQtnOrdered.Location = new System.Drawing.Point(132, 80);
            this.textBoxLineQtnOrdered.Name = "textBoxLineQtnOrdered";
            this.textBoxLineQtnOrdered.Size = new System.Drawing.Size(126, 20);
            this.textBoxLineQtnOrdered.TabIndex = 22;
            this.textBoxLineQtnOrdered.Enter += new System.EventHandler(this.textBoxLineQtnOrdered_Enter);
            // 
            // textBoxLineOrderId
            // 
            this.textBoxLineOrderId.Location = new System.Drawing.Point(132, 28);
            this.textBoxLineOrderId.Name = "textBoxLineOrderId";
            this.textBoxLineOrderId.Size = new System.Drawing.Size(100, 20);
            this.textBoxLineOrderId.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Quantity Ordered: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "ISBN: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Order ID:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.OrderDate,
            this.OrderType,
            this.RequiredDate,
            this.ShippingDate,
            this.OrderStatus,
            this.CustomerId,
            this.EmployeeId});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(363, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(844, 350);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.Name = "OrderId";
            this.OrderId.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "OrderDate";
            this.OrderDate.HeaderText = "OrderDate";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // OrderType
            // 
            this.OrderType.DataPropertyName = "OrderType";
            this.OrderType.HeaderText = "OrderType";
            this.OrderType.Name = "OrderType";
            this.OrderType.ReadOnly = true;
            // 
            // RequiredDate
            // 
            this.RequiredDate.DataPropertyName = "RequiredDate";
            this.RequiredDate.HeaderText = "RequiredDate";
            this.RequiredDate.Name = "RequiredDate";
            this.RequiredDate.ReadOnly = true;
            // 
            // ShippingDate
            // 
            this.ShippingDate.DataPropertyName = "ShippingDate";
            this.ShippingDate.HeaderText = "ShippingDate";
            this.ShippingDate.Name = "ShippingDate";
            this.ShippingDate.ReadOnly = true;
            // 
            // OrderStatus
            // 
            this.OrderStatus.DataPropertyName = "OrderStatus";
            this.OrderStatus.HeaderText = "OrderStatus";
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.ReadOnly = true;
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomerId";
            this.CustomerId.HeaderText = "CustomerId";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            // 
            // EmployeeId
            // 
            this.EmployeeId.DataPropertyName = "EmployeeId";
            this.EmployeeId.HeaderText = "EmployeeId";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            this.EmployeeId.Width = 101;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderLineId,
            this.ISBN,
            this.QuantityOrdered});
            this.dataGridView2.Enabled = false;
            this.dataGridView2.Location = new System.Drawing.Point(363, 383);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(844, 356);
            this.dataGridView2.TabIndex = 25;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // OrderLineId
            // 
            this.OrderLineId.DataPropertyName = "OrderId";
            this.OrderLineId.HeaderText = "OrderId";
            this.OrderLineId.Name = "OrderLineId";
            this.OrderLineId.ReadOnly = true;
            this.OrderLineId.Width = 266;
            // 
            // ISBN
            // 
            this.ISBN.DataPropertyName = "ISBN";
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.Name = "ISBN";
            this.ISBN.ReadOnly = true;
            this.ISBN.Width = 266;
            // 
            // QuantityOrdered
            // 
            this.QuantityOrdered.DataPropertyName = "QuantityOrdered";
            this.QuantityOrdered.HeaderText = "QuantityOrdered";
            this.QuantityOrdered.Name = "QuantityOrdered";
            this.QuantityOrdered.ReadOnly = true;
            this.QuantityOrdered.Width = 269;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(15, 702);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(101, 44);
            this.buttonReset.TabIndex = 20;
            this.buttonReset.Text = "&RESET";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(230, 703);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(101, 44);
            this.buttonExit.TabIndex = 26;
            this.buttonExit.Text = "&EXIT";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSignOut
            // 
            this.buttonSignOut.Location = new System.Drawing.Point(122, 703);
            this.buttonSignOut.Name = "buttonSignOut";
            this.buttonSignOut.Size = new System.Drawing.Size(102, 43);
            this.buttonSignOut.TabIndex = 27;
            this.buttonSignOut.Text = "&SIGNOUT";
            this.buttonSignOut.UseVisualStyleBackColor = true;
            this.buttonSignOut.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Orders_Form_Entity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 758);
            this.Controls.Add(this.buttonSignOut);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1247, 797);
            this.MinimumSize = new System.Drawing.Size(1247, 797);
            this.Name = "Orders_Form_Entity";
            this.Text = "Orders Application";
            this.Load += new System.EventHandler(this.Orders_Form_Entity_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOrderType;
        private System.Windows.Forms.TextBox textBoxOrderId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxLineQtnOrdered;
        private System.Windows.Forms.TextBox textBoxLineOrderId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonOrderLineUpdate;
        private System.Windows.Forms.Button buttonOrderLineList;
        private System.Windows.Forms.Button buttonOrderLineCancel;
        private System.Windows.Forms.Button buttonOrderLineAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxLineSearch;
        private System.Windows.Forms.Button buttonLineSearch;
        private System.Windows.Forms.ComboBox comboBoxLineSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityOrdered;
        private System.Windows.Forms.DateTimePicker dateTimePickerReqDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerShipDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
        private System.Windows.Forms.ComboBox comboBoxISBN;
        private System.Windows.Forms.ComboBox comboBoxOrderStatus;
        private System.Windows.Forms.ComboBox comboBoxCustomerID;
        private System.Windows.Forms.ComboBox comboBoxEmployeeID;
        private System.Windows.Forms.Button buttonSignOut;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
    }
}