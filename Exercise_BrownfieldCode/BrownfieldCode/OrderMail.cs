using System.Net.Mail;

namespace BrownfieldCode
{
    public class OrderMail : MailMessage
    {
        public OrderMail()
        {
            this.Subject = "Your order has been processed";
            this.Body = "Please find your invoice attached";
            this.From = new MailAddress("kaj@ugilic.dk");
        }
    }
}