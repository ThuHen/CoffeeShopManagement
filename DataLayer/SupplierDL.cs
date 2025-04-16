using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;


namespace DataLayer
{
    public class SupplierDL:DataProvider
    {
        public List<Supplier> GetSuppliers()
        {
            string sql = "SELECT * FROM Supplier";
            string id, name, address;
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = reader[0].ToString();
                    name = reader["name"].ToString();
                    address = reader[2].ToString();
                    Supplier supplier = new Supplier(id, name, address);
                    suppliers.Add(supplier);
                }
                reader.Close();
                return suppliers;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        //public int Add(Supplier supplier)
        //{
        //    string sql = "INSERT INTO Supplier(id, name, address) VALUES('" + supplier.Id + "', '" + supplier.Name + "', '" + supplier.Address + "')";
        //    try
        //    {
        //        return MyExcuteNonQuery(sql, CommandType.Text);
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw ex;
        //    }
        //}

        public int Add(Supplier supplier)
        {
            string sql = "uspAddSupplier";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", supplier.Id));
            parameters.Add(new SqlParameter("@name", supplier.Name));
            parameters.Add(new SqlParameter("@address", supplier.Address));
            try
            {
                return MyExcuteNonQuery(sql, CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Del(string id)
        {
            string sql = "uspDelSupplier";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));
            try
            {
                MyExcuteNonQuery(sql, CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
