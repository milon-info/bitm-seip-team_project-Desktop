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
    public partial class ProductEntryUI : Form
    {
        public ProductEntryUI()
        {
            InitializeComponent();
        }
        Product products = new Product();
        ProductManager productManager = new ProductManager();
        CategoryManager categoryManager = new CategoryManager();
        public int productID = 0;
        public bool IsUpdateMode = false;
        public string searchByProductCode = "";
        private void addMoreCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryUI categoryUi = new CategoryUI();
            categoryUi.Show();
        }

        public void LoadAllCategoryComboBox()
        {
            List<Category> categoryList = categoryManager.GetAllCategory();

            categoryComboBox.DisplayMember = "CategoryName";
            categoryComboBox.ValueMember = "CategoryId";
            categoryComboBox.DataSource = null;
            categoryComboBox.DataSource = categoryList;
        }

        private void ProductEntryUI_Load(object sender, EventArgs e)
        {
            LoadAllCategoryComboBox();
            LoadAllProductsListView();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (productCodeTextBox.Text == "" || productNameTextBox.Text == "" || quantityTextBox.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                products.ProductCategoryId = int.Parse(categoryComboBox.SelectedValue.ToString());
                products.ProductCode = productCodeTextBox.Text;
                products.ProductName = productNameTextBox.Text;
                products.ProductQuantity = int.Parse(quantityTextBox.Text);

                products.ProductId = productID;

                if (IsUpdateMode)
                {
                    MessageBox.Show(productManager.Update(products, productID));
                    LoadAllProductsListView();
                    ClearAllTextBoxes();
                    saveButton.Text = "Save";
                }
                else
                {
                    MessageBox.Show(productManager.Save(products));
                    LoadAllProductsListView();
                    //ClearAllTextBoxes();
                }
            }
        }

        public void ClearAllTextBoxes()
        {
            productCodeTextBox.Text = string.Empty;
            productNameTextBox.Text = string.Empty;
            quantityTextBox.Text = string.Empty;
            //categoryComboBox.Text = string.Empty;
        }

        public void LoadAllProductsListView()
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productDisplayListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = productDisplayListView.SelectedItems[0];

                Product taggedProduct = (Product)selectedItem.Tag;
                productID = taggedProduct.ProductId;

                bool IsDeleteMode = productManager.Delete(productID);
                if (IsDeleteMode)
                {
                    MessageBox.Show("Deleted Successfully!");
                    LoadAllProductsListView();
                }
                else
                {
                    MessageBox.Show("Could Not Delete!");
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productDisplayListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = productDisplayListView.SelectedItems[0];

                Product taggedProduct = (Product)selectedItem.Tag;
                productID = taggedProduct.ProductId;

                Product products = productManager.GetAllProductsByProductId(productID);

                categoryComboBox.Text = products.ProductCategoryName;
                productCodeTextBox.Text = products.ProductCode;
                productNameTextBox.Text = products.ProductName;
                quantityTextBox.Text = int.Parse(products.ProductQuantity.ToString()).ToString();

                IsUpdateMode = true;

                saveButton.Text = "Update";
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (IsUpdateMode)
            {
                ClearAllTextBoxes();
                saveButton.Text = "Save";
            }
            ClearAllTextBoxes();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchByProductCode = searchProductCodeTextBox.Text;

            List<Product> productList = productManager.SearchProductByProductCode(searchByProductCode);

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
