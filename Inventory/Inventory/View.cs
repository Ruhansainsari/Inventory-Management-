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

namespace Inventory
{
    public partial class View : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-C3720HF\MSSQLSERVER01;Initial Catalog=Inventory;Integrated Security=True");
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = "SELECT DateTime, Name, Code, Quantity FROM StockTransactionsLog";

                SqlCommand command = new SqlCommand(query, conn);

                DataTable dataTable = new DataTable();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                DataGridViewTextBoxColumn dateTimeColumn = new DataGridViewTextBoxColumn();
                dateTimeColumn.HeaderText = "Date and Time";
                dateTimeColumn.DataPropertyName = "DateTime"; 
                dataGridView1.Columns.Add(dateTimeColumn);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            mainMenu.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
