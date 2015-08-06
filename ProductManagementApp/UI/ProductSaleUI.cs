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
    public partial class ProductSaleUI : Form
    {
        public ProductSaleUI()
        {
            InitializeComponent();
        }
        Product products = new Product();
        ProductManager productManager = new ProductManager();
        //public string productName = "";
        public int productID = 0;
        private void saleButton_Click(object sender, EventArgs e)
        {
            if (saleProductComboBox.Text == "" || saleQuantityTextBox.Text == "")
            {
                MessageBox.Show("Please Select Product!");
            }
            else
            {
                products.ProductId = int.Parse(saleProductComboBox.SelectedValue.ToString());
                products.ProductQuantity = int.Parse(saleQuantityTextBox.Text);

                productID = products.ProductId;

                MessageBox.Show(productManager.Sale(products, productID));
                ClearTextBoxes();
            }
        }

        public void ClearTextBoxes()
        {
            //saleProductComboBox.Text = string.Empty;
            saleQuantityTextBox.Text = string.Empty;
        }
        public void LoadAllProductsByComboBox()
        {
            List<Product> productList = productManager.GetAllProductsByComboBox();

            saleProductComboBox.DisplayMember = "ProductName";
            saleProductComboBox.ValueMember = "ProductId";
            saleProductComboBox.DataSource = null;
            saleProductComboBox.DataSource = productList;
        }

        private void ProductSaleUI_Load(object sender, EventArgs e)
        {
            LoadAllProductsByComboBox();
        }

        private void saleReportButton_Click(object sender, EventArgs e)
        {
            SaleReportUI saleReportUi = new SaleReportUI();
            saleReportUi.Show();
        }

    }
}
