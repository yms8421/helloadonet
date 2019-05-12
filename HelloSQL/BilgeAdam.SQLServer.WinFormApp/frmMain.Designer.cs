namespace BilgeAdam.SQLServer.WinFormApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msbMenu = new System.Windows.Forms.MenuStrip();
            this.ürünlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msbAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.msbProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.satışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msbOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.msbOrderDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.msbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msbMenu
            // 
            this.msbMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünlerToolStripMenuItem,
            this.satışToolStripMenuItem});
            this.msbMenu.Location = new System.Drawing.Point(0, 0);
            this.msbMenu.Name = "msbMenu";
            this.msbMenu.Size = new System.Drawing.Size(865, 24);
            this.msbMenu.TabIndex = 1;
            this.msbMenu.Text = "Ana Menü";
            // 
            // ürünlerToolStripMenuItem
            // 
            this.ürünlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msbAddProduct,
            this.msbProducts});
            this.ürünlerToolStripMenuItem.Name = "ürünlerToolStripMenuItem";
            this.ürünlerToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ürünlerToolStripMenuItem.Text = "Ürünler";
            // 
            // msbAddProduct
            // 
            this.msbAddProduct.Name = "msbAddProduct";
            this.msbAddProduct.Size = new System.Drawing.Size(180, 22);
            this.msbAddProduct.Text = "Ürün Ekle";
            this.msbAddProduct.Click += new System.EventHandler(this.msbAddProduct_Click);
            // 
            // msbProducts
            // 
            this.msbProducts.Name = "msbProducts";
            this.msbProducts.Size = new System.Drawing.Size(180, 22);
            this.msbProducts.Text = "Ürün Listesi";
            this.msbProducts.Click += new System.EventHandler(this.msbProducts_Click);
            // 
            // satışToolStripMenuItem
            // 
            this.satışToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msbOrders,
            this.msbOrderDetail});
            this.satışToolStripMenuItem.Name = "satışToolStripMenuItem";
            this.satışToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.satışToolStripMenuItem.Text = "Satış";
            // 
            // msbOrders
            // 
            this.msbOrders.Name = "msbOrders";
            this.msbOrders.Size = new System.Drawing.Size(180, 22);
            this.msbOrders.Text = "Satışlar";
            // 
            // msbOrderDetail
            // 
            this.msbOrderDetail.Name = "msbOrderDetail";
            this.msbOrderDetail.Size = new System.Drawing.Size(180, 22);
            this.msbOrderDetail.Text = "Sipariş Fiş Detayı";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 487);
            this.Controls.Add(this.msbMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msbMenu;
            this.Name = "frmMain";
            this.Text = "Ürün Yönetimi";
            this.msbMenu.ResumeLayout(false);
            this.msbMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msbMenu;
        private System.Windows.Forms.ToolStripMenuItem ürünlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msbAddProduct;
        private System.Windows.Forms.ToolStripMenuItem msbProducts;
        private System.Windows.Forms.ToolStripMenuItem satışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msbOrders;
        private System.Windows.Forms.ToolStripMenuItem msbOrderDetail;
    }
}