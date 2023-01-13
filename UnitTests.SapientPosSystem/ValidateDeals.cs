using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosSystem.Models;
using System;
using System.Collections.Generic;

namespace UnitTests.PosSystem
{
    [TestClass]
    public class ValidateDeals
    {
        [TestMethod]
        public void ValidateDealBeingNULL()
        {
            var p1 = new Product { Id = 453, Name = "Apples per KG", Price = 75 };
            // var deal1 = new Deal { Id = 1, Description = "INR 1 off" };

            p1.UpdeateDeal(null);

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
        }

        [TestMethod]
        public void ValidateDeal1INROff()
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
        }

        [TestMethod]
        public void ValidateDeal210PercentOff()
        {
            var p1 = new Product { Id = 453, Name = "Apples per KG", Price = 75 };
            var deal2 = new Deal { Id = 2, Description = "10% off" };

            p1.UpdeateDeal(deal2);

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
            Assert.AreEqual(67.5, order.Total, "Total and expected total doesn't match");
            Assert.AreEqual(7.5, order.TotalDiscount, "Total and expected total doesn't match");
        }

        [TestMethod]
        public void ValidateDeal3BTGOOff()
        {
            var p1 = new Product { Id = 125, Name = "Amul Butter 100g", Price = 20 };
            var p2 = new Product { Id = 125, Name = "Amul Butter 100g", Price = 20 };
            var p3 = new Product { Id = 125, Name = "Amul Butter 100g", Price = 20 };

            var deal3 = new Deal { Id = 3, Description = "Buy two and get 1 off" };

            p1.UpdeateDeal(deal3);
            p2.UpdeateDeal(deal3);
            p3.UpdeateDeal(deal3);

            var products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);

            var order = new Order()
            {
                Id = 1,
                Products = products
            };

            // Act
            order.GenerateOrderSummary();

            // Assert
            Assert.AreEqual(40, order.Total, "Total and expected total doesn't match");
            Assert.AreEqual(20, order.TotalDiscount, "Total and expected total doesn't match");
        }
    }
}
