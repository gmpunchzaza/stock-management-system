namespace stock_management__system
{
    partial class UserControl2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.pronbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.costbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pricebox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.supnbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.emailbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.phonenummaskedbox = new System.Windows.Forms.MaskedTextBox();
            this.probtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Catcombo = new System.Windows.Forms.ComboBox();
            this.categoriesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.stockDataSet1 = new stock_management__system.stockDataSet1();
            this.stockDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriesTableAdapter = new stock_management__system.stockDataSet1TableAdapters.CategoriesTableAdapter();
            this.fKProductsCatego3B75D760BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter = new stock_management__system.stockDataSet1TableAdapters.ProductsTableAdapter();
            this.stockDataSet11 = new stock_management__system.stockDataSet1();
            this.supbox = new System.Windows.Forms.ComboBox();
            this.suppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.unitbox = new System.Windows.Forms.ComboBox();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suppliersTableAdapter = new stock_management__system.stockDataSet1TableAdapters.SuppliersTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKProductsCatego3B75D760BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pronbox
            // 
            this.pronbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pronbox.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pronbox.Location = new System.Drawing.Point(107, 108);
            this.pronbox.Multiline = true;
            this.pronbox.Name = "pronbox";
            this.pronbox.Size = new System.Drawing.Size(269, 42);
            this.pronbox.TabIndex = 11;
            this.pronbox.TextChanged += new System.EventHandler(this.supnbox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "Name";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(103, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "Cost";
            // 
            // costbox
            // 
            this.costbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.costbox.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costbox.Location = new System.Drawing.Point(107, 220);
            this.costbox.Multiline = true;
            this.costbox.Name = "costbox";
            this.costbox.Size = new System.Drawing.Size(269, 42);
            this.costbox.TabIndex = 23;
            this.costbox.TextChanged += new System.EventHandler(this.costbox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(410, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Price";
            // 
            // pricebox
            // 
            this.pricebox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pricebox.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricebox.Location = new System.Drawing.Point(414, 220);
            this.pricebox.Multiline = true;
            this.pricebox.Name = "pricebox";
            this.pricebox.Size = new System.Drawing.Size(269, 42);
            this.pricebox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(410, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "Category ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(103, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 21);
            this.label4.TabIndex = 30;
            this.label4.Text = "Name";
            // 
            // supnbox
            // 
            this.supnbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.supnbox.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supnbox.Location = new System.Drawing.Point(107, 75);
            this.supnbox.Multiline = true;
            this.supnbox.Name = "supnbox";
            this.supnbox.Size = new System.Drawing.Size(269, 42);
            this.supnbox.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(410, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 21);
            this.label6.TabIndex = 32;
            this.label6.Text = "Email";
            // 
            // emailbox
            // 
            this.emailbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emailbox.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailbox.Location = new System.Drawing.Point(414, 73);
            this.emailbox.Multiline = true;
            this.emailbox.Name = "emailbox";
            this.emailbox.Size = new System.Drawing.Size(269, 42);
            this.emailbox.TabIndex = 31;
            this.emailbox.TextChanged += new System.EventHandler(this.emailbox_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(720, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 21);
            this.label7.TabIndex = 34;
            this.label7.Text = "Phonenumber";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 41);
            this.label8.TabIndex = 35;
            this.label8.Text = "Products";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(3, 434);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 41);
            this.label9.TabIndex = 36;
            this.label9.Text = "Suppliers";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // phonenummaskedbox
            // 
            this.phonenummaskedbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.phonenummaskedbox.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonenummaskedbox.Location = new System.Drawing.Point(724, 73);
            this.phonenummaskedbox.Mask = "000-00-0000";
            this.phonenummaskedbox.Name = "phonenummaskedbox";
            this.phonenummaskedbox.PromptChar = 'x';
            this.phonenummaskedbox.Size = new System.Drawing.Size(269, 40);
            this.phonenummaskedbox.TabIndex = 37;
            this.phonenummaskedbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // probtn
            // 
            this.probtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.probtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.probtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.probtn.FlatAppearance.BorderSize = 0;
            this.probtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.probtn.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.probtn.ForeColor = System.Drawing.Color.Transparent;
            this.probtn.Location = new System.Drawing.Point(1055, 220);
            this.probtn.Name = "probtn";
            this.probtn.Size = new System.Drawing.Size(176, 50);
            this.probtn.TabIndex = 38;
            this.probtn.Text = "Add";
            this.probtn.UseVisualStyleBackColor = false;
            this.probtn.Click += new System.EventHandler(this.insertbtn_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(720, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 21);
            this.label10.TabIndex = 40;
            this.label10.Text = "Unit Of Measure";
            // 
            // Catcombo
            // 
            this.Catcombo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Catcombo.BackColor = System.Drawing.Color.White;
            this.Catcombo.DataSource = this.categoriesBindingSource1;
            this.Catcombo.DisplayMember = "CategoryName";
            this.Catcombo.DropDownHeight = 85;
            this.Catcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Catcombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Catcombo.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Catcombo.FormattingEnabled = true;
            this.Catcombo.IntegralHeight = false;
            this.Catcombo.Location = new System.Drawing.Point(414, 105);
            this.Catcombo.Margin = new System.Windows.Forms.Padding(0);
            this.Catcombo.MaxDropDownItems = 100;
            this.Catcombo.Name = "Catcombo";
            this.Catcombo.Size = new System.Drawing.Size(269, 42);
            this.Catcombo.TabIndex = 41;
            this.Catcombo.ValueMember = "CategoryID";
            this.Catcombo.SelectedIndexChanged += new System.EventHandler(this.Catcombo_SelectedIndexChanged);
            // 
            // categoriesBindingSource1
            // 
            this.categoriesBindingSource1.DataMember = "Categories";
            this.categoriesBindingSource1.DataSource = this.stockDataSet1;
            // 
            // stockDataSet1
            // 
            this.stockDataSet1.DataSetName = "stockDataSet1";
            this.stockDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockDataSet1BindingSource
            // 
            this.stockDataSet1BindingSource.DataSource = this.stockDataSet1;
            this.stockDataSet1BindingSource.Position = 0;
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.stockDataSet1BindingSource;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // fKProductsCatego3B75D760BindingSource
            // 
            this.fKProductsCatego3B75D760BindingSource.DataMember = "FK__Products__Catego__3B75D760";
            this.fKProductsCatego3B75D760BindingSource.DataSource = this.categoriesBindingSource;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // stockDataSet11
            // 
            this.stockDataSet11.DataSetName = "stockDataSet1";
            this.stockDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // supbox
            // 
            this.supbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.supbox.BackColor = System.Drawing.Color.White;
            this.supbox.DataSource = this.suppliersBindingSource;
            this.supbox.DisplayMember = "SupplierName";
            this.supbox.DropDownHeight = 85;
            this.supbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supbox.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supbox.FormattingEnabled = true;
            this.supbox.IntegralHeight = false;
            this.supbox.Location = new System.Drawing.Point(724, 105);
            this.supbox.Margin = new System.Windows.Forms.Padding(0);
            this.supbox.MaxDropDownItems = 100;
            this.supbox.Name = "supbox";
            this.supbox.Size = new System.Drawing.Size(269, 42);
            this.supbox.TabIndex = 42;
            this.supbox.ValueMember = "SupplierID";
            this.supbox.SelectedIndexChanged += new System.EventHandler(this.supbox_SelectedIndexChanged);
            // 
            // suppliersBindingSource
            // 
            this.suppliersBindingSource.DataMember = "Suppliers";
            this.suppliersBindingSource.DataSource = this.stockDataSet1BindingSource;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(720, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 21);
            this.label11.TabIndex = 43;
            this.label11.Text = "Supplier";
            // 
            // unitbox
            // 
            this.unitbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitbox.BackColor = System.Drawing.Color.White;
            this.unitbox.DataSource = this.productsBindingSource;
            this.unitbox.DisplayMember = "UnitOfMeasure";
            this.unitbox.DropDownHeight = 85;
            this.unitbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unitbox.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitbox.FormattingEnabled = true;
            this.unitbox.IntegralHeight = false;
            this.unitbox.Location = new System.Drawing.Point(724, 220);
            this.unitbox.Margin = new System.Windows.Forms.Padding(0);
            this.unitbox.MaxDropDownItems = 100;
            this.unitbox.Name = "unitbox";
            this.unitbox.Size = new System.Drawing.Size(269, 42);
            this.unitbox.TabIndex = 44;
            this.unitbox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.stockDataSet1BindingSource;
            // 
            // suppliersTableAdapter
            // 
            this.suppliersTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1055, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 50);
            this.button1.TabIndex = 45;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.costbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.probtn);
            this.panel1.Controls.Add(this.pricebox);
            this.panel1.Controls.Add(this.supbox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.Catcombo);
            this.panel1.Controls.Add(this.unitbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pronbox);
            this.panel1.Location = new System.Drawing.Point(3, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1286, 374);
            this.panel1.TabIndex = 46;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.phonenummaskedbox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.emailbox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.supnbox);
            this.panel2.Location = new System.Drawing.Point(3, 483);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1286, 184);
            this.panel2.TabIndex = 47;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1292, 670);
            this.tableLayoutPanel1.TabIndex = 45;
            // 
            // UserControl2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(208, 0);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1368, 698);
            this.Load += new System.EventHandler(this.UserControl2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKProductsCatego3B75D760BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox pronbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox costbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pricebox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox supnbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox emailbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox phonenummaskedbox;
        private System.Windows.Forms.Button probtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Catcombo;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private System.Windows.Forms.BindingSource stockDataSet1BindingSource;
        private stockDataSet1 stockDataSet1;
        private stockDataSet1TableAdapters.CategoriesTableAdapter categoriesTableAdapter;
        private System.Windows.Forms.BindingSource categoriesBindingSource1;
        private System.Windows.Forms.BindingSource fKProductsCatego3B75D760BindingSource;
        private stockDataSet1TableAdapters.ProductsTableAdapter productsTableAdapter;
        private stockDataSet1 stockDataSet11;
        private System.Windows.Forms.ComboBox supbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox unitbox;
        private System.Windows.Forms.BindingSource suppliersBindingSource;
        private stockDataSet1TableAdapters.SuppliersTableAdapter suppliersTableAdapter;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
