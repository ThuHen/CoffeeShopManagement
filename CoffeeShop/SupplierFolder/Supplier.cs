using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BussinessLayer;
using PresentaitionLayer.SupplierFolder;
using TransferObject;

namespace PresentationLayer.SupplierFolder
{
    public partial class Supplier : Form
    {
        private SupplierBL supplierBL;
        public Supplier()
        {
            InitializeComponent();
            supplierBL = new SupplierBL();
        }
        private void LoadData()
        {
            try
            {
                dataGV.DataSource = new SupplierBL().GetSuppliers();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Supplier_Load(object sender, EventArgs e)
        {
            List<String> names = new List<string> { "Id", "Name", "Address" };
            //AdjustColumnWidths();
            dataGV = CustomDdv(dataGV, names);
            LoadData();
        }

        private DataGridView CustomDdv (DataGridView dgv, List<String> names)
        {
            dgv.Rows.Clear();
            for (int i = 0; i < names.Count; i++)
            {
                dgv.Columns.Add(new DataGridViewTextBoxColumn());
            }
            for (int i = 0; i < names.Count; i++)
            {
                dgv.Columns[i].Name = names[i];
                dgv.Columns[i].DataPropertyName = names[i];
            }
            dgv.Columns.Add(new DataGridViewImageColumn());
            dgv.Columns[3].Name = "Delete";
            return dgv;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmNewSupplier frmNewSupplier = new FrmNewSupplier();
            DialogResult result = frmNewSupplier.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadData();
            }                 
        }
        private void Delete(string id)
        {

            supplierBL.Del(id);
            LoadData();
            
        }

        private void dataGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;

            if (dataGV.Columns[col] is DataGridViewImageColumn)
            {
                int row = e.RowIndex;
                //MessageBox.Show("cot - dong: " + col.ToString() + " - " + row.ToString());
                string id = dataGV.Rows[row].Cells["id"].Value.ToString();
                //MessageBox.Show(id.ToString());
                Delete(id);
            }
        }


        
    }
}
