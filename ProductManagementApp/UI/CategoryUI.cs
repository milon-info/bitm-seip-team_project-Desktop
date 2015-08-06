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
    public partial class CategoryUI : Form
    {
        public CategoryUI()
        {
            InitializeComponent();
        }
        Category categorys = new Category();
        CategoryManager categoryManager = new CategoryManager();
        public int categoryID = 0;
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
                //ClearTextBoxes();
            }
        }

        public void ClearTextBoxes()
        {
            categoryCodeTextBox.Text = string.Empty;
            categoryNameTextBox.Text = string.Empty;
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

        private void CategoryUI_Load(object sender, EventArgs e)
        {
            LoadAllCategoriesListView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (categoryListView.SelectedItems.Count > 0)
            //{
            //    ListViewItem selectedItem = categoryListView.SelectedItems[0];

            //    Category taggedCategory = (Category)selectedItem.Tag;
            //    categoryID = taggedCategory.CategoryId;

            //    bool IsDeleteMode = categoryManager.Delete(categoryID);
            //    if (IsDeleteMode)
            //    {
            //        MessageBox.Show("Deleted Successfully!");
            //        LoadAllCategoriesListView();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Could Not Delete!");
            //    }
            //}
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
