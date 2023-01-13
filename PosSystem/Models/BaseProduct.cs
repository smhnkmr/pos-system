using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Models
{
    /// <summary>
    /// Represents a class consisting basic properties of a product
    /// </summary>
    public class BaseProduct
    {
        public BaseProduct()
        {
            this.Currency = Currency.INR;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Currency Currency { get; set; }
    }
}
