using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using NotificationServiceLibrary.Models;

namespace NotificationServiceLibrary.Services
{
    public class EmailNotificationService : BaseNotificationService
    {
        public override async Task<NotificationResult> SendNotificationAsync(NotificationRequest request)
        {
            var result = new NotificationResult
            {
                NotificationId = request.NotificationId
            };

            try
            {
                using (var smtpClient = new SmtpClient("smtp.example.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("username", "password");
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("no-reply@example.com"),
                        Subject = request.Subject,
                        Body = request.Message,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(request.Recipient);

                    await smtpClient.SendMailAsync(mailMessage);
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
