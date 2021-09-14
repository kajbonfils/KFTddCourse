using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace BrownfieldCode
{
    public class OrderProcessingManager
    {
        private readonly IOrderPriceCalculator priceCalculator;
        private readonly IMailSender mailSender;

        public OrderProcessingManager(IOrderPriceCalculator priceCalculator, IMailSender mailSender)
        {
            this.priceCalculator = priceCalculator;
            this.mailSender = mailSender;
        }

        public void ProcessOrder(int id)
        {
            var orderService = new OrderService();
            var order = orderService.GetOrder(id);
            if (order.IsProcessed)
                throw new OrderHasBeenProcessedException();

            var totalPrice = priceCalculator.CalculateTotalPrice(order);

            var pdfReportFileName = GenerateInvoice(order, totalPrice);

            mailSender.SendInvoiceMail(order, pdfReportFileName);

            orderService.ProcessOrder(order);
        }

        private static string GenerateInvoice(Order order, decimal totalPrice)
        {
            var reportBuilder = new ReportBuilder();
            foreach (var orderItem in order.OrderItems)
            {
                reportBuilder.AddOrderLine(orderItem);
            }

            reportBuilder.AddTotalPrice(totalPrice);
            var address = order.Customer.Address.Streetname + order.Customer.Address.Streetnumber + Environment.NewLine +
                          order.Customer.Address.ZipCode + " " + order.Customer.Address.City + Environment.NewLine +
                          order.Customer.Address.Country;
            reportBuilder.AddCustomer(order.Customer.Name, address);

            var pdfReportFileName = reportBuilder.GenerateInvoice();
            return pdfReportFileName;
        }


        public interface IOrderPriceCalculator
        {
            decimal CalculateTotalPrice(Order order);
        }

        public class OrderPriceCalculator : OrderProcessingManager.IOrderPriceCalculator
        {
            public decimal CalculateTotalPrice(Order order)
            {
                var totalPrice = 0m;
                foreach (var orderItem in order.OrderItems)
                {
                    totalPrice += orderItem.Price * orderItem.NumberOfItems;
                }

                return totalPrice;
            }
        }
    }
}