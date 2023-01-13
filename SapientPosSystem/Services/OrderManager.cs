using PosSystem.Datastore;
using PosSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace PosSystem.Services
{
    /// <summary>
    /// Represents the class handling the business logics of applying deals and discounts for the order
    /// </summary>
    public class OrderManager
    {
        /// <summary>
        /// Tax value fetched from datastore
        /// </summary>
        public static double Tax = TestData.TaxValue;

        /// <summary>
        /// Generates the order by applying discounts and taxes
        /// </summary>
        /// <param name="order"></param>
        public static void GenerateOrder(Order order)
        {
            if(order == null)
            {
                return;
            }

            ApplyDiscount(order.Products);

            CalculateTotals(order);
        }

        /// <summary>
        /// Calculates the totals, discounts and taxes
        /// </summary>
        /// <param name="order"></param>
        private static void CalculateTotals(Order order)
        {
            double total = 0;
            double discount = 0;

            foreach (var product in order.Products)
            {
                total += product.GetFinalPrice();
                discount += product.Discount;
            }

            order.Total = total;
            order.TotalDiscount = discount;

            order.TotalAfteTax = total + (total * (Tax / 100));
        }

        /// <summary>
        /// Applies the logic to calculate the discount based on deals being applied for all prodcuts
        /// </summary>
        /// <param name="products"></param>
        private static void ApplyDiscount(List<Product> products)
        {
            foreach(var product in products)
            {
                if(product != null && product.deal != null && product.IsDealApplied == false)
                {
                    switch(product.deal.Id)
                    {
                        case 1: // Price -1 off
                            product.Discount = 1;
                            break;
                        case 2: // 10% off
                            product.Discount = product.Price * 0.10;
                            break;
                        case 3: // Buy two and get 1 off
                            if(CheckEligibilityForBTGO(products, product))
                            {
                                product.Discount = product.Price;
                            }
                            break;
                        default:
                            product.Discount = 0;
                            break;

                    }
                }
            }
        }

        /// <summary>
        /// Checks the eligibility of the product for buy two get one offer
        /// </summary>
        /// <param name="products"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        private static bool CheckEligibilityForBTGO(List<Product> products, Product current)
        {
            var pdts = products.Where(x => x.IsDealApplied == false && x.deal != null && x.deal.Id == current.deal.Id).ToList();

            if(pdts.Count >= 3)
            {
                current.IsDealApplied = true;

                var applydisc = pdts.Where(x => x.IsDealApplied == false).Take(2).ToList();

                foreach (var p in applydisc)
                {
                    p.IsDealApplied = true;
                }

                return true;
            }

            return false;
        }

    }
}
