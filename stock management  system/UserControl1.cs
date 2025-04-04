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
using stock_management_system;

namespace stock_management__system
{
    public partial class UserControl1 : UserControl
    {
        private DataTable dt;
        public UserControl1()
        {
            InitializeComponent();
            loadjoineddata1();

            allcirclepro.Value = 0;
            allcirclepro.Minimum = 0;
            allcirclepro.Maximum = 100;
            if (!dataGridView1.Columns.Contains("StockProgress"))
            {
                DataGridViewProgressBarColumn progressBarColumn = new DataGridViewProgressBarColumn();
                progressBarColumn.HeaderText = "Stock Percentage";
                progressBarColumn.Name = "StockProgress";
                dataGridView1.Columns.Add(progressBarColumn);
            }

        }
        connectclass con = new connectclass();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void loadjoineddata1()
        {
            con.Connect();
            SqlDataAdapter sda = new SqlDataAdapter("select p.Productname, st.QtyinStock FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID  left JOIN Stock as st ON p.Productid = st.Productid order by st.QtyinStock desc", connectclass.con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            int totalStock = 0;


            foreach (DataRow row in dt.Rows)
            {
                if (row["QtyinStock"] != DBNull.Value)
                {
                    totalStock += Convert.ToInt32(row["QtyinStock"]);
                }
            }

            int stockPercentage = (int)Math.Round((double)totalStock / 5000 * 100);
            allcirclepro.Value = Math.Min(stockPercentage, allcirclepro.Maximum);
            allcirclepro.Text = allcirclepro.Value.ToString() + "%";
            label4.Text = totalStock.ToString() + " Items";

            foreach (DataRow row in dt.Rows)
            {
                if (row["QtyinStock"] != DBNull.Value)
                {
                    int stockQty = Convert.ToInt32(row["QtyinStock"]);
                    int stockPercentageRow = (int)Math.Round((double)stockQty / 5000 * 100);

                    int rowIndex = dt.Rows.IndexOf(row);

                    // Ensure the row exists before setting the value
                    if (rowIndex < dataGridView1.Rows.Count)
                    {
                        dataGridView1.Rows[rowIndex].Cells["StockProgress"].Value = stockPercentageRow;
                    }
                    
                    
                }
            }
            connectclass.con.Close();
        }



        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            loadjoineddata1();
        }

        private void allcirclepro_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* allcirclepro.Value += 1;
             allcirclepro.Text = allcirclepro.Value.ToString();*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}