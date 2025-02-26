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
    //อันนี้ยังไม่เสร็จ
    //อันนี้ยังไม่เสร็จ
    //อันนี้ยังไม่เสร็จ
    //อันนี้ยังไม่เสร็จ
    //อันนี้ยังไม่เสร็จ
    //อันนี้ยังไม่เสร็จ
    //อันนี้ยังไม่เสร็จ
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
            SqlDataAdapter sda = new SqlDataAdapter("select s.SupplierName, c.CategoryName, p.ProductName, p.Price,p.cost, p.UnitOfMeasure, s.ContactEmail, s.PhoneNumber FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID   ", connectclass.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void emailbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            
            con.Connect();
            
            SqlCommand cmd = new SqlCommand("insert into Suppliers(SupplierName, ContactEmail, PhoneNumber) values(@SupplierName, @ContactEmail, @PhoneNumber)", connectclass.con);
            cmd.Parameters.AddWithValue("@SupplierName", supnbox.Text);
            cmd.Parameters.AddWithValue("@ContactEmail", emailbox.Text);    
            cmd.Parameters.AddWithValue("@PhoneNumber", phonenummaskedbox.Text);
            cmd.ExecuteNonQuery();
            
            SqlCommand cmd1 = new SqlCommand("insert into Categories(CategoryName) values(@CategoryName)", connectclass.con);
            cmd1.Parameters.AddWithValue("@CategoryName", catnbox.Text);
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("insert into Products(ProductName, Price, cost, UnitOfMeasure) values(@ProductName, @Price, @cost, @UnitOfMeasure)", connectclass.con);
            cmd2.Parameters.AddWithValue("@ProductName", pronbox.Text);
            cmd2.Parameters.AddWithValue("@Price", pricebox.Text);
            cmd2.Parameters.AddWithValue("@cost", costbox.Text);
            cmd2.Parameters.AddWithValue("@UnitOfMeasure", unitbox.Text);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("insert into Stock(QtyinStock) values(0)", connectclass.con);
            cmd3.ExecuteNonQuery();

            loadjoineddata2();

        }
    }

}
