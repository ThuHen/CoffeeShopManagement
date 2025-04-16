using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using BussinessLayer;

namespace PresentaitionLayer.SupplierFolder
{
    public partial class FrmNewSupplier : Form
    {
        private SupplierBL supplierBL;
        public FrmNewSupplier()
        {
            InitializeComponent();
            supplierBL = new SupplierBL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id, name, address;
            id = txtId.Text;
            name = txtName.Text;
            address = txtAddress.Text;

            //if (id == "" && name =="" && address == "")
            //{
            //    MessageBox.Show("Vui long khong de trong.");
            //}
            Supplier supplier = new Supplier(id, name, address);
            try
            {
                //supplierBL.Add(supplier);
                int numberOfRows = supplierBL.Add(supplier);
                if (numberOfRows > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
