using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.SupplierFolder
{
    public partial class frmSupplier: Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dataGV.DataSource = new SupplierBL().GetSuppliers();
        }
        private void Supplier_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    // D
        //    string sql = " DELETE FROM Supplier WHERE id = @maNCC";
        //    // U
        //    string sqlUpdate = "UPDATE Supplier SET name = @name, address= @address WHERE id = @maNCC";
        //    SqlCommand cmd = new SqlCommand(sql, cn);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add("@maNCC", SqlDbType.VarChar, 20, "id");
        //    adapter.DeleteCommand = cmd;

        //    SqlCommand cmdU = new SqlCommand(sqlUpdate, cn);
        //    cmdU.Parameters.Add("@maNCC", SqlDbType.VarChar, 20, "id");
        //    cmdU.CommandType = CommandType.Text;
        //    cmdU.Parameters.Add("@name", SqlDbType.VarChar, 100, "name");
        //    cmdU.Parameters.Add("@address", SqlDbType.VarChar, 200, "address");
        //    adapter.UpdateCommand = cmdU;

        //    adapter.Update(dataSet.Tables["Supplier"]);
        //}
    }
}
