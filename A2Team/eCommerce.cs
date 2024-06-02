using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Team
{
    public class eCommerce
    {
        // Properties
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; private set; }

        // Constructor
        public eCommerce(int productID, string productName, decimal price, int stock)
        {
            if (productID < 1 || productID > 1000)
                throw new ArgumentException("ProductID must be between 1 and 1000.");

            if (string.IsNullOrEmpty(productName))
                throw new ArgumentException("ProductName cannot be null or empty.");

            if (price < 1 || price > 5000)
                throw new ArgumentException("Price must be between $1 and $5000.");

            if (stock < 1 || stock > 1000)
                throw new ArgumentException("Stock must be between 1 and 1000.");

            ProductID = productID;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        // Methods
        public void IncreaseStock(int quantity)
        {
            Stock += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (Stock >= quantity)
            {
                Stock -= quantity;
            }
            else
            {
                throw new InvalidOperationException("Insufficient stock.");
            }
        }
    }
}
