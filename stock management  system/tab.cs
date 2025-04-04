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
    public partial class tab : Form
    {
        public tab()
        {
            InitializeComponent();
        }

        private void tab_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.stockDataSet.Suppliers);

        }
    }
}
