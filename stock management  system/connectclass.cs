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
            if (con == null)
            {
                con = new SqlConnection("Server=tcp:stockserverzzz.database.windows.net,1433;Initial Catalog=stock;Persist Security Info=False;User ID=punch;Password=GMpp12531254;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }

     /*   public void Disconnect()
        {
            try
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing connection: " + ex.Message);
            }
        }*/
    }
}

