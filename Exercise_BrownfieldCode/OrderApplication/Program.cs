using System;
using System.Diagnostics;
using System.Linq;
using BrownfieldCode;

namespace OrderApplication
{
    internal class Program
    {
        /*
         TODO:
         * 
         *  
         * New Feature requirement:
         * We must be able to test mail sending without sending an actual mail.
         * Invoice is missing space between name and invoice lines
         * Invoice is missing price pr item (Only total price)
         * 
         * 
         Notes: https://www.guerrillamail.com/inbox?mail_id=21136041
         * 
         Gmail account: UgilicTest@gmail.com / Ugilic2015
         
         */


        private static void Main(string[] args)
        {
            IMailSender mailSender = null;
            if (args.Any() && args[0] == "test")
                mailSender = new TestMailSender();
            else
            {
                mailSender = new MailSender();
                
            }
            var orderCalculator = new OrderProcessingManager.OrderPriceCalculator();

            var orderManager = new OrderProcessingManager(orderCalculator, mailSender);
            orderManager.ProcessOrder(1);
        }
    }

    internal class TestMailSender : IMailSender
    {
        public void SendInvoiceMail(Order order, string pdfReportFileName)
        {
            Console.WriteLine("Invoice has been send:");
            Process.Start(pdfReportFileName);
        }
    }
}