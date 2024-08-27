using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;

namespace Inventory
{
    public partial class addStock : Form
    {
        private readonly TransactionLog transactionLog;
        public addStock()
        {
            InitializeComponent();
            transactionLog = new TransactionLog();
        }

        private void addStock_Load(object sender, EventArgs e)
        {

        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            string stockName = txt_Name.Text;
            string stockCode = txt_Code.Text;
            int stockQuantity = Convert.ToInt32(txt_Quantity.Text);

            try
            {
                StockAdd newItem = new StockAdd(stockName, stockCode, stockQuantity) ;
                transactionLog.InsertStock(newItem);

                txt_Name.Clear();
                txt_Code.Clear();
                txt_Quantity.Clear();

                MessageBox.Show("Item Added");
            }
            catch 
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            mainMenu.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Name.Clear();
            txt_Code.Clear();
            txt_Quantity.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
