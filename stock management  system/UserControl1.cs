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
    public partial class UserControl1 : UserControl
    {
        private DataTable dt;
        public UserControl1()
        {
            InitializeComponent();
            loadjoineddata1();
            InitializeSearchBar();
            
        }
        connectclass con = new connectclass();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void loadjoineddata1()
        {
            con.Connect();
            SqlDataAdapter sda = new SqlDataAdapter("select p.Productid,p.Productname,c.Categoryid, c.CategoryName, st.QtyinStock FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID  left JOIN Stock as st ON p.Productid = st.Productid", connectclass.con);
            dt = new DataTable();  
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void InitializeSearchBar()
        {
            
            TextBox SearchTextBox = new TextBox();
            SearchTextBox.Location = new Point(420, 22); 
            SearchTextBox.Size = new Size(200, 22);
            SearchTextBox.Font = new Font("Impact", 16);
            this.Controls.Add(SearchTextBox); 

            
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            string searchTerm = searchTextBox.Text.Trim();

            
            DataView dv = dt.DefaultView; 

            
            if (int.TryParse(searchTerm, out int categoryId))
            {
                
                dv.RowFilter = string.Format("Categoryid = {0}", categoryId);
            }
            else if (string.IsNullOrEmpty(searchTerm))
            {
                
                dv.RowFilter = string.Empty;
            }
            else
            {
                
                dv.RowFilter = string.Empty;
            }

            
            dataGridView1.DataSource = dv.ToTable();
        }

        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            loadjoineddata1();
        }
    }
}