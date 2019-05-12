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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
            CommonQuery = @"SELECT TOP 15 p.ProductName, c.CategoryName, s.CompanyName, p.UnitPrice, p.UnitsInStock
                             FROM dbo.Products p
                             INNER JOIN dbo.Categories c ON c.CategoryID = p.CategoryID
                             INNER JOIN dbo.Suppliers s ON s.SupplierID = p.SupplierID";
        }
        public string CommonQuery { get; }
        public int PageNumber { get; set; }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            //Bu method ölümüne keko yöntemler kullanılarak yapıldı
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

            //using --> IDisposable bir nesnenin scope dışına geçildiğinde Dispose edilmesini sağlar
            using (var rows = dh.GetSqlData(CommonQuery))
            {
                dgvProducts.DataSource = rows;
            }

            //Yukarıda connection tanımlanmadı çünkü bir adet sorgu çalışacak 
            //GetSqlData zaten bir connection oluşturuyor ve o connection kapatılıyor. Bkz: frmNewProduct
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = CommonQuery + " WHERE c.CategoryId = @cid AND s.SupplierId = @sid ORDER BY p.ProductName";
            var dh = new DataHelper();
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@cid", cmbCategories.SelectedValue));
            parameters.Add(new SqlParameter("@sid", cmbSuppliers.SelectedValue));
            using (var table = dh.GetSqlData(query, parameters))
            {
                dgvProducts.DataSource = table;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            PageNumber++;
            var query = CommonQuery + " ORDER BY p.ProductName OFFSET @start ROWS FETCH NEXT 15 ROWS ONLY";
            query = query.Replace("TOP 15", string.Empty);
            var dh = new DataHelper();
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@start", (PageNumber - 1) * 15));
            using (var table = dh.GetSqlData(query, parameters))
            {
                dgvProducts.DataSource = table;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PageNumber--;
            if (PageNumber == 0)
            {
                PageNumber = 1;
            }
            var query = CommonQuery + " ORDER BY p.ProductName OFFSET @start ROWS FETCH NEXT 15 ROWS ONLY";
            query = query.Replace("TOP 15", string.Empty);
            var dh = new DataHelper();
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@start", (PageNumber - 1) * 15));
            using (var table = dh.GetSqlData(query, parameters))
            {
                dgvProducts.DataSource = table;
            }
        }

        private void btnReturnToStart_Click(object sender, EventArgs e)
        {
            var dh = new DataHelper();
            using (var rows = dh.GetSqlData(CommonQuery))
            {
                dgvProducts.DataSource = rows;
            }
        }
    }
}
