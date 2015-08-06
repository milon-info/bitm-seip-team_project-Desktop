using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementApp.DAL;
using ProductManagementApp.MODEL;

namespace ProductManagementApp.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();

        public bool IsCategoryCodeExists(string categoryCode)
        {
            Category IsCategoryCode = categoryGateway.GetCategoryCode(categoryCode);
            if (IsCategoryCode != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Save(Category categorys)
        {
            bool checkCategoryCode = IsCategoryCodeExists(categorys.CategoryCode);
            if (checkCategoryCode)
            {
                return "Category Code Allready Exists!";
            }
            if (categoryGateway.Save(categorys) > 0)
            {
                return "Added Successfully!";
            }
            else
            {
                return "Could Not Added!";
            }
        }

        public List<Category> GetAllCategory()
        {
            return categoryGateway.GetAllCategory();
        }

        public List<Category> LoadAllCategories()
        {
            return categoryGateway.LoadAllCategories();
        }

        //public bool Delete(int categoryID)
        //{
        //    return categoryGateway.Delete(categoryID) > 0;
        //}
    }
}
