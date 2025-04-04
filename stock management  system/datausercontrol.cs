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

using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts.Wpf;
using LiveCharts;
using System.Threading;


namespace stock_management__system
{
    public partial class datausercontrol : UserControl
    {
        public datausercontrol()
        {
            InitializeComponent();

            // LoadChartData();
            LoadYearsIntoComboBox();
            cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;






        }
        connectclass con = new connectclass();


        public async void Loaddata()
        {
            await Task.Run(async () => await Task.Delay(30)); // Simulate a delay for loading data
            {
                con.Connect();
               
                

                string query = @"
        SELECT 
            (SELECT SUM(total) FROM transactions WHERE Type = 'Purchase') AS TotalPurchase,
            (SELECT SUM(total) FROM transactions WHERE Type = 'Sale') AS TotalSale,
            (SELECT SUM(Quantity) FROM transactions WHERE Type = 'Sale') AS SoldProducts,
            (SELECT SUM(Quantity) FROM transactions WHERE Type = 'Purchase') AS PurchasedProducts";

                int totalPurchase = 0, totalSale = 0, soldProducts = 0, purchasedProducts = 0;

                using (SqlCommand cmd = new SqlCommand(query, connectclass.con))
                    
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    try
                    {
                        if (dr.Read())
                        {
                            totalPurchase = dr["TotalPurchase"] != DBNull.Value ? Convert.ToInt32(dr["TotalPurchase"]) : 0;
                            totalSale = dr["TotalSale"] != DBNull.Value ? Convert.ToInt32(dr["TotalSale"]) : 0;
                            soldProducts = dr["SoldProducts"] != DBNull.Value ? Convert.ToInt32(dr["SoldProducts"]) : 0;
                            purchasedProducts = dr["PurchasedProducts"] != DBNull.Value ? Convert.ToInt32(dr["PurchasedProducts"]) : 0;
                        }
                    }
                    finally
                    {
                        dr.Close();
                        connectclass.con.Close();// Ensure the SqlDataReader is closed after reading
                    }
                }

                // Update UI safely from the main thread
                this.Invoke(new Action(() =>
                {
                    profitlabel.Text = FormatNumber(totalSale - totalPurchase);
                    label15.Text = FormatNumber(soldProducts);
                    label7.Text = FormatNumber(purchasedProducts);
                }));
            };

            // Load charts and dropdown asynchronously
            await Task.Run(() => LoadStockPrediction());
            await Task.Run(() => LoadMonthlySalesGrowth());

            // Load years directly on the UI thread
            this.Invoke(new Action(() => LoadYearsIntoComboBox()));
        }









        private void datausercontrol_Load(object sender, EventArgs e)
        {
            if (cmbYear.Items.Count > 0)
            {
                cmbYear.SelectedIndex = 0;
                int selectedYear = Convert.ToInt32(cmbYear.SelectedValue);
                LoadChartDatacar(selectedYear);
            }
            //  LoadStockPrediction();
            //  LoadMonthlySalesGrowth();
            // LoadYearsIntoComboBox();
            //  Loaddata();
            // GetSalesData();
            //   LoadMonthlySalesGrowth();




        }

        private void profitlabel_Click(object sender, EventArgs e)
        {

        }

        private void profitpnl_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void LoadYearsIntoComboBox()
        {
            
            string query = "SELECT DISTINCT YEAR(Date) AS SalesYear FROM Transactions ORDER BY SalesYear ASC";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectclass.con))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbYear.DataSource = dataTable;
                cmbYear.DisplayMember = "SalesYear";
                cmbYear.ValueMember = "SalesYear";
                connectclass.con.Close();

            }
        }

        public void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cmbYear.Text, out int selectedYear))
            {
                LoadChartDatacar(selectedYear);
            }
        }






        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        public void LoadChartDatacar(int selectedYear)
        {
            con.Connect();
            string query = @"
WITH MonthNames AS (
    SELECT 1 AS MonthNum, 'Jan' AS MonthName UNION ALL
    SELECT 2, 'Feb' UNION ALL
    SELECT 3, 'Mar' UNION ALL
    SELECT 4, 'Apr' UNION ALL
    SELECT 5, 'May' UNION ALL
    SELECT 6, 'June' UNION ALL
    SELECT 7, 'July' UNION ALL
    SELECT 8, 'Aug' UNION ALL
    SELECT 9, 'Sep' UNION ALL
    SELECT 10, 'Oct' UNION ALL
    SELECT 11, 'Nov' UNION ALL
    SELECT 12, 'Dec'
),
ProductSales AS (
    SELECT 
        P.ProductName, 
        MONTH(T.Date) AS SalesMonthNum,
        SUM(CASE WHEN T.Type = 'Sale' THEN T.Total ELSE 0 END) AS TotalSales,
        SUM(CASE WHEN T.Type = 'Purchase' THEN T.Total ELSE 0 END) AS TotalPurchases
    FROM Transactions T
    JOIN Products P ON T.ProductID = P.ProductID
    WHERE YEAR(T.Date) = @SelectedYear 
    GROUP BY P.ProductName, MONTH(T.Date)
),
RankedProducts AS (
    SELECT ProductName, SUM(TotalSales - TotalPurchases) AS NetTotalSales
    FROM ProductSales
    GROUP BY ProductName
    ORDER BY NetTotalSales DESC
    OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY
)
SELECT M.MonthNum, M.MonthName, PS.ProductName, 
       ISNULL(PS.TotalSales - PS.TotalPurchases, 0) AS NetTotalSales
FROM MonthNames M
LEFT JOIN ProductSales PS 
    ON M.MonthNum = PS.SalesMonthNum
JOIN RankedProducts RP 
    ON PS.ProductName = RP.ProductName
ORDER BY M.MonthNum, RP.NetTotalSales DESC;";

            SqlCommand cmd = new SqlCommand(query, connectclass.con) ;
            cmd.Parameters.AddWithValue("@SelectedYear", selectedYear); 

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Clear previous chart data
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            // Define months for X-Axis
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };

            var products = dataTable.AsEnumerable()
                                    .Select(row => row["ProductName"].ToString())
                                    .Distinct();

            // Define chart series for each product
            foreach (var product in products)
            {
                ChartValues<double> productValues = new ChartValues<double>();

                for (int month = 1; month <= 12; month++)
                {
                    string monthName = months[month - 1]; // Convert index to month name
                    double netTotalSales = dataTable.AsEnumerable()
                                                    .Where(row => row["ProductName"].ToString() == product
                                                               && row["MonthName"].ToString() == monthName)
                                                    .Select(row => Convert.ToDouble(row["NetTotalSales"]))
                                                    .FirstOrDefault();

                    productValues.Add(netTotalSales);
                }

                // Add series to the chart
                cartesianChart1.Series.Add(new LineSeries
                {
                    Title = product,
                    Values = productValues,
                    StrokeThickness = 3, // Line thickness
                    PointGeometrySize = 10, // Size of data points
                  // Fill = System.Windows.Media.Brushes.Transparent // No fill under the line
                });
            }

            // Configure X-Axis (Months)
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Months",
                Labels = months.ToList(), // Set month labels
                FontSize = 20
                
            });

            // Configure Y-Axis (Profit & Loss)
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Profit & Loss",
                FontSize = 20
            });
            connectclass.con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbYear.SelectedValue != null)
            {
                int selectedYear;
                if (cmbYear.SelectedValue is DataRowView dataRowView)
                {
                    selectedYear = Convert.ToInt32(dataRowView["SalesYear"]);
                }
                else
                {
                    selectedYear = Convert.ToInt32(cmbYear.SelectedValue);
                }

                LoadChartDatacar(selectedYear);
            }
        }
        private void LoadStockPrediction()
        {
            // Get past sales data
            DataTable salesData = GetSalesData();

            // Create a table to store predictions
            DataTable predictionTable = new DataTable();
            predictionTable.Columns.Add("ProductID", typeof(int));
            predictionTable.Columns.Add("ProductName", typeof(string));
            predictionTable.Columns.Add("PredictedNextMonthSales", typeof(int));
            predictionTable.Columns.Add("CurrentStock", typeof(int));
            predictionTable.Columns.Add("SuggestedRestock", typeof(int));


            var productGroups = salesData.AsEnumerable().GroupBy(row => new
            {
                ProductID = row["ProductID"],
                ProductName = row["ProductName"]
            });

            foreach (var productGroup in productGroups)
            {
                int productId = Convert.ToInt32(productGroup.Key.ProductID);
                string productName = productGroup.Key.ProductName.ToString(); // Get product name

                var months = productGroup
                    .Where(row => row["Month"] != DBNull.Value && row["TotalSold"] != DBNull.Value)
                    .Select(row => (Month: Convert.ToInt32(row["Month"]), Sales: Convert.ToInt32(row["TotalSold"])))
                    .ToList();


                int predictedSales = PredictNextMonthSales(months);


                int currentStock = GetCurrentStock(productId);


                int restockAmount = Math.Max(0, predictedSales - currentStock);


                predictionTable.Rows.Add(productId, productName, predictedSales, currentStock, restockAmount);
            }

            this.Invoke(new Action(() =>
            {
                dataGridView1.DataSource = predictionTable;
                dataGridView1.Columns["ProductID"].Visible = false;
                dataGridView1.Columns["currentStock"].Visible = false;
                dataGridView1.Columns["PredictedNextMonthSales"].HeaderText = "Sales";
                dataGridView1.Columns["SuggestedRestock"].HeaderText = "Restock";
                dataGridView1.Columns["productname"].HeaderText = "Product";
            }));

            connectclass.con.Close();
        }

        private DataTable GetSalesData()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                p.Productname,
                 t.productid,
                YEAR(t.Date) AS Year, 
                MONTH(t.Date) AS Month, 
                SUM(t.Quantity) AS TotalSold
            FROM Transactions as t LEFT JOIN Products as p ON p.ProductID = t.ProductID
            WHERE Type = 'Sale'
            GROUP BY p.productname, YEAR(t.Date), MONTH(t.Date) , t.productid
            ORDER BY  Year, Month;";

            try
            {connectclass.con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectclass.con))
                {
                    adapter.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                
                MessageBox.Show($"SQL Error: {ex.Message}");
            }
            return dt;
           
        }

        private int GetCurrentStock(int productId)
        {
            int stockQty = 0;
            string query = "SELECT QtyinStock FROM Stock WHERE ProductID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(query, connectclass.con))
            {
                
                cmd.Parameters.AddWithValue("@ProductID", productId);
                object result = cmd.ExecuteScalar();
                stockQty = result != null ? Convert.ToInt32(result) : 0;
            }
            
            return stockQty;
        }

        private int PredictNextMonthSales(List<(int Month, int Sales)> salesData)
        {
            int n = salesData.Count;
            if (n == 0) return 0;
            if (n == 1) return salesData[0].Sales;

            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;
            for (int i = 0; i < n; i++)
            {
                int x = i + 1;
                int y = salesData[i].Sales;

                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumX2 += x * x;
            }

            double slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double intercept = (sumY - slope * sumX) / n;
            int nextMonth = n + 1;
           // MessageBox.Show($"M: {slope}, C: {intercept}");

            return Math.Max(0, (int)(slope * nextMonth + intercept));
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private string FormatNumber(int number)
        {
            if (number >= 1000000) // 1M and above
                return (number / 1000000D).ToString("0.#M");
            else if (number >= 1000) // 1K and above
                return (number / 1000D).ToString("0.#K");
            else
                return number.ToString(); // Show normal number if less than 1K
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        public void LoadMonthlySalesGrowth()
        {
            con.Connect();

            // Get current month and previous month sales
            string query = @"
 SELECT 
     SUM(CASE WHEN MONTH(Date) = MONTH(GETDATE()) AND YEAR(Date) = YEAR(GETDATE()) THEN Total ELSE 0 END) AS CurrentMonthSales,
     SUM(CASE WHEN MONTH(Date) = MONTH(DATEADD(MONTH, -1, GETDATE())) AND YEAR(Date) = YEAR(DATEADD(MONTH, -1, GETDATE())) THEN Total ELSE 0 END) AS PreviousMonthSales
 FROM transactions 
 WHERE Type = 'Sale'";

            SqlCommand cmd = new SqlCommand(query, connectclass.con);
            SqlDataReader dr = cmd.ExecuteReader();

            double currentMonthSales = 0;
            double previousMonthSales = 0;
            double growthPercentage = 0;

            if (dr.Read())
            {
                currentMonthSales = dr["CurrentMonthSales"] != DBNull.Value ? Convert.ToDouble(dr["CurrentMonthSales"]) : 0;
                previousMonthSales = dr["PreviousMonthSales"] != DBNull.Value ? Convert.ToDouble(dr["PreviousMonthSales"]) : 0;
            }
            dr.Close();
            connectclass.con.Close();

            // Calculate growth percentage
            if (previousMonthSales > 0)
            {
                growthPercentage = ((currentMonthSales - previousMonthSales) / previousMonthSales) * 100;
            }
            else if (currentMonthSales > 0)
            {
                growthPercentage = 100;
            }


            this.Invoke(new Action(() =>
            {
                label8.Text = growthPercentage.ToString("0.##");
            }));

        }

        
    }
}