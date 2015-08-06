using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementApp.MODEL;

namespace ProductManagementApp.DAL
{
    public class CategoryGateway
    {
        public string databaseConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public int Save(Category categorys)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "INSERT INTO tbl_category VALUES ('" + categorys.CategoryCode + "','" + categorys.CategoryName +
                           "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public Category GetCategoryCode(string categoryCode)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_category WHERE category_code = '" + categoryCode + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Category categorys = null;

            while (reader.Read())
            {
                if (categorys == null)
                {
                    categorys = new Category();
                }
                categorys.CategoryCode = reader["category_code"].ToString();
                categorys.CategoryName = reader["category_name"].ToString();
            }
            reader.Close();
            connection.Close();

            return categorys;
        }

        public List<Category> GetAllCategory()
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_category";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Category> categoryList = new List<Category>();

            while (reader.Read())
            {
                Category categorys = new Category();
                categorys.CategoryId = int.Parse(reader["category_id"].ToString());
                categorys.CategoryCode = reader["category_code"].ToString();
                categorys.CategoryName = reader["category_name"].ToString();

                categoryList.Add(categorys);
            }
            reader.Close();
            connection.Close();

            return categoryList;
        }

        public List<Category> LoadAllCategories()
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_category";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Category> categoryList = new List<Category>();

            while (reader.Read())
            {
                Category categorys = new Category();
                categorys.CategoryId = int.Parse(reader["category_id"].ToString());
                categorys.CategoryCode = reader["category_code"].ToString();
                categorys.CategoryName = reader["category_name"].ToString();

                categoryList.Add(categorys);
            }
            reader.Close();
            connection.Close();

            return categoryList;
        }

        //public int Delete(int categoryID)
        //{
        //    SqlConnection connection = new SqlConnection(databaseConString);
        //    string query = "DELETE FROM tbl_category WHERE category_id = '" + categoryID + "'";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    connection.Open();
        //    int rowAffected = command.ExecuteNonQuery();
        //    connection.Close();

        //    return rowAffected;
        //}
    }
}
