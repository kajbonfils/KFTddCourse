namespace BrownfieldCode
{
    public class OrderItem
    {
        public OrderItem(int itemId, int numberOfItems, string name, decimal price)
        {
            ItemId = itemId;
            NumberOfItems = numberOfItems;
            Name = name;
            Price = price;
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal NumberOfItems { get; set; }
    }
}