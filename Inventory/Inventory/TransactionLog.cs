using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Inventory
{
    internal class TransactionLog
    {

        private readonly SqlConnection conn;

        public TransactionLog()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-C3720HF\MSSQLSERVER01;Initial Catalog=Inventory;Integrated Security=True");
        }

        public void InsertStock(StockAdd stockAdd)
        {
            try
            {
                conn.Open();

                using (SqlCommand insertCommand = new SqlCommand("INSERT INTO InsertStock (Name, Code, Quantity) VALUES (@Name, @Code, @Quantity)", conn))
                {
                    insertCommand.Parameters.AddWithValue("@Name", stockAdd.Name);
                    insertCommand.Parameters.AddWithValue("@Code", stockAdd.Code);
                    insertCommand.Parameters.AddWithValue("@Quantity", stockAdd.Quantity);
                    insertCommand.ExecuteNonQuery();
                }

                using (SqlCommand logCommand = new SqlCommand("INSERT INTO StockTransactionsLog (DateTime, Name, Code, Quantity) VALUES (@DateTime, @Name, @Code, @Quantity)", conn))
                {
                    logCommand.Parameters.AddWithValue("@DateTime", DateTime.Now);
                    logCommand.Parameters.AddWithValue("@Name", stockAdd.Name);
                    logCommand.Parameters.AddWithValue("@Code", stockAdd.Code);
                    logCommand.Parameters.AddWithValue("@Quantity", stockAdd.Quantity);
                    logCommand.ExecuteNonQuery();
                }
            }

            catch (Exception e) 
            {
                throw e;
            }

            finally
            {
                conn.Close();
            }
        }
    }
}
