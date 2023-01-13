using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosSystem.Models;
using System.Collections.Generic;

namespace UnitTests.PosSystem
{
    [TestClass]
    public class ValidateTotals
    {
        [TestMethod]
        public void ValidateTotalWithoutDealsApplied()
        {
            // Arrange
            var p1 = new Product { Id = 453, Name = "Apples per KG", Price = 75 };

            var products = new List<Product>();

            products.Add(p1);

            var order = new Order()
            {
                Id = 1,
                Products = products
            };

            // Act
            order.GenerateOrderSummary();

            // Assert
            Assert.AreEqual(75, order.Total, "Total and expected total doesn't match");
        }

        [TestMethod]
        public void ValidateDiscountWithoutDealsApplied()
        {
            // Arrange
            var p1 = new Product { Id = 453, Name = "Apples per KG", Price = 75 };

            var products = new List<Product>();

            products.Add(p1);

            var order = new Order()
            {
                Id = 1,
                Products = products
            };

            // Act
            order.GenerateOrderSummary();

            // Assert
            Assert.AreEqual(0, order.TotalDiscount, "Total and expected discount doesn't match");
        }

        [TestMethod]
        public void ValidateTotalAfterTaxWithoutDealsApplied()
        {
            // Arrange
            var p1 = new Product { Id = 453, Name = "Apples per KG", Price = 75 };

            var products = new List<Product>();

            products.Add(p1);

            var order = new Order()
            {
                Id = 1,
                Products = products
            };

            // Act
            order.GenerateOrderSummary();

            // Assert
            Assert.AreEqual(78.75, order.TotalAfteTax, "Total and expected total after tax doesn't match");

        }
    }
}
