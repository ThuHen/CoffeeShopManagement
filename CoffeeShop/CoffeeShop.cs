using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class CoffeeShop: Form
    {
        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void CoffeeShop_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;
            Login login = new Login();
            DialogResult result = login.ShowDialog();
            //Supplier supplier = new Supplier();
            //supplier.Show();
            if (result == DialogResult.OK)
            {
                lblWelcome.Text = "Welcome, " + "login.Username;";
                this.Enabled = true;
            }
            else
            {
                Application.Exit();
            }
        }
        private void AddForm(Form form)
        {
            form.TopLevel = false;
            panelCenter.Controls.Clear();
            panelCenter.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            AddForm(new SupplierFolder.Supplier());
        }
    }
}
