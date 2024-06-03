using A2Team;
using System;
using NUnit.Framework;

namespace eCommerceTest
{
    [TestFixture]
    public class eCommerceTest
    {
        [Test]
        public void Constructor_ValidInputs_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int itemQuantity = 75;

            // Act
            eCommerce product = new eCommerce(itemId, itemName, itemPrice, itemQuantity);

            // Assert
            Assert.AreEqual(itemId, product.ProductID);
            Assert.AreEqual(itemName, product.ProductName);
            Assert.AreEqual(itemPrice, product.Price);
            Assert.AreEqual(itemQuantity, product.Stock);
        }

        [TestCase(0)]
        [TestCase(1001)]
        public void Constructor_ProductIDOutOfRange_ShouldThrowArgumentException(int invalidProductID)
        {
            // Arrange
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int itemQuantity = 75;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new eCommerce(invalidProductID, itemName, itemPrice, itemQuantity));
        }

        [TestCase(1)]
        [TestCase(1000)]
        public void Constructor_ProductIDInValidRange_ShouldSetPropertyCorrectly(int validProductID)
        {
            // Arrange
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int itemQuantity = 75;

            // Act
            eCommerce product = new eCommerce(validProductID, itemName, itemPrice, itemQuantity);

            // Assert
            Assert.AreEqual(validProductID, product.ProductID);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ProductNameNullOrEmpty_ShouldThrowArgumentException(string invalidProductName)
        {
            // Arrange
            int itemId = 456;
            decimal itemPrice = 19.99m;
            int itemQuantity = 75;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new eCommerce(itemId, invalidProductName, itemPrice, itemQuantity));
        }

        [Test]
        public void Constructor_ValidProductName_ShouldSetPropertyCorrectly()
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int itemQuantity = 75;

            // Act
            eCommerce product = new eCommerce(itemId, itemName, itemPrice, itemQuantity);

            // Assert
            Assert.AreEqual(itemName, product.ProductName);
        }

        [TestCase(0.99)]
        [TestCase(5000.01)]
        public void Constructor_PriceOutOfRange_ShouldThrowArgumentException(decimal invalidPrice)
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            int itemQuantity = 75;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new eCommerce(itemId, itemName, invalidPrice, itemQuantity));
        }

        [TestCase(1.00)]
        [TestCase(5000.00)]
        public void Constructor_PriceInValidRange_ShouldSetPropertyCorrectly(decimal validPrice)
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            int itemQuantity = 75;

            // Act
            eCommerce product = new eCommerce(itemId, itemName, validPrice, itemQuantity);

            // Assert
            Assert.AreEqual(validPrice, product.Price);
        }

        [TestCase(0)]
        [TestCase(1001)]
        public void Constructor_StockOutOfRange_ShouldThrowArgumentException(int invalidStock)
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new eCommerce(itemId, itemName, itemPrice, invalidStock));
        }

        [TestCase(1)]
        [TestCase(1000)]
        public void Constructor_StockInValidRange_ShouldSetPropertyCorrectly(int validStock)
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;

            // Act
            eCommerce product = new eCommerce(itemId, itemName, itemPrice, validStock);

            // Assert
            Assert.AreEqual(validStock, product.Stock);
        }

        [Test]
        public void IncreaseStock_ValidQuantity_ShouldIncreaseStockCorrectly()
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int initialStock = 75;
            int increaseQuantity = 25;
            eCommerce product = new eCommerce(itemId, itemName, itemPrice, initialStock);

            // Act
            product.IncreaseStock(increaseQuantity);

            // Assert
            Assert.AreEqual(initialStock + increaseQuantity, product.Stock);
        }

        [Test]
        public void IncreaseStock_ZeroQuantity_ShouldNotChangeStock()
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int initialStock = 75;
            int increaseQuantity = 0;
            eCommerce product = new eCommerce(itemId, itemName, itemPrice, initialStock);

            // Act
            product.IncreaseStock(increaseQuantity);

            // Assert
            Assert.AreEqual(initialStock, product.Stock);
        }

        [Test]
        public void DecreaseStock_ValidQuantity_ShouldDecreaseStockCorrectly()
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int initialStock = 75;
            int decreaseQuantity = 25;
            eCommerce product = new eCommerce(itemId, itemName, itemPrice, initialStock);

            // Act
            product.DecreaseStock(decreaseQuantity);

            // Assert
            Assert.AreEqual(initialStock - decreaseQuantity, product.Stock);
        }

        [Test]
        public void DecreaseStock_ZeroQuantity_ShouldNotChangeStock()
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int initialStock = 75;
            int decreaseQuantity = 0;
            eCommerce product = new eCommerce(itemId, itemName, itemPrice, initialStock);

            // Act
            product.DecreaseStock(decreaseQuantity);

            // Assert
            Assert.AreEqual(initialStock, product.Stock);
        }

        [Test]
        public void DecreaseStock_InsufficientStock_ShouldThrowInvalidOperationException()
        {
            // Arrange
            int itemId = 456;
            string itemName = "Sample Item";
            decimal itemPrice = 19.99m;
            int initialStock = 75;
            int decreaseQuantity = 100;
            eCommerce product = new eCommerce(itemId, itemName, itemPrice, initialStock);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(decreaseQuantity));
        }
    }
}
