using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp.MODEL
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }

        public int productSaleId { get; set; }
    }
}
