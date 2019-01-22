using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTechniques.Refactorings
{
    // KÖTÜ TASARIM
    public class ExtractVariableBad
    {
        public double GetTotalPrice()
        {
            var order = new Order();// get order 

            return order.Quantity * order.ItemPrice -
                   Math.Max(0, order.Quantity - 500) * order.ItemPrice * 0.05 +
                   Math.Min(order.Quantity * order.ItemPrice * 0.1, 100);
        }
    }

    // İYİ TASARIM
    public class ExtractVariableGood
    {
        public double GetTotalPrice()
        {
            var order = new Order();// get order 

            var basePrice = order.Quantity * order.ItemPrice;
            var quantityDiscount = Math.Max(0, order.Quantity - 500) * order.ItemPrice * 0.05;
            var shipping = Math.Min(basePrice * 0.1, 100);

            return basePrice - quantityDiscount + shipping;
        }
    }

    public class Order
    {
        public double Quantity;

        public double ItemPrice;
    }
}
