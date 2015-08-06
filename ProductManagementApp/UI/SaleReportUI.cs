using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductManagementApp.BLL;
using ProductManagementApp.MODEL;

namespace ProductManagementApp.UI
{
    public partial class SaleReportUI : Form
    {
        public SaleReportUI()
        {
            InitializeComponent();
        }
        ProductManager productManager = new ProductManager();
        private void SaleReportUI_Load(object sender, EventArgs e)
        {
            LoadAllSaleProductsListView();
        }
        public void LoadAllSaleProductsListView()
        {
            List<Product> productList = productManager.GetAllSaleProducts();

            saleReportListView.Items.Clear();
            int serialNo = 0;
            foreach (var product in productList)
            {
                serialNo++;
                ListViewItem listViewItem = new ListViewItem(serialNo.ToString());
                listViewItem.SubItems.Add(product.ProductCode);
                listViewItem.SubItems.Add(product.ProductName);
                listViewItem.SubItems.Add(product.ProductQuantity.ToString());

                listViewItem.Tag = product;

                saleReportListView.Items.Add(listViewItem);
            }
        }
    }
}
