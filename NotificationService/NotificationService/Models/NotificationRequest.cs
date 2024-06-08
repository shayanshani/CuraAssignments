using System;

namespace NotificationServiceLibrary.Models
{
    public class NotificationRequest
    {
        public Guid NotificationId { get; } = Guid.NewGuid();
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
