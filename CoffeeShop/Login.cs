using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CoffeeShop
{
    public partial class Login: Form
    {
        private SqlConnection conn;
        private DataProvider dataProvider;
        private SqlCommand cmd;
        public Login()
        {
            InitializeComponent();
        }
        private bool ValidateLogin(string username, string password)
        {
            dataProvider = new DataProvider();
            dataProvider.Connect();
            //string query = "SELECT COUNT(username) FROM Users WHERE username = '" + username + "' AND password = '" + password + "'";
            string query = "SELECT COUNT(username) FROM Users WHERE username = @username AND password = @password";
            cmd = new SqlCommand(query, dataProvider.GetConnection());
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (ValidateLogin(username, password))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Invalid username or password", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    this.txtUsername.Focus();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
