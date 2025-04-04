using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock_management__system
{
    public partial class Formlogin : Form
    {
        public Formlogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Formlogin_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {

            string username = textBox2.Text.Trim();
            string password = textBox1.Text.Trim();

            
            if (username == "" || password == "")
            {
                MessageBox.Show("Please Enter Username and Password");
            }
            else
            {
                
                if (username == "admin" && password == "12345")
                {
                    
                    this.Hide();
                    Main f2 = new Main();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }


