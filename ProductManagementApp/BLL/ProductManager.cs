using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementApp.DAL;
using ProductManagementApp.MODEL;

namespace ProductManagementApp.BLL
{
    public class ProductManager
    {
        ProductGateway productGateway = new ProductGateway();
        
        public string Save(Product products)
        {
            bool checkProductCode = IsProductCodeExists(products.ProductCode);
            bool checkProductCodeAndName = IsProductCodeAndNameExists(products.ProductName);
            if (checkProductCode)
            {
                if (checkProductCodeAndName)
                {
                    if (productGateway.UpdateProductQuantity(products, products.ProductName) > 0)
                    {
                        return "Product Quantity Increament!";
                    }
                    else
                    {
                        return "Could Not Product Quantity Increament!";
                    }
                    //return "Product Name Allready Exists!";
                }
                return "Product Code Allready Exists!";
            }
            if (productGateway.Save(products) > 0)
            {
                return "Added Successfully!";
            }
            else
            {
                return "Could Not Added!";
            }
        }
        private bool IsProductCodeExists(string productCode)
        {
            Product products = productGateway.GetProductCode(productCode);
            if (products != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsProductCodeAndNameExists(string productName)
        {
            Product products = productGateway.GetProductCodeAndName(productName);
            if (products != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            return productGateway.GetAllProducts();
        }

        public bool Delete(int productID)
        {
            return productGateway.Delete(productID) > 0;
        }

        public Product GetAllProductsByProductId(int productID)
        {
            return productGateway.GetAllProductsByProductId(productID);
        }

        public string Update(Product products, int productID)
        {
            if (productGateway.Update(products, productID) > 0)
            {
                return "Updated Successfully!";
            }
            else
            {
                return "Could Not Update!";
            }
        }

        public List<Product> GetAllProductsByComboBox()
        {
            return productGateway.GetAllProductsByComboBox();
        }

        public string Sale(Product products, int productID)
        {
            //int productQuantity = productGateway.CheckProductQuantity();

            Product aProduct = productGateway.CheckProductQuantity(productID);

            if (aProduct.ProductQuantity < products.ProductQuantity)
            {
                return "Insufficient Product Quantity!";
            }

            aProduct.ProductQuantity = products.ProductQuantity;

            if (productGateway.Sale(products, productID) > 0 && productGateway.SaleProductSave(aProduct) > 0)
            {
                return "Sale Successfully!";
            }

            else
            {
                return "Could Not Sale!";
            }
        }

        public List<Product> GetAllSaleProducts()
        {
            return productGateway.GetAllSaleProducts();
        }

        public List<Product> SearchProductByProductCode(string searchByProductCode)
        {
            return productGateway.SearchProductByProductCode(searchByProductCode);
        }
    }
}
