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
    public class ProductGateway
    {
        public string databaseConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public int Save(Product products)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "INSERT INTO tbl_product VALUES ('" + products.ProductCode + "','" + products.ProductName +
                           "','" + products.ProductQuantity + "','" + products.ProductCategoryId + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public Product GetProductCode(string productCode)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_product WHERE product_code = '" + productCode + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Product products = null;

            while (reader.Read())
            {
                if (products == null)
                {
                    products = new Product();
                }
                products.ProductCode = reader["product_code"].ToString();
                products.ProductName = reader["product_name"].ToString();
                products.ProductQuantity = int.Parse(reader["product_quantity"].ToString());
                products.ProductCategoryId = int.Parse(reader["product_categoryId"].ToString());
            }
            reader.Close();
            connection.Close();

            return products;
        }

        public List<Product> GetAllProducts()
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM view_productCategory";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Product> productList = new List<Product>();

            while (reader.Read())
            {
                Product products = new Product();
                products.ProductId = int.Parse(reader["product_id"].ToString());
                products.ProductCode = reader["product_code"].ToString();
                products.ProductName = reader["product_name"].ToString();
                products.ProductQuantity = int.Parse(reader["product_quantity"].ToString());
                products.ProductCategoryName = reader["category_name"].ToString();

                productList.Add(products);
            }
            reader.Close();
            connection.Close();

            return productList;
        }

        public int Delete(int productID)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "DELETE FROM tbl_product WHERE product_id = '" + productID + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public Product GetAllProductsByProductId(int productID)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM view_productCategory WHERE product_id = '" + productID + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Product products = new Product();

            while (reader.Read())
            {
                products.ProductId = int.Parse(reader["product_id"].ToString());
                products.ProductCode = reader["product_code"].ToString();
                products.ProductName = reader["product_name"].ToString();
                products.ProductQuantity = int.Parse(reader["product_quantity"].ToString());
                products.ProductCategoryName = reader["category_name"].ToString();
            }
            reader.Close();
            connection.Close();

            return products;
        }
       
        public int Update(Product products, int productID)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "UPDATE tbl_product SET product_categoryId = '" + products.ProductCategoryId +
                           "',product_name = '" + products.ProductName +
                           "',product_quantity ='" + products.ProductQuantity + "' WHERE product_id = '" +
                           productID + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public Product GetProductCodeAndName(string productName)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_product WHERE product_name = '" +
                           productName + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Product products = null;

            while (reader.Read())
            {
                if (products == null)
                {
                    products = new Product();
                }
                products.ProductCode = reader["product_code"].ToString();
                products.ProductName = reader["product_name"].ToString();
                products.ProductQuantity = int.Parse(reader["product_quantity"].ToString());
                products.ProductCategoryId = int.Parse(reader["product_categoryId"].ToString());
            }
            reader.Close();
            connection.Close();

            return products;
        }


        public int UpdateProductQuantity(Product products, string productName)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "UPDATE tbl_product SET product_quantity = product_quantity + '" + products.ProductQuantity +
                           "' WHERE product_name = '" + productName + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<Product> GetAllProductsByComboBox()
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_product";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Product> productList = new List<Product>();

            while (reader.Read())
            {
                Product products = new Product();
                products.ProductId = int.Parse(reader["product_id"].ToString());
                products.ProductCode = reader["product_code"].ToString();
                products.ProductName = reader["product_name"].ToString();
                products.ProductQuantity = int.Parse(reader["product_quantity"].ToString());
                //products.ProductCategoryName = reader["category_name"].ToString();

                productList.Add(products);
            }
            reader.Close();
            connection.Close();

            return productList;
        }

        public int Sale(Product products, int productID)
        {
            SqlConnection connection = new SqlConnection(databaseConString);

            
            string query = "UPDATE tbl_product SET product_quantity = product_quantity - '" + products.ProductQuantity +
                           "' WHERE product_id = '" + productID + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public Product CheckProductQuantity(int productID)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_product WHERE product_id = '" + productID + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Product products = new Product();

            while (reader.Read())
            {
                products.ProductId = int.Parse(reader["product_id"].ToString());
                products.ProductCode = reader["product_code"].ToString();
                products.ProductName = reader["product_name"].ToString();
                products.ProductQuantity = int.Parse(reader["product_quantity"].ToString());
            }
            reader.Close();
            connection.Close();

            return products;
        }

        public int SaleProductSave(Product products)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "INSERT INTO tbl_productSale VALUES ('" + products.ProductCode +
                           "','" + products.ProductName + "','" + products.ProductQuantity + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<Product> GetAllSaleProducts()
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_productSale";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Product> productList = new List<Product>();

            while (reader.Read())
            {
                Product products = new Product();
                products.ProductId = int.Parse(reader["sale_id"].ToString());
                products.ProductCode = reader["sale_productCode"].ToString();
                products.ProductName = reader["sale_productName"].ToString();
                products.ProductQuantity = int.Parse(reader["sale_productQuantity"].ToString());

                productList.Add(products);
            }
            reader.Close();
            connection.Close();

            return productList;
        }

        public List<Product> SearchProductByProductCode(string searchByProductCode)
        {
            SqlConnection connection = new SqlConnection(databaseConString);

            string query = "SELECT * FROM view_productCategory";
            if (searchByProductCode != "")
            {
                query = "SELECT * FROM view_productCategory WHERE product_code = '" + searchByProductCode + "'";
            }

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Product> productList = new List<Product>();


            while (reader.Read())
            {
                Product products = new Product();
                products.ProductId = int.Parse(reader["product_id"].ToString());
                products.ProductCode = reader["product_code"].ToString();
                products.ProductName = reader["product_name"].ToString();
                products.ProductQuantity = int.Parse(reader["product_quantity"].ToString());
                products.ProductCategoryName = reader["category_name"].ToString();

                productList.Add(products);
            }
            reader.Close();
            connection.Close();

            return productList;
        }
    }
}
