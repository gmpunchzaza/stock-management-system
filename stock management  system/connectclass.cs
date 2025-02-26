using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock_management__system
{
    internal class connectclass
    {
        public static SqlConnection con;

        public void Connect()
        {
            con = new SqlConnection("Data Source=DESKTOP-U196HJO\\MSSQLSERVER01;Initial Catalog=stock;Integrated Security=True;TrustServerCertificate=True");
            try
            {

                con.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }

        }
    }
}

