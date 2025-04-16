using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public class SupplierBL
    {
        private SupplierDL supplierDL;
        public SupplierBL()
        {
            supplierDL = new SupplierDL();
        }
        public List<Supplier> GetSuppliers()
        {
            try
            {
                return supplierDL.GetSuppliers();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Add(Supplier supplier)
        {
            try
            {
                return supplierDL.Add(supplier);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Del(string  id)
        {
            try
            {
                supplierDL.Del(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
