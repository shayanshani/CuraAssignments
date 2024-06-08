using System;

namespace NotificationServiceLibrary.Models
{
    public class NotificationResult
    {
        public Guid NotificationId { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
