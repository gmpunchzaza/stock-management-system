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
    public partial class tabpro : Form
    {
        public tabpro()
        {
            InitializeComponent();
        }
        connectclass con = new connectclass();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void loadjoineddata()
        {
            
            con.Connect();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT  p.Productname AS Product, c.CategoryName AS Category, s.SupplierName AS Supplier, p.Price, p.Cost AS Cost, p.UnitOfMeasure AS Unit FROM Products as  p INNER JOIN Categories as c ON p.CategoryID = c.CategoryID INNER JOIN Suppliers as s ON p.SupplierID = s.SupplierID order by p.productname asc", connectclass.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            connectclass.con.Close();

        }
       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

    
