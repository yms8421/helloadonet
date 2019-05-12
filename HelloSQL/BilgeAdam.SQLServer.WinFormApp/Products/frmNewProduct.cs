using BilgeAdam.SQLServer.WinFormApp.Helpers;
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

namespace BilgeAdam.SQLServer.WinFormApp.Products
{
    public partial class frmNewProduct : Form
    {
        public frmNewProduct()
        {
            InitializeComponent();
        }

        private void frmNewProduct_Load(object sender, EventArgs e)
        {
            //Connection dışarıdan tanımlandı çünkü aynı zamanda iki sorgu çalıştırılacak
            var dh = new DataHelper();
            using (var connection = ConnectionHelper.CreateConnection())
            {
                var categories = dh.GetSqlData("SELECT CategoryId, CategoryName FROM Categories", connection);
                var suppliers = dh.GetSqlData("SELECT SupplierId, CompanyName FROM Suppliers", connection);
                cmbCategories.DataSource = categories;
                cmbCategories.DisplayMember = "CategoryName";
                cmbCategories.ValueMember = "CategoryId";

                cmbSuppliers.DataSource = suppliers;
                cmbSuppliers.DisplayMember = "CompanyName";
                cmbSuppliers.ValueMember = "SupplierId";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var query = $@"INSERT INTO dbo.Products (ProductName, SupplierID, CategoryID, UnitPrice, UnitsInStock)
                          VALUES (@pName, @company, @category, @price, @stock)";
            using (var connection = ConnectionHelper.CreateConnection())
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@pName", txtName.Text);
                command.Parameters.AddWithValue("@company", cmbSuppliers.SelectedValue);
                command.Parameters.AddWithValue("@category", cmbCategories.SelectedValue);
                command.Parameters.AddWithValue("@price", nudPrice.Value);
                command.Parameters.Add(new SqlParameter("@stock", nudStock.Value));

                var count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Ürün Kaydedildi", "Ürün İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    nudPrice.Value = 0;
                    nudStock.Value = 0;
                    cmbCategories.SelectedIndex = -1;
                    cmbSuppliers.SelectedIndex = -1;
                }
            }
        }
    }
}
