using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace stock_management__system
{
    public partial class Main : Form
    {
        private Timer timer;
        private DataTable dtProducts;
        private DataTable dtSuppliers;
        public Main()
        {
            InitializeComponent();
           
            UserControl1 userControl1 = new UserControl1();
            this.Controls.Add(userControl1); 
            userControl1.Visible = false;
            
            UserControl2 userControl2 = new UserControl2();
            this.Controls.Add(userControl2);

            datausercontrol datausercontrol = new datausercontrol();
            this.Controls.Add(datausercontrol);
            datausercontrol.Visible = false;

            userControl2.Visible = false;
            addpnl.Visible = false;
            storagepnl.Visible = true;
            tranpnl.Visible = false;
            datapnl.Visible = false;

            maskedTextBox1.Text = DateTime.Now.ToString("MM/dd/yyyy");
            maskedTextBox2.Text = DateTime.Now.ToString("HH:mm");


        }
        
        connectclass con = new connectclass();
        
        private void Form2_Load(object sender, EventArgs e)
        {
            
            this.productsTableAdapter1.Fill(this.stockDataSet2.Products);

            loadjoineddata();
            
            
            userControl11.Show();
            userControl11.BringToFront();
            userControl21.Hide();
            userControl11.loadjoineddata1();
            datausercontrol1.Hide();
           // datausercontrol1.Loaddata();




        }


        private void loadjoineddata()
        {
            con.Connect();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT t.Date, t.Time, p.Productname AS Product, c.CategoryName AS Category, s.SupplierName AS Supplier, t.Quantity AS Qty, p.Price, p.Cost AS Cost, p.UnitOfMeasure AS Unit, t.Type, t.Total FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID INNER JOIN Transactions t ON p.ProductID = t.ProductID LEFT JOIN Stock st ON p.ProductID = st.ProductID order by t.date desc, t.time desc", connectclass.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT DISTINCT p.Productid, p.Productname, s.suppliername, s.supplierid FROM Products p LEFT JOIN Suppliers s ON p.supplierid = s.supplierid ORDER BY p.productname ASC", connectclass.con);
            dtProducts = new DataTable();
            sda1.Fill(dtProducts);

            dtSuppliers = dtProducts.Clone();
            prodcombo.DataSource = dtProducts;
            prodcombo.DisplayMember = "Productname";
            prodcombo.ValueMember = "Productid";
            
            connectclass.con.Close();
        }

       
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0)
             {
                 DataGridViewRow row = dataGridView1.Rows[e.RowIndex];



               //  textBox4.Text = row.Cells["Productid"].Value.ToString();
                // textBox3.Text = row.Cells["Date"].Value.ToString();
               //  textBox2.Text = row.Cells["Transactiontype"].Value.ToString();
               //  textBox5.Text = row.Cells["Quantity"].Value.ToString();
                // textBox1.Text = row.Cells["TotalPrice"].Value.ToString();

             }
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.Text == "" || maskedTextBox1.Text == "" || prodcombo.Text == "" || textBox5.Text == "" || maskedTextBox2.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }

            else if (comboBox1.Text == "Sale")
            {

                int b = Convert.ToInt32(textBox5.Text);
                int c = 0;
                int p = 0;

                string query = "SELECT Price FROM Products WHERE Productid = @Productid";
                string query2 = "SELECT QtyinStock FROM Stock WHERE Productid = @Productid";

                con.Connect();
                SqlCommand cmd = new SqlCommand(query, connectclass.con);
                cmd.Parameters.AddWithValue("@Productid", Convert.ToInt32(prodcombo.SelectedValue));


                SqlCommand cmd2 = new SqlCommand(query2, connectclass.con);
                cmd2.Parameters.AddWithValue("@Productid", Convert.ToInt32(prodcombo.SelectedValue));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = Convert.ToInt32(reader["Price"]);
                }
                reader.Close();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    p = Convert.ToInt32(reader2["QtyinStock"]);
                }
                reader2.Close();


                int totalPrice = b * c;
                int currentstock = p - b;


                SqlCommand insertCmd = new SqlCommand("INSERT INTO Transactions (Productid, Date, Type, Quantity, Total,Time) VALUES (@Productid, @Date, @Type, @Quantity, @Total, @Time)", connectclass.con);
                insertCmd.Parameters.AddWithValue("@Productid", Convert.ToInt32(prodcombo.SelectedValue));
                insertCmd.Parameters.AddWithValue("@Date", maskedTextBox1.Text);
                insertCmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                insertCmd.Parameters.AddWithValue("@Quantity", textBox5.Text);
                insertCmd.Parameters.AddWithValue("@Total", totalPrice);
                insertCmd.Parameters.AddWithValue("@Time", maskedTextBox2.Text);

                SqlCommand updateCmd2 = new SqlCommand("UPDATE Stock SET QtyinStock = @QtyinStock WHERE Productid = @Productid", connectclass.con);
                updateCmd2.Parameters.AddWithValue("@QtyinStock", currentstock);
                updateCmd2.Parameters.AddWithValue("@Productid", Convert.ToInt32(prodcombo.SelectedValue));

                insertCmd.ExecuteNonQuery();
                updateCmd2.ExecuteNonQuery();

                MessageBox.Show("Transaction Added Successfully");

                loadjoineddata();
                connectclass.con.Close();
            }
            else if (comboBox1.Text == "Purchase")
            {
                int d = Convert.ToInt32(textBox5.Text);
                int f = 0;
                int g = 0;

                string query1 = "SELECT Cost FROM Products WHERE Productid = @Productid";
                string query2 = "SELECT QtyinStock FROM Stock WHERE Productid = @Productid";

                con.Connect();

                
                SqlCommand cmd1 = new SqlCommand(query1, connectclass.con);
                cmd1.Parameters.AddWithValue("@Productid",Convert.ToInt32( prodcombo.SelectedValue)); 

                
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    f = Convert.ToInt32(reader1["Cost"]);
                }
                reader1.Close(); 

                
                SqlCommand cmd2 = new SqlCommand(query2, connectclass.con);
                cmd2.Parameters.AddWithValue("@Productid", Convert.ToInt32(prodcombo.SelectedValue)); 

                
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    g = Convert.ToInt32(reader2["QtyinStock"]);
                }
                reader2.Close();    

                    
                int totalCost = d * f;
                int currentstock = g + d;

                
                SqlCommand insertCmd1 = new SqlCommand("INSERT INTO Transactions (Productid, Date, Type, Quantity, Total, Time) VALUES (@Productid, @Date, @Type, @Quantity, @Total, @Time)", connectclass.con);
                insertCmd1.Parameters.AddWithValue("@Productid", Convert.ToInt32(prodcombo.SelectedValue));  
                insertCmd1.Parameters.AddWithValue("@Date", maskedTextBox1.Text);
                insertCmd1.Parameters.AddWithValue("@Type", comboBox1.Text);
                insertCmd1.Parameters.AddWithValue("@Quantity", textBox5.Text);
                insertCmd1.Parameters.AddWithValue("@Total", totalCost);
                insertCmd1.Parameters.AddWithValue("@Time", maskedTextBox2.Text);

                
                SqlCommand updateCmd2 = new SqlCommand("UPDATE Stock SET QtyinStock = @QtyinStock WHERE Productid = @Productid", connectclass.con);
                updateCmd2.Parameters.AddWithValue("@QtyinStock", currentstock);
                updateCmd2.Parameters.AddWithValue("@Productid", Convert.ToInt32(prodcombo.SelectedValue));  

                
                insertCmd1.ExecuteNonQuery();
                updateCmd2.ExecuteNonQuery();

                
                MessageBox.Show("Transaction Added Successfully");
                loadjoineddata();
                connectclass.con.Close();

            }
                }
            
        

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl21.BringToFront();
            datausercontrol1.Hide();

            tranpnl.Visible = true;
            addpnl.Visible = false;
            storagepnl.Visible = false;
            datapnl.Visible = false;
            loadjoineddata();
            maskedTextBox1.Text = DateTime.Now.ToString("MM/dd/yyyy");
            maskedTextBox2.Text = DateTime.Now.ToString("HH:mm");
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl11.BringToFront();
            userControl11.Show();
            userControl11.loadjoineddata1();
            userControl21.Hide();
            storagepnl.Visible = true;
            tranpnl.Visible = false;
            addpnl.Visible = false;
            datapnl.Visible = false;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void Supplierbtn_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.BringToFront();
            userControl21.Show();
            addpnl.Visible = true;
            storagepnl.Visible = false;
            tranpnl.Visible = false; 
            datapnl.Visible = false;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void customPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void customPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void htmlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void homebtn_Click(object sender, EventArgs e)
        {

        }

        private void tranpnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void databtn_Click(object sender, EventArgs e)
        {
            datausercontrol1.BringToFront();
            datausercontrol1.Show();
            datapnl.Visible = true;
            storagepnl.Visible = false;
            tranpnl.Visible = false;
            addpnl.Visible = false;
            userControl11.Hide();
            userControl21.Hide();
            datausercontrol1.Loaddata();
            

            datausercontrol1.LoadYearsIntoComboBox();
            




        }

        private void datausercontrol1_Load(object sender, EventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

    private enum _Process_DPI_Awareness
        {
            Process_DPI_Unaware = 0,
            Process_System_DPI_Aware = 1,
            Process_Per_Monitor_DPI_Aware = 2
        }

        private void supcombox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
