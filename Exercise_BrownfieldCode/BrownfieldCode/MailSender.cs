using System.IO;
using System.Net;
using System.Net.Mail;

namespace BrownfieldCode
{
    public interface IMailSender
    {
        void SendInvoiceMail(Order order, string pdfReportFileName);
    }

    public class MailSender : IMailSender
    {
        public void SendInvoiceMail(Order order, string pdfReportFileName)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("ugilictest@gmail.com", "Ugilic2015")
            };
            using (var mail = new OrderMail())
            {
                mail.To.Add(order.Customer.Email);
                mail.Attachments.Add(new Attachment(pdfReportFileName));

                smtp.Send(mail);
            }
            File.Delete(pdfReportFileName);
        }
    }
}