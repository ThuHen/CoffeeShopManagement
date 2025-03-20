using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class Supplier : Form
    {
        //Disconnected Model
        //SqlAdapter + Dataset
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private SqlConnection cn;
        private DataProvider dataProvider;
        public Supplier()
        {
            InitializeComponent();
            dataProvider = new DataProvider();
            cn = dataProvider.GetConnection();
        }
        private void LoadData()
        {

            string sql = "SELECT * FROM Supplier";
            adapter = new SqlDataAdapter(sql, cn);
            //Fill()
            dataSet = new DataSet();
            dataProvider.Connect();
            adapter.Fill(dataSet, "Supplier");
            dataProvider.Disconnect();
            dataGV.DataSource = dataSet.Tables["Supplier"];
        }
        private void Supplier_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // D
            string sql = " DELETE FROM Supplier WHERE id = @maNCC";
            // U
            string sqlUpdate = "UPDATE Supplier SET name = @name, address= @address WHERE id = @maNCC";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@maNCC", SqlDbType.VarChar, 20, "id");
            adapter.DeleteCommand = cmd;

            SqlCommand cmdU = new SqlCommand(sqlUpdate, cn);
            cmdU.Parameters.Add("@maNCC", SqlDbType.VarChar, 20, "id");
            cmdU.CommandType = CommandType.Text;
            cmdU.Parameters.Add("@name", SqlDbType.VarChar, 100, "name");
            cmdU.Parameters.Add("@address", SqlDbType.VarChar, 200, "address");
            adapter.UpdateCommand = cmdU;

            adapter.Update(dataSet.Tables["Supplier"]);
        }
    }
}
