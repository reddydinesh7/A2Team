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
    public int ProductID { get; private set; }
    public string ProductName { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    // Constructor
    public eCommerce(int productID, string productName, decimal price, int stock)
    {
        // Validate and assign ProductID
        if (productID < 1 || productID > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(productID), "ProductID must be between 1 and 1000.");
        }
        ProductID = productID;

        // Validate and assign ProductName
        if (string.IsNullOrWhiteSpace(productName))
        {
            throw new ArgumentException("ProductName cannot be null or whitespace.", nameof(productName));
        }
        ProductName = productName;

        // Validate and assign Price
        if (price < 1m || price > 5000m)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price must be between $1 and $5000.");
        }
        Price = price;

        // Validate and assign Stock
        if (stock < 1 || stock > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(stock), "Stock must be between 1 and 1000.");
        }
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
