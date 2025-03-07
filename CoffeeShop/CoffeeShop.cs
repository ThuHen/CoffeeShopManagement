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
    }
}
