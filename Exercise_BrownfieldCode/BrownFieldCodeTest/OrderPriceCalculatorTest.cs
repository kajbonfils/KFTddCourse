using System;
using System.Collections.Generic;
using BrownfieldCode;
using Xunit;

namespace BrownFieldCodeTest
{
    public class OrderPriceCalculatorTest
    {
        [Fact]
        public void CalculateTotalPrice_OrderLineWithMultipleUnits_CalculatesCorrectPrice()
        {
            var order = new Order();
            order.OrderItems = new List<OrderItem>();
            order.OrderItems.Add(
                new OrderItem(1, 10, "", 10));

            var target = new OrderProcessingManager.OrderPriceCalculator();
            var actual = target.CalculateTotalPrice(order);


            Assert.Equal(100m, actual);
        }
    }
}
