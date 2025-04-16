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
using TransferObject;
using BussinessLayer;


namespace PresentationLayer
{
    public partial class Login: Form
    {
        
        private LoginBL loginBL;

        public Login()
        {
            InitializeComponent();
            loginBL = new LoginBL();
   
        }
        private bool ValidateLogin(Account account)
        {
            try
            {
                return loginBL.Login(account);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            Account account = new Account(username, password);
            if (ValidateLogin(account))
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
