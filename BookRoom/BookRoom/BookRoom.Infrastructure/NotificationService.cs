using BookRoom.Application.Interfaces;
using BookRoom.Application.Notifications.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookRoom.Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration _configuration;

        public NotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAsync(Message message)
        {
            MailAddress fromAddress = new MailAddress(
                _configuration["EmailCredentials:Email"],
                _configuration["EmailCredentials:Name"]);

            MailAddress toAddress = new MailAddress(message.To);

            var smtp = new SmtpClient
            {
                Host = _configuration["EmailCredentials:Host"],
                Port = int.Parse(_configuration["EmailCredentials:Port"]),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, _configuration["EmailCredentials:Password"])
            };

            using (var mail = new MailMessage(fromAddress, toAddress)
            {
                Subject = message.Subject,
                Body = message.Body
            })
            {
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
