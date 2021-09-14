using System.Collections.Generic;

namespace BrownfieldCode
{
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; }
        public bool IsProcessed { get; set; }
        public Customer Customer { get; set; }
        public int OrderId { get; set; }
    }
}