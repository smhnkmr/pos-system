using PosSystem.Services;
using System.Collections.Generic;

namespace PosSystem.Models
{
    /// <summary>
    /// Represents an order class
    /// </summary>
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public double Total { get; set; }

        public double TotalAfteTax { get; set; }

        public double TotalDiscount { get; set; }

        /// <summary>
        /// Add a product in order
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            this.Products.Add(product);
        }

        /// <summary>
        /// Remove the product from the order
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Product product)
        {
            this.Products.Remove(product);
        }

        /// <summary>
        /// Generates the order summary including totals, taxes and discounts
        /// </summary>
        public void GenerateOrderSummary()
        {
            OrderManager.GenerateOrder(this);
        }
        
    }
}
