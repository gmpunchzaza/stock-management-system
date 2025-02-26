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


namespace stock_management__system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
             
             UserControl1 userControl1 = new UserControl1();
             this.Controls.Add(userControl1); 
            userControl1.Visible = false;
            UserControl2 userControl2 = new UserControl2();
            this.Controls.Add(userControl2);
            userControl2.Visible = false;
            userControl21.Visible = false;
        }
        connectclass con = new connectclass();
        
        private void Form2_Load(object sender, EventArgs e)
        {
            
            loadjoineddata();
            userControl11.Hide();

            
             

        }


        private void loadjoineddata()
        {
            con.Connect();
            SqlDataAdapter sda = new SqlDataAdapter("select p.Productid,p.Productname, c.CategoryName, s.SupplierName, t.Quantity, p.Price,p.cost, p.UnitOfMeasure, t.Date,t.Time,t.type,t.Total FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID INNER JOIN Transactions as t ON p.productid = t.productid left JOIN Stock as st ON p.Productid = st.Productid ", connectclass.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
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
            if (comboBox1.Text == "" || maskedTextBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || maskedTextBox2.Text == "")
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
                cmd.Parameters.AddWithValue("@Productid", textBox4.Text);


                SqlCommand cmd2 = new SqlCommand(query2, connectclass.con);
                cmd2.Parameters.AddWithValue("@Productid", textBox4.Text);


                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    p = Convert.ToInt32(reader2["QtyinStock"]);
                }
                reader2.Close();


                int totalPrice = b * c;
                int currentstock = p - b;


                SqlCommand insertCmd = new SqlCommand("INSERT INTO Transactions (Productid, Date, Type, Quantity, Total,Time) VALUES (@Productid, @Date, @Type, @Quantity, @Total, @Time)", connectclass.con);
                insertCmd.Parameters.AddWithValue("@Productid", textBox4.Text);
                insertCmd.Parameters.AddWithValue("@Date", maskedTextBox1.Text);
                insertCmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                insertCmd.Parameters.AddWithValue("@Quantity", textBox5.Text);
                insertCmd.Parameters.AddWithValue("@Total", totalPrice);
                insertCmd.Parameters.AddWithValue("@Time", maskedTextBox2.Text);

                SqlCommand updateCmd2 = new SqlCommand("UPDATE Stock SET QtyinStock = @QtyinStock WHERE Productid = @Productid", connectclass.con);
                updateCmd2.Parameters.AddWithValue("@QtyinStock", currentstock);
                updateCmd2.Parameters.AddWithValue("@Productid", textBox4.Text);

                insertCmd.ExecuteNonQuery();
                updateCmd2.ExecuteNonQuery();

                MessageBox.Show("Transaction Added Successfully");

                loadjoineddata();
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
                cmd1.Parameters.AddWithValue("@Productid", textBox4.Text); 

                
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    f = Convert.ToInt32(reader1["Cost"]);
                }
                reader1.Close(); 

                
                SqlCommand cmd2 = new SqlCommand(query2, connectclass.con);
                cmd2.Parameters.AddWithValue("@Productid", textBox4.Text); 

                
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    g = Convert.ToInt32(reader2["QtyinStock"]);
                }
                reader2.Close();    

                    
                int totalCost = d * f;
                int currentstock = g + d;

                
                SqlCommand insertCmd1 = new SqlCommand("INSERT INTO Transactions (Productid, Date, Type, Quantity, Total, Time) VALUES (@Productid, @Date, @Type, @Quantity, @Total, @Time)", connectclass.con);
                insertCmd1.Parameters.AddWithValue("@Productid", textBox4.Text);  
                insertCmd1.Parameters.AddWithValue("@Date", maskedTextBox1.Text);
                insertCmd1.Parameters.AddWithValue("@Type", comboBox1.Text);
                insertCmd1.Parameters.AddWithValue("@Quantity", textBox5.Text);
                insertCmd1.Parameters.AddWithValue("@Total", totalCost);
                insertCmd1.Parameters.AddWithValue("@Time", maskedTextBox2.Text);

                
                SqlCommand updateCmd2 = new SqlCommand("UPDATE Stock SET QtyinStock = @QtyinStock WHERE Productid = @Productid", connectclass.con);
                updateCmd2.Parameters.AddWithValue("@QtyinStock", currentstock);
                updateCmd2.Parameters.AddWithValue("@Productid", textBox4.Text);  

                
                insertCmd1.ExecuteNonQuery();
                updateCmd2.ExecuteNonQuery();

                
                MessageBox.Show("Transaction Added Successfully");
                loadjoineddata();
            }
                }
            
        

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl11.BringToFront();
            userControl11.Show();
            userControl11.loadjoineddata1();
            userControl21.Hide();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void Supplierbtn_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.BringToFront();
            userControl21.Show();


        }
    }
}
