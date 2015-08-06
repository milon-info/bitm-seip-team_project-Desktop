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
    public partial class ProductReportUI : Form
    {
        public ProductReportUI()
        {
            InitializeComponent();
        }

        ProductManager productManager = new ProductManager();
        //ProductEntryUI productEntryUi = new ProductEntryUI();
        private void ProductReportUI_Load(object sender, EventArgs e)
        {
            LoadAllProductByReport();
        }

        public void LoadAllProductByReport()
        {
            List<Product> productList = productManager.GetAllProducts();

            productDisplayListView.Items.Clear();
            int serialNo = 0;
            foreach (var product in productList)
            {
                serialNo++;
                ListViewItem listViewItem = new ListViewItem(serialNo.ToString());
                listViewItem.SubItems.Add(product.ProductCategoryName);
                listViewItem.SubItems.Add(product.ProductCode);
                listViewItem.SubItems.Add(product.ProductName);
                listViewItem.SubItems.Add(product.ProductQuantity.ToString());

                listViewItem.Tag = product;

                productDisplayListView.Items.Add(listViewItem);
            }
        }
    }
}
