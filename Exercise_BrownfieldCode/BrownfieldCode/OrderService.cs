using System.Collections.Generic;

namespace BrownfieldCode
{
    public class OrderService
    {
        public Order GetOrder(int id)
        {
            return new Order
            {
                OrderId = id,
                Customer = new Customer()
                {
                    Name = "Donald Duck",
                    Email = "kaj@sharklasers.com",
                    Address = new Address
                    {
                        Streetname = "Quack Street",
                        Streetnumber = "1113",
                        ZipCode = 1113,
                        City = "Duckburg",
                        Country = "Calisota-USA"
                    }
                },
                IsProcessed = false,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem(133, 1, "Kite", 9.94m),
                    new OrderItem(3341, 30, "Chocolatebar", 0.94m),
                    new OrderItem(313, 3, "Tea cup", 1.24m)
                }
            };
        }

        public void ProcessOrder(Order order)
        {
            order.IsProcessed = true;
        }
    }
}