using System;
using System.IO;

namespace BrownfieldCode
{
    public class ReportBuilder
    {
        private string orders = "";
        private string recipient = "";
        private string totalPrice = "";

        public void AddOrderLine(OrderItem orderItem)
        {
            orders += string.Format("[{0}]{1}\t{2}\t{3}{4}", orderItem.ItemId, orderItem.Name,orderItem.NumberOfItems,
                orderItem.NumberOfItems*orderItem.Price, Environment.NewLine);
        }

        public void AddTotalPrice(decimal totalPrice)
        {
            this.totalPrice = "-----------------------------------------" + Environment.NewLine
                         + "Total Price\t\t\t" + totalPrice.ToString();
        }

        public void AddCustomer(string name, string address)
        {
            recipient = string.Format("{0}{1}{2}", name, Environment.NewLine, address);
        }

        public string GenerateInvoice()
        {
            var fileContent = string.Format("{0}{1}{2}", recipient, orders, totalPrice);
            var filename = Path.GetTempFileName().Replace(".tmp", ".txt");
            File.WriteAllText(filename, fileContent);

            return filename;
        }
    }
}