using AndalCommerceModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace AndalCommerceAppService
{
    public class EmailServices
    {
        private readonly IConfiguration _configuration;

        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(Order order, string recipientEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(
                _configuration["EmailSettings:FromName"],
                _configuration["EmailSettings:FromEmail"]
            ));
            message.To.Add(new MailboxAddress("Account Owner", recipientEmail));
            message.Subject = "AndalCommerce - Order Confirmation";
            message.Body = new TextPart("plain")
            {
                Text = $"Hello {order.Name},\n\n" +
                       $"Your order has been successfully created!\n\n" +
                       $"------ Order Summary ------\n\n" +
                       $"Name: {order.Name}\n" +
                       $"Phone Number: {order.Phone}\n" +
                       $"Address: {order.Address}\n" +
                       $"Postal Code: {order.Postal}\n" +
                       $"Shipping Method: {order.ShippingMethod}\n" +
                       $"Payment Method: {order.PaymentMethod}\n\n" +
                       $"Thank you for your order!" 
            };

            using (var client = new SmtpClient())
            {
                client.Connect(
                    _configuration["EmailSettings:SmtpHost"],
                    int.Parse(_configuration["EmailSettings:SmtpPort"]),
                    SecureSocketOptions.StartTls
                );

                client.Authenticate(
                    _configuration["EmailSettings:Username"],
                    _configuration["EmailSettings:Password"]
                );

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}