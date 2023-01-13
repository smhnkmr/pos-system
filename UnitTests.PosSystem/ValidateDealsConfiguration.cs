using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosSystem.Models;
using System;
using System.Collections.Generic;

namespace UnitTests.PosSystem
{
    [TestClass]
    public class ValidateDealsConfiguration
    {
        [TestMethod]
        public void AddDeal()
        {
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
            Assert.AreEqual(0, order.TotalDiscount, "Total and expected total doesn't match");

            // Act
            order = new Order()
            {
                Id = 1,
                Products = products
            };
            var deal2 = new Deal { Id = 2, Description = "10% off" };
            p1.UpdeateDeal(deal2);

            order.GenerateOrderSummary();

            // Assert
            Assert.AreEqual(67.5, order.Total, "Total and expected total doesn't match");
            Assert.AreEqual(7.5, order.TotalDiscount, "Total and expected total doesn't match");
        }

        [TestMethod]
        public void UpdateDeal()
        {
            var p1 = new Product { Id = 453, Name = "Apples per KG", Price = 75 };
            var deal1 = new Deal { Id = 1, Description = "INR 1 off" };

            p1.UpdeateDeal(deal1);

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
            Assert.AreEqual(74, order.Total, "Total and expected total doesn't match");
            Assert.AreEqual(1, order.TotalDiscount, "Total and expected total doesn't match");

            // Act
            order = new Order()
            {
                Id = 1,
                Products = products
            };
            var deal2 = new Deal { Id = 2, Description = "10% off" };
            p1.UpdeateDeal(deal2);

            order.GenerateOrderSummary();

            // Assert
            Assert.AreEqual(67.5, order.Total, "Total and expected total doesn't match");
            Assert.AreEqual(7.5, order.TotalDiscount, "Total and expected total doesn't match");
        }

        [TestMethod]
        public void RemoveDeal()
        {
            var p1 = new Product { Id = 453, Name = "Apples per KG", Price = 75 };
            var deal1 = new Deal { Id = 1, Description = "INR 1 off" };

            p1.UpdeateDeal(deal1);

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
            Assert.AreEqual(74, order.Total, "Total and expected total doesn't match");
            Assert.AreEqual(1, order.TotalDiscount, "Total and expected total doesn't match");

            // Act
            p1 = new Product { Id = 453, Name = "Apples per KG", Price = 75 };
            products = new List<Product>();
            products.Add(p1);
            order = new Order()
            {
                Id = 1,
                Products = products
            };
            p1.UpdeateDeal(null);

            order.GenerateOrderSummary();

            // Assert
            Assert.AreEqual(75, order.Total, "Total and expected total doesn't match");
            Assert.AreEqual(0, order.TotalDiscount, "Total and expected total doesn't match");
        }
    }
}
