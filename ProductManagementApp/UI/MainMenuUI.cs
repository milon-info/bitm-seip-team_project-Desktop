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
    public partial class MainMenuUI : Form
    {
        public MainMenuUI()
        {
            InitializeComponent();
            LoadAllCategoryComboBox();
            LoadAllProductsListView();
            LoadAllCategoriesListView();
            LoadAllUsersListView();
            LoadAllProductsByComboBox();
        }

        Product products = new Product();
        ProductManager productManager = new ProductManager();
        CategoryManager categoryManager = new CategoryManager();
        public int productID = 0;
        public bool IsUpdateMode = false;
        public string searchByProductCode = "";


        Category categorys = new Category();
        public int categoryID = 0;

        User aUser = new User();
        UserManager aUserManager = new UserManager();
        public void LoadAllCategoryComboBox()
        {
            List<Category> categoryList = categoryManager.GetAllCategory();

            categoryComboBox.DisplayMember = "CategoryName";
            categoryComboBox.ValueMember = "CategoryId";
            categoryComboBox.DataSource = null;
            categoryComboBox.DataSource = categoryList;
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
            categoryCodeTextBox.Text = string.Empty;
            categoryNameTextBox.Text = string.Empty;
            fullNameTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            mobileNoTextBox.Text = string.Empty;
            userNameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
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

        private void addButton_Click(object sender, EventArgs e)
        {
            if (categoryCodeTextBox.Text == "" || categoryNameTextBox.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                categorys.CategoryCode = categoryCodeTextBox.Text;
                categorys.CategoryName = categoryNameTextBox.Text;

                MessageBox.Show(categoryManager.Save(categorys));
                LoadAllCategoriesListView();
                ClearAllTextBoxes();
            }
        }
        public void LoadAllCategoriesListView()
        {
            List<Category> categoryList = categoryManager.LoadAllCategories();

            categoryListView.Items.Clear();
            int serialNo = 0;
            foreach (var category in categoryList)
            {
                serialNo++;
                ListViewItem listViewItem = new ListViewItem(serialNo.ToString());
                listViewItem.SubItems.Add(category.CategoryCode);
                listViewItem.SubItems.Add(category.CategoryName);

                listViewItem.Tag = category;

                categoryListView.Items.Add(listViewItem);
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

        private void addUserButton_Click(object sender, EventArgs e)
        {
            if (fullNameTextBox.Text == "" || emailTextBox.Text == "" || mobileNoTextBox.Text == "" ||
                userNameTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                aUser.FullName = fullNameTextBox.Text;
                aUser.Email = emailTextBox.Text;
                aUser.MobileNo = mobileNoTextBox.Text;
                aUser.UserName = userNameTextBox.Text;
                aUser.Password = passwordTextBox.Text;

                MessageBox.Show(aUserManager.AddUser(aUser));

                LoadAllUsersListView();

                ClearAllTextBoxes();
            }
        }
        public void LoadAllUsersListView()
        {
            List<User> userList = UserManager.GetAllUsers();

            userDisplayListView.Items.Clear();
            int serialNo = 0;
            foreach (var user in userList)
            {
                
                ListViewItem listViewItem = new ListViewItem(user.UserName);
                listViewItem.SubItems.Add(user.Password);
                listViewItem.SubItems.Add(user.Email);
               

                listViewItem.Tag = user;

                userDisplayListView.Items.Add(listViewItem);
            }
        }

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
                ClearAllTextBoxes();
            }
        }
        public void LoadAllProductsByComboBox()
        {
            List<Product> productList = productManager.GetAllProductsByComboBox();

            saleProductComboBox.DisplayMember = "ProductName";
            saleProductComboBox.ValueMember = "ProductId";
            saleProductComboBox.DataSource = null;
            saleProductComboBox.DataSource = productList;
        }

        private void saleReportButton_Click(object sender, EventArgs e)
        {
            //SaleReportUI saleReport = new SaleReportUI();
            //saleReport.Show();
            LoadAllSaleProductsListView();
        }
        public void LoadAllSaleProductsListView()
        {
            List<Product> productList = productManager.GetAllSaleProducts();

            saleReportListView.Items.Clear();
            int serialNumber = 0;
            foreach (var product in productList)
            {
                serialNumber++;
                ListViewItem listViewItem = new ListViewItem(serialNumber.ToString());
                listViewItem.SubItems.Add(product.ProductCode);
                listViewItem.SubItems.Add(product.ProductName);
                listViewItem.SubItems.Add(product.ProductQuantity.ToString());

                listViewItem.Tag = product;

                saleReportListView.Items.Add(listViewItem);
            }
        }
    }
}
