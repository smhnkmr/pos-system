namespace PosSystem.Models
{
    /// <summary>
    /// Represents a class with deals and discounts being considered
    /// </summary>
    public class Product : BaseProduct
    {
        public Product()
        {
            this.Discount = 0;
        }

        public Deal deal { get; private set; }

        public double Discount { get; set;  }

        public bool IsDealApplied { get; set; }

        /// <summary>
        /// Claculates the final price considering the dicounts
        /// </summary>
        /// <returns></returns>
        public double GetFinalPrice()
        {
            return (Price - Discount);
        }

        /// <summary>
        /// Update the deal for the product
        /// </summary>
        /// <param name="deal"></param>
        public void UpdeateDeal(Deal deal)
        {
            this.deal = deal;
        }
    }
}
