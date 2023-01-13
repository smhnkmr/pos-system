using PosSystem.Models;
using System.Collections.Generic;

namespace PosSystem.Datastore
{
    public class TestData
    {
        public static double TaxValue = 5;

        public static Order Order1()
        {
            var deal1 = new Deal { Id = 1, Description = "INR 1 off" };
            var deal2 = new Deal { Id = 2, Description = "10% off" };
            var deal3 = new Deal { Id = 3, Description = "Buy two and get 1 off" };

            var p1 = new Product{ Id = 453, Name = "Apples per KG", Price = 75 };
            var p2 = new Product { Id = 799, Name = "Hair Tie per pair", Price = 15 };
            var p3 = new Product { Id = 125, Name = "Amul Butter 100g", Price = 20 };

            p1.UpdeateDeal(deal1);
            p2.UpdeateDeal(deal2);
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

            return order;
        }
    }
}
