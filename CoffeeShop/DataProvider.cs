using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    

namespace CoffeeShop
{
    public class DataProvider
    {
        private SqlConnection conn;
        public DataProvider() {
            String connString = "Data Source=HENPC;Initial Catalog=CoffeeShop;Integrated Security=True";
            conn = new SqlConnection(connString);
        }
        public SqlConnection GetConnection()
        {
            return conn;
        }
        public void Connect()
        {
            try
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public void Disconnect()
        {
            try
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}
