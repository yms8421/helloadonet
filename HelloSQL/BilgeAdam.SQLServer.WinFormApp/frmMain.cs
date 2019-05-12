using BilgeAdam.SQLServer.WinFormApp.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeAdam.SQLServer.WinFormApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void msbProducts_Click(object sender, EventArgs e)
        {
            var frm = new frmProducts();
            frm.MdiParent = this;
            frm.Show();
        }

        private void msbAddProduct_Click(object sender, EventArgs e)
        {
            var frm = new frmNewProduct();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
