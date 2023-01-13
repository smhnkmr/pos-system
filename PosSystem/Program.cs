using PosSystem.Datastore;
using System;

namespace PosSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            GenerateOrderWithData();

            Console.ReadKey();
        }

        /// <summary>
        /// Generates the order with test data
        /// </summary>
        static void GenerateOrderWithData()
        {
            var order = TestData.Order1();

            order.GenerateOrderSummary();

            Console.WriteLine(order.TotalAfteTax);
        }
    }
}
