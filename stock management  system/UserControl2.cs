using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stock_management__system
{
    
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
            loadjoineddata2();  
        }
        connectclass con = new connectclass();
        private void UserControl2_Load(object sender, EventArgs e)
        {
           loadjoineddata2();

        }
        public void loadjoineddata2()
        {

            con.Connect();

            
            SqlDataAdapter categoryAdapter = new SqlDataAdapter("SELECT DISTINCT CategoryID, CategoryName FROM Categories order by CategoryName asc ", connectclass.con);
            DataTable categoryTable = new DataTable();
            categoryAdapter.Fill(categoryTable);

            
            SqlDataAdapter supplierAdapter = new SqlDataAdapter("SELECT DISTINCT SupplierID, SupplierName FROM Suppliers order by SupplierName asc", connectclass.con);
            DataTable supplierTable = new DataTable();
            supplierAdapter.Fill(supplierTable);

            SqlDataAdapter unit = new SqlDataAdapter("SELECT DISTINCT UnitOfMeasure FROM Products order by UnitOfMeasure asc  ", connectclass.con);
            DataTable unitTable = new DataTable();
            unit.Fill(unitTable);


            Catcombo.DataSource = categoryTable;
            Catcombo.DisplayMember = "CategoryName";
            Catcombo.ValueMember = "CategoryID";

            supbox.DataSource = supplierTable;
            supbox.DisplayMember = "SupplierName";
            supbox.ValueMember = "SupplierID";

            unitbox.DataSource = unitTable;
            unitbox.DisplayMember = "UnitOfMeasure";

            connectclass.con.Close();

        }

        private void emailbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            if (pronbox.Text == "" || pricebox.Text == "" || costbox.Text == "" || supbox.Text == "" || Catcombo.Text == "" || unitbox.Text == "")
            {
                MessageBox.Show("Please fill all the fields");

            }
            else
            {
                con.Connect();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO Products 
                                      (Productname, CategoryID, SupplierID, UnitOfMeasure, Price, Cost) 
                                      OUTPUT INSERTED.ProductID 
                                      VALUES 
                                      (@Productname, @CategoryID, @SupplierID, @UnitOfMeasure, @Price, @Cost)", connectclass.con);

                cmd.Parameters.AddWithValue("@Productname", pronbox.Text);
                cmd.Parameters.AddWithValue("@CategoryID", Catcombo.SelectedValue);
                cmd.Parameters.AddWithValue("@SupplierID", supbox.SelectedValue);
                cmd.Parameters.AddWithValue("@UnitOfMeasure", unitbox.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(pricebox.Text));
                cmd.Parameters.AddWithValue("@Cost", Convert.ToDecimal(costbox.Text));

                int productId = (int)cmd.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand("INSERT INTO Stock (ProductID, QTYinstock) VALUES (@ProductID, 0)", connectclass.con);
                cmd1.Parameters.AddWithValue("@ProductID", productId);

                cmd1.ExecuteNonQuery();
                loadjoineddata2();
                connectclass.con.Close();
                MessageBox.Show("Product Added Successfully");
            }
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void supnbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Catcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void supbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (supnbox.Text == "" || emailbox.Text == "" || phonenummaskedbox.Text == "")
            {
                MessageBox.Show("Please fill all the fields");

            }
            else
            {
                con.Connect();
                string queryint = "insert into Suppliers (SupplierName,ContactEmail,PhoneNumber) values (@SupplierName,@ContactEmail,@PhoneNumber)";
                SqlCommand cmd = new SqlCommand(queryint, connectclass.con);
                cmd.Parameters.AddWithValue("@SupplierName", supnbox.Text);
                cmd.Parameters.AddWithValue("@ContactEmail", emailbox.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", phonenummaskedbox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supplier Added Successfully!");
                loadjoineddata2();
                connectclass.con.Close();
            }
        }
            

        private void costbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            tab tab = new tab();
            tab.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            tabpro tabpro = new tabpro();
            tabpro.Show();
            tabpro.loadjoineddata();
        }
    }

}
